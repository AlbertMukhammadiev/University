--Сделайте процедуру заказа, указывая параметрами блюда и их количество и время выполнения заказа.
--Если время выполнения текущее (или +- 10 минут), то считайте, что заказ выполняется сразу.
--При этом надо уменьшать количество ингредиентов, необходимое для выполнения конкретного заказа.
--Если время выполнения заказа – в будущем, то надо резервировать продукты, необходимые для выполнения заказа,
--и фиксировать время, когда заказ должен быть готов. Количество и название (id) блюд можно брать из временной таблицы или табличной переменной.
--Если для выполнения заказа не хватает продуктов, то надо посмотреть, не прошел ли срок выполнения какого-то заказа,
--который так и не был выполнен (клиент не пришел) – тогда надо снимать бронь со всех продуктов и отменять заказ.
ALTER PROCEDURE MakeOrder (@ord Ord READONLY, @time DATETIME, @message CHAR(30) OUTPUT) AS
BEGIN
	DECLARE @now DATETIME = GETDATE();
	IF DATEADD(MI, -10, @now) > @time
	BEGIN
		SET @message = 'incorrect date';
		RETURN;
	END
	ELSE
	BEGIN		
		--сняли бронь с заказов, за которыми не пришли клиенты
		DELETE Reservation WHERE @now > DATEADD(HOUR, +2, ExactTime);

		--Проверили выполнимость заказа
		DECLARE CurrentDish CURSOR FOR SELECT * FROM @ord;
		OPEN CurrentDish;
		DECLARE @currentDish CHAR(30), @currentExpected INT, @response INT = 0, @msg CHAR(30) = '';
		FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
		
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			EXECUTE NumberOfServings @currentDish, @response OUT, @msg OUT;
			IF @response < @currentExpected
			BEGIN
				SET @message = 'Sorry, we can not complete your order';
				CLOSE CurrentDish;
				DEALLOCATE CurrentDish;
				RETURN;
			END
			FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
		END

		CLOSE CurrentDish;
		DEALLOCATE CurrentDish;

		-- МОЖНО СОЕДИНИТЬ ВЕРХНЕЕ И НИЖНЕЕ

		DECLARE @reserv ProductReservation;
		DECLARE CurrentDish CURSOR FOR SELECT * FROM @ord;
		OPEN CurrentDish;
		FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			-- ОПТИМИЗАЦИЯ
			INSERT INTO @reserv (Ingredient_Res, ReplaceBy_Res, Total_Res)
			SELECT Ingredient, ReplaceBy, Dosage * @currentExpected
			FROM ForCooking WHERE Dish = @currentDish

			FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
		END

		CLOSE CurrentDish;
		DEALLOCATE CurrentDish;


		

		IF DATEADD(MI, -10, @now) < @time AND @time < DATEADD(MI, 10, @now)
			BEGIN
				--выполнили заказ немедленно
				INSERT INTO History (Dish, ExactTime, Number)
				SELECT Dish_Order, @time, Num_Order FROM @ord 

				DECLARE CurrentIngredient CURSOR FOR SELECT * FROM @reserv;
				OPEN CurrentIngredient;
				DECLARE @currentTotal FLOAT, @currentIngredient CHAR(30), @currentReplaceBy CHAR(30), @reserved FLOAT, @freeForUse FLOAT;
				FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;

				WHILE (@@FETCH_STATUS = 0)
					BEGIN
						SELECT @freeForUse = Total - ISNULL(Reserved, 0) FROM ForCooking WHERE Ingredient = @currentIngredient
						IF @freeForUse < @currentTotal
							BEGIN
								UPDATE Storage SET Total -= @freeForUse WHERE Ingredient = @currentIngredient
								UPDATE Storage SET Total -= (@currentTotal - @freeForUse) WHERE Ingredient = @currentReplaceBy
							END
						ELSE
							BEGIN
								UPDATE Storage SET Total -= @currentTotal WHERE Ingredient = @currentIngredient
							END

						FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
					END
			
				CLOSE CurrentIngredient;
				DEALLOCATE CurrentIngredient;
				SET @message = 'Order completed';
			END
		ELSE
			BEGIN
				--Забронировали заказ
				INSERT INTO Reservation (ExactTime) VALUES (@time);
				DECLARE @id INT;
				SELECT @id = MAX(ID) FROM Reservation;
		
				INSERT INTO ReservedDishes (ID_Reservation, Dish, Number)
					SELECT @id, Dish_Order, Num_Order
					FROM @ord

				SET @message = 'Order reserved';
			END
		RETURN;
	END
END
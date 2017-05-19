--Ќаписать процедуру выполнени€ зарезервированного заказа, который уменьшает количество ингредиентов на зарезервированное количество.
ALTER PROCEDURE CompleteOrder (@ID_Order INT) AS
BEGIN
	DECLARE @ord Ord;
	INSERT INTO @ord (Dish_Order, Num_Order)
		SELECT Dish, Number
		FROM ReservedDishes WHERE ID_Reservation = @ID_Order
	
	DECLARE @reserv ProductReservation, @currentDish CHAR(30), @currentExpected INT;
	DECLARE CurrentDish CURSOR FOR SELECT * FROM @ord;
	OPEN CurrentDish;
	FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			-- ќѕ“»ћ»«ј÷»я
			INSERT INTO @reserv (Ingredient_Res, ReplaceBy_Res, Total_Res)
			SELECT Ingredient, ReplaceBy, Dosage * @currentExpected
			FROM ForCooking WHERE Dish = @currentDish

			FETCH FROM CurrentDish INTO @currentDish, @currentExpected;
		END

	CLOSE CurrentDish;
	DEALLOCATE CurrentDish;

	DECLARE CurrentIngredient CURSOR FOR SELECT * FROM @reserv;
	OPEN CurrentIngredient;
	DECLARE @currentTotal FLOAT, @currentIngredient CHAR(30), @currentReplaceBy CHAR(30), @reserved FLOAT, @freeForUse FLOAT;
	FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			SET @reserved = @currentTotal - (SELECT ISNULL(Reserved, 0) FROM Storage WHERE Ingredient = @currentIngredient)
			IF  @reserved > 0
			BEGIN
				UPDATE Storage SET Total -= ISNULL(Reserved, 0) WHERE Ingredient = @currentIngredient
				UPDATE Storage SET Reserved = 0 WHERE Ingredient = @currentIngredient
				
				UPDATE Storage SET Total -= @reserved, Reserved -= @reserved WHERE Ingredient = @currentReplaceBy
			END
			ELSE
			BEGIN
				UPDATE Storage SET Total -= @currentTotal, Reserved -= @currentTotal WHERE Ingredient = @currentIngredient
			END

			FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
		END

	RETURN;
END
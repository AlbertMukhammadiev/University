-- “риггер, бронирующий и снимающий бронь с продуктов
ALTER TRIGGER IngredientReservation ON ReservedDishes
FOR INSERT, DELETE AS
BEGIN
	IF (SELECT COUNT(*) FROM inserted) > 0
		BEGIN
			DECLARE CurrentDish CURSOR FOR SELECT Dish, Number FROM inserted
		END
	ELSE
		BEGIN
			DECLARE CurrentDish CURSOR FOR SELECT Dish, Number FROM deleted
		END
	
	DECLARE @reserv ProductReservation, @currentDish CHAR(30), @currentNum INT
	OPEN CurrentDish
	FETCH FROM CurrentDish INTO @currentDish, @currentNum;
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			-- ќѕ“»ћ»«ј÷»я
			INSERT INTO @reserv (Ingredient_Res, ReplaceBy_Res, Total_Res)
			SELECT Ingredient, ReplaceBy, Dosage * @currentNum
			FROM ForCooking WHERE Dish = @currentDish

			FETCH FROM CurrentDish INTO @currentDish, @currentNum;
		END

	CLOSE CurrentDish;
	DEALLOCATE CurrentDish;

	DECLARE CurrentIngredient CURSOR FOR SELECT * FROM @reserv;
	OPEN CurrentIngredient;
	DECLARE @currentTotal FLOAT, @currentIngredient CHAR(30), @currentReplaceBy CHAR(30), @reserved FLOAT, @freeForUse FLOAT;
	FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
	
	IF (SELECT COUNT(*) FROM inserted) > 0
		BEGIN -- резервируем
			WHILE (@@FETCH_STATUS = 0)
				BEGIN		
					SELECT @freeForUse = Total - ISNULL(Reserved, 0) FROM ForCooking WHERE Ingredient = @currentIngredient
					IF @freeForUse < @currentTotal
						BEGIN
							UPDATE Storage SET Reserved = ISNULL(Reserved, 0) + @freeForUse WHERE Ingredient = @currentIngredient
							UPDATE Storage SET Reserved = ISNULL(Reserved, 0) + (@currentTotal - @freeForUse) WHERE Ingredient = @currentReplaceBy
						END
					ELSE
						BEGIN
							UPDATE Storage SET Reserved = ISNULL(Reserved, 0) + @currentTotal WHERE Ingredient = @currentIngredient
						END

					FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
				END
		END
	ELSE
		BEGIN  -- снимаем бронь
			WHILE (@@FETCH_STATUS = 0)
				BEGIN
					SELECT @reserved = ISNULL(Reserved, 0) FROM Storage WHERE Ingredient = @currentIngredient
					IF @currentTotal > @reserved
						BEGIN
							UPDATE Storage SET Reserved = 0 WHERE Ingredient = @currentIngredient
							UPDATE Storage SET Reserved -= (@currentTotal - @reserved) WHERE Ingredient = @currentReplaceBy
						END
					ELSE
						BEGIN
							UPDATE Storage SET Reserved -= @reserved WHERE Ingredient = @currentIngredient
						END

					FETCH FROM CurrentIngredient INTO @currentIngredient, @currentTotal, @currentReplaceBy;
				END
		END

	CLOSE CurrentIngredient;
	DEALLOCATE CurrentIngredient;
	RETURN;
END
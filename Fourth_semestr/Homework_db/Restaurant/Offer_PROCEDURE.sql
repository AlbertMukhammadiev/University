ALTER FUNCTION GetMax (@dish CHAR(30))
RETURNS INT
AS
BEGIN
	IF 0 = (SELECT COUNT(*) FROM Menu WHERE @dish = Dish)
	BEGIN
		RETURN 0
	END

	DECLARE @Recipe TABLE (Ingredient CHAR(20), Dosage FLOAT, Reserved FLOAT, Total FLOAT, ReplaceBy CHAR(20));
	
	INSERT INTO @Recipe (Ingredient, Dosage, Reserved, Total, ReplaceBy)
	SELECT Ingredient, Dosage, Reserved, Total, ReplaceBy
	FROM ForCooking
	WHERE Dish = @dish

	DECLARE @result1 INT, @result2 INT;

	SELECT @result1 = MIN((CAST((Total - ISNULL(Reserved, 0)) as FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe

	UPDATE @Recipe SET Total += Storage.Total FROM Storage JOIN @Recipe ON ReplaceBy = Storage.Ingredient
	
	SELECT @result2 = MIN((CAST((Total - ISNULL(Reserved, 0)) as FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe


	IF (@result2 > @result1)
	BEGIN
		RETURN @result2
	END
	ELSE
	BEGIN
		RETURN @result1
	END
	RETURN 0
END

--  вам пришел заказ на комплексный обед дл€ 50 человек.
--ѕредложите на выбор (один дл€ всех) два вида комплексных обедов,
--дл€ выполнени€ которых есть все ингредиенты Ц самый дорогой и самый дешевый.
CREATE PROCEDURE Offer (@cheap INT OUTPUT, @expensive INT OUTPUT) AS
BEGIN
	DECLARE @ord Ord;
	INSERT INTO @ord (Dish_Order)
		SELECT Dish
		FROM Menu WHERE Dish IN (SELECT Dish FROM ComplexLunches)
	
	DECLARE @Lunches MyType
	INSERT INTO @Lunches (MyName, MyNum)
		select distinct Name, 10000 from ComplexLunches

	DECLARE CurrentDish CURSOR FOR SELECT Dish_Order FROM @ord;
	OPEN CurrentDish;
	DECLARE @currentDish CHAR(30), @lunch CHAR(30), @num INT
	FETCH FROM CurrentDish INTO @currentDish;
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			SELECT @lunch = Name FROM ComplexLunches WHERE Dish = @currentDish
			SELECT @num = dbo.GetMax(@currentDish)
			IF (SELECT MyNum FROM @Lunches where MyName = @lunch) > @num
				BEGIN
					UPDATE @Lunches SET MyNum = @num WHERE MyName = @lunch
				END
			FETCH FROM CurrentDish INTO @currentDish;
		END

	CLOSE CurrentDish;
	DEALLOCATE CurrentDish;

	DELETE @Lunches WHERE MyNum < 50

	DECLARE CurrentLunch CURSOR FOR SELECT MyName FROM @Lunches;
	OPEN CurrentLunch;
	DECLARE @currentLunch CHAR(30), @lunchPrice INT;
	FETCH FROM CurrentLunch INTO @currentLunch;
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			SELECT @lunchPrice = SUM(price) FROM Menu WHERE Dish IN (SELECT Dish FROM ComplexLunches WHERE Name = @currentLunch)
			UPDATE @Lunches SET MyNum = @lunchPrice WHERE MyName = @currentLunch
			FETCH FROM CurrentLunch INTO @currentLunch;
		END

	CLOSE CurrentLunch;
	DEALLOCATE CurrentLunch;
	
	SELECT @cheap = MIN(MyNum) FROM @Lunches	
	SELECT @expensive = MAX(MyNum) FROM @Lunches
	RETURN
END
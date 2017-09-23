--ѕроцедура (ѕараметр Ц блюдо).
--≈сли все ингредиенты есть в наличии, то подсчитайте количество порций, которое можно изготовить.
--≈сли какого-то одного ингредиента нет, то замените продукт, выдав об этом сообщение,
--и сделайте расчет с учетом замены продукта (вес брать тот же)	
ALTER PROCEDURE NumberOfServings (@dish CHAR(30), @number INT OUTPUT, @message CHAR(30) OUT) AS
BEGIN
	IF 0 = (SELECT COUNT(*) FROM Menu WHERE @dish = Dish)
	BEGIN
		SET @number = 0
		SET @message = 'There is no such a dish in menu'
		RETURN
	END

	DECLARE @Recipe TABLE (Ingredient CHAR(20), Dosage FLOAT, Reserved FLOAT, Total FLOAT, ReplaceBy CHAR(20));
	
	INSERT INTO @Recipe (Ingredient, Dosage, Reserved, Total, ReplaceBy)
	SELECT Ingredient, Dosage, Reserved, Total, ReplaceBy
	FROM ForCooking
	WHERE Dish = @dish

	DECLARE @result1 INT, @result2 INT;

	SELECT @result1 = MIN((CAST((Total - ISNULL(Reserved, 0)) AS FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe

	UPDATE @Recipe SET Total += Storage.Total FROM Storage JOIN @Recipe ON ReplaceBy = Storage.Ingredient
	
	SELECT @result2 = MIN((CAST((Total - ISNULL(Reserved, 0)) as FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe

	IF (@result2 > @result1)
	BEGIN
		SET @number = @result2
		SET @message = 'some ingredients were replaced'
		RETURN
	END
	ELSE
	BEGIN
		SET @number = @result1
		SET @message = 'there was no replacement'
		RETURN
	END
END
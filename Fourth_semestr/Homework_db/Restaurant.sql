CREATE TABLE  Menu (
Dish CHAR(30) PRIMARY KEY,
Price INT NOT NULL CHECK (Price >= 0),
Category CHAR(30) NOT NULL CHECK (Category IN ('Салаты', 'Супы', 'Мясные', 'Вегетарианские', 'Рыбные блюда', 'Десерты', 'Напитки'))
);

INSERT INTO Menu (Dish, Price, Category) VALUES
('Цезарь', 200, 'Салаты'),
('Мимоза', 150, 'Салаты'),
('Греческий салат', 250,  'Салаты'),
('Мясо по французски', 400, 'Мясные'),
('Сельдь под шубой', 300, 'Салаты'),
('Солянка', 150, 'Супы'),
('Шашлык', 800, 'Мясные'),
('Шоколадное мороженое', 499, 'Десерты'),
('Торт "Прага"', 500, 'Десерты'),
('Сидр', 440, 'Напитки'),
('Жареные бананы', 800, 'Десерты');

CREATE TABLE  Storage (
Ingredient CHAR(30) PRIMARY KEY,
Reserved FLOAT CHECK (Reserved >= 0),
Total FLOAT NOT NULL CHECK (Total >= 0),
Category CHAR(30) CHECK (Category IN ('мясо', 'овощи', 'фрукты', 'яйца', 'мучное', 'молочное', 'сладости', 'масло', 'морепродукты'))
);

SELECT * FROM Storage
DELETE Storage

INSERT INTO Storage (Ingredient, Total, Category) VALUES
('майонез', 20, 'молочное'), ('петрушка', 15, 'овощи'), ('свинина', 100, 'мясо'), ('картофель', 300, 'овощи'), ('мука', 200, 'мучное'),
('говядина', 300, 'мясо'), ('огурцы', 250, 'овощи'), ('колбаса', 100, 'мясо'), ('шоколад', 200, 'сладости'), ('какао', 200, 'сладости'),
('сахар', 200, 'сладости'), ('сметана', 200, 'молочное'), ('яблоко', 200, 'фрукты'), ('груша', 200, 'фрукты'),('банан', 200, 'фрукты'),
('оливковое масло', 30, 'масло'), ('сайра', 50, 'морепродукты'), ('морковь', 30, 'овощи'), ('лук', 25, 'овощи'), ('сыр', 30, 'молочное'),
('курица', 200, 'мясо'), ('томаты', 200, 'овощи'), ('яйцо', 150, 'яйца'), ('хлеб', 100, 'мучное'), ('листья салата', 50, 'овощи');


CREATE TABLE Recipe (
Ingredient CHAR(30) NOT NULL,
Dosage FLOAT NOT NULL CHECK (Dosage >= 0),
Dish CHAR(30) NOT NULL,
ReplaceBy CHAR(30)
);

INSERT INTO Recipe (Ingredient, Dish, Dosage, ReplaceBy) VALUES
('банан', 'Жареные бананы', 1.2, NULL), ('сахар', 'Жареные бананы', 0.18, NULL),
('яблоко', 'Сидр', 3, 'груша'), ('сахар', 'Сидр', 0.18, NULL),
('шоколад', 'Шоколадное мороженое', 0.18, NULL), ('молоко', 'Шоколадное мороженое', 0.25, NULL),
('мука', 'Торт "Прага"', 0.3, NULL), ('шоколад', 'Торт "Прага"', 0.4, 'какао'),
('яйцо', 'Торт "Прага"', 6, NULL), ('молоко', 'Торт "Прага"', 2.5, NULL),
('сметана', 'Торт "Прага"', 0.7, NULL), ('сахар', 'Торт "Прага"', 0.3, NULL),
('картофель', 'Мимоза', 0.3, NULL), ('сайра', 'Мимоза', 0.2, 'лосось'),
('морковь', 'Мимоза', 0.2, NULL), ('лук', 'Мимоза', 0.1, NULL),
('сыр', 'Мимоза', 0.15, NULL), ('майонез', 'Мимоза', 0.25, NULL),
('яйцо', 'Мимоза', 4, NULL), ('петрушка', 'Мимоза', 0.05, 'укроп'),
('курица', 'Цезарь', 0.15, 'креветки'), ('томат', 'Цезарь', 1, NULL),
('яйцо', 'Цезарь', 2, NULL), ('хлеб', 'Цезарь', 0.2, NULL),
('листья салата', 'Цезарь', 0.3, NULL), ('оливковое масло', 'Цезарь', 0.1, NULL),
('свинина', 'Мясо по французски', 0.5, 'курица'), ('лук', 'Мясо по французски', 0.8, NULL),
('картофель', 'Мясо по французски', 1, NULL), ('сыр', 'Мясо по французски', 0.25, NULL),
('майонез', 'Мясо по французски', 0.3, NULL), ('растительное масло', 'Мясо по французски', 0.3, NULL),
('свинина', 'Шашлык', 3, 'курица'), ('лук', 'Шашлык', 0.4, NULL), ('уксус', 'Шашлык', 0.3, NULL),
('сельдь', 'Сельдь под шубой', 1, NULL), ('свекла', 'Сельдь под шубой', 1, NULL),
('морковь', 'Сельдь под шубой', 0.7, NULL), ('картофель', 'Сельдь под шубой', 1, NULL),
('лук', 'Сельдь под шубой', 0.3, NULL), ('майонез', 'Сельдь под шубой', 0.3, NULL);



--Сколько видов десертов есть в меню?
SELECT COUNT(*) AS Deserts
FROM Menu
WHERE Category = 'Десерты'

--Сделайте сводную таблицу по видам фруктов (названия столбцов) и блюдам (столбцы),
--в состав которых входят фрукты
ALTER VIEW FruitMenu AS
	SELECT Storage.Total, Dish, Recipe.Ingredient
	FROM Recipe JOIN Storage ON Recipe.Ingredient = Storage.Ingredient
	WHERE EXISTS (	SELECT Ingredient
					FROM Storage
					WHERE Category = 'фрукты' AND Storage.Ingredient = Recipe.Ingredient)
				
SELECT Dish, [яблоко], [банан]
FROM FruitMenu
PIVOT (COUNT(Total) FOR Ingredient in ([яблоко],[банан])) pvt

--Процедура (Параметр – блюдо).
--Если все ингредиенты есть в наличии, то подсчитайте количество порций, которое можно изготовить.
--Если какого-то одного ингредиента нет, то замените продукт, выдав об этом сообщение,
--и сделайте расчет с учетом замены продукта (вес брать тот же)
ALTER VIEW ForCooking AS
SELECT  Recipe.Dish, Recipe.Ingredient, Recipe.Dosage, Storage.Total, Recipe.ReplaceBy
FROM Storage JOIN Recipe ON Storage.Ingredient = Recipe.Ingredient;
	
ALTER PROCEDURE NumberOfServings (@dish CHAR(30), @number INT OUTPUT, @message CHAR(30) OUT) AS
BEGIN
	IF 0 = (SELECT COUNT(*) FROM Menu WHERE @dish = Dish)
	BEGIN
		SET @number = 0
		SET @message = 'THERE IS NO SUCH A DISH IN THE MENU'
		RETURN
	END

	DECLARE @Recipe TABLE (Ingredient CHAR(20), Dosage FLOAT, Total FLOAT, ReplaceBy CHAR(20));
	
	INSERT INTO @Recipe (Ingredient, Dosage, Total, ReplaceBy)
	SELECT Ingredient, Dosage, Total, ReplaceBy
	FROM ForCooking
	WHERE Dish = @dish

	DECLARE @result1 INT, @result2 INT;

	SELECT @result1 = MIN((CAST(Total as FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe

	UPDATE @Recipe SET Total += Storage.Total FROM Storage JOIN @Recipe ON ReplaceBy = Storage.Ingredient
	
	SELECT @result2 = MIN((CAST(Total as FLOAT)) / CAST(Dosage as FLOAT)) FROM @Recipe


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



--Сделайте процедуру заказа, указывая параметрами блюда и их количество и время выполнения заказа.
--Если время выполнения текущее (или +- 10 минут), то считайте, что заказ выполняется сразу.
--При этом надо уменьшать количество ингредиентов, необходимое для выполнения конкретного заказа.
--Если время выполнения заказа – в будущем, то надо резервировать продукты, необходимые для выполнения заказа,
--и фиксировать время, когда заказ должен быть готов. Количество и название (id) блюд можно брать из временной таблицы или табличной переменной.
--Если для выполнения заказа не хватает продуктов, то надо посмотреть, не прошел ли срок выполнения какого-то заказа,
--который так и не был выполнен (клиент не пришел) – тогда надо снимать бронь со всех продуктов и отменять заказ.
CREATE TYPE Ord AS TABLE
	(Dish_Order CHAR(30) NOT NULL,
	Num_Order INT NOT NULL CHECK(Num_Order> 0));

CREATE TABLE Reservation (
ID INT IDENTITY(1,1) PRIMARY KEY,
ExactTime DATETIME NOT NULL,
);

CREATE TABLE ReservedDishes (
	ID_Reservation INT NOT NULL FOREIGN KEY REFERENCES Reservation(ID),
	Dish CHAR(30) NOT NULL,
	Number INT CHECK (Number > 0));

CREATE PROCEDURE MakeOrder (@ord Ord, @time DATETIME, @message CHAR(30) OUTPUT) AS
BEGIN
	DECLARE @now DATETIME = GETDATE()

	IF DATEADD(MI, -10, @now) > @time
	BEGIN
		SET @message = 'incorrect date'
		RETURN
	END
	ELSE
	BEGIN
		--сняли бронь с заказов, за которыми не пришли клиенты
		DELETE Reservation WHERE @now > DATEADD(HOUR, 2, ExactTime)
		
		--Проверили выполнимость заказа
		DECLARE CurrentOrder CURSOR FOR SELECT * FROM @ord
		OPEN CurrentOrder
		DECLARE @currentDish CHAR(30), @currentExpected INT, @response INT = 0, @msg CHAR(30) = ''
		FETCH FROM CurrentOrder INTO @currentDish, @currentExpected
		
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			EXECUTE NumberOfServings @currentDish, @response, @msg
			IF @response = 0
			BEGIN
				SET @message = 'Sorry, we can not complete your order'
				RETURN
			END
			FETCH FROM CurrentOrder INTO @currentDish, @currentExpected
		END

		--Забронировали заказ
		INSERT INTO Reservation (ExactTime) VALUES (@time)					
		DECLARE @id INT
		SELECT @id = MAX(ID) FROM Reservation
		
		INSERT INTO ReservedDishes (ID_Reservation, Dish, Number)
			SELECT @id, Dish_Order, Num_Order
			FROM @ord
		
		--выполнили заказ немедленно
		IF DATEADD(MI, -10, @now) < @time AND @time < DATEADD(MI, 10, @now)
		BEGIN
			SET @message = 'Order completed'
			EXECUTE CompleteOrder @id
			RETURN
		END

		SET @message = 'Order reserved'
		RETURN
	END
END

--Написать процедуру выполнения зарезервированного заказа, который уменьшает количество ингредиентов на зарезервированное количество.
ALTER PROCEDURE CompleteOrder (@ID_Order INT) AS
BEGIN
	DELETE Reservation WHERE ID = @ID_Order
END


--Триггер
--Таблицу выполненных заказов надо хранить в течение месяца,
--при добавлении строк в эту таблицу старые заказы надо удалять.

CREATE TABLE History (
cid int,
sourse_x char(1) CHECK (sourse_x LIKE'[a-h]'),
sourse_y int CHECK (sourse_y > 0 and sourse_y < 9),
target_x char(1) CHECK (target_x LIKE'[a-h]'),
target_y int CHECK (target_y > 0 and target_y < 9),
);

ALTER TRIGGER MovementsOfFigures ON Chessboard
FOR UPDATE, DELETE AS
BEGIN
	IF ((SELECT COUNT(*) FROM inserted) = 0)
		BEGIN
			INSERT History (cid, sourse_x, sourse_y)
			SELECT cid, x, y FROM deleted
		END
	ELSE
		BEGIN
			INSERT History (cid, sourse_x, sourse_y, target_x, target_y)
			SELECT deleted.cid, deleted.x, deleted.y, inserted.x, inserted.y
			FROM deleted JOIN inserted ON deleted.cid = inserted.cid
		END
END


























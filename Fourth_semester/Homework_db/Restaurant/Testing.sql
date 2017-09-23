DECLARE @order Ord;
DECLARE @number INT;
DECLARE @message CHAR(30);
DECLARE @now DATETIME = GETDATE()
DECLARE @future DATETIME = DATEADD(YEAR, 2, GETDATE())

INSERT INTO @order (Dish_Order, Num_Order) VALUES ('Шашлык', 3), ('Сидр', 1);

EXECUTE NumberOfServings 'Шашлык', @number output, @message output
SELECT @number AS Ресторан_может_предоставить, @message AS Сообщение_о_замене_ингридиентов

EXECUTE NumberOfServings 'Сидр', @number output, @message output
SELECT @number AS Ресторан_может_предоставить, @message AS Сообщение_о_замене_ингридиентов

EXECUTE MakeOrder @order, @future, @message OUTPUT
SELECT @message

EXECUTE NumberOfServings 'Шашлык', @number output, @message output
SELECT @number AS Ресторан_может_предоставить, @message AS Сообщение_о_замене_ингридиентов


SELECT * FROM ReservedDishes
SELECT * FROM ReservedDishes
SELECT * FROM Reservation
SELECT * FROM Storage

EXECUTE NumberOfServings 'Шашлык', @number output, @message output
SELECT @number AS Ресторан_может_предоставить, @message AS Сообщение_о_замене_ингридиентов

EXECUTE NumberOfServings 'Сидр', @number output, @message output
SELECT @number AS Ресторан_может_предоставить, @message AS Сообщение_о_замене_ингридиентов

DECLARE @past DATETIME = DATEADD(YEAR, -2, GETDATE())
UPDATE Reservation SET ExactTime = @past WHERE ID = 56

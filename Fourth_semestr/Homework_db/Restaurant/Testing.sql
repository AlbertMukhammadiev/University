DECLARE @order Ord;
DECLARE @number INT;
DECLARE @message CHAR(30);
DECLARE @now DATETIME = GETDATE()
DECLARE @future DATETIME = DATEADD(YEAR, 2, GETDATE())

INSERT INTO @order (Dish_Order, Num_Order) VALUES ('������', 3), ('����', 1);

EXECUTE NumberOfServings '������', @number output, @message output
SELECT @number AS ��������_�����_������������, @message AS ���������_�_������_������������

EXECUTE NumberOfServings '����', @number output, @message output
SELECT @number AS ��������_�����_������������, @message AS ���������_�_������_������������

EXECUTE MakeOrder @order, @future, @message OUTPUT
SELECT @message

EXECUTE NumberOfServings '������', @number output, @message output
SELECT @number AS ��������_�����_������������, @message AS ���������_�_������_������������


SELECT * FROM ReservedDishes
SELECT * FROM ReservedDishes
SELECT * FROM Reservation
SELECT * FROM Storage

EXECUTE NumberOfServings '������', @number output, @message output
SELECT @number AS ��������_�����_������������, @message AS ���������_�_������_������������

EXECUTE NumberOfServings '����', @number output, @message output
SELECT @number AS ��������_�����_������������, @message AS ���������_�_������_������������

DECLARE @past DATETIME = DATEADD(YEAR, -2, GETDATE())
UPDATE Reservation SET ExactTime = @past WHERE ID = 56

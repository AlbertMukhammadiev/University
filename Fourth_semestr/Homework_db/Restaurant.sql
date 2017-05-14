CREATE TABLE  Menu (
Dish CHAR(30) PRIMARY KEY,
Price INT NOT NULL CHECK (Price >= 0),
Category CHAR(30) NOT NULL CHECK (Category IN ('������', '����', '������', '��������������', '������ �����', '�������', '�������'))
);

INSERT INTO Menu (Dish, Price, Category) VALUES
('������', 200, '������'),
('������', 150, '������'),
('��������� �����', 250,  '������'),
('���� �� ����������', 400, '������'),
('������ ��� �����', 300, '������'),
('�������', 150, '����'),
('������', 800, '������'),
('���������� ���������', 499, '�������'),
('���� "�����"', 500, '�������'),
('����', 440, '�������'),
('������� ������', 800, '�������');

CREATE TABLE  Storage (
Ingredient CHAR(30) PRIMARY KEY,
Reserved FLOAT CHECK (Reserved >= 0),
Total FLOAT NOT NULL CHECK (Total >= 0),
Category CHAR(30) CHECK (Category IN ('����', '�����', '������', '����', '������', '��������', '��������', '�����', '������������'))
);

SELECT * FROM Storage
DELETE Storage

INSERT INTO Storage (Ingredient, Total, Category) VALUES
('�������', 20, '��������'), ('��������', 15, '�����'), ('�������', 100, '����'), ('���������', 300, '�����'), ('����', 200, '������'),
('��������', 300, '����'), ('������', 250, '�����'), ('�������', 100, '����'), ('�������', 200, '��������'), ('�����', 200, '��������'),
('�����', 200, '��������'), ('�������', 200, '��������'), ('������', 200, '������'), ('�����', 200, '������'),('�����', 200, '������'),
('��������� �����', 30, '�����'), ('�����', 50, '������������'), ('�������', 30, '�����'), ('���', 25, '�����'), ('���', 30, '��������'),
('������', 200, '����'), ('������', 200, '�����'), ('����', 150, '����'), ('����', 100, '������'), ('������ ������', 50, '�����');


CREATE TABLE Recipe (
Ingredient CHAR(30) NOT NULL,
Dosage FLOAT NOT NULL CHECK (Dosage >= 0),
Dish CHAR(30) NOT NULL,
ReplaceBy CHAR(30)
);

INSERT INTO Recipe (Ingredient, Dish, Dosage, ReplaceBy) VALUES
('�����', '������� ������', 1.2, NULL), ('�����', '������� ������', 0.18, NULL),
('������', '����', 3, '�����'), ('�����', '����', 0.18, NULL),
('�������', '���������� ���������', 0.18, NULL), ('������', '���������� ���������', 0.25, NULL),
('����', '���� "�����"', 0.3, NULL), ('�������', '���� "�����"', 0.4, '�����'),
('����', '���� "�����"', 6, NULL), ('������', '���� "�����"', 2.5, NULL),
('�������', '���� "�����"', 0.7, NULL), ('�����', '���� "�����"', 0.3, NULL),
('���������', '������', 0.3, NULL), ('�����', '������', 0.2, '������'),
('�������', '������', 0.2, NULL), ('���', '������', 0.1, NULL),
('���', '������', 0.15, NULL), ('�������', '������', 0.25, NULL),
('����', '������', 4, NULL), ('��������', '������', 0.05, '�����'),
('������', '������', 0.15, '��������'), ('�����', '������', 1, NULL),
('����', '������', 2, NULL), ('����', '������', 0.2, NULL),
('������ ������', '������', 0.3, NULL), ('��������� �����', '������', 0.1, NULL),
('�������', '���� �� ����������', 0.5, '������'), ('���', '���� �� ����������', 0.8, NULL),
('���������', '���� �� ����������', 1, NULL), ('���', '���� �� ����������', 0.25, NULL),
('�������', '���� �� ����������', 0.3, NULL), ('������������ �����', '���� �� ����������', 0.3, NULL),
('�������', '������', 3, '������'), ('���', '������', 0.4, NULL), ('�����', '������', 0.3, NULL),
('������', '������ ��� �����', 1, NULL), ('������', '������ ��� �����', 1, NULL),
('�������', '������ ��� �����', 0.7, NULL), ('���������', '������ ��� �����', 1, NULL),
('���', '������ ��� �����', 0.3, NULL), ('�������', '������ ��� �����', 0.3, NULL);



--������� ����� �������� ���� � ����?
SELECT COUNT(*) AS Deserts
FROM Menu
WHERE Category = '�������'

--�������� ������� ������� �� ����� ������� (�������� ��������) � ������ (�������),
--� ������ ������� ������ ������
ALTER VIEW FruitMenu AS
	SELECT Storage.Total, Dish, Recipe.Ingredient
	FROM Recipe JOIN Storage ON Recipe.Ingredient = Storage.Ingredient
	WHERE EXISTS (	SELECT Ingredient
					FROM Storage
					WHERE Category = '������' AND Storage.Ingredient = Recipe.Ingredient)
				
SELECT Dish, [������], [�����]
FROM FruitMenu
PIVOT (COUNT(Total) FOR Ingredient in ([������],[�����])) pvt

--��������� (�������� � �����).
--���� ��� ����������� ���� � �������, �� ����������� ���������� ������, ������� ����� ����������.
--���� ������-�� ������ ����������� ���, �� �������� �������, ����� �� ���� ���������,
--� �������� ������ � ������ ������ �������� (��� ����� ��� ��)
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



--�������� ��������� ������, �������� ����������� ����� � �� ���������� � ����� ���������� ������.
--���� ����� ���������� ������� (��� +- 10 �����), �� ��������, ��� ����� ����������� �����.
--��� ���� ���� ��������� ���������� ������������, ����������� ��� ���������� ����������� ������.
--���� ����� ���������� ������ � � �������, �� ���� ������������� ��������, ����������� ��� ���������� ������,
--� ����������� �����, ����� ����� ������ ���� �����. ���������� � �������� (id) ���� ����� ����� �� ��������� ������� ��� ��������� ����������.
--���� ��� ���������� ������ �� ������� ���������, �� ���� ����������, �� ������ �� ���� ���������� ������-�� ������,
--������� ��� � �� ��� �������� (������ �� ������) � ����� ���� ������� ����� �� ���� ��������� � �������� �����.
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
		--����� ����� � �������, �� �������� �� ������ �������
		DELETE Reservation WHERE @now > DATEADD(HOUR, 2, ExactTime)
		
		--��������� ������������ ������
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

		--������������� �����
		INSERT INTO Reservation (ExactTime) VALUES (@time)					
		DECLARE @id INT
		SELECT @id = MAX(ID) FROM Reservation
		
		INSERT INTO ReservedDishes (ID_Reservation, Dish, Number)
			SELECT @id, Dish_Order, Num_Order
			FROM @ord
		
		--��������� ����� ����������
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

--�������� ��������� ���������� ������������������ ������, ������� ��������� ���������� ������������ �� ����������������� ����������.
ALTER PROCEDURE CompleteOrder (@ID_Order INT) AS
BEGIN
	DELETE Reservation WHERE ID = @ID_Order
END


--�������
--������� ����������� ������� ���� ������� � ������� ������,
--��� ���������� ����� � ��� ������� ������ ������ ���� �������.

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


























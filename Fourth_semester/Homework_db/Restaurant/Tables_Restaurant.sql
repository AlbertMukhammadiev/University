CREATE TABLE  Menu (
	Dish CHAR(30) PRIMARY KEY,
	Price INT NOT NULL CHECK (Price >= 0),
	Category CHAR(30) NOT NULL CHECK (Category IN ('������', '����', '������', '��������������', '������ �����', '�������', '�������')));

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
	Category CHAR(30) CHECK (Category IN ('����', '�����', '������', '����', '������', '��������', '��������', '�����', '������������')));

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
	ReplaceBy CHAR(30));

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

CREATE TABLE ComplexLunches(
	Name CHAR(30) NOT NULL,
	Dish CHAR(30) NOT NULL);

INSERT INTO ComplexLunches (Name, Dish) VALUES
	('�����������', '���� �� ����������'), ('�����������', '���������� ���������'),
	('�����������', '���� "�����"'),
	('���', '������'), ('���', '������ ��� �����'),
	('���', '������'),
	('��������', '������� ������'),
	('��������', '����'), ('��������', '���������� ���������');

CREATE TYPE Ord AS TABLE
	(Dish_Order CHAR(30) NOT NULL,
	Num_Order INT CHECK(Num_Order >= 0));

CREATE TYPE ProductReservation AS TABLE
	(Ingredient_Res CHAR(30) NOT NULL,
	Total_Res FLOAT NOT NULL,
	ReplaceBy_Res CHAR(30));

CREATE TABLE Reservation (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ExactTime DATETIME NOT NULL);

CREATE TABLE ReservedDishes (
	ID_Reservation INT NOT NULL FOREIGN KEY REFERENCES Reservation (ID) ON DELETE CASCADE,
	Dish CHAR(30) NOT NULL,
	Number INT CHECK (Number > 0));

CREATE TABLE History (
	Dish CHAR(30) NOT NULL,
	Number INT NOT NULL,
	ExactTime DATETIME NOT NULL);

ALTER VIEW ForCooking AS
	SELECT  Recipe.Dish, Recipe.Ingredient, Recipe.Dosage, Storage.Reserved, Storage.Total, Recipe.ReplaceBy
	FROM Storage JOIN Recipe ON Storage.Ingredient = Recipe.Ingredient;

CREATE TYPE MyType AS TABLE
	(MyName CHAR(30) NOT NULL,
	MyNum INT);

ALTER VIEW FruitMenu AS
	SELECT Storage.Total, Dish, Recipe.Ingredient
	FROM Recipe JOIN Storage ON Recipe.Ingredient = Storage.Ingredient
	WHERE EXISTS (	SELECT Ingredient
					FROM Storage
					WHERE Category = '������' AND Storage.Ingredient = Recipe.Ingredient)
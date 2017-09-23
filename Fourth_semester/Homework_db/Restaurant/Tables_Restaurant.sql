CREATE TABLE  Menu (
	Dish CHAR(30) PRIMARY KEY,
	Price INT NOT NULL CHECK (Price >= 0),
	Category CHAR(30) NOT NULL CHECK (Category IN ('Салаты', 'Супы', 'Мясные', 'Вегетарианские', 'Рыбные блюда', 'Десерты', 'Напитки')));

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
	Category CHAR(30) CHECK (Category IN ('мясо', 'овощи', 'фрукты', 'яйца', 'мучное', 'молочное', 'сладости', 'масло', 'морепродукты')));

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
	ReplaceBy CHAR(30));

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

CREATE TABLE ComplexLunches(
	Name CHAR(30) NOT NULL,
	Dish CHAR(30) NOT NULL);

INSERT INTO ComplexLunches (Name, Dish) VALUES
	('Европейский', 'Мясо по французски'), ('Европейский', 'Шоколадное мороженое'),
	('Европейский', 'Торт "Прага"'),
	('Наш', 'Мимоза'), ('Наш', 'Сельдь под шубой'),
	('Наш', 'Шашлык'),
	('Сладости', 'Жареные бананы'),
	('Сладости', 'Сидр'), ('Сладости', 'Шоколадное мороженое');

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
					WHERE Category = 'фрукты' AND Storage.Ingredient = Recipe.Ingredient)
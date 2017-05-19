CREATE TABLE Chessman (
cid int PRIMARY KEY,
color char(6) NOT NULL CHECK (color IN ('black', 'white')),
typeF char(10) NOT NULL CHECK (typeF IN ('king', 'gueen', 'rook', 'bishop', 'knight', 'pawn'))
);

CREATE TABLE Chessboard (
cid int FOREIGN KEY REFERENCES Chessman(cid) PRIMARY KEY,
x char(1) NOT NULL CHECK (x LIKE'[a-h]'),
y int NOT NULL CHECK (y > 0 and y < 9),
UNIQUE (x,y)
);

INSERT INTO Chessman (cid, color, typeF) VALUES
(1, 'black', 'pawn'), (2, 'black', 'pawn'), (3, 'black', 'pawn'), (4, 'black', 'pawn'),
(5, 'black', 'pawn'), (6, 'black', 'pawn'), (7, 'black', 'pawn'), (8, 'black', 'pawn'),
(9, 'black', 'king'), (10, 'black', 'gueen'), (11,'black', 'rook'), (12, 'black', 'rook'),
(13,'black', 'bishop'), (14,'black', 'bishop'), (15, 'black', 'knight'), (16,'black', 'knight');

INSERT INTO Chessman (cid, color, typeF) VALUES
(17, 'white', 'pawn'), (18, 'white', 'pawn'), (19, 'white', 'pawn'), (20, 'white', 'pawn'),
(21, 'white', 'pawn'), (22, 'white', 'pawn'), (23, 'white', 'pawn'), (24, 'white', 'pawn'),
(25, 'white', 'king'), (26, 'white', 'gueen'), (27,'white', 'rook'), (28, 'white', 'rook'),
(29,'white', 'bishop'), (30,'white', 'bishop'), (31, 'white', 'knight'), (32,'white', 'knight');

INSERT INTO Chessboard (cid, x, y) VALUES
(17,'a',2),(18,'b',2),(19,'c',2),(20,'d',2),(21,'e',2),(22,'f',2),(23,'g',2),(24,'h',2),
(1,'a',7),(2,'b',7),(3,'c',7),(4,'d',7),(5,'e',7),(6,'f',7),(7,'g',7),(8,'h',7),
(25,'e',1),(26,'d',1),(27,'a',1),(28,'h',1),(29,'c',1),(30,'f',1),(31,'b',1),(32,'g',1),
(9,'e',8),(10,'d',8),(11,'a',8),(12,'h',8),(13,'c',8),(14,'f',8),(15,'b',8),(16,'g',8);

--1. Сколько фигур стоит на доске? Вывести количество.
SELECT
COUNT(*)
FROM Chessboard

--2. Вывести id фигур, чьи названия начинаются на букву k.
SELECT cid
FROM Chessman
WHERE typeF LIKE 'k%'

--3. Какие типы фигур бывают и по сколько штук? Вывести тип и количество.
SELECT typeF, COUNT(typeF)  AS numOfF
FROM Chessman
GROUP BY typeF

--4. Вывести id белых пешек , стоящих на доске?
SELECT cid
FROM Chessboard
WHERE cid = (SELECT cid FROM Chessman 
		WHERE ((color = 'white') AND (Chessboard.cid = Chessman.cid) AND (Chessman.typeF = 'pawn')))

--4. Вывести id белых пешек , стоящих на доске?  (Э)
SELECT Chessman.cid
FROM Chessboard JOIN Chessman ON Chessman.cid = Chessboard.cid
WHERE color = 'white' AND typeF = 'pawn'

--5. Какие фигуры стоят на главной диагонали? Вывести их тип и цвет.   (Э)
SELECT Chessman.cid, typeF, color
FROM Chessboard JOIN Chessman ON Chessman.cid = Chessboard.cid
WHERE ASCII(x)-ASCII('`') = y

--Создание представления таблицы
--(Виртуальная таблица, к которой потом можно будет обращаться)
CREATE VIEW ManOnBoard AS
SELECT Chessman.typeF, Chessman.color, Chessboard.x, Chessboard.y
FROM Chessman JOIN Chessboard ON Chessman.cid = Chessboard.cid

--6. Найдите общее количество фигур, оставшихся у каждого игрока. Вывести цвет и количество.
SELECT COUNT(color) as 'numberOf', color
FROM ManOnBoard
GROUP BY color

--7. Какие фигуры черных имеются на доске? Вывести тип.
SELECT typeF
FROM ManOnBoard
WHERE (color = 'black')
GROUP BY typeF

--8. Какие фигуры черных имеются на доске? Вывести тип и количество.
SELECT COUNT(typeF) as 'numberOf', typeF
FROM ManOnBoard
WHERE (color = 'black')
GROUP BY typeF

--9. Найдите типы фигур (любого цвета), которых осталось, по крайней мере, не меньше двух на доске.
SELECT typeF
FROM ManOnBoard
GROUP by typeF
HAVING COUNT(typeF) >= 2

--10. Вывести цвет фигур, которых на доске больше.
CREATE VIEW CountOfColor AS
SELECT color, COUNT(color) as countF
FROM ManOnBoard
GROUP BY color

SELECT color
FROM CountOfColor
WHERE countF = (SELECT MAX(countF) FROM CountOfColor)

--11. Найдите фигуры, которые стоят на возможном пути движения ладьи (rock)
--    (Любой ладьи любого цвета). (Ладья может двигаться по горизонтали или по вертикали
--     относительно своего положения на доске в любом направлении.).
CREATE VIEW AllRooks AS
SELECT x, y
FROM ManOnBoard
WHERE typeF = 'rook'

SELECT typeF, x, y
FROM ManOnBoard
WHERE EXISTS (SELECT x y FROM AllRooks WHERE (ManOnBoard.x = AllRooks.x OR ManOnBoard.y = AllRooks.y))

--12. У каких игроков (цвета) еще остались ВСЕ пешки (pawn)?
SELECT color
FROM ManOnBoard
WHERE typeF = 'pawn'
GROUP BY color
HAVING COUNT(typeF) = 8

--13. Пусть отношения board1 и board2 представляют собой два последовательных состояние игры (Chessboard).
--	  Какие фигуры (cid) изменили свою позицию (за один ход это может быть передвигаемая фигура и возможно еще фигура, которая была “съедена”)?
--	  В отношение Chessboard2 надо скопировать все строки отношения Chessboard. Из Chessboard2 надо одну фигуру удалить,
--	  а другую фигуру поставить на место удаленной («съесть фигуру»). Задание надо выполнить двумя способами:
--		a) через JOIN
--		b) через UNION/INTERSECT/EXCEPT
CREATE TABLE Chessboard2 (
cid int FOREIGN KEY REFERENCES Chessman(cid) PRIMARY KEY,
x char(1) NOT NULL CHECK (x LIKE'[a-h]'),
y int NOT NULL CHECK (y > 0 and y < 9),
UNIQUE (x,y)
);

INSERT INTO Chessboard2 (cid, x, y) VALUES
(17,'a',2),(18,'b',2),(19,'c',2),(20,'d',2),(21,'e',2),(22,'f',2),(23,'g',2),(24,'h',2),
(1,'a',7),(2,'b',7),(3,'c',7),(4,'d',7),(5,'e',7),(6,'f',7),(7,'g',7),(8,'h',7),
(25,'e',1),(26,'d',1),(27,'a',1),(28,'h',1),(29,'c',1),(30,'f',1),(31,'b',1),(32,'g',1),
(9,'e',8),(10,'d',8),(11,'a',8),(12,'h',8),(13,'c',8),(14,'f',8),(15,'b',8),(16,'g',8);

SELECT *
FROM Chessboard2 LEFT JOIN Chessboard ON Chessboard2.cid = Chessboard.cid
WHERE Chessboard.x <> Chessboard2.x OR Chessboard.y <> Chessboard2.y or Chessboard.cid IS NULL 

SELECT cid
FROM Chessboard2
WHERE NOT EXISTS(
		SELECT * FROM Chessboard INTERSECT SELECT * FROM Chessboard2 AS inter
		WHERE Chessboard2.cid = inter.cid)

SELECT *
FROM Chessboard INTERSECT SELECT * FROM Chessboard2

--14. Вывести id фигуры, если она стоит в «опасной близости» от черного короля?
--    опасной близостью» будем считать квадрат 5х5 с королем в центре.
SELECT cid
FROM Chessboard
WHERE
	EXISTS(	SELECT x, y
			FROM ManOnBoard
			WHERE	color = 'black' AND typeF = 'king' AND
					(ABS(ASCII(ManOnBoard.x) - ASCII(Chessboard.x)) < 3
					AND ABS(ManOnBoard.y - Chessboard.y) < 3)
					AND (ManOnBoard.x <> Chessboard.x OR ManOnBoard.y <> Chessboard.y))

--15. Найти фигуру, ближе всех стоящую к белому королю (расстояние считаем по
--    метрике L1 – разница координат по X + разница координат по Y.
CREATE VIEW WhiteKing AS
SELECT x, y
FROM ManOnBoard
WHERE typeF = 'king' AND color = 'white'

CREATE VIEW DistanceFromWhiteKing AS
SELECT cid, (ABS(ASCII(Chessboard.x) - ASCII(WhiteKing.x)) + ABS(Chessboard.y - WhiteKing.y)) as distance
FROM Chessboard JOIN WhiteKing ON NOT (Chessboard.x = WhiteKing.x AND Chessboard.y = WhiteKing.y)

SELECT cid
FROM DistanceFromWhiteKing
WHERE distance = (	SELECT MIN(distance)
					FROM DistanceFromWhiteKing)

--16. Найти фигуры, которые может съесть ладья (Cid ладьи задан). Помните, что «своих» есть нельзя!
--Создание представления таблицы
--(Виртуальная таблица, к которой потом можно будет обращаться)
CREATE VIEW FullTable AS
SELECT Chessman.cid, Chessman.typeF, Chessman.color, Chessboard.x, Chessboard.y
FROM Chessman JOIN Chessboard ON Chessman.cid = Chessboard.cid

--SELECT cid, x, y
--FROM Chessboard
--WHERE EXISTS (SELECT x, y
--				FROM Chessboard AS C
--				WHERE cid = 27 AND ((C.x = Chessboard.x) OR (C.y = Chessboard.y)))

SELECT cid, x, y
FROM FullTable
WHERE EXISTS (SELECT x, y, color
			  FROM FullTable AS Copy
			  WHERE cid = 27
					AND ((Copy.x = FullTable.x) OR (Copy.y = FullTable.y))
					AND color <> FullTable.color)

--17. Сделайте сводную таблицу, показывающую, сколько фигур каждого типа есть у каждого
--	  игрока (при помощи функции PIVOT). Столбцы должны соответствовать цветам, а строки – типам фигур.
CREATE VIEW For17 AS
SELECT typeF, color, Count(cid) as num
FROM FullTable
GROUP BY typeF, color

SELECT * FROM FullTable

SELECT * FROM Chessman

SELECT typeF, [white], [black]
FROM (SELECT cid, color, typeF
		FROM FullTable) AS AA
PIVOT (Count(cid) FOR color in ([white],[black])) pvt
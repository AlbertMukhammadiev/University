--1. ���������
--������� ��������� Move_figure.
--���������: cid, x, y + ������� �������� 
--��������� �������� �� ���� ������������� ������ � ����������, ���� ������ ����� (��������� ������������ ���� �� ���������).
--���� ��� �������� � ������ ���� ������, �� ���� ����������� ������ � ������� 1.
--���� �� ������ ���� ����� ������ ��������������� �����, �� �� ���� "������" � ������ �� ������ ����. ��������� - 2.
--�� ���� ��������� ������� ��������� 0.

ALTER PROCEDURE MoveFigure (@cid INT, @x CHAR(1), @y INT, @response INT OUTPUT) AS
BEGIN
	DECLARE @id INT;
	SELECT @id = cid FROM Chessboard WHERE x = @x AND y = @y
	IF @id IS NULL
	BEGIN
		UPDATE Chessboard SET x = @x, y = @y WHERE cid = @cid
		SET @response = 1
		RETURN
	END

	DECLARE @atackColor CHAR(6), @defColor CHAR(6);
	SELECT @atackColor = color FROM Chessman WHERE cid = @cid
	SELECT @defColor = color FROM Chessman WHERE cid = @id
	IF (@defColor <> @atackColor)
	BEGIN
		DELETE FROM Chessboard WHERE cid = @id
		UPDATE Chessboard SET x = @x, y = @y WHERE cid = @cid
		SET @response = 2
		RETURN
	END

	SET @response = 0
	RETURN
END

SELECT * FROM Chessboard


DECLARE @ccid INT, @xx CHAR(1), @yy INT, @resp INT
SET @ccid = 5
SET @xx = 'b'
SET @yy = 2
SET @resp = 0
EXECUTE MoveFigure @ccid, @xx, @yy, @resp

--2. �������.
--	 ���������� ������� ��������� ������.
--   ��� ����� ���� ������� ������� �������������� ��������� (� ������� ���� � ��������� ������).
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

--3. ��������� � ��������.
--	 ��������� "����" �������� ������ �� ������ ������ � ������� L1.
--	 �������� ��������� - ������������ ������, ������� �������� - ����.
ALTER PROCEDURE GetWay (@cid INT, @way INT OUTPUT) AS
BEGIN
	DECLARE HistoryOfMovements CURSOR FOR SELECT * FROM History;
	OPEN HistoryOfMovements
	DECLARE @id INT, @x CHAR(1), @y INT, @x1 CHAR(1), @y1 INT;
	FETCH FROM HistoryOfMovements INTO @id, @x, @y, @x1, @y1
	WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF @cid = @id
				BEGIN
					IF @x1 IS NULL
						RETURN @way
					SELECT @way += (ABS (ASCII(@x) - ASCII(@x1)) + ABS(@y - @y1))
				END

			FETCH FROM HistoryOfMovements INTO @id, @x, @y, @x1, @y1
		END

	CLOSE HistoryOfMovements
	DEALLOCATE HistoryOfMovements
	RETURN @way
END

--�������-�������.
--����� ����� ��� �����, ������� �� ����� ������ 1.
--��� ����� ���� ����� ������� ���������, ������� �� �������������� ������ ������ ������� ��� �����, ���� �������� ����� ������.
--��������� �������-������� �� ���� ������� ���������� ���� ��� ������ OUTER APPLY.

--������� �� ��������, �� �� ������ ����������

CREATE FUNCTION FullTable (@cid INT)
	RETURNS @Table TABLE (cid INT, x CHAR(1), y INT) AS
BEGIN
	DECLARE @x INT, @y INT, @color char(6)
	SELECT @x = x FROM FullTable WHERE cid = @cid
	SELECT @y = y FROM FullTable WHERE cid = @cid
	SELECT @color = color FROM FullTable WHERE cid = @cid
	INSERT @Table
		SELECT cid, x, y
			FROM FullTable
				WHERE EXISTS (	SELECT x, y, color
								FROM FullTable AS Copy
								WHERE cid = @cid
										AND ((Copy.x = FullTable.x) OR (Copy.y = FullTable.y))
										AND color <> FullTable.color)
	RETURN
END
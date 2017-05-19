--�������
--������� ����������� ������� ���� ������� � ������� ������,
--��� ���������� ����� � ��� ������� ������ ������ ���� �������.
ALTER TRIGGER Completed ON Reservation
FOR DELETE AS
BEGIN
	IF GETDATE() < (SELECT MIN(ExactTime) FROM deleted)
	BEGIN
		INSERT INTO History (Dish, Number, ExactTime)
		SELECT Dish, Number, GETDATE() FROM ReservedDishes WHERE ID_Reservation IN (SELECT ID FROM deleted)
	END

	DELETE HISTORY WHERE ExactTime > DATEADD(MONTH, 1, GETDATE())
END
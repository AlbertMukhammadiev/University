--������� ����� �������� ���� � ����?
SELECT COUNT(*) AS Deserts
FROM Menu
WHERE Category = '�������'


--�������� ������� ������� �� ����� ������� (�������� ��������) � ������ (�������),
--� ������ ������� ������ ������
SELECT Dish, [������], [�����]
FROM FruitMenu
PIVOT (COUNT(Total) FOR Ingredient in ([������],[�����])) pvt
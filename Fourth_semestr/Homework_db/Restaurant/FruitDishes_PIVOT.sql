--—колько видов десертов есть в меню?
SELECT COUNT(*) AS Deserts
FROM Menu
WHERE Category = 'ƒесерты'


--—делайте сводную таблицу по видам фруктов (названи€ столбцов) и блюдам (столбцы),
--в состав которых вход€т фрукты
SELECT Dish, [€блоко], [банан]
FROM FruitMenu
PIVOT (COUNT(Total) FOR Ingredient in ([€блоко],[банан])) pvt
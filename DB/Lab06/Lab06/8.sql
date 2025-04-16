USE KOR_MyBase


SELECT Отделы.НазваниеОтдела,
       AVG(Заказы.ПотраченнаяСумма) AS [AVG], 
       MIN(Заказы.ПотраченнаяСумма) AS [MIN], 
       MAX(Заказы.ПотраченнаяСумма) AS [MAX], 
       COUNT(*) AS [COUNT], 
       SUM(Заказы.ПотраченнаяСумма) AS [SUM]
FROM Заказы 
INNER JOIN Отделы ON Заказы.Отдел = Отделы.НазваниеОтдела
GROUP BY Отделы.НазваниеОтдела;



SELECT * FROM (
    SELECT CASE 
        WHEN ПотраченнаяСумма < 500 THEN '< 500'
        WHEN ПотраченнаяСумма < 2000 THEN '500-1999'
        WHEN ПотраченнаяСумма >= 2000 THEN ' >= 2000'
    END AS [СуммаКатегория], 
    COUNT(*) AS [Количество]
    FROM Заказы
    GROUP BY CASE 
        WHEN ПотраченнаяСумма < 500 THEN '< 500'
        WHEN ПотраченнаяСумма < 2000 THEN '500-1999'
        WHEN ПотраченнаяСумма >= 2000 THEN ' >= 2000'
    END 
) AS T
ORDER BY CASE [СуммаКатегория]
    WHEN ' >= 2000' THEN 1
    WHEN '500-1999' THEN 2
    WHEN '< 500' THEN 3
END;



SELECT Отделы.НазваниеОтдела, 
       ROUND(AVG(CAST(Заказы.ПотраченнаяСумма AS FLOAT)), 2) AS 'avg on dep'
FROM Заказы 
INNER JOIN Отделы ON Заказы.Отдел = Отделы.НазваниеОтдела
GROUP BY Отделы.НазваниеОтдела;


SELECT Заказы.Дата,  
       ROUND(AVG(CAST(Заказы.ПотраченнаяСумма AS FLOAT)), 2) AS 'avg on date'
FROM Заказы 
INNER JOIN Отделы ON Заказы.Отдел = Отделы.НазваниеОтдела
GROUP BY Заказы.Дата;


SELECT Отделы.НазваниеОтдела, 
       ROUND(AVG(CAST(Заказы.ПотраченнаяСумма AS FLOAT)), 2) AS 'avg on list'
FROM Заказы 
INNER JOIN Отделы ON Заказы.Отдел = Отделы.НазваниеОтдела
where Заказы.Товар IN ('Монитор', 'Яблоко', 'Ложка')
GROUP BY Отделы.НазваниеОтдела;



select  Отделы.НазваниеОтдела ,count(*) as amount 
from Заказы inner join Отделы on ОТделы.НазваниеОтдела = Заказы.Отдел
where Заказы.ПотраченнаяСумма > Отделы.ПредельнаяНормаРасхода
group by Отделы.НазваниеОтдела
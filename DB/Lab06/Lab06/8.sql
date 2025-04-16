USE KOR_MyBase


SELECT ������.��������������,
       AVG(������.����������������) AS [AVG], 
       MIN(������.����������������) AS [MIN], 
       MAX(������.����������������) AS [MAX], 
       COUNT(*) AS [COUNT], 
       SUM(������.����������������) AS [SUM]
FROM ������ 
INNER JOIN ������ ON ������.����� = ������.��������������
GROUP BY ������.��������������;



SELECT * FROM (
    SELECT CASE 
        WHEN ���������������� < 500 THEN '< 500'
        WHEN ���������������� < 2000 THEN '500-1999'
        WHEN ���������������� >= 2000 THEN ' >= 2000'
    END AS [��������������], 
    COUNT(*) AS [����������]
    FROM ������
    GROUP BY CASE 
        WHEN ���������������� < 500 THEN '< 500'
        WHEN ���������������� < 2000 THEN '500-1999'
        WHEN ���������������� >= 2000 THEN ' >= 2000'
    END 
) AS T
ORDER BY CASE [��������������]
    WHEN ' >= 2000' THEN 1
    WHEN '500-1999' THEN 2
    WHEN '< 500' THEN 3
END;



SELECT ������.��������������, 
       ROUND(AVG(CAST(������.���������������� AS FLOAT)), 2) AS 'avg on dep'
FROM ������ 
INNER JOIN ������ ON ������.����� = ������.��������������
GROUP BY ������.��������������;


SELECT ������.����,  
       ROUND(AVG(CAST(������.���������������� AS FLOAT)), 2) AS 'avg on date'
FROM ������ 
INNER JOIN ������ ON ������.����� = ������.��������������
GROUP BY ������.����;


SELECT ������.��������������, 
       ROUND(AVG(CAST(������.���������������� AS FLOAT)), 2) AS 'avg on list'
FROM ������ 
INNER JOIN ������ ON ������.����� = ������.��������������
where ������.����� IN ('�������', '������', '�����')
GROUP BY ������.��������������;



select  ������.�������������� ,count(*) as amount 
from ������ inner join ������ on ������.�������������� = ������.�����
where ������.���������������� > ������.����������������������
group by ������.��������������
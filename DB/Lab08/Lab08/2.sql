--create view [Количество кафедр] as
select faculty.FACULTY_NAME, count(*) AS Количество
from FACULTY INNER JOIN PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
GROUP BY FACULTY.FACULTY_NAME

select * from [Количество кафедр]

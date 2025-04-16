alter view [Количество кафедр] with schemabinding as
select faculty.FACULTY_NAME, COUNT(*) AS Количество
FROM dbo.FACULTY INNER JOIN dbo.PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
GROUP BY FACULTY.FACULTY_NAME
go
select * from [Количество кафедр]




 
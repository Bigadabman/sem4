alter view [���������� ������] with schemabinding as
select faculty.FACULTY_NAME, COUNT(*) AS ����������
FROM dbo.FACULTY INNER JOIN dbo.PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
GROUP BY FACULTY.FACULTY_NAME
go
select * from [���������� ������]




 
--create view [���������� ������] as
select faculty.FACULTY_NAME, count(*) AS ����������
from FACULTY INNER JOIN PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
GROUP BY FACULTY.FACULTY_NAME

select * from [���������� ������]

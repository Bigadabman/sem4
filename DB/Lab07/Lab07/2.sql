use UNIVER

select  FACULTY.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT ,round(avg(cast(PROGRESS.NOTE as float(4))),2) as 'avg'
from FACULTY inner join GROUPS on GROUPS.FACULTY = FACULTY.FACULTY
inner join STUDENT on GROUPS.IDGROUP = STUDENT.IDGROUP
inner join PROGRESS on PROGRESS.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE FACULTY.FACULTY = '���'
GROUP BY 
CUBE (FACULTY.FACULTY, GROUPS.PROFESSION, PROGRESS.SUBJECT)


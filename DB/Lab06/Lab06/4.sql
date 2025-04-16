USE UNIVER;

select round(avg(cast(progress.NOTE as float(4))), 2) as 'avg on course',GROUPS.YEAR_FIRST from progress inner join student on progress.IDSTUDENT = student.IDSTUDENT
inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
group by groups.YEAR_FIRST

select round(avg(cast(progress.NOTE as float(4))), 2) as 'avg on prof',PROFESSION.PROFESSION_NAME from progress inner join student on progress.IDSTUDENT = student.IDSTUDENT
inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP inner join PROFESSION on GROUPS.PROFESSION = PROFESSION.PROFESSION
group by PROFESSION.PROFESSION_NAME

select round(avg(cast(progress.NOTE as float(4))), 2) as 'avg on faculty', FACULTY.FACULTY_NAME
from PROGRESS inner join  STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT 
INNER JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP 
INNER JOIN FACULTY ON GROUPS.FACULTY = FACULTY.FACULTY
GROUP BY FACULTY.FACULTY_NAME

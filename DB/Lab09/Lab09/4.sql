declare @x int = 10,
		@t int = 20;

declare @z float(4);

if @t > @x
set @z = power(sin(@t), 2);
else if @t < @x
set @z = 4 * (@t + @x);
else 
set @z = 1 - exp(@x - 2);

print @z;


USE UNIVER;


declare @fio varchar(30) = (select top(1) student.name from STUDENT);

declare @shortedFio varchar(30)= substring(@fio, 0, charindex(' ', @fio) + 2) + '. ' + 
substring(@fio, charindex(' ', @fio, charindex(' ', @fio)+1) + 1,  1) + '.';

print @shortedFio;


select STUDENT.NAME, STUDENT.BDAY, (DATEDIFF(YEAR, STUDENT.BDAY, GETDATE())) as age
from STUDENT
where DATEDIFF(M, STUDENT.BDAY, GETDATE())%12 = 11


SELECT STUDENT.NAME, STUDENT.IDGROUP, DATENAME(DW, PROGRESS.PDATE) AS DW, PROGRESS.SUBJECT
FROM STUDENT INNER JOIN PROGRESS ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
WHERE PROGRESS.SUBJECT = 'ясад'
AND STUDENT.IDGROUP = 4


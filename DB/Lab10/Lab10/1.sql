use UNIVER

exec SP_HELPINDEX 'AUDITORIUM'
exec SP_HELPINDEX 'AUDITORIUM_TYPE'
exec SP_HELPINDEX 'FACULTY'
exec SP_HELPINDEX 'PULPIT'
exec SP_HELPINDEX 'GROUPS'
exec SP_HELPINDEX 'PROFESSION'
exec SP_HELPINDEX 'PROGRESS'
exec SP_HELPINDEX 'STUDENT'
exec SP_HELPINDEX 'SUBJECT'
exec SP_HELPINDEX 'TEACHER'

go


set nocount on

CREATE TABLE #TABL(
	id int,
	ival int,
	fval float(2)
)
go


declare @counter int = 0;

while @counter < 10000
begin

insert #TABL(id, ival, fval) values (@counter, 1000*RAND(), 1000*RAND())

set @counter = @counter + 1;

end


select ival from #TABL
where ival between 100 and 500;
go

checkpoint;
DBCC DROPCLEANBUFFERS;

create clustered index #TABLE_CLUSTERED on #TABL(ival asc) 

select ival from #TABL
where ival between 500 and 900;

drop index #TABLE_CLUSTERED on #TABL
go

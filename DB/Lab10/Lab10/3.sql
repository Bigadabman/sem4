
set nocount on

CREATE TABLE #TABL(
	id int,
	ival int,
	fval float(2)
)

go

declare @counter int = 0;

while @counter < 30000
begin

insert #TABL(id, ival, fval) values (@counter, 1000*RAND(), 1000*RAND())

set @counter = @counter + 1;

end
go

select * from #TABL
where ival = 500 and fval > 800;

create nonclustered index #TABLE_NONCLUSTERED on #TABL(ival, fval) include (id)

select * from #TABL
where ival = 500 and fval > 800;

go
drop index #TABLE_NONCLUSTERED on #TABL

checkpoint;
DBCC DROPCLEANBUFFERS;


select * from #TABL
where ival = 600 and fval > 900;
drop table #TABL
go
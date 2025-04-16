


CREATE TABLE #TABL(
	id int,
	ival int,
	fval float(2)
)

go
set nocount on
declare @counter int = 0;

while @counter < 30000
begin

insert #TABL(id, ival, fval) values (@counter, 1000*RAND(), 1000*RAND())

set @counter = @counter + 1;

end


select ival, fval from #TABL
where ival = 500 and fval > 800;



checkpoint;
DBCC DROPCLEANBUFFERS;

create nonclustered index #TABLE_NONCLUSTERED on #TABL(ival, fval) where (ival = 500 and fval > 800)-- with (DROP_EXISTING = on)

select ival, fval from #TABL
where ival = 500 and fval > 800;

go 

drop index #TABLE_NONCLUSTERED on #TABL
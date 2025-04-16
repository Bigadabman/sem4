create table #tab (
	id int,
	iValue int,
	fValue float(2)
	)
	go
declare @counter int = 0;

while @counter < 10
begin 

insert into #tab(id, iValue, fValue) values (@counter, 1000*RAND(), 1000 * RAND())

set @counter = @counter + 1;
end

SELECT * FROM #tab

drop table #tab
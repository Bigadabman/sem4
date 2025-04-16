use tempdb;
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
    insert #TABL(id, ival, fval) 
    values (@counter, CAST(1000*RAND() as int), 1000*RAND())
    set @counter = @counter + 1;
end
go


create nonclustered index #TABLE_NONCLUSTERED on #TABL(ival, fval)
go


SELECT name[Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
WHERE name is not null
go


delete from #TABL
where id % 2 = 0
and id between (select Min(id) from #TABL) + 2000 
and (select max(id) from #TABL) - 2000
go

declare @counter int = 10000;
while @counter < 15000
begin
    insert #TABL(id, ival, fval) 
    values (@counter, CAST(1000*RAND() as int), 1000*RAND())
    set @counter = @counter + 1;
end
go


SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
WHERE name is not null
go


ALTER INDEX #TABLE_NONCLUSTERED ON #TABL REORGANIZE
go


SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
WHERE name is not null
go


ALTER INDEX #TABLE_NONCLUSTERED ON #TABL REBUILD
go


SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ss  
JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
WHERE name is not null
go

drop table #TABL
go
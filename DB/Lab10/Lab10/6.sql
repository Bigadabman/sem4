use KOR_MyBase;
go


set nocount on

CREATE TABLE #TABL(
    id int,
    ival int,
    fval float(2),
    description varchar(200)
)
go


declare @counter int = 0;

while @counter < 10000
begin
    insert #TABL(id, ival, fval, description) 
    values (@counter, 
            CAST(1000*RAND() as int), 
            1000*RAND(),
            'Description ' + CAST(@counter as varchar(10)))
    set @counter = @counter + 1;
end
go


create nonclustered index #TABLE_NONCLUSTERED_FILLFACTOR on #TABL(ival)
with (fillfactor = 70)
go


create nonclustered index #TABLE_NONCLUSTERED_NOFILLFACTOR on #TABL(fval)
go
USE tempdb
GO
SELECT name FROM sys.indexes WHERE object_id = OBJECT_ID(N'tempdb..#TABL')

SELECT 
    i.name [Индекс],
    ips.avg_fragmentation_in_percent [Фрагментация (%)],
    ips.page_count [Кол-во страниц],
    ips.avg_page_space_used_in_percent [Заполненность страниц (%)],
    CASE WHEN i.fill_factor = 0 THEN 100 ELSE i.fill_factor END [FillFactor]
FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ips
JOIN sys.indexes i ON ips.object_id = i.object_id AND ips.index_id = i.index_id
WHERE i.name IS NOT NULL
go
declare @counter int = 10000;
set @counter = 10000;
while @counter < 15000
begin
    insert #TABL(id, ival, fval, description) 
    values (@counter, 
            CAST(1000*RAND() as int), 
            1000*RAND(),
            'New data ' + CAST(@counter as varchar(10)))
    set @counter = @counter + 1;
end
go


SELECT 
    i.name [Индекс],
    ips.avg_fragmentation_in_percent [Фрагментация (%)],
    ips.page_count [Кол-во страниц],
    ips.avg_page_space_used_in_percent [Заполненность страниц (%)],
    CASE WHEN i.fill_factor = 0 THEN 100 ELSE i.fill_factor END [FillFactor]
FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(N'#TABL'), NULL, NULL, 'DETAILED') ips
JOIN sys.indexes i ON ips.object_id = i.object_id AND ips.index_id = i.index_id
WHERE i.name IS NOT NULL
go


drop table #TABL
go
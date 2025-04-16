USE KOR_MyBase
set nocount on
-- 1

SELECT НомерЧека FROM Заказы


go
-- 2


create nonclustered index NonclusteredЗаказы on Заказы (Отдел, Товар, Дата)

select Отдел, Товар, Дата
from Заказы
go


-- 3


create nonclustered index NonclusteredЗаказыCovered
on Заказы (Отдел, Товар) include (Дата, ПотраченнаяСумма)

go
select Отдел, Товар, Дата, ПотраченнаяСумма
from ЗАказы

go
-- 4

create nonclustered index nonclusteredFiltered on Заказы (Товар, Отдел, ПотраченнаяСумма)
where ПотраченнаяСумма >=1000 and ПотраченнаяСумма < 3000

go
select Товар, Отдел, ПотраченнаяСумма
from Заказы
where ПотраченнаяСумма >=1000 and ПотраченнаяСумма < 3000



-- 5

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'NonclusteredЗаказы'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

go
declare @i int =0;

while @i < 10000
	begin
		insert into Заказы 
		values (@i, null, null,
		@i, GETDATE() )
		set @i = @i + 1;
	end


	go
SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'NonclusteredЗаказы'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

alter index NonclusteredЗаказы on Заказы reorganize

	go
SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'NonclusteredЗаказы'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

alter index NonclusteredЗаказы on Заказы rebuild
alter index NonclusteredЗаказыCovered on Заказы rebuild
alter index NonclusteredFiltered on Заказы rebuild
alter index PK__Заказы__A572DAE57D8A64C6 on Заказы rebuild


go
SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'NonclusteredЗаказы'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

declare @i int =0;

while @i < 10000
	begin
		delete Заказы where НомерЧека = cast(@i as char(10))
		set @i = @i + 1;
	end


	go


-- 6 



create nonclustered index NonclusteredFillfactor
on Заказы (Отдел, Товар) include (Дата, ПотраченнаяСумма)
with (fillfactor = 70)

go
declare @i int =0;

while @i < 10000
	begin
		insert into Заказы 
		values (@i, null, null,
		@i, GETDATE() )
		set @i = @i + 1;
	end


	go

	
SELECT 
    i.name [Индекс],
    ips.avg_fragmentation_in_percent [Фрагментация (%)],
    ips.page_count [Кол-во страниц],
    ips.avg_page_space_used_in_percent [Заполненность страниц (%)],
    CASE WHEN i.fill_factor = 0 THEN 100 ELSE i.fill_factor END [FillFactor]
FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(N'Заказы'), NULL, NULL, 'DETAILED') ips
JOIN sys.indexes i ON ips.object_id = i.object_id AND ips.index_id = i.index_id
WHERE i.name IS NOT NULL
go

declare @i int = 0;
while @i < 10000
	begin
		delete Заказы where НомерЧека = cast(@i as char(10))
		set @i = @i + 1;
	end


	go

	alter index NonclusteredFillfactor on Заказы rebuild

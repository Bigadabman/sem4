USE KOR_MyBase
set nocount on
-- 1

SELECT ��������� FROM ������


go
-- 2


create nonclustered index Nonclustered������ on ������ (�����, �����, ����)

select �����, �����, ����
from ������
go


-- 3


create nonclustered index Nonclustered������Covered
on ������ (�����, �����) include (����, ����������������)

go
select �����, �����, ����, ����������������
from ������

go
-- 4

create nonclustered index nonclusteredFiltered on ������ (�����, �����, ����������������)
where ���������������� >=1000 and ���������������� < 3000

go
select �����, �����, ����������������
from ������
where ���������������� >=1000 and ���������������� < 3000



-- 5

SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'Nonclustered������'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

go
declare @i int =0;

while @i < 10000
	begin
		insert into ������ 
		values (@i, null, null,
		@i, GETDATE() )
		set @i = @i + 1;
	end


	go
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'Nonclustered������'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

alter index Nonclustered������ on ������ reorganize

	go
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'Nonclustered������'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

alter index Nonclustered������ on ������ rebuild
alter index Nonclustered������Covered on ������ rebuild
alter index NonclusteredFiltered on ������ rebuild
alter index PK__������__A572DAE57D8A64C6 on ������ rebuild


go
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(), 
OBJECT_ID(N'Nonclustered������'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
go

declare @i int =0;

while @i < 10000
	begin
		delete ������ where ��������� = cast(@i as char(10))
		set @i = @i + 1;
	end


	go


-- 6 



create nonclustered index NonclusteredFillfactor
on ������ (�����, �����) include (����, ����������������)
with (fillfactor = 70)

go
declare @i int =0;

while @i < 10000
	begin
		insert into ������ 
		values (@i, null, null,
		@i, GETDATE() )
		set @i = @i + 1;
	end


	go

	
SELECT 
    i.name [������],
    ips.avg_fragmentation_in_percent [������������ (%)],
    ips.page_count [���-�� �������],
    ips.avg_page_space_used_in_percent [������������� ������� (%)],
    CASE WHEN i.fill_factor = 0 THEN 100 ELSE i.fill_factor END [FillFactor]
FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(N'������'), NULL, NULL, 'DETAILED') ips
JOIN sys.indexes i ON ips.object_id = i.object_id AND ips.index_id = i.index_id
WHERE i.name IS NOT NULL
go

declare @i int = 0;
while @i < 10000
	begin
		delete ������ where ��������� = cast(@i as char(10))
		set @i = @i + 1;
	end


	go

	alter index NonclusteredFillfactor on ������ rebuild

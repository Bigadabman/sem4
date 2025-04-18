use KOR_MyBase
go
--1

declare items cursor for
select ������.�������������� from ������

declare @items varchar(150) = '',
		@item varchar(15);


open items

fetch from items into @item;

while @@FETCH_STATUS = 0
	begin
		
		set @items = rtrim(@item) + ', ' + @items;
		fetch from items into @item;
	end


print @items;

close items

deallocate items


-- 2

go
declare items cursor global for
select ������.�������������� from ������
go
declare @items varchar(150) = '',
		@item varchar(15);


open items

fetch from items into @item;

while @@FETCH_STATUS = 0
	begin
		
		set @items = rtrim(@item) + ', ' + @items;
		fetch from items into @item;
	end


print @items;

close items

deallocate items

go
----------------

go
declare items cursor local for
select ������.�������������� from ������
go
declare @items varchar(150) = '',
		@item varchar(15);


open items

fetch from items into @item;

while @@FETCH_STATUS = 0
	begin
		
		set @items = rtrim(@item) + ', ' + @items;
		fetch from items into @item;
	end


print @items;

close items

deallocate items


go




-- 3


go
declare items cursor local static for
select ������.�������������� from ������


declare @items varchar(150) = '',
		@item varchar(15);


open items

	insert ������(��������������, ��������)
	values ('�����1', '��������'), ('�����2', '��������')


fetch from items into @item;

while @@FETCH_STATUS = 0
	begin
		
		set @items = rtrim(@item) + ', ' + @items;
		fetch from items into @item;
	end


print @items;

close items

deallocate items

delete ������ WHERE �������������� like '%�����%'

go


-----------


go
declare items cursor local dynamic for
select ������.�������������� from ������


declare @items varchar(150) = '',
		@item varchar(15);


open items

	insert ������(��������������, ��������)
	values ('�����1', '��������'), ('�����2', '��������')


fetch from items into @item;

while @@FETCH_STATUS = 0
	begin
		
		set @items = rtrim(@item) + ', ' + @items;
		fetch from items into @item;
	end


print @items;

close items

deallocate items

delete ������ WHERE �������������� like '%�����%'

go


-- 4 


go
declare items cursor scroll local for
select ������.�������������� from ������

declare @items varchar(150) = '',
		@item varchar(15);


open items


	

	fetch first from items into @item;
	print @item;

	fetch last from items into @item;
	print @item;

	fetch absolute 1 from items into @item;
	print @item;

	fetch relative 3 from items into @item;
	print @item;


close items

deallocate items


go

-- 6 


go


	insert ������(��������������, ��������)
	values ('�����1', '��������'), ('�����2', '��������')

declare items cursor local dynamic for
select * from ������ WHERE �������������� like '%�����%'


declare @items varchar (150) = '',
		@description varchar(10),
		@item varchar(15);


open items



fetch from items into @item, @description;

while @@FETCH_STATUS = 0
	begin
		
		delete from ������ where current of items;

		
fetch from items into @item, @description;
	end


print @items;

close items;


select * from ������

deallocate items



go


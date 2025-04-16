use KOR_MyBase
go
--1

declare items cursor for
select Товары.НазваниеТовара from Товары

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
use KOR_MyBase
go


-- 1 

create function DPRODUCTS(@d varchar(20)) returns int
as
begin
	declare @amount int = (select count(*) from Заказы where Заказы.Отдел = @d);

	return @amount;
end

go


select dbo.DPRODUCTS('Отдел продаж');
go


alter function DPRODUCTS(@d varchar(20), @p varchar(20)) returns int
as
begin
	declare @amount int = (select count(*) from Заказы 
	where Заказы.Отдел = isnull(@d, Заказы.Отдел) and Заказы.Товар = isnull(@p, Заказы.Товар));

	return @amount;

end
go

select dbo.DPRODUCTS('Отдел продаж', 'Ложка');
go


-- 2

alter function SPRODUCTS(@d varchar(20)) returns varchar(200)
as
begin
	
	declare @products varchar(200) = 'Продукты: ', @product varchar(20);

	declare productsCursor cursor for
	select Заказы.Товар from Заказы where Заказы.Отдел = @d;

	open productsCursor;

	fetch productsCursor into @product

	while @@FETCH_STATUS = 0
	begin
		set @products = @products + ',' + @product;
		fetch productsCursor into @product

	end

	close productsCursor;
	deallocate productsCursor;


	return @products;
end
go

select Заказы.Отдел, dbo.SPRODUCTS(Заказы.Отдел)as [Список заказов] from Заказы;
go

--3

create function tPRODUCTS(@d varchar(20), @p varchar(20)) returns table
as return 
	select * from Отделы left outer join Заказы on Заказы.Отдел = Отделы.НазваниеОтдела
	and Заказы.Товар = isnull(@p, Заказы.Товар) and Отделы.НазваниеОтдела = isnull(@d, Отделы.НазваниеОтдела)

go


select * from tPRODUCTS(null, null) 



select * from tPRODUCTS('Отдел разработки', null) 


select * from tPRODUCTS(null, 'Яблоко') 
go

-- 4



alter function DPRODUCTS(@d varchar(20)) returns int
as
begin
	declare @amount int = (select count(*) from Заказы where Заказы.Отдел = isnull(@d, Заказы.Отдел));

	return @amount;
end

go


select distinct Заказы.Отдел, dbo.DPRODUCTS(Заказы.Отдел) from Заказы;

select dbo.DPRODUCTS(null) as [Всего заказов]
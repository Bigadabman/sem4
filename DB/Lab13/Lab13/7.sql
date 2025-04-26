use KOR_MyBase
set nocount on
go

-- 1

create procedure printing
as 
begin
select * from Заказы
return @@ROWCOUNT;
end 

go

exec printing
go
-- 2

alter procedure selectItems
(
	@i varchar(20) = null,
	@c int output
)
as
begin
	
	select * from Товары
	where НазваниеТовара = @i;

	set @c = @@ROWCOUNT;
	
	declare @linesAmount int = (select count(*) from Товары)

	return @linesAmount;
end 
go
	declare @amount int;
	exec selectItems 'Ложка', @amount
	print 'Всего товаров' + cast(@amount as varchar(3));


go

-- 3 

create table #Товары
(
	НазваниеТовара varchar(10),
	Описание varchar(30)
)
go
alter procedure selectItems
(
	@i varchar(10)
)
as 
begin
	select * from Товары 
	where НазваниеТовара = @i


end

go

insert #Товары exec selectItems 'Монитор'

select * from #Товары

go


-- 4

create procedure Iorders_insert
(
	@cheque varchar(10),
	@department varchar(20),
	@product varchar(10),
	@cost int,
	@date date
)

as 
begin
	
	begin try
		if (@cost <= 0) or (@date > getdate())
		begin 
			raiserror('Ошибка в параметрах', 14, 1);
		end

		insert into Заказы
		values (@cheque, @department, @product, @cost, @date)


		return 1

	end try
	begin catch
		print 'Код ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print 'Ошибка: ' + error_message();
		
		return -1;
	end catch

end

go

	exec Iorders_insert 'k19faj1ca0', 'Отдел продаж', 'Монитор', 10000, '2025.04.26'
	select * from Заказы

go

-- 5

create procedure DORDERS_REPORT
(
	@department varchar(20) = null
)
as 
begin
	begin try
	if not exists (select * from Заказы where Отдел = @department)
		raiserror('Ошибка в параметрах', 14, 1);

	declare currentOrder cursor for
	select distinct Товар from Заказы where Отдел = @department

	open currentOrder

	declare @ordersAmount int = @@CURSOR_ROWS;

	declare @order varchar(10), @orders varchar(200) = '';
	fetch currentOrder into @order;

	while @@FETCH_STATUS = 0
	begin
		set @orders = rtrim(@order) + ', ' + @orders;
		fetch currentOrder into @order;
	end
	print @orders
	
	close currentOrder
	deallocate currentOrder

	return @ordersAmount;

	end try
	begin catch
		print 'Номер ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print error_message();
		return -1;
	end catch


end

go

exec DORDERS_REPORT 'Отдел продаж'

go

-- 6

create procedure DORDERS_INSERTX
(	
	@cheque varchar(10),
	@department varchar(20),
	@product varchar(10),
	@cost int,
	@date date,
	@description varchar(50)
)
as 
begin 
	begin try
		
		if (@cost <= 0) or (@date > getdate())
		begin 
			raiserror('Ошибка в параметрах', 14, 1);
		end

		begin tran 
			insert into Товары 
			values (@product, @description);

			exec Iorders_insert @cheque, @department, @product, @cost, @date

		commit

		return 1
	end try
	
	begin catch

		if @@TRANCOUNT > 0
			rollback

		print 'Номер ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print error_message();
		return -1;

	end catch


end 

go



exec DORDERS_INSERTX 'mo1iurjh91', 'Отдел электроники', 'Груша', 200, '2025.04.26' , 'Почти как яблоко'
select * from Заказы
go

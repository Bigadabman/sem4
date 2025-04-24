use KOR_MyBase
set nocount on
go

-- 1

set implicit_transactions on

	begin try 
		begin tran 
			insert into Товары 
			values ('Ложка', 'Чтобы кушать');

		commit 
		
	end try

	begin catch
		rollback

	end catch

	select * from Товары

go
-- 2

begin tran 

begin try 
		begin tran 


			update Товары set Товары.Описание = 'Просто новый' where Товары.НазваниеТовара = 'Монитор';


			delete Товары where Товары.НазваниеТовара = 'Яблоко';
			
			insert into Товары 
			values ('Ложка', 'Чтобы кушать');

		commit 
		
	end try

	begin catch
		rollback

	end catch

	select * from Товары


	go

	-- 3 

	declare @point varchar(15);
begin tran 

begin try 
		begin tran 


			update Товары set Товары.Описание = 'Просто новый' where Товары.НазваниеТовара = 'Монитор';
			set @point = 'point1'; save tran @point;

			delete Товары where Товары.НазваниеТовара = 'Яблоко';
			
			insert into Товары 
			values ('Ложка', 'Чтобы кушать');

		commit 
		
	end try

	begin catch
		rollback tran @point 
		select * from Товары
	end catch
	rollback
	select * from Товары


	go


	-- 8


	begin tran 


		update Товары set Товары.Описание = 'Просто новый' where Товары.НазваниеТовара = 'Монитор';

		begin tran 
			
			insert into Товары 
			values ('Вилка', 'Как ложка, но острая');

		rollback
	commit


	go
update Товары set Товары.Описание = 'Новый вместо старого' where Товары.НазваниеТовара = 'Монитор';
delete Товары where Товары.НазваниеТовара = 'Вилка'

use UNIVER;
set nocount on

go
delete pulpit where pulpit.PULPIT = 'КБ'
go
declare @point varchar(10);

begin try
begin tran 

	insert into Pulpit values ('КБ', 'Компьютерной безопасности', 'ИТ')
	set @point = 'point1';save tran @point;

	update Pulpit set pulpit.PULPIT_NAME = 'Интернет Спасет И Тяжелый день' where pulpit.PULPIT = 'ИСиТ'

	delete Pulpit where pulpit.PULPIT = 'ИСиТ'

commit tran 
	end try

	

	begin catch
		rollback tran @point;
		print Error_message()
	end catch
	select * from Pulpit 
	
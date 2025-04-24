use UNIVER
go
-- B


begin tran

	insert into Pulpit values ('КБ', 'Компьютерной безопасности', 'ИТ')


	update Pulpit set pulpit.PULPIT_NAME = 'Интернет Спасет И Тяжелый день' where pulpit.PULPIT = 'ИСиТ'

	
		waitfor delay '00:00:15'

rollback
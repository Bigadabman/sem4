use UNIVER
go


begin tran

	insert into Pulpit values ('КБ', 'Компьютерной безопасности', 'ИТ')

	begin tran 
		update Pulpit set pulpit.PULPIT_NAME = 'Интернет Спасет И Тяжелый день' where pulpit.PULPIT = 'ИСиТ'


		
	commit
commit


	select  * from pulpit


go
delete Pulpit where Pulpit.PULPIT = 'КБ';
go
update Pulpit set PULPIT.PULPIT_NAME = 'Информационых систем и технологий' 
where pulpit.PULPIT = 'ИСиТ'

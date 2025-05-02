use UNIVER
go
-- B


begin tran

	insert into Pulpit values ('КБ', 'Компьютерной безопасности', 'ИТ')
	update Pulpit set pulpit.PULPIT_NAME = 'Интернет Спасет И Тяжелый день' where pulpit.PULPIT = 'ИСиТ'

commit


waitfor delay '00:00:10'

delete Pulpit where Pulpit.PULPIT = 'КБ';

update Pulpit set PULPIT.PULPIT_NAME = 'Информационых систем и технологий' 
where pulpit.PULPIT = 'ИСиТ'

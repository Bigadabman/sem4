use UNIVER
go
-- B


begin tran

	insert into Pulpit values ('КБ', 'Компьютерной безопасности', 'ИТ')

commit


waitfor delay '00:00:10'

delete Pulpit where Pulpit.PULPIT = 'КБ';

update Pulpit set PULPIT.PULPIT_NAME = 'Информационых систем и технологий' 
where pulpit.PULPIT = 'ИСиТ'

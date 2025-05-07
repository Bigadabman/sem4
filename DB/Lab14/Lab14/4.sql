use UNIVER
go

create function FCTEACHER (@p varchar(20))
returns int
as 
begin
	declare @tc int = (select count(*) from TEACHER
	where TEACHER.PULPIT = isnull(@p, TEACHER.PULPIT));

	return @tc;
	end

go

select PULPIT.PULPIT, dbo.FCTEACHER(PULPIT.PULPIT) as [Количество преподавателей] from PULPIT;
select dbo.FCTEACHER(null) as [Всего преподавателей]
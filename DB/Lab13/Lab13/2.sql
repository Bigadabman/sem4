use UNIVER;
go

alter proc PSUBJECT
(
	@p varchar(20) = null,
	@c int output
)
as 
begin
	
	select * from SUBJECT
	where subject.PULPIT = @p;

	set @c = @@ROWCOUNT;

	declare @linesAmount int = (select count(*) from subject);
	return @linesAmount;
end
go 
declare @rowsAmount int,
		@totalRows int;

exec @totalRows = PSUBJECT @p = 'ИСиТ', @c = @rowsAmount;
print 'Всего на кафедре: ' + cast(@rowsAmount as varchar(3)) + 'дисциплин';
print 'Всего дисиплин: ' + cast(@totalRows as varchar(3));


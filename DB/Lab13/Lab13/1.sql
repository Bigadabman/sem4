use UNIVER

go


create procedure PSUBJECT
as begin 

	declare @linesAmount int = (select count(*) from SUBJECT);

	select * from subject;
	return @linesAmount;

end

go

	declare @c int;
 exec @c = PSUBJECT;

 print 'Всего строк: ' + cast(@c as varchar(3))

use UNIVER
go

create function FSUBJECT(@p varchar(20)) returns varchar(300)
as
begin
	declare @subjects varchar(300) = 'Дисциплины: ', @subject varchar(20);

	declare subjectCursor cursor local for
	select SUBJECT.SUBJECT from SUBJECT where SUBJECT.PULPIT = @p;

	open subjectCursor;

	fetch subjectCursor into @subject;
	

	while @@FETCH_STATUS = 0
	begin
		set @subjects = @subjects + @subject + ',';
		fetch subjectCursor into @subject;
	end


	close subjectCursor;
	deallocate subjectCursor;

	return @subjects;
end
go


select distinct Subject.PULPIT, dbo.FSUBJECT(SUBJECT.PULPIT) 
from SUBJECT;
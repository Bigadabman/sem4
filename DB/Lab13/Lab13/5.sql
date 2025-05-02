use UNIVER;

go


create procedure SUBJECT_REPORT
(
	@p char(10)
)
as 
begin
	begin try
		declare csubject cursor for
			select SUBJECT from SUBJECT 
			where SUBJECT.PULPIT = @p

		if not exists (select * from subject where SUBJECT.PULPIT = @p)
			raiserror('Ошибка в параметрах', 14, 1);


		declare @currentSubject varchar(30), @subjects varchar(200) = '', @subjectAmount int; 
		
		open csubject 
		set @subjectAmount = @@CURSOR_ROWS;
		fetch csubject into @currentSubject;

		while @@FETCH_STATUS = 0
			begin
				set @subjects = rtrim(@currentSubject) + ',' + @subjects;
				fetch csubject into @currentSubject;

			end 


		close csubject

		deallocate csubject

		print @subjects

		return @subjectAmount;

	end try

	begin catch
		
		close csubject

		deallocate csubject

		print 'Код ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print 'Ошибка: ' + error_message();

		return -1
	end catch

end


go

	exec SUBJECT_REPORT 'ИСиТ'


	go 

use UNIVER



declare @subjects char(100) = '',
		@subject char(10);

		declare cursorSubject Cursor for
		select [subject]
		from [SUBJECT]
		where PULPIT = 'ศั่า'


open cursorSubject;

fetch cursorSubject into @subject;
set @subjects = rtrim(@subject); 
fetch cursorSubject into @subject;

while @@FETCH_STATUS = 0
	begin 
		set @subjects = rtrim(@subject) + ', ' + @subjects; 
		--set @subjects = @subjects + ', ' + ltrim(@subject);
		fetch cursorSubject into @subject;

	end;


	print @subjects
	
	
close cursorSubject

deallocate cursorSubject
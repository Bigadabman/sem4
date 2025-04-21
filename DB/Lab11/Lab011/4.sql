use UNIVER
set nocount on 

declare cursorFaculty cursor local static for
select row_number() over (order by FACULTY.FACULTY) N, FACULTY from FACULTY


declare @string char(100) = '',
		@faculty char(5),
		@rowNumber int;


open cursorFaculty;
	
fetch cursorFaculty into @rowNumber, @faculty;

while @@FETCH_STATUS = 0
	begin
			
		set @string = 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;
		fetch cursorFaculty into @rowNumber, @faculty;
			

	end;

	print '----------------'

	fetch prior from cursorFaculty into @rowNumber, @faculty;
	set @string = 'prior ' + 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;


	print '----------------'

	fetch first from cursorFaculty into @rowNumber, @faculty;
	set @string = 'first ' + 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;


	print '----------------'

	fetch absolute 4 from cursorFaculty into @rowNumber, @faculty;
	set @string = 'absolute 4 ' + 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;

	print '----------------'

	fetch relative -4 from cursorFaculty into @rowNumber, @faculty;
	set @string = 'relative -4 ' + 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;

	print '----------------'
	fetch next from cursorFaculty into @rowNumber, @faculty;
	set @string = 'next ' + 'строка ' + cast(@rowNumber as nchar(2)) + rtrim(@faculty);
		print @string;

	

close cursorFaculty;

deallocate cursorfaculty;
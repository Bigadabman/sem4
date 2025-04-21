use UNIVER
set nocount on 

declare cursorFaculty cursor local static for
select FACULTY from Faculty

open cursorFaculty;
insert Faculty(FACULTY)
	values('ИБ'),
			('ФФК');


declare @faculties char(100) = '',
		@faculty char(5);


	
	
	fetch cursorFaculty into @faculty;

	while @@FETCH_STATUS = 0
		begin
			
			set @faculties = rtrim(@faculty) + ', ' + @faculties;
			fetch cursorFaculty into @faculty;
			

		end;
		
		print @faculties;


		close cursorFaculty;

		deallocate cursorfaculty;

		go
	delete FACULTY where FACULTY_NAME = 'Не указано'


	--------------------------------------------------------------

	
declare cursorFaculty cursor local dynamic for
select FACULTY from Faculty

open cursorFaculty;
insert Faculty(FACULTY)
	values('ИБ'),
			('ФФК');


declare @faculties char(100) = '',
		@faculty char(5);


	
	
	fetch cursorFaculty into @faculty;

	while @@FETCH_STATUS = 0
		begin
			
			set @faculties = rtrim(@faculty) + ', ' + @faculties;
			fetch cursorFaculty into @faculty;
			

		end;
		
		print @faculties;


		close cursorFaculty;

		deallocate cursorfaculty;

		go
	delete FACULTY where FACULTY_NAME = 'Не указано'
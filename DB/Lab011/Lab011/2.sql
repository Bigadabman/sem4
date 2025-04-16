use UNIVER 


declare cursorFaculty cursor local for
select FACULTY from FACULTY


go

declare @faculties char(30) = '',
		@faculty char(5);


	open cursorFaculty
	fetch cursorFaculty into @faculty;

while @@FETCH_STATUS = 0
	begin
	set @faculties = rtrim(@faculty) + ', ' + @faculties;

	end


	print @faculties;


	close cursorFaculty;

	deallocate cursorFaculty
	go
	-------------------

	
declare cursorFaculty cursor global for
select FACULTY from FACULTY


go

declare @faculties char(30) = '',
		@faculty char(5);


	open cursorFaculty
	fetch cursorFaculty into @faculty;

while @@FETCH_STATUS = 0
	begin
	set @faculties = rtrim(@faculty) + ', ' + @faculties;
	fetch cursorFaculty into @faculty;
	end


	print @faculties;


	close cursorFaculty;

	deallocate cursorFaculty
	go


use UNIVER
go

create function FACULTY_REPORT(@c int) returns @fr table
	                        ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	                                                                 [Количество студентов] int, [Количество специальностей] int )
	as begin 
                 declare cc CURSOR static for 
	       select FACULTY from FACULTY 
                                                    where dbo.COUNT_STUDENTS(FACULTY, default) > @c; 
	       declare @f varchar(30);
	       open cc;  
                 fetch cc into @f;
	       while @@fetch_status = 0
	       begin
	            insert @fr values( @f,  dbo.COUNT_PULPITS(@f),
	            dbo.COUNT_GROUPS(@f),   dbo.COUNT_STUDENTS(@f, default),
	            dbo.COUNT_PROFS(@f)   ); 
	            fetch cc into @f;  
	       end;   
                 return; 
	end;
	go


	create function COUNT_PULPITS(@f varchar(20)) returns int
	as
	begin

	declare @amount int = (select count(*) 
	from PULPIT where PULPIT.FACULTY = @f);

	return @amount;
	end

	go

	create function COUNT_GROUPS(@f varchar(20)) returns int
	as 
	begin
		declare @amount int = (select count(*) from GROUPS where GROUPS.FACULTY = @f);

		return @amount;
	end

	go


	create function COUNT_PROFS(@f varchar(20)) returns int
	as 
	begin 
	declare @amount int= (select count(*) from PROFESSION where FACULTY = @f);

	return @amount;
	end 

	go

	select * from FACULTY_REPORT(-1);

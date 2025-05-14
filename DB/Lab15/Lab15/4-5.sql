use UNIVER 
go

create trigger TR_TEACHER on TEACHER
after insert, delete, update
as
begin
	declare @ins int = (select count(*) from inserted),
	@del int = (select count(*) from deleted);

	declare @newTeacher nvarchar(10)= (select TEACHER from inserted),
	@newTeacherName nvarchar(50)= (select TEACHER_Name from inserted),
	@newGender nvarchar(1) = (select GENDER from inserted),
	@newPulpit varchar(20) = (select pulpit from inserted);


	declare @oldTeacher nvarchar(10)= (select TEACHER from deleted),
	@oldTeacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@oldGender nvarchar(1) = (select GENDER from deleted),
	@oldPulpit varchar(20) = (select pulpit from deleted);
	declare @resultingString varchar(200);



	if @ins > 0 and @del = 0
	begin

	set @resultingString =  @newTeacher+ @newTeacherName + @newGender+ @newPulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('INS', 'TR_TEACHER', @resultingString);
	

	end 
	else

	if @ins > 0 and @del > 0
	begin
		
	set @resultingString = @oldTeacher + @oldTeacherName+ @oldGender+ @oldPulpit
									+ @newTeacher+ @newTeacherName + @newGender+ @newPulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('UPD', 'TR_TEACHER', @resultingString);
	

	end 
	else
	if @ins = 0 and @del > 0
	begin

	set @resultingString = @oldTeacher + ' ' + @oldTeacherName + ' ' + @oldGender + ' ' + @oldPulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('DEL', 'TR_TEACHER', @resultingString);
	end



end 

go
-- 5


insert into TEACHER 
values (NULL, NULL, NULL, NULL)
go

select * from TR_AUDIT
use UNIVER
go

create TABLE TR_AUDIT
(
ID int identity,
STMT varchar(20) check (STMT in ('INS', 'DEL', 'UPD')), 
TRNAME varchar(50),
CC varchar(300)
)

go

-- 1

create trigger TR_TEACHER_INS on TEACHER
after insert
as
begin
	declare @teacher nvarchar(10)= (select TEACHER from inserted),
	@teacherName nvarchar(50)= (select TEACHER_Name from inserted),
	@gender nvarchar(1) = (select GENDER from inserted),
	@pulpit varchar(20) = (select pulpit from inserted);

	declare @resultingString varchar(85) = @teacher + ' ' + @teacherName + ' ' + @gender + ' ' + @pulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('INS', 'TR_TEACHER_INS', @resultingString);
	


end

go

-- 2


create trigger TR_TEACHER_DEL on TEACHER
after delete
as
begin
	declare @teacher nvarchar(10)= (select TEACHER from deleted),
	@teacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@gender nvarchar(1) = (select GENDER from deleted),
	@pulpit varchar(20) = (select pulpit from deleted);

	declare @resultingString varchar(85) = @teacher + ' ' + @teacherName + ' ' + @gender + ' ' + @pulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('DEL', 'TR_TEACHER_DEL', @resultingString);
	


end
go
-- 3


create trigger TR_TEACHER_UPD on TEACHER
after update
as
begin
	declare @newTeacher nvarchar(10)= (select TEACHER from inserted),
	@newTeacherName nvarchar(50)= (select TEACHER_Name from inserted),
	@newGender nvarchar(1) = (select GENDER from inserted),
	@newPulpit varchar(20) = (select pulpit from inserted);


	declare @oldTeacher nvarchar(10)= (select TEACHER from deleted),
	@oldTeacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@oldGender nvarchar(1) = (select GENDER from deleted),
	@oldPulpit varchar(20) = (select pulpit from deleted);


	declare @resultingString varchar(200) = @oldTeacher + ' ' + @oldTeacherName + ' ' + @oldGender + ' ' + @oldPulpit
									+ ' ' + @newTeacher + ' ' + @newTeacherName + ' ' + @newGender + ' ' + @newPulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('UPD', 'TR_TEACHER_UPD', @resultingString);
	


end

go

insert Teacher 
values ('БЕВ', 'Барковский Евгений Валерьевич', 'м', 'ИСиТ');
go
update TEACHER set pulpit = 'КБ' where teacher = 'БЕВ'

go

delete teacher where teacher = 'БЕВ'
go
select * from TEACHER


go
select * from TR_AUDIT
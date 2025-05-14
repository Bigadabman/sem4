use UNIVER;
go
create trigger TR_TEACHER_DEL1 on TEACHER
after delete
as
begin
	declare @teacher nvarchar(10)= (select TEACHER from deleted),
	@teacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@gender nvarchar(1) = (select GENDER from deleted),
	@pulpit varchar(20) = (select pulpit from deleted);

	declare @resultingString varchar(85) = @teacher + ' ' + @teacherName + ' ' + @gender + ' ' + @pulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('DEL', 'TR_TEACHER_DEL1', @resultingString);
	


end
go


create trigger TR_TEACHER_DEL2 on TEACHER
after delete
as
begin
	declare @teacher nvarchar(10)= (select TEACHER from deleted),
	@teacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@gender nvarchar(1) = (select GENDER from deleted),
	@pulpit varchar(20) = (select pulpit from deleted);

	declare @resultingString varchar(85) = @teacher + ' ' + @teacherName + ' ' + @gender + ' ' + @pulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('DEL', 'TR_TEACHER_DEL2', @resultingString);
	


end
go


create trigger TR_TEACHER_DEL3 on TEACHER
after delete
as
begin
	declare @teacher nvarchar(10)= (select TEACHER from deleted),
	@teacherName nvarchar(50)= (select TEACHER_Name from deleted),
	@gender nvarchar(1) = (select GENDER from deleted),
	@pulpit varchar(20) = (select pulpit from deleted);

	declare @resultingString varchar(85) = @teacher + ' ' + @teacherName + ' ' + @gender + ' ' + @pulpit;

	insert TR_AUDIT (STMT, TRNAME, CC)
	values ('DEL', 'TR_TEACHER_DEL3', @resultingString);
	


end
go


exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE';



exec SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last', @stmttype = 'DELETE';

go

select t.name, e.type_desc, e.is_first, e.is_last 
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                         --   where --OBJECT_NAME(t.parent_id) = 'Товары' and 
	                       --                                                 e.type_desc = 'DELETE' ; 
																			


go

delete teacher where teacher = 'БЕВ'

go

select * from TR_AUDIT
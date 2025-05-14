use UNIVER;
go

create trigger TEACHER_INSTEAD_OF on TEACHER
instead of delete
as
begin
raiserror('Удаление запрещено', 11, 1);
end
go

delete TEACHER where TEACHER = 'БЕВ'

go 

drop trigger TR_TEACHER_INS
drop trigger TR_TEACHER_DEL
drop trigger TR_TEACHER_UPD

drop trigger TR_TEACHER
drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3
drop trigger TEACHER_INSTEAD_OF

go

-- 9

create trigger DDL_TRIGGER on database
for DDL_DATABASE_LEVEL_EVENTS
as
begin
	declare @table varchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(20)');
	declare @event varchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(20)');
	declare @object varchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(20)');

	print 'Объект: ' + @object
	print 'Название: ' + @table;
	print 'Событие: ' + @event;
	


	if(@event in ('CREATE_TABLE', 'DROP_TABLE', 'ALTER_TABLE'))
	begin
		raiserror('Выполнение запрещенной операции', 11, 1);
		print 'Операция ' + @event +' запрещена';
		rollback;
	end



end 

go


create table buildings(
	ID int identity,
	name varchar(20)
)
go



drop table TEACHER
go




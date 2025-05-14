use KOR_MyBase
go

create table TRAudit
(
	id int identity,
	STMT varchar(20) check (STMT in ('INS', 'DEL', 'UPD')), 
	TRNAME varchar(50),
	CC varchar(300)
)

go
create trigger TROrdersINS on Заказы
after insert
as
begin
	declare @product nvarchar(20)= (select Товар from inserted),
	@department nvarchar(20)= (select Отдел from inserted),
	@Sum int = (select ПотраченнаяСумма from inserted),
	@date date = (select Дата from inserted),
	@cheque nvarchar(10) = (select НомерЧека from inserted);

	declare @resultingString nvarchar(100) = @cheque + @department + @product + cast(@Sum as nvarchar(10)) + cast(@date as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('INS', 'TROrdersINS', @resultingString);
	


end

go


create trigger TROrdersDEL on Заказы
after delete
as
begin

	declare @product nvarchar(20)= (select Товар from deleted),
	@department nvarchar(20)= (select Отдел from deleted),
	@Sum int = (select ПотраченнаяСумма from deleted),
	@date date = (select Дата from deleted),
	@cheque nvarchar(10) = (select НомерЧека from deleted);

	declare @resultingString nvarchar(100) = @cheque + @department + @product + cast(@Sum as nvarchar(10)) + cast(@date as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('DEL', 'TROrdersDEL', @resultingString);
	


end

go


create trigger TROrdersUPD on Заказы
after update
as
begin


	declare @newProduct nvarchar(20)= (select Товар from inserted),
	@newDepartment nvarchar(20)= (select Отдел from inserted),
	@newSum int = (select ПотраченнаяСумма from inserted),
	@newDate date = (select Дата from inserted),
	@newCheque nvarchar(10) = (select НомерЧека from inserted);


	declare @oldProduct nvarchar(20)= (select Товар from deleted),
	@oldDepartment nvarchar(20)= (select Отдел from deleted),
	@oldSum int = (select ПотраченнаяСумма from deleted),
	@oldDate date = (select Дата from deleted),
	@oldCheque nvarchar(10) = (select НомерЧека from deleted);



	declare @resultingString nvarchar(200) = @oldCheque + @oldDepartment + @oldProduct + cast(@oldSum as nvarchar(10)) + cast(@oldDate as nvarchar(10))
											+ @newCheque + @newDepartment + @newProduct + cast(@newSum as nvarchar(10)) + cast(@newDate as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('UPD', 'TROrdersUPD', @resultingString);
	


end

go


create trigger TROrders on Заказы
after insert, update, delete
as
begin
	
	declare @ins int = (select count(*) from inserted),
	@del int = (select count(*) from deleted);

	declare @newProduct nvarchar(20),
	@newDepartment nvarchar(20),
	@newSum int,
	@newDate date,
	@newCheque nvarchar(10);

	declare @oldProduct nvarchar(20),
	@oldDepartment nvarchar(20),
	@oldSum int,
	@oldDate date,
	@oldCheque nvarchar(10);

	declare @resultingString nvarchar(200)



	if (@ins > 0 and @del = 0)
	begin

	select @newProduct = (select Товар from inserted),
	@newDepartment= (select Отдел from inserted),
	@newSum = (select ПотраченнаяСумма from inserted),
	@newDate  = (select Дата from inserted),
	@newCheque  = (select НомерЧека from inserted);

	set @resultingString = @newCheque + @newDepartment + @newProduct + cast(@newSum as nvarchar(10)) + cast(@newDate as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('UPD', 'TROrders', @resultingString);
		
	end 

	else
	if( @ins = 0 and @del > 0)
	begin
		
		
	select @oldProduct = (select Товар from deleted),
	@oldDepartment= (select Отдел from deleted),
	@oldSum = (select ПотраченнаяСумма from deleted),
	@oldDate  = (select Дата from deleted),
	@oldCheque  = (select НомерЧека from deleted);

	set @resultingString = @oldCheque + @oldDepartment + @oldProduct + cast(@oldSum as nvarchar(10)) + cast(@oldDate as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('DEL', 'TROrders', @resultingString);
		

	end

	else
	if( @ins > 0 and @del > 0)
	begin

	select @newProduct = (select Товар from inserted),
	@newDepartment= (select Отдел from inserted),
	@newSum = (select ПотраченнаяСумма from inserted),
	@newDate  = (select Дата from inserted),
	@newCheque  = (select НомерЧека from inserted);

	select @oldProduct = (select Товар from deleted),
	@oldDepartment= (select Отдел from deleted),
	@oldSum = (select ПотраченнаяСумма from deleted),
	@oldDate  = (select Дата from deleted),
	@oldCheque  = (select НомерЧека from deleted);


	set @resultingString = @oldCheque + @oldDepartment + @oldProduct + cast(@oldSum as nvarchar(10)) + cast(@oldDate as nvarchar(10))
											+ @newCheque + @newDepartment + @newProduct + cast(@newSum as nvarchar(10)) + cast(@newDate as nvarchar(10));
	
	insert TRAudit(STMT, TRNAME, CC)
	values ('UPD', 'TROrders', @resultingString);

	end

end 

go



alter trigger TRDDLKOR_MyBase on database
for DDL_DATABASE_LEVEL_EVENTS 
as
begin
	declare @table nvarchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'nvarchar(20)'),
	@event nvarchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'nvarchar(20)'),
	@object nvarchar(20) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'nvarchar(20)');


	print 'Объект: ' + @object;
	print 'Название: ' + @table;
	print 'Событие: ' + @event;


	if(@event in ('CREATE_TABLE', 'ALTER_TABLE', 'DROP_TABLE'))
	begin
		raiserror('Выполнение запрещенной операции', 11, 1);
		print 'Операция ' + @event +' запрещена';
		rollback;
	end


end

go


insert Заказы 
values ('jf8dh40xjw', 'Отдел разработки', 'Груша', 100, GETDATE());

go

update Заказы set Товар = 'Яблоко' where НомерЧека = 'jf8dh40xjw';

go
delete Заказы where НомерЧека = 'jf8dh40xjw';

go


create table Работники
(
	ID int identity,
  Имя nvarchar(10),
  Отдел nvarchar(20) foreign key references Отделы
)


go

select * from TRAudit
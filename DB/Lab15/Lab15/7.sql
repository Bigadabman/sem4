use UNIVER 
go

create trigger TEACHER_TRAN on TEACHER 
after insert, delete, update
as 
begin
declare @teachers int = (select count(*) from teacher where pulpit = 'ПИ')

end

if(@teachers  = 0)
begin
	raiserror('На факультете нет преподавателей', 11, 1) ;
	rollback
end 


go


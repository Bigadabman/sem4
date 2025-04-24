use UNIVER
go
-- A

set transaction isolation level serializable

begin tran
	select @@spid, * from Pulpit;

	waitfor delay '00:00:10'


	select @@spid, * from pulpit;
	

commit tran


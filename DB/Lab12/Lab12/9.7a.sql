use KOR_MyBase

go


set transaction isolation level serializable


begin tran 
	select * from Товары

	waitfor delay '00:00:10'

	select * from Товары


commit
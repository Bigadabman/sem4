use UNIVER;
set nocount on
go

create procedure PAUDITORIUM_INSERT
(
	@a char(20),
	@n varchar(50),
	@t char(10),
	@c int = 0
)
as 
begin
	begin try
		insert into AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
		values (@a, @n, @c, @t);

		return 1;
	end try
	
	begin catch
		
		print 'Номер ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print 'Ошибка: ' + error_message();

		return -1
	end catch

end
go

exec PAUDITORIUM_INSERT '200-3a', '200-3a', 'ЛК', 250;

exec PAUDITORIUM_INSERT '408-2', '408-2', 'ЛК'
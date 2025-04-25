USE UNIVER;

go



create procedure PAUDITORIUM_INSERTX
(
	@a char(20),
	@n varchar(50),
	@t char(10),
	@c int = 0,
	@tn varchar(50)

)
as 
begin
	
	begin try

	set transaction isolation level serializable
	
		begin tran 
		
			insert into AUDITORIUM_TYPE
			values ( @t, @tn);

			exec PAUDITORIUM_INSERT @a, @n, @t, @c

		commit 


		return 1;
	end try

	begin catch

		if @@TRANCOUNT > 0
			rollback

		print 'Код ошибки: ' + cast(error_number() as varchar(6));
		print 'Уровень: '  + cast(error_severity() as varchar(6));
		print 'Ошибка: ' + error_message();

		return -1;
	end catch


end 



go 


exec PAUDITORIUM_INSERTX '321-1', '321-1', 'ЛБ-К', 250, 'Лабораторная'

select * from AUDITORIUM
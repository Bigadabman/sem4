DECLARE @c char = 'E',
		@vc varchar(10) = 'Egor',
		@dt datetime,
		@t time,
		@i int,
		@si smallint,
		@ti tinyint,
		@n numeric(12, 5);

SET @dt = GETDATE();
SET @t = '14:30';

SELECT @i = 2147283647, @si = 32767, @ti = 255, @n = 1234567.1234;

print @c;
print @vc;
print @dt;
select @t t, @i i, @si si, @ti ti, @n n;

use UNIVER;

DECLARE @capacity int = (SELECT SUM(AUDITORIUM.AUDITORIUM_CAPACITY)
FROM AUDITORIUM),
		@avgCapacity float(2) = (select ROUND(AVG(CAST(AUDITORIUM.AUDITORIUM_CAPACITY AS FLOAT(4))), 2) from AUDITORIUM);

DECLARE @lessAvg int = (SELECT COUNT(*) FROM AUDITORIUM WHERE AUDITORIUM.AUDITORIUM_CAPACITY < @avgCapacity)

DECLARE @percent numeric(5, 2) = (select cast( @lessavg/cast(COUNT(AUDITORIUM.AUDITORIUM) as numeric(5,2)) as numeric(5,2)) * 100 from AUDITORIUM)


if @capacity >= 200
begin 
	SELECT COUNT(AUDITORIUM.AUDITORIUM) AS COUNT, @avgCapacity AS avgCapacity, @lessAvg AS lessAvg,
	cast(@percent as varchar(5)) + '%' as 'less/count'
	FROM AUDITORIUM
end

else 
print 'Capacity = ' + cast(@capacity as varchar(10));
use UNIVER
go

create function FFACPUL(@f varchar(20), @p varchar(20))
returns table	
as return 
	select Faculty.FACULTY, PULPIT.PULPIT 
	from FACULTY left outer join  PULPIT on FACULTY.FACULTY = PULPIT.FACULTY
	where FACULTY.FACULTY = isnull(@f, FACULTY.FACULTY)
	and PULPIT.PULPIT = isnull(@p, PULPIT.PULPIT);


go

select * from  FFACPUL(null, null);

select * from  FFACPUL('ÈÄèÏ', null);

select * from  FFACPUL(null, 'ËÌèËÇ');
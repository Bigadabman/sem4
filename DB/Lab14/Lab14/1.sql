use UNIVER;
go


alter function COUNT_STUDENTS(@faculty varchar(20)) returns int
as
begin

	declare @amount int = (select count(*) from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
														inner join FACULTY on GROUPS.FACULTY = FACULTY.FACULTY
											where FACULTY.FACULTY = @faculty); 

	return @amount;
end
go
select dbo.COUNT_STUDENTS('ÒÎÂ') as amount


go

alter function dbo.COUNT_STUDENTS (@faculty varchar(20) = null, @prof varchar(20) = null)
returns int
as 
begin
	declare @amount int = (select count(*) from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP
														inner join FACULTY on GROUPS.FACULTY = FACULTY.FACULTY
											where FACULTY.FACULTY = @faculty 
											and GROUPS.PROFESSION = isnull(@prof, GROUPS.PROFESSION)); 

	return @amount;

end

go

select dbo.COUNT_STUDENTS('ÒÎÂ', null) as amount


use UNIVER;
go

alter proc PSUBJECT
(
	@p varchar(20)
)
as 
begin
	
	select * from SUBJECT
	where subject.PULPIT = @p;

	
end
go 

create table #SUBJECT 
(
	subject varchar(10),
	subject_name varchar(50),
	pulpit varchar(10)
)

go
insert #SUBJECT exec PSUBJECT 'ศั่า'

select * from #SUBJECT
go

drop table #subject


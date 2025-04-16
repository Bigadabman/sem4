
create table tableA(
	ID int,
	IDValue nvarchar(20)
);
insert into tableA(ID, IDValue)
values (1, 'A'), (2, 'B'), (3, 'C');

create table tableB(
	ID int,
	IDValue nvarchar(20)
);
insert into tableB(ID, IDValue)
values (2, 'X'), (3, 'Y'), (4, 'Z');


select * from tableA full outer join tableB 
on tableA.ID = tableB.ID 
where tableB.ID is null 


select * from tableA full outer join tableB
on tableA.ID = tableB.ID
where tableA.ID is null


select * from tableA full outer join tableB
on tableA.ID = tableB.ID
where tableA.ID is not null
and tableB.ID is not null


drop table tableA
drop table tableB
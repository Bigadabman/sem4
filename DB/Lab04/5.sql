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

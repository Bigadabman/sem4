use KOR_MyBase
--1
select ������.�����, sum(������.����������������), ������.����
from ������
group by 
rollup (������.�����, ������.����)

--2
select ������.�����, sum(������.����������������), ������.����
from ������
group by 
cube (������.�����, ������.����)

--3
select * from ������
where ������.����� like '%�����������%'

union all

select * from ������
where ������.����� in ('����� �����������', '����� ������')

--4
select * from ������
where ������.����� like '%�����������%'

intersect

select * from ������
where ������.����� in ('����� �����������', '����� ������')


--5
select * from ������
where ������.����� in ('����� �����������', '����� ������')

except

select * from ������
where ������.����� like '%�����������%'


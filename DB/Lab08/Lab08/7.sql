create view [�����_�����] as
select ������.�����, ������.����������������, ������.����
from ������
where ������.����� = '�����'
go
select * from [�����_�����]
drop view [�����_�����]
go


create view [������] as
select ������.�����, ������.����, ������.�����, ������.��������
from ������ inner join ������ on ������.����� = ������.��������������
where ������.���������������� > 1000
go
select * from ������
drop view ������

go
create view ��������������������� as
select ������.��������������, ������.���������������������
from ������
go

select * from ���������������������

insert ���������������������
values ('����� ������', 20, 1000)

drop view ���������������������

go

create view �������� as
select TOP(50) ������.�����, ������.�����, ������.����������������, ������.����
from ������
where ������.���������������� > 1500
order by ������.����������������

go

select * from ��������
drop view ��������
go

create view ������� with schemaBinding as
select ������.�����, count(*) as ����������
from dbo.������
group by ������.�����

go
select * from �������

drop view �������


create table ������ (
�������������� nvarchar(20) primary key,
�������� nvarchar(50) not null
) on FG1

create table ������ (
�������������� nvarchar(20) primary key,
��������������������� int not null check (��������������������� > 0),
���������������������� int not null check (���������������������� > 0)

) on FG1


create table ������ (
��������� nvarchar(10) primary key,
����� nvarchar(20) foreign key references ������(��������������),
����� nvarchar(20) foreign key references ������(��������������),
���������������� int not null,
���� date not null check (���� <= GETDATE())

) on FG1
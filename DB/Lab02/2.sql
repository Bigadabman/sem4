

create table Товары (
НазваниеТовара nvarchar(20) primary key,
Описание nvarchar(50) not null
) on FG1

create table Отделы (
НазваниеОтдела nvarchar(20) primary key,
КоличествоСотрудников int not null check (КоличествоСотрудников > 0),
ПредельнаяНормаРасхода int not null check (ПредельнаяНормаРасхода > 0)

) on FG1


create table Заказы (
НомерЧека nvarchar(10) primary key,
Отдел nvarchar(20) foreign key references Отделы(НазваниеОтдела),
Товар nvarchar(20) foreign key references Товары(НазваниеТовара),
ПотраченнаяСумма int not null,
Дата date not null check (Дата <= GETDATE())

) on FG1
create view [Заказ_ручек] as
select Заказы.Отдел, Заказы.ПотраченнаяСумма, Заказы.Дата
from Заказы
where Заказы.Товар = 'Ручка'
go
select * from [Заказ_ручек]
drop view [Заказ_ручек]
go


create view [Закази] as
select Заказы.Отдел, Заказы.Дата, Заказы.Товар, Товары.Описание
from Заказы inner join Товары on Заказы.Товар = Товары.НазваниеТовара
where Заказы.ПотраченнаяСумма > 1000
go
select * from Закази
drop view Закази

go
create view КоличествоСотрудников as
select Отделы.НазваниеОтдела, Отделы.КоличествоСотрудников
from Отделы
go

select * from КоличествоСотрудников

insert КоличествоСотрудников
values ('Отдел уборки', 20, 1000)

drop view КоличествоСотрудников

go

create view Заказища as
select TOP(50) Заказы.Отдел, Заказы.Товар, Заказы.ПотраченнаяСумма, Заказы.Дата
from Заказы
where ЗАказы.ПотраченнаяСумма > 1500
order by Заказы.ПотраченнаяСумма

go

select * from Заказища
drop view Заказища
go

create view Покупки with schemaBinding as
select Заказы.Товар, count(*) as Количество
from dbo.Заказы
group by Заказы.Товар

go
select * from Покупки

drop view Покупки
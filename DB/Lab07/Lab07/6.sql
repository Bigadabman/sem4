use KOR_MyBase
--1
select Заказы.Отдел, sum(Заказы.ПотраченнаяСумма), Заказы.Дата
from Заказы
group by 
rollup (Заказы.Отдел, Заказы.Дата)

--2
select Заказы.Отдел, sum(Заказы.ПотраченнаяСумма), Заказы.Дата
from Заказы
group by 
cube (Заказы.Отдел, Заказы.Дата)

--3
select * from Заказы
where Заказы.Отдел like '%электроники%'

union all

select * from Заказы
where Заказы.Отдел in ('отдел электроники', 'отдел продаж')

--4
select * from Заказы
where Заказы.Отдел like '%электроники%'

intersect

select * from Заказы
where Заказы.Отдел in ('отдел электроники', 'отдел продаж')


--5
select * from Заказы
where Заказы.Отдел in ('отдел электроники', 'отдел продаж')

except

select * from Заказы
where Заказы.Отдел like '%электроники%'


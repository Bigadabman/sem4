--create view Аудитории as
select AUDITORIUM.AUDITORIUM, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM.AUDITORIUM_TYPE
from auditorium
WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE 'ЛК%'
 
INSERT Аудитории values ('200-3a', '200-3a', 'ЛК-К' )

select * from Аудитории

delete Аудитории where Аудитории.Auditorium = '200-3a'

select * from Аудитории
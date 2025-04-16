alter table Товары add Цена int not null check(Цена > 0)

--alter table Товары drop constraint 
--alter table Товары drop column Цена
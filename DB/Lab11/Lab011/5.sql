use KOR_MyBase

declare cursorMyBase cursor scroll dynamic for
select * from Товары for update


open cursorMyBase


declare @name varchar(10),
		@description varchar(30);


		insert into Товары 
		values ('Стол', 'Чтобы ставить что-то')


fetch last from cursorMyBase into @name, @description;
fetch relative -1 from cursorMyBase into @name, @description;
print @name + @description


update Товары set Описание = 'на четырех ножках' where current of cursorMyBase


delete Товары where current of cursorMyBase


close cursorMyBase

deallocate cursorMyBase
use KOR_MyBase

go


begin tran 


			update Товары set Товары.Описание = 'Просто новый' where Товары.НазваниеТовара = 'Монитор';

			
			insert into Товары 
			values ('Вилка', 'Как ложка, но острая');


	commit


	waitfor delay '00:00:10'

	go
	update Товары set Товары.Описание = 'Новый вместо старого' where Товары.НазваниеТовара = 'Монитор';
	delete Товары where Товары.НазваниеТовара = 'Вилка'

Use KOR_MyBase


declare @amount int = (SELECT COUNT(*) FROM Заказы);

IF @amount >= 20
begin
	print 'Total amount is ' + Cast(@amount as varchar(5));
	Select * from Заказы;
end
else
begin 
	print 'Not enough orders';
	select * from Заказы;
end
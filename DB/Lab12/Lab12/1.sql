


create table #bankAccaunts 
(
	userName varchar(10) not null,
	Balance int check(Balance >= 0) not null
)

insert into #bankAccaunts
values ('Лёша', 1000);

go
set implicit_transactions on

begin try

	update #bankAccaunts set Balance = Balance - 2000;


	commit
end try


begin catch
	rollback
end catch

set implicit_transactions off


select * from #bankAccaunts
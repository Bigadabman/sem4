use KOR_MyBase

declare cursorMyBase cursor scroll dynamic for
select * from ������ for update


open cursorMyBase


declare @name varchar(10),
		@description varchar(30);


		insert into ������ 
		values ('����', '����� ������� ���-��')


fetch last from cursorMyBase into @name, @description;
fetch relative -1 from cursorMyBase into @name, @description;
print @name + @description


update ������ set �������� = '�� ������� ������' where current of cursorMyBase


delete ������ where current of cursorMyBase


close cursorMyBase

deallocate cursorMyBase
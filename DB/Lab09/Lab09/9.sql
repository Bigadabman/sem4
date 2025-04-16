begin try 
declare @x int = 1/0;
end try
begin catch
print ERROR_NUMBER();
print ERROR_MESSAGE();
print ERROR_LINE();
print ERROR_PROCEDURE();
print ERROR_SEVERITY();
print ERROR_STATE();


end catch
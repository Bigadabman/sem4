use master;

drop database UNIVER;

create database UNIVER 
on primary (
name = N'UNIVER_mdf',
filename = N'D:\bstu\sem 4\DB\Lab04\UNIVER.mdf',
size = 10240Kb,
maxsize = unlimited,
filegrowth = 25%
)
LOG ON
(
name = N'UNIVER_log',
filename = N'D:\bstu\sem 4\DB\Lab04\UNIVER.ldf',
size = 10240Kb,
maxsize = 2Gb,
filegrowth = 25%
)
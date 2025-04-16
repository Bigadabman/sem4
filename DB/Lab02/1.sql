--create database KOR_MyBase
--use master;
--drop database KOR_MyBase;
create database KOR_MyBase
on primary (
Name = N'KOR_MyBase1_mdf',
filename = N'D:\bstu\sem 4\DB\Lab02\KOR_MyBase1.mdf',
size = 10240Kb,
maxsize = unlimited,
filegrowth = 1024Kb
),
(
name = N'KOR_MyBase2_ndf',
filename = N'D:\bstu\sem 4\DB\Lab02\KOR_MyBase2.ndf',
size = 10240Kb,
maxsize = 1Gb,
filegrowth = 25%
),

filegroup FG1(
name = N'KOR_MyBase1_1_ndf',
filename = N'D:\bstu\sem 4\DB\Lab02\KOR_MyBase3.ndf',
size = 10240Kb,
maxsize = 1GB,
filegrowth = 25%
),
(
name = N'KOR_MyBase1_2_ndf',
filename = N'D:\bstu\sem 4\DB\Lab02\KOR_MyBase4.ndf',
size = 10240Kb,
maxsize = 1GB,
filegrowth = 25%
)


LOG ON (
name = N'KOR_MyBase_log',
filename = N'D:\bstu\sem 4\DB\Lab02\KOR_MyBase_log.ldf',
size = 10240Kb,
maxsize = 2048Gb,
filegrowth = 10%

)
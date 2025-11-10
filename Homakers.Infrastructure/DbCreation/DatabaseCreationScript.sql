-- ******** Database Creation ***********
CREATE DATABASE HomakersDb
    ON PRIMARY
    (
        NAME = HomakersDb,
        FILENAME = 'C:\SourceCode\Data\HomakersDb_Data.mdf',
         SIZE = 500MB,
        MAXSIZE = UNLIMITED,
        FILEGROWTH = 1MB
    )
    LOG ON
    (
        NAME = HomakersDb_Log,
        FILENAME = 'C:\SourceCode\Log\HomakersDb_Log.ldf',
        SIZE = 500MB,
        MAXSIZE = 2000MB,
        FILEGROWTH = 1MB
    );


    USE [master] 
GO
CREATE LOGIN admin WITH PASSWORD=N'admin'
CREATE USER admin FOR LOGIN admin
ALTER ROLE db_owner ADD MEMBER admin
GO


USE HomakersDb
GO
CREATE USER admin FOR LOGIN admin
GO
USE HomakersDb
GO
EXEC sp_addrolemember N'db_owner', N'admin'
GO

GO
CREATE LOGIN pixtrackeruser WITH PASSWORD = N'!4321abcd', CHECK_POLICY = off
GO

GO
CREATE USER [pixtrackeruser] FOR LOGIN [pixtrackeruser]
GO


GO
EXEC sp_addrolemember N'db_owner', N'pixtrackeruser'
GO
GO
if (select count(*) from sysusers where name='pixtrackeruser') > 0 
begin
drop user [pixtrackeruser]
end
GO


use [Master]
if (select count(*) from syslogins where name='pixtrackeruser') > 0 
begin
drop login [pixtrackeruser]
end
GO
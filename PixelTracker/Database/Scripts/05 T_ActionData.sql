IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ActionData]') AND type in (N'U'))
DROP TABLE [dbo].[T_ActionData]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_ActionData](
	[PK_ID] [int] PRIMARY KEY CLUSTERED IDENTITY (1,1),
	[FK_ActionID] [int] REFERENCES [dbo].[T_ActionAssertion]([PK_ID]) ON DELETE CASCADE,
	[ActionOrder] [int], 
	[LagTime] decimal(18,10), 	
	[X] [int], 
	[Y] [int], 	
	[IsMouseAction] bit,
	[IsCapsLockON] [bit], 
	[KeyValue] char
) ON [PRIMARY]
GO


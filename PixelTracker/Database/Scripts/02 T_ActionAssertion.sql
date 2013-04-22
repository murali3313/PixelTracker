IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ActionAssertion]') AND type in (N'U'))
DROP TABLE [dbo].[T_ActionAssertion]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_ActionAssertion](
	[PK_ID] [int] PRIMARY KEY CLUSTERED IDENTITY (1,1),
	[FK_ScenarioID] [int] REFERENCES [dbo].[T_Scenario]([PK_ID]) ON DELETE CASCADE,
	[TestType] [int], 
	[ActionOrder] int NOT NULL
) ON [PRIMARY]
GO


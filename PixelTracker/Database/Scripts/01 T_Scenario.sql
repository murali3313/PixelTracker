IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Scenario]') AND type in (N'U'))
DROP TABLE [dbo].[T_Scenario]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_Scenario](
	[PK_ID] [int] IDENTITY (1,1) PRIMARY KEY CLUSTERED,
	[Description] [nvarchar] (MAX) NULL,
	[IgnoreScenario] [bit] 
) ON [PRIMARY]
GO


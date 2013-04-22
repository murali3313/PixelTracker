IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_AssertionData]') AND type in (N'U'))
DROP TABLE [dbo].[T_AssertionData]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_AssertionData](
	[PK_ID] [int] PRIMARY KEY CLUSTERED IDENTITY (1,1),
	[FK_AssertionID] [int] REFERENCES [dbo].[T_ActionAssertion]([PK_ID]) ON DELETE CASCADE,
	[AssertionOrder] [int], 
	[X] [int], 
	[Y] [int], 
	[Height] [int], 
	[Width] [int], 
	[ExpectedImage] Image,
	[FailureReason] nvarchar(1000)
) ON [PRIMARY]
GO


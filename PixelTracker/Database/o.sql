-- Script generated at 2013-04-22T18:41:49



--------------- Fragment begins: #1: 01 T_Scenario.sql ---------------
INSERT INTO changelog (change_number, delta_set, start_dt, applied_by, description) VALUES (1, 'Main', getdate(), user_name(), '01 T_Scenario.sql')
GO

-- Change script: #1: 01 T_Scenario.sql
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


UPDATE changelog SET complete_dt = getdate() WHERE change_number = 1 AND delta_set = 'Main'
GO
--------------- Fragment ends: #1: 01 T_Scenario.sql ---------------


--------------- Fragment begins: #2: 02 T_ActionAssertion.sql ---------------
INSERT INTO changelog (change_number, delta_set, start_dt, applied_by, description) VALUES (2, 'Main', getdate(), user_name(), '02 T_ActionAssertion.sql')
GO

-- Change script: #2: 02 T_ActionAssertion.sql
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


UPDATE changelog SET complete_dt = getdate() WHERE change_number = 2 AND delta_set = 'Main'
GO
--------------- Fragment ends: #2: 02 T_ActionAssertion.sql ---------------


--------------- Fragment begins: #3: 03 T_AssertionData.sql ---------------
INSERT INTO changelog (change_number, delta_set, start_dt, applied_by, description) VALUES (3, 'Main', getdate(), user_name(), '03 T_AssertionData.sql')
GO

-- Change script: #3: 03 T_AssertionData.sql
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


UPDATE changelog SET complete_dt = getdate() WHERE change_number = 3 AND delta_set = 'Main'
GO
--------------- Fragment ends: #3: 03 T_AssertionData.sql ---------------


--------------- Fragment begins: #4: 04 sp_SaveAssertionImage.sql ---------------
INSERT INTO changelog (change_number, delta_set, start_dt, applied_by, description) VALUES (4, 'Main', getdate(), user_name(), '04 sp_SaveAssertionImage.sql')
GO

-- Change script: #4: 04 sp_SaveAssertionImage.sql
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_AssertionSaveImage]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[sp_AssertionSaveImage]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE sp_AssertionSaveImage
	@fkAssertionID int,
	@assertionOrder int,
	@x int,
	@y int,
	@height int,
	@width int,
	@failureReason nvarchar(1000) = null,
	@expectedImage image
AS
BEGIN

INSERT INTO dbo.T_AssertionData (FK_AssertionID,AssertionOrder,ExpectedImage,X,Y,Height,Width,FailureReason) 
Values(@fkAssertionID,@assertionOrder,@expectedImage,@x,@y,@height,@width,@failureReason)

END
GO



UPDATE changelog SET complete_dt = getdate() WHERE change_number = 4 AND delta_set = 'Main'
GO
--------------- Fragment ends: #4: 04 sp_SaveAssertionImage.sql ---------------


--------------- Fragment begins: #5: 05 T_ActionData.sql ---------------
INSERT INTO changelog (change_number, delta_set, start_dt, applied_by, description) VALUES (5, 'Main', getdate(), user_name(), '05 T_ActionData.sql')
GO

-- Change script: #5: 05 T_ActionData.sql
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


UPDATE changelog SET complete_dt = getdate() WHERE change_number = 5 AND delta_set = 'Main'
GO
--------------- Fragment ends: #5: 05 T_ActionData.sql ---------------


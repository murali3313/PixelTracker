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



 /****** Object:  Table [dbo].[ChangeLog]    Script Date: 08/27/2008 09:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_TYPE='BASE TABLE' 
    AND TABLE_NAME='ChangeLog') 
BEGIN
CREATE TABLE [dbo].[ChangeLog](
	[change_number] [int] NOT NULL,
	[delta_set] [varchar](10) COLLATE Latin1_General_CI_AS NOT NULL,
	[start_dt] [datetime] NOT NULL,
	[complete_dt] [datetime] NULL,
	[applied_by] [varchar](100) COLLATE Latin1_General_CI_AS NOT NULL,
	[description] [varchar](500) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [Pkchangelog] PRIMARY KEY CLUSTERED 
(
	[change_number] ASC,
	[delta_set] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

END
GO
SET ANSI_PADDING OFF
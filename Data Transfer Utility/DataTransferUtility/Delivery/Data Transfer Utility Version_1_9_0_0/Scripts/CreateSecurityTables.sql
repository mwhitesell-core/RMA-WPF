/****** Object:  Table [dbo].[Renaissance_Designer_Security]    Script Date: 5/25/2017 11:55:55 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renaissance_Designer_Security]') AND type in (N'U'))
BEGIN
DROP TABLE [dbo].[Renaissance_Designer_Security]
END
CREATE TABLE [dbo].[Renaissance_Designer_Security](
	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()),
	[Role] [char](50) NOT NULL,
	[Screen] [char](50) NOT NULL,
	[Desiner_Name] [char](50) NULL,
	[Enable] [numeric](1, 0) NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[Renaissance_Designer_Security] ADD  DEFAULT ((1)) FOR [Enable]

SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Renaissance_Menu_Security]    Script Date: 5/25/2017 11:55:55 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renaissance_Menu_Security]') AND type in (N'U'))
BEGIN
DROP TABLE [dbo].[Renaissance_Menu_Security]
END
CREATE TABLE [dbo].[Renaissance_Menu_Security](
	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()),
	[Role] [char](50) NOT NULL,
	[Tag] [char](50) NOT NULL,
	[Visible] [numeric](1, 0) NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[Renaissance_Menu_Security] ADD  DEFAULT (1) FOR [Visible]

SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Renaissance_Roles]    Script Date: 5/25/2017 11:55:55 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renaissance_Roles]') AND type in (N'U'))
BEGIN
DROP TABLE [dbo].[Renaissance_Roles]
END
CREATE TABLE [dbo].[Renaissance_Roles](
	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()),
	[Role_Name] [varchar](32) NOT NULL,
	[Role_Priority] [int] NOT NULL
 CONSTRAINT [PK_UserRole] PRIMARY KEY NONCLUSTERED 
(
	[Role_Name] ASC,
	[Role_Priority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Renaissance_Roles] ADD  DEFAULT (0) FOR [Role_Priority]

SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Renaissance_Screen_Security]    Script Date: 5/25/2017 11:55:55 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renaissance_Screen_Security]') AND type in (N'U'))
BEGIN
DROP TABLE [dbo].[Renaissance_Screen_Security]
END
CREATE TABLE [dbo].[Renaissance_Screen_Security ](
	[ROWID] [uniqueidentifier] NULL DEFAULT (newid()),
	[Screen] [char](50) NOT NULL,
	[Role] [char](32) NULL,
	[Screen_Entry] [numeric](1, 0) NULL DEFAULT(1),
	[Screen_Find] [numeric](1, 0) NULL DEFAULT(1),
	[Screen_Change] [numeric](1, 0) NULL DEFAULT(1),
	[Screen_Delete] [numeric](1, 0) NULL DEFAULT(1)
) ON [PRIMARY]

SET ANSI_PADDING OFF

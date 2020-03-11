
USE [contadores]
GO

/****** Object:  Table [dbo].[gateway]    Script Date: 11/03/2020 22:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[gateway](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serialNumber] [varchar](50) NOT NULL,
	[brand] [varchar](50) NULL,
	[model] [varchar](50) NULL,
	[ip] [varchar](50) NOT NULL,
	[port] [varchar](50) NULL,
 CONSTRAINT [PK_GateWay] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[serialNumber] ASC,
	[ip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[meter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serialNumber] [varchar](50) NOT NULL,
	[brand] [varchar](50) NULL,
	[model] [varchar](50) NULL,
 CONSTRAINT [PK_meter] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[serialNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
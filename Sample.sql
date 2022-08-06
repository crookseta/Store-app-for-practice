CREATE DATABASE StoreDB

USE [StoreDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bill](
	[idbill] [int] NOT NULL,
	[bill_number] [varchar](10) NOT NULL,
	[date] [date] NULL,
	[idclient] [int] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[idbill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill1] FOREIGN KEY([idclient])
REFERENCES [dbo].[Client] ([idclient])
GO

ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill1]
GO


/****** ************************************************************************************************************************************************** ******/
USE [StoreDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bill_Detail](
	[idbill] [int] NOT NULL,
	[idproduct] [int] NOT NULL,
	[quantity] [int] NULL,
	[idbill_detail] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[idbill_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bill_Detail]  WITH CHECK ADD  CONSTRAINT [FC_BillDetail_Bill] FOREIGN KEY([idbill])
REFERENCES [dbo].[Bill] ([idbill])
GO

ALTER TABLE [dbo].[Bill_Detail] CHECK CONSTRAINT [FC_BillDetail_Bill]
GO

ALTER TABLE [dbo].[Bill_Detail]  WITH CHECK ADD  CONSTRAINT [FC_BillDetail_Product] FOREIGN KEY([idproduct])
REFERENCES [dbo].[Product] ([idproduct])
GO

ALTER TABLE [dbo].[Bill_Detail] CHECK CONSTRAINT [FC_BillDetail_Product]
GO


/****** ************************************************************************************************************************************************** ******/
USE [StoreDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[idcategory] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[idcategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** ************************************************************************************************************************************************** ******/
USE [StoreDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[idclient] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[address] [varchar](50) NULL,
	[id_number] [char](11) NULL,
	[phone_number] [char](10) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idclient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** ************************************************************************************************************************************************** ******/
USE [StoreDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[idproduct] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NULL,
	[price] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[idproduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


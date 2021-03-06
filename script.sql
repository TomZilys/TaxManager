USE [C:\DB\TAXMANAGERDB.MDF]
GO
/****** Object:  Table [dbo].[TaxType]    Script Date: 02/06/2017 08:25:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaxType] ON
INSERT [dbo].[TaxType] ([Id], [Value]) VALUES (1, N'Daily')
INSERT [dbo].[TaxType] ([Id], [Value]) VALUES (2, N'Weekly')
INSERT [dbo].[TaxType] ([Id], [Value]) VALUES (3, N'Monthly')
INSERT [dbo].[TaxType] ([Id], [Value]) VALUES (4, N'Yearly')
SET IDENTITY_INSERT [dbo].[TaxType] OFF
/****** Object:  Table [dbo].[MunicipalityTax]    Script Date: 02/06/2017 08:25:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MunicipalityTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MunicipalityId] [int] NOT NULL,
	[TaxTypeId] [int] NOT NULL,
	[TaxValue] [decimal](5, 2) NOT NULL,
	[PeriodStartDate] [datetime] NOT NULL,
	[PeriodEndDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MunicipalityTax] ON
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (1, 1, 1, CAST(0.10 AS Decimal(5, 2)), CAST(0x0000A58000000000 AS DateTime), CAST(0x0000A580018B80D4 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (2, 1, 1, CAST(0.10 AS Decimal(5, 2)), CAST(0x0000A6E700000000 AS DateTime), CAST(0x0000A6E7018B80D4 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (3, 1, 3, CAST(0.40 AS Decimal(5, 2)), CAST(0x0000A5F900000000 AS DateTime), CAST(0x0000A617018B80D4 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (4, 1, 4, CAST(0.20 AS Decimal(5, 2)), CAST(0x0000A58000000000 AS DateTime), CAST(0x0000A6ED018B80D4 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (39, 3, 1, CAST(0.08 AS Decimal(5, 2)), CAST(0x0000A71100000000 AS DateTime), CAST(0x0000A71100000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (40, 3, 1, CAST(0.07 AS Decimal(5, 2)), CAST(0x0000A71100000000 AS DateTime), CAST(0x0000A71100000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (41, 2, 1, CAST(0.50 AS Decimal(5, 2)), CAST(0x0000A71C00000000 AS DateTime), CAST(0x0000A71C00000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (42, 2, 4, CAST(0.20 AS Decimal(5, 2)), CAST(0x0000A6EE00000000 AS DateTime), CAST(0x0000A85A00000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (43, 2, 1, CAST(0.50 AS Decimal(5, 2)), CAST(0x0000A71C00000000 AS DateTime), CAST(0x0000A71C00000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (44, 2, 4, CAST(0.20 AS Decimal(5, 2)), CAST(0x0000A6EE00000000 AS DateTime), CAST(0x0000A85A00000000 AS DateTime))
INSERT [dbo].[MunicipalityTax] ([Id], [MunicipalityId], [TaxTypeId], [TaxValue], [PeriodStartDate], [PeriodEndDate]) VALUES (45, 3, 1, CAST(0.08 AS Decimal(5, 2)), CAST(0x0000A71200000000 AS DateTime), CAST(0x0000A71200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[MunicipalityTax] OFF
/****** Object:  Table [dbo].[Municipality]    Script Date: 02/06/2017 08:25:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MunicipalityName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Municipality] ON
INSERT [dbo].[Municipality] ([Id], [MunicipalityName]) VALUES (1, N'Vilnius')
INSERT [dbo].[Municipality] ([Id], [MunicipalityName]) VALUES (2, N'Kaunas')
INSERT [dbo].[Municipality] ([Id], [MunicipalityName]) VALUES (3, N'TestingMunicipality')
SET IDENTITY_INSERT [dbo].[Municipality] OFF

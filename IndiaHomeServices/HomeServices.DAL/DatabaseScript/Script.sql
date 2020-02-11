CREATE DATABASE [HomeServices]
GO

USE [HomeServices]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Services](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](200) NOT NULL,
	[CategoryLkpId] [int] NOT NULL,
	[CategoryLkpName] [varchar](100) NOT NULL,
	[ServiceType] [varchar](500) NULL,
	[Timing] [varchar](100) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CommonLookup](
[CommonLkpId] [int] IDENTITY(1,1) NOT NULL,
[CommonLkpType] [varchar](50) NOT NULL,
[CommonLkpName] [varchar](2000) NOT NULL,
[CreatedBy] [varchar](50) NOT NULL,
[CreatedDate] [datetime] NOT NULL,
[ModifiedBy] [varchar](50) NOT NULL,
[ModifiedDate] [datetime] NOT NULL,
[SortOrder] [int] NULL,
 CONSTRAINT [CommonLookup_PK] PRIMARY KEY CLUSTERED
(
[CommonLkpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert Into [Services] ([ServiceName],[CategoryLkpId],[CategoryLkpName], 
[ServiceType],[Timing], [CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate]) Values ('Senthil','1','Repairs','Laptop','12','SYS-Created',GetDate(),'SYS-Created',GetDate())


DECLARE @LookUpType		VARCHAR(50) = '',
		@CreatedBy		VARCHAR(20),
		@CreatedDate	DATETIME;
set nocount on
SELECT 	@CreatedBy='SYS',@CreatedDate=GETDATE();
SET @LookUpType = 'ServiceCategory'
BEGIN
	INSERT INTO CommonLookup (CommonLkpType,CommonLkpName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) 	
	VALUES (@LookUpType, 'Cleaning', @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate)
	INSERT INTO CommonLookup (CommonLkpType,CommonLkpName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) 	
	VALUES (@LookUpType, 'Repairs', @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate)
	INSERT INTO CommonLookup (CommonLkpType,CommonLkpName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) 	
	VALUES (@LookUpType, 'Salon', @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate)
	INSERT INTO CommonLookup (CommonLkpType,CommonLkpName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate) 	
	VALUES (@LookUpType, 'Pest Control', @CreatedBy, @CreatedDate, @CreatedBy, @CreatedDate)
END

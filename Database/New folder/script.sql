USE [master]
GO
/****** Object:  Database [ECommerce_Db]    Script Date: 03/03/2024 11:39:34 PM ******/
CREATE DATABASE [ECommerce_Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECommerce_Db', FILENAME = N'E:\Main\CSharp\Asp.Net Core\Asp.Net Core Projects\MyProjects\ECommerceSite\Database\ECommerce_Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ECommerce_Db_log', FILENAME = N'E:\Main\CSharp\Asp.Net Core\Asp.Net Core Projects\MyProjects\ECommerceSite\Database\ECommerce_Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ECommerce_Db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECommerce_Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECommerce_Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECommerce_Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECommerce_Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECommerce_Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECommerce_Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECommerce_Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ECommerce_Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECommerce_Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECommerce_Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECommerce_Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECommerce_Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECommerce_Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECommerce_Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECommerce_Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECommerce_Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ECommerce_Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECommerce_Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECommerce_Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECommerce_Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECommerce_Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECommerce_Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECommerce_Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECommerce_Db] SET RECOVERY FULL 
GO
ALTER DATABASE [ECommerce_Db] SET  MULTI_USER 
GO
ALTER DATABASE [ECommerce_Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECommerce_Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECommerce_Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECommerce_Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ECommerce_Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ECommerce_Db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ECommerce_Db', N'ON'
GO
ALTER DATABASE [ECommerce_Db] SET QUERY_STORE = ON
GO
ALTER DATABASE [ECommerce_Db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ECommerce_Db]
GO
/****** Object:  Table [dbo].[TB_BRAND]    Script Date: 03/03/2024 11:39:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_BRAND](
	[TB_NAME] [varchar](50) NULL,
	[TB_IMG] [varchar](500) NULL,
	[TB_DESC] [varchar](50) NULL,
	[TB_STATUS] [varchar](50) NULL,
	[TB_ORDER] [float] NULL,
	[TB_CREATE] [datetime] NULL,
	[TB_MODIFY] [datetime] NULL,
	[TB_CREATE_USER] [varchar](50) NULL,
	[TB_MODIFY_USER] [varchar](50) NULL,
	[TB_ID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TB_ID] PRIMARY KEY CLUSTERED 
(
	[TB_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CATEGORY]    Script Date: 03/03/2024 11:39:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CATEGORY](
	[TB_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TB_NAME] [varchar](50) NULL,
	[TB_IMG] [varchar](500) NULL,
	[TB_DESC] [varchar](500) NULL,
	[TB_STATUS] [varchar](50) NULL,
	[TB_ORDER] [varchar](50) NULL,
	[TB_CREATE] [datetime] NULL,
	[TB_MODIFY] [datetime] NULL,
	[TB_CREATE_USER] [varchar](50) NULL,
	[TB_MODIFY_USER] [varchar](50) NULL,
	[TB_PARENTID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TB_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_BRAND] ON 

INSERT [dbo].[TB_BRAND] ([TB_NAME], [TB_IMG], [TB_DESC], [TB_STATUS], [TB_ORDER], [TB_CREATE], [TB_MODIFY], [TB_CREATE_USER], [TB_MODIFY_USER], [TB_ID]) VALUES (N'Iphone', N'\admin\images\brands\37eb4cb7-403d-4548-883a-d3852d6a0354.png', N'<p>abcd</p>', N'0', 1, CAST(N'2024-02-14T17:42:32.900' AS DateTime), CAST(N'2024-02-14T17:42:32.900' AS DateTime), N'1', N'1', 1)
INSERT [dbo].[TB_BRAND] ([TB_NAME], [TB_IMG], [TB_DESC], [TB_STATUS], [TB_ORDER], [TB_CREATE], [TB_MODIFY], [TB_CREATE_USER], [TB_MODIFY_USER], [TB_ID]) VALUES (N'HP', N'\admin\images\brands\3eb631cc-7cd7-4959-bf54-1ea22f08d3dc.jpg', N'<p>abc</p>', N'0', 1, CAST(N'2024-02-14T14:52:52.237' AS DateTime), CAST(N'2024-02-14T14:52:52.237' AS DateTime), N'1', N'1', 2)
SET IDENTITY_INSERT [dbo].[TB_BRAND] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_CATEGORY] ON 

INSERT [dbo].[TB_CATEGORY] ([TB_ID], [TB_NAME], [TB_IMG], [TB_DESC], [TB_STATUS], [TB_ORDER], [TB_CREATE], [TB_MODIFY], [TB_CREATE_USER], [TB_MODIFY_USER], [TB_PARENTID]) VALUES (1, N'Cat', N'\admin\images\categories\2793aa2d-d316-4de8-ba54-b1c4fb30a224.png', N'<p>123</p>', N'0', N'1', CAST(N'2024-02-16T16:18:28.210' AS DateTime), CAST(N'2024-02-16T16:18:28.210' AS DateTime), N'1', N'1', NULL)
INSERT [dbo].[TB_CATEGORY] ([TB_ID], [TB_NAME], [TB_IMG], [TB_DESC], [TB_STATUS], [TB_ORDER], [TB_CREATE], [TB_MODIFY], [TB_CREATE_USER], [TB_MODIFY_USER], [TB_PARENTID]) VALUES (2, N'Bugatti', N'\admin\images\categories\55ecedab-173a-4a1e-897f-0d5ac5fd40e9.png', N'<p>abc</p>', N'0', N'2', CAST(N'2024-02-14T17:45:24.447' AS DateTime), CAST(N'2024-02-14T17:45:24.447' AS DateTime), N'1', N'1', NULL)
INSERT [dbo].[TB_CATEGORY] ([TB_ID], [TB_NAME], [TB_IMG], [TB_DESC], [TB_STATUS], [TB_ORDER], [TB_CREATE], [TB_MODIFY], [TB_CREATE_USER], [TB_MODIFY_USER], [TB_PARENTID]) VALUES (3, N'Farori', N'\admin\images\categories\f41bd3af-b096-4d8a-bd2e-9e612c84c38f.png', N'<p>asd</p>', N'0', N'1', CAST(N'2024-02-17T17:11:53.823' AS DateTime), CAST(N'2024-02-17T17:11:53.823' AS DateTime), N'1', N'1', N'2')
SET IDENTITY_INSERT [dbo].[TB_CATEGORY] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_ABrands]    Script Date: 03/03/2024 11:39:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ABrands]
	@Operation nvarchar(50),
	@TB_ID float = null,
	@TB_NAME varchar(50) = null,
	@TB_DESC varchar(500) = null,
	@TB_STATUS varchar(50) = null,
	@TB_ORDER varchar(50) = null,
	@TB_IMG varchar(500) = null,
	@TB_CREATE datetime = null,
	@TB_MODIFY datetime = null,
	@TB_CREATE_USER varchar(50) = null,
	@TB_MODIFY_USER varchar(50) = null,
	@BrandCount float = null OUTPUT
as
Begin
	If @Operation = 'GetBrands'
	Begin
		Select * From TB_BRAND
	End
	If @Operation = 'GetBrandById'
	Begin
		Select * From TB_BRAND Where TB_ID = @TB_ID
	End
	If @Operation = 'CreateBrand'
	Begin
		Insert Into TB_BRAND(TB_NAME,TB_DESC,TB_STATUS,TB_ORDER,TB_IMG,TB_CREATE,TB_MODIFY,TB_CREATE_USER,TB_MODIFY_USER)
		Values(@TB_NAME,@TB_DESC,@TB_STATUS,@TB_ORDER,@TB_IMG,@TB_CREATE,@TB_MODIFY,@TB_CREATE_USER,@TB_MODIFY_USER)	
	End
	If @Operation = 'UpdateBrand'
	Begin
		Update TB_BRAND Set TB_NAME = @TB_NAME,TB_DESC = @TB_DESC,TB_STATUS = @TB_STATUS,TB_ORDER = @TB_ORDER,
		TB_IMG = @TB_IMG,TB_MODIFY = @TB_MODIFY,TB_MODIFY_USER = @TB_MODIFY_USER
		Where TB_ID = @TB_ID
	End
	If @Operation = 'DeleteBrand'
	Begin
		Delete TB_BRAND Where TB_ID = @TB_ID
	End
	If @Operation = 'GetBrandsCount'
	Begin
		SET NOCOUNT ON;
		select @BrandCount = count(TB_ID) + 1 From TB_BRAND
	End
End


GO
/****** Object:  StoredProcedure [dbo].[sp_ACategories]    Script Date: 03/03/2024 11:39:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_ACategories]
	@Operation nvarchar(50),
	@TB_ID float = null,
	@TB_NAME varchar(50) = null,
	@TB_DESC varchar(500) = null,
	@TB_STATUS varchar(50) = null,
	@TB_PARENTID varchar(50) = null,
	@TB_ORDER varchar(50) = null,
	@TB_IMG varchar(500) = null,
	@TB_CREATE datetime = null,
	@TB_MODIFY datetime = null,
	@TB_CREATE_USER varchar(50) = null,
	@TB_MODIFY_USER varchar(50) = null,
	@CatCount float = null OUTPUT
as
Begin
	If @Operation = 'GetCategories'
	Begin
		Select * From TB_CATEGORY Where TB_PARENTID Is Null
	End
	If @Operation = 'GetCategoryById'
	Begin
		Select * From TB_CATEGORY Where TB_ID = @TB_ID
	End
	If @Operation = 'CreateCategory'
	Begin
		Insert Into TB_CATEGORY(TB_NAME,TB_DESC,TB_PARENTID,TB_STATUS,TB_ORDER,TB_IMG,TB_CREATE,TB_MODIFY,TB_CREATE_USER,TB_MODIFY_USER)
		Values(@TB_NAME,@TB_DESC,@TB_PARENTID,@TB_STATUS,@TB_ORDER,@TB_IMG,@TB_CREATE,@TB_MODIFY,@TB_CREATE_USER,@TB_MODIFY_USER)	
	End
	If @Operation = 'UpdateCategory'
	Begin
		Update TB_CATEGORY Set TB_NAME = @TB_NAME,TB_PARENTID = @TB_PARENTID,TB_DESC = @TB_DESC,TB_STATUS = @TB_STATUS,TB_ORDER = @TB_ORDER,
		TB_IMG = @TB_IMG,TB_MODIFY = @TB_MODIFY,TB_MODIFY_USER = @TB_MODIFY_USER
		Where TB_ID = @TB_ID
	End
	If @Operation = 'DeleteCategory'
	Begin
		Delete TB_CATEGORY Where TB_ID = @TB_ID
	End
	If @Operation = 'GetCategoriesCount'
	Begin
		SET NOCOUNT ON;
		select @CatCount = count(TB_ID) + 1 From TB_CATEGORY Where TB_PARENTID Is Null
	End
	If @Operation = 'GetSubCat'
	Begin
		Select * From TB_CATEGORY
		 --Where TB_PARENTID Is Not Null
	End
	If @Operation = 'GetSubCatsCount'
	Begin
		SET NOCOUNT ON;
		select @CatCount = count(TB_ID) + 1 From TB_CATEGORY Where TB_PARENTID Is Not Null 
	End
End
GO
USE [master]
GO
ALTER DATABASE [ECommerce_Db] SET  READ_WRITE 
GO

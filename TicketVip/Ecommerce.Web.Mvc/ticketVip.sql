USE [master]
GO
/****** Object:  Database [ticketvip2024]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE DATABASE [ticketvip2024]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ticketvip2024', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ticketvip2024.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ticketvip2024_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ticketvip2024_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ticketvip2024] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ticketvip2024].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ticketvip2024] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ticketvip2024] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ticketvip2024] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ticketvip2024] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ticketvip2024] SET ARITHABORT OFF 
GO
ALTER DATABASE [ticketvip2024] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ticketvip2024] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ticketvip2024] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ticketvip2024] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ticketvip2024] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ticketvip2024] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ticketvip2024] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ticketvip2024] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ticketvip2024] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ticketvip2024] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ticketvip2024] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ticketvip2024] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ticketvip2024] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ticketvip2024] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ticketvip2024] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ticketvip2024] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ticketvip2024] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ticketvip2024] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ticketvip2024] SET  MULTI_USER 
GO
ALTER DATABASE [ticketvip2024] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ticketvip2024] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ticketvip2024] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ticketvip2024] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ticketvip2024] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ticketvip2024] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ticketvip2024] SET QUERY_STORE = ON
GO
ALTER DATABASE [ticketvip2024] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ticketvip2024]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppConfigurations]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfigurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](256) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AppConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](800) NOT NULL,
	[Amount] [real] NULL,
	[FromDate] [datetime2](7) NULL,
	[Enđate] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
	[ShippingAddress] [nvarchar](500) NULL,
	[BillingAddress] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Galleries]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Galleries](
	[Id] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](256) NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Galleries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityRoleClaims]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityRoles]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserClaims]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserLogins]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserRoles]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUsers]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](256) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_IdentityUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserTokens]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortfolioCategorys]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortfolioCategorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Desciption] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](256) NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[ImageBanner] [nvarchar](max) NULL,
	[ParentPortfolioCategoryId] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_PortfolioCategorys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketBooks]    Script Date: 8/26/2024 10:14:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketBooks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DoiTac] [nvarchar](100) NULL,
	[MaDonHang] [nvarchar](200) NULL,
	[SanphamDichvu] [nvarchar](200) NULL,
	[Tongtien] [float] NOT NULL,
	[Ngaydathang] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[TongNguoiLons] [nvarchar](max) NULL,
	[TongTreEms] [nvarchar](max) NULL,
	[LoaiThanhToan] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TicketBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240826101708_AddBlogUrl', N'7.0.4')
GO
SET IDENTITY_INSERT [dbo].[AppConfigurations] ON 

INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (1, N'HeaderSlider', N'[{"Image":null,"HeaderTextLineOne":"Start Buying","HeaderTextLineTwo":"Item One","SubText":"This is sub text for details info","IsActive":true,"Order":0},{"Image":null,"HeaderTextLineOne":"Start Buying","HeaderTextLineTwo":"Item Two","SubText":"This is sub text for details info","IsActive":true,"Order":0},{"Image":null,"HeaderTextLineOne":"Start Buying","HeaderTextLineTwo":"Item Three","SubText":"This is sub text for details info","IsActive":true,"Order":0}]', NULL, CAST(N'2024-08-26T17:18:12.3151311' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151311' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (2, N'GeneralConfiguration', N'{"CompanyName":"EShop","CompanySlogan":null,"CompanyLogo":null,"CompanyFavicon":null,"CompanyContact":null,"CompanyEmail":null,"CompanyLocation":null,"CurrencySymbol":"$","CurrencyPosition":1,"IsPaypalEnabled":true,"IsStripeEnabled":true}', NULL, CAST(N'2024-08-26T17:18:12.3151318' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151318' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (3, N'FeatureProductConfiguration', N'[]', NULL, CAST(N'2024-08-26T17:18:12.3151319' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151319' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (4, N'TopCategoriesConfiguration', N'[]', NULL, CAST(N'2024-08-26T17:18:12.3151321' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151321' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (5, N'DealOfTheDay', N'{"Title":null,"ProductId":0,"ActualPrice":0,"OfferPrice":0,"StartTime":"0001-01-01T00:00:00","EndTime":"0001-01-01T00:00:00","Description":null,"Image":null,"IsActive":false}', NULL, CAST(N'2024-08-26T17:18:12.3151322' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151322' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (6, N'SocialProfile', N'{"Facebook":null,"Youtube":null,"Twitter":null,"Instagram":null,"Linkedin":null,"Pinterest":null}', NULL, CAST(N'2024-08-26T17:18:12.3151323' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151323' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (7, N'StockConfiguration', N'{"IsLowStockNotificationEnabled":true,"IsOutOfStockNotificationEnabled":true,"LowStockThreshold":10,"OutOfStockThreshold":0,"IsOutOfStockItemHidden":false}', NULL, CAST(N'2024-08-26T17:18:12.3151324' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151324' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (8, N'BasicSeoConfiguration', N'{"SeoTitle":"EShop - Shop Online for Branded Shoes, Clothing \u0026 Accessories","SeoDescription":"Online Shopping Site for Fashion \u0026 Lifestyle. Best Fashion Expert brings you a variety of footwear, Clothing, Accessories and lifestyle products for women \u0026 men. Best Online Fashion Store *COD *Easy returns and exchanges. Get all your desire product in one place.","SeoKeywords":"shop, product, ecommerce"}', NULL, CAST(N'2024-08-26T17:18:12.3151326' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151326' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (9, N'SmtpConfiguration', N'{"EmailFromName":null,"EmailFromEmail":null,"EmailUserName":null,"EmailPassword":null,"EmailHost":null,"EmailPort":null}', NULL, CAST(N'2024-08-26T17:18:12.3151327' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151327' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (10, N'SecurityConfiguration', N'{"IsPasswordRequireDigit":false,"IsPasswordRequireLowercase":false,"IsPasswordRequireUppercase":false,"IsPasswordRequireNonAlphanumeric":false,"PasswordRequiredLength":1,"IsUserLockoutEnabled":false,"MaxFailedAccessAttempts":9999,"UserLockoutTime":0}', NULL, CAST(N'2024-08-26T17:18:12.3151328' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151328' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (11, N'AdvancedConfiguration', N'{"EnableTwoFactorAuthentication":false,"ActiveResetPassword":false,"EnableEmailConfirmation":false,"IsComingSoonEnabled":false,"RoleName":null}', NULL, CAST(N'2024-08-26T17:18:12.3151329' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151329' AS DateTime2))
INSERT [dbo].[AppConfigurations] ([Id], [Key], [Value], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (12, N'BannerConfiguration', N'[{"Title":"Get Up To 50% Off","SubTitle":"Keep It Casual","ColorHexCode":"#000000","BackgroundColorHexCode":"#FFD393","BannerType":"BannerOne","IsActive":true},{"Title":"New Year Collection","SubTitle":"Get All New Items","ColorHexCode":"#000000","BackgroundColorHexCode":"#F5F3EF","BannerType":"BannerOne","IsActive":true}]', NULL, CAST(N'2024-08-26T17:18:12.3151330' AS DateTime2), NULL, CAST(N'2024-08-26T17:18:12.3151330' AS DateTime2))
SET IDENTITY_INSERT [dbo].[AppConfigurations] OFF
GO
INSERT [dbo].[Galleries] ([Id], [Title], [Name], [Tags], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (N'2b91f857-bee1-4f14-aa1b-ac4b25a7c10c', NULL, N'gallery/719fb1e7-2859-4ad1-b8e3-2d94adb28897.png', NULL, N'superadmin', CAST(N'2024-08-26T21:41:53.8584347' AS DateTime2), N'superadmin', CAST(N'2024-08-26T21:41:53.8584347' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[IdentityRoleClaims] ON 

INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (1, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Product.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (2, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Product.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (3, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Product.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (4, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Product.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (5, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Category.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (6, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Category.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (7, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Category.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (8, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Category.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (9, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Color.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (10, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Color.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (11, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Color.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (12, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Color.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (13, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Size.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (14, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Size.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (15, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Size.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (16, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Size.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (17, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.DeliveryMethod.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (18, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.DeliveryMethod.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (19, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.DeliveryMethod.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (20, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.DeliveryMethod.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (21, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Order.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (22, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Order.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (23, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Order.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (24, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.PendingOrder.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (25, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.CancelledOrder.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (26, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Inventory.AddStock')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (27, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Inventory.StockHistory')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (28, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.OrderStatus.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (29, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.OrderStatus.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (30, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.OrderStatus.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (31, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.OrderStatus.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (32, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.ShippingArea.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (33, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.ShippingArea.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (34, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.ShippingArea.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (35, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.ShippingArea.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (36, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.CustomerReview.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (37, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.CustomerReview.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (38, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.User.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (39, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.User.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (40, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.User.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (41, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.User.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (42, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Role.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (43, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Role.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (44, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Role.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (45, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Role.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (46, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.RolePermission.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (47, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.UserPermission.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (48, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.UserRole.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (49, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.General')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (50, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Shop')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (51, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Social')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (52, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Stock')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (53, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.BasicSeo')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (54, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Smtp')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (55, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Security')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (56, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Configuration.Advanced')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (57, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Gallery.Manage')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (58, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Customer.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (59, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.Customer.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (60, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.ContactQuery.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (61, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.PortfolioCategory.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (62, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.PortfolioCategory.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (63, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.PortfolioCategory.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (64, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.PortfolioCategory.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (65, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.QR.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (66, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.QR.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (67, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.QR.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (68, N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'Permission', N'Permissions.QR.Delete')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (69, N'76bcc9e9-da16-417b-8c9d-2a411f227728', N'Permission', N'Permissions.QR.View')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (70, N'76bcc9e9-da16-417b-8c9d-2a411f227728', N'Permission', N'Permissions.QR.Create')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (71, N'76bcc9e9-da16-417b-8c9d-2a411f227728', N'Permission', N'Permissions.QR.Edit')
INSERT [dbo].[IdentityRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (72, N'76bcc9e9-da16-417b-8c9d-2a411f227728', N'Permission', N'Permissions.QR.Delete')
SET IDENTITY_INSERT [dbo].[IdentityRoleClaims] OFF
GO
INSERT [dbo].[IdentityRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'57fcb387-20a9-4552-b506-655b429e0a7e', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[IdentityRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'60d33670-9919-4a34-99da-5d2fad0aa687', N'DoiTac', N'DOITAC', N'aceae2fc-cb17-4349-8d4f-a4397bee6aaa')
INSERT [dbo].[IdentityRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'76bcc9e9-da16-417b-8c9d-2a411f227728', N'BanHang', N'BANHANG', N'95db6b79-5a4b-48b1-8cbd-c7bc3819c308')
INSERT [dbo].[IdentityRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a14574c6-93ad-4a2c-977b-5cbd6b5b74dc', N'Customer', N'CUSTOMER', NULL)
INSERT [dbo].[IdentityRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b94f4088-e5fa-428b-986d-51160e78cbd3', N'SuperAdmin', N'SUPERADMIN', N'ed99aa10-8571-4990-8580-d070fa862ee2')
GO
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'57fcb387-20a9-4552-b506-655b429e0a7e')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'60d33670-9919-4a34-99da-5d2fad0aa687')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'e0429af9-6d51-43bf-9310-fb7ef010770f', N'60d33670-9919-4a34-99da-5d2fad0aa687')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'892cd1ed-296b-453d-8cfd-7029ad31e3cc', N'76bcc9e9-da16-417b-8c9d-2a411f227728')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'76bcc9e9-da16-417b-8c9d-2a411f227728')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'd12fb98c-6eeb-4310-86c3-9f46b27d68ce', N'76bcc9e9-da16-417b-8c9d-2a411f227728')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'a14574c6-93ad-4a2c-977b-5cbd6b5b74dc')
INSERT [dbo].[IdentityUserRoles] ([UserId], [RoleId]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'b94f4088-e5fa-428b-986d-51160e78cbd3')
GO
INSERT [dbo].[IdentityUsers] ([Id], [FirstName], [LastName], [DateOfBirth], [ProfilePicture], [Gender], [Address], [IsActive], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'892cd1ed-296b-453d-8cfd-7029ad31e3cc', N'Tiến', N'Lạt', NULL, NULL, N'1', NULL, 1, N'superadmin', CAST(N'2024-08-26T14:50:34.7555516' AS DateTime2), N'superadmin', CAST(N'2024-08-26T14:50:34.7555516' AS DateTime2), N'banhang', N'BANHANG', N'tiendev88@gmail.com', N'TIENDEV88@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEO/P78NMCPEzLiwQvhlIQyZMFE12RgfcekXFgHKSxr/lJ+WQkvXSRktxiWNWT1Z7Zw==', N'LOAHFVRMLXUOXSU2CCIZEHZTMESQ6A2B', N'eb2cb871-fde0-41fe-a9bd-363b6da5279d', N'0944838788', 0, 0, NULL, 1, 0)
INSERT [dbo].[IdentityUsers] ([Id], [FirstName], [LastName], [DateOfBirth], [ProfilePicture], [Gender], [Address], [IsActive], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9185e0f3-8611-4fc5-9199-dbbe0cccd837', N'Super', N'Admin', NULL, NULL, NULL, NULL, 1, NULL, CAST(N'2024-08-26T10:18:12.5869083' AS DateTime2), NULL, CAST(N'2024-08-26T10:18:12.5869554' AS DateTime2), N'superadmin', N'SUPERADMIN', N'superadmin@domain.com', N'SUPERADMIN@DOMAIN.COM', 1, N'AQAAAAIAAYagAAAAEP3TAWllqB0b9bFgaWqArrSXoKuARB4stR7XboV+j7qg2kgEAsPmLhvajgzmlkw63A==', N'3QCUMUN4WSCVJNKOF26W7MYYMK6AKXTW', N'415d58fc-f1d7-4843-bc56-9547619853cf', NULL, 1, 0, NULL, 1, 0)
INSERT [dbo].[IdentityUsers] ([Id], [FirstName], [LastName], [DateOfBirth], [ProfilePicture], [Gender], [Address], [IsActive], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd12fb98c-6eeb-4310-86c3-9f46b27d68ce', N'Tiến', N'Lạt', CAST(N'2024-08-15T00:00:00.0000000' AS DateTime2), NULL, N'2', NULL, 1, N'superadmin', CAST(N'2024-08-26T15:03:24.9071591' AS DateTime2), N'superadmin', CAST(N'2024-08-26T15:03:24.9071591' AS DateTime2), N'tiendev', N'TIENDEV', N'tiendev881@gmail.com', N'TIENDEV881@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELVOmp5TOV84ygs74vFlEiftjgila8LY5Bdo1N4FhBotp+AhFVF5EsnOiaVMefvd2g==', N'XKQ3D3YYBOZDI3AMP2DXDDU3Z7PNZZRV', N'450e04dd-d9c2-4ff5-9034-2eb751ee15ac', N'0944838788', 0, 0, NULL, 1, 0)
INSERT [dbo].[IdentityUsers] ([Id], [FirstName], [LastName], [DateOfBirth], [ProfilePicture], [Gender], [Address], [IsActive], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e0429af9-6d51-43bf-9310-fb7ef010770f', N'changvangshow', N'changvangshow', NULL, NULL, N'2', NULL, 1, N'superadmin', CAST(N'2024-08-26T15:10:35.0590154' AS DateTime2), N'superadmin', CAST(N'2024-08-26T15:10:35.0590154' AS DateTime2), N'changvangshow', N'CHANGVANGSHOW', N'changvangshow@gmail.com', N'CHANGVANGSHOW@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEH/NO21mG+2DQIaMnNX93gmxNdHDN2MOyBzEZJCpXVKDd4oaf5W5MN0FpMGQOpHvSw==', N'XL3G6TDC37UWRBBSCX5TJUISCJIPIH6D', N'1dada193-7ec5-4f3c-8528-d7aa7dbeb3a3', N'0944838788', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[PortfolioCategorys] ON 

INSERT [dbo].[PortfolioCategorys] ([Id], [Name], [Desciption], [Slug], [Icon], [ImageBanner], [ParentPortfolioCategoryId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (1, N'Vườn Hoa Đà Lạt', N'Vườn Hoa Đà Lạt', N'vườn-hoa-đà-lạt', NULL, NULL, NULL, N'superadmin', CAST(N'2024-08-26T21:42:04.7578287' AS DateTime2), N'superadmin', CAST(N'2024-08-26T21:42:04.7578287' AS DateTime2))
INSERT [dbo].[PortfolioCategorys] ([Id], [Name], [Desciption], [Slug], [Icon], [ImageBanner], [ParentPortfolioCategoryId], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (2, N'changvangshow', N'changvangshow', N'changvangshow', NULL, NULL, NULL, N'superadmin', CAST(N'2024-08-26T22:09:34.9452804' AS DateTime2), N'superadmin', CAST(N'2024-08-26T22:09:34.9452804' AS DateTime2))
SET IDENTITY_INSERT [dbo].[PortfolioCategorys] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketBooks] ON 

INSERT [dbo].[TicketBooks] ([Id], [DoiTac], [MaDonHang], [SanphamDichvu], [Tongtien], [Ngaydathang], [Name], [Email], [Phone], [Address], [Note], [UserName], [Status], [TongNguoiLons], [TongTreEms], [LoaiThanhToan], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]) VALUES (1, N'changvangshow', N'DLRV-f81f84ae', N'Vé them quan,
Vé đi xe điện 2 vé', 300000, N'Monday, August 26, 2024', N'Tiến Đà Lạt', N'tiendev88@gmail.com', N'0944838788', N'HCM', N'OK NHé', N'tiendev', 1, N'{"SoLuong":1,"Tong":200000}', N'{"SoLuong":2,"Tong":50000}', N'Chuyển khoản', N'tiendev', CAST(N'2024-08-26T22:11:55.5549780' AS DateTime2), N'tiendev', CAST(N'2024-08-26T22:11:55.5549780' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TicketBooks] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customers_ApplicationUserId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers_ApplicationUserId] ON [dbo].[Customers]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityRoleClaims_RoleId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRoleClaims_RoleId] ON [dbo].[IdentityRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[IdentityRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityUserClaims_UserId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdentityUserClaims_UserId] ON [dbo].[IdentityUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityUserLogins_UserId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdentityUserLogins_UserId] ON [dbo].[IdentityUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_IdentityUserRoles_RoleId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_IdentityUserRoles_RoleId] ON [dbo].[IdentityUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[IdentityUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[IdentityUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PortfolioCategorys_ParentPortfolioCategoryId]    Script Date: 8/26/2024 10:14:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_PortfolioCategorys_ParentPortfolioCategoryId] ON [dbo].[PortfolioCategorys]
(
	[ParentPortfolioCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_IdentityUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_IdentityUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[IdentityRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityRoleClaims_IdentityRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[IdentityRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityRoleClaims] CHECK CONSTRAINT [FK_IdentityRoleClaims_IdentityRoles_RoleId]
GO
ALTER TABLE [dbo].[IdentityUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserClaims_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserClaims] CHECK CONSTRAINT [FK_IdentityUserClaims_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[IdentityUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogins_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserLogins] CHECK CONSTRAINT [FK_IdentityUserLogins_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRoles_IdentityRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[IdentityRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_IdentityUserRoles_IdentityRoles_RoleId]
GO
ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRoles_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_IdentityUserRoles_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[IdentityUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserTokens_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserTokens] CHECK CONSTRAINT [FK_IdentityUserTokens_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[PortfolioCategorys]  WITH CHECK ADD  CONSTRAINT [FK_PortfolioCategorys_PortfolioCategorys_ParentPortfolioCategoryId] FOREIGN KEY([ParentPortfolioCategoryId])
REFERENCES [dbo].[PortfolioCategorys] ([Id])
GO
ALTER TABLE [dbo].[PortfolioCategorys] CHECK CONSTRAINT [FK_PortfolioCategorys_PortfolioCategorys_ParentPortfolioCategoryId]
GO
USE [master]
GO
ALTER DATABASE [ticketvip2024] SET  READ_WRITE 
GO

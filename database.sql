USE [master]
GO
/****** Object:  Database [webphimonline]    Script Date: 4/16/2024 1:17:55 PM ******/
CREATE DATABASE [webphimonline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webphimonline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\webphimonline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webphimonline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\webphimonline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [webphimonline] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webphimonline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webphimonline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webphimonline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webphimonline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webphimonline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webphimonline] SET ARITHABORT OFF 
GO
ALTER DATABASE [webphimonline] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [webphimonline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webphimonline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webphimonline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webphimonline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webphimonline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webphimonline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webphimonline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webphimonline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webphimonline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [webphimonline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webphimonline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webphimonline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webphimonline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webphimonline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webphimonline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webphimonline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webphimonline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [webphimonline] SET  MULTI_USER 
GO
ALTER DATABASE [webphimonline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webphimonline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webphimonline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webphimonline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webphimonline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [webphimonline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [webphimonline] SET QUERY_STORE = ON
GO
ALTER DATABASE [webphimonline] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [webphimonline]
GO
/****** Object:  Table [dbo].[binhluan]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[binhluan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](50) NULL,
	[ThoiGian] [datetime] NULL,
	[ID_TapPhim] [int] NOT NULL,
	[ID_TK] [int] NOT NULL,
 CONSTRAINT [PK__binhluan__3214EC275BC9BBC8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitiethd]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethd](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhan] [datetime] NOT NULL,
	[SoTien] [int] NULL,
	[ID_TK] [int] NULL,
	[ID_HD] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitiethdn]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethdn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GiaPhim] [int] NULL,
	[ID_PNK] [int] NULL,
	[ID_TapPhim] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhgia]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhgia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoDiem] [float] NULL,
	[ThoiGian] [datetime] NULL,
	[ID_TapPhim] [int] NOT NULL,
	[ID_TK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hangphim]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hangphim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_HangPhim] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadonnhap]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadonnhap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lichsuphim]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lichsuphim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tapphim] [int] NULL,
	[ID_TK] [int] NULL,
	[create_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaiphim]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiphim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_LP] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phim]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_Phim] [nvarchar](50) NOT NULL,
	[Anh_Phim] [nvarchar](50) NOT NULL,
	[NgayPhatHanh] [datetime] NOT NULL,
	[ThoiLuongPhim] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
	[DanhGia] [float] NULL,
	[ID_HangPhim] [int] NULL,
	[ID_LP] [int] NULL,
	[TongSoTap] [int] NOT NULL,
 CONSTRAINT [PK__phim__3214EC2749695C36] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taikhoan]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_TK] [nvarchar](50) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Loai_TK] [int] NOT NULL,
	[RefreshToken] [varchar](255) NULL,
 CONSTRAINT [PK__taikhoan__3214EC272A392132] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tapphim]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tapphim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ThoiHan] [datetime] NOT NULL,
	[TapSo] [int] NOT NULL,
	[ThoiGianChieu] [datetime] NOT NULL,
	[ThoiLuong] [varchar](10) NULL,
	[URL_Phim] [varchar](255) NULL,
	[URL_Trailer] [varchar](255) NULL,
	[ID_Phim] [int] NULL,
 CONSTRAINT [PK__tapphim__3214EC27E875C46D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[binhluan] ON 

INSERT [dbo].[binhluan] ([ID], [NoiDung], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (37, N'Hay', CAST(N'2024-04-12T14:12:15.477' AS DateTime), 1, 3)
INSERT [dbo].[binhluan] ([ID], [NoiDung], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (38, N'Hay', CAST(N'2024-04-12T15:55:34.510' AS DateTime), 1, 3)
INSERT [dbo].[binhluan] ([ID], [NoiDung], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (39, N'Hay', CAST(N'2024-04-12T15:58:20.403' AS DateTime), 1, 3)
INSERT [dbo].[binhluan] ([ID], [NoiDung], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (40, N'Hay', CAST(N'2024-04-12T16:26:49.887' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[binhluan] OFF
GO
SET IDENTITY_INSERT [dbo].[chitiethdn] ON 

INSERT [dbo].[chitiethdn] ([ID], [GiaPhim], [ID_PNK], [ID_TapPhim]) VALUES (3, 12345678, 4, 14)
INSERT [dbo].[chitiethdn] ([ID], [GiaPhim], [ID_PNK], [ID_TapPhim]) VALUES (4, 100000, 7, 15)
SET IDENTITY_INSERT [dbo].[chitiethdn] OFF
GO
SET IDENTITY_INSERT [dbo].[danhgia] ON 

INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (1, 4.5, CAST(N'2024-03-26T09:47:37.423' AS DateTime), 1, 1)
INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (11, NULL, CAST(N'2024-03-26T14:48:03.993' AS DateTime), 1, 1)
INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (12, 1, CAST(N'2024-03-26T14:50:01.380' AS DateTime), 1, 1)
INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (13, 1, CAST(N'2024-03-26T14:51:58.670' AS DateTime), 1, 1)
INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (14, 5, CAST(N'2024-03-26T14:52:05.023' AS DateTime), 1, 1)
INSERT [dbo].[danhgia] ([ID], [SoDiem], [ThoiGian], [ID_TapPhim], [ID_TK]) VALUES (15, 4, CAST(N'2024-04-09T16:50:02.393' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[danhgia] OFF
GO
SET IDENTITY_INSERT [dbo].[hangphim] ON 

INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (1, N'Trung Quốc')
INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (2, N'JaPan')
INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (3, N'Mỹ')
INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (4, N'Anh')
INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (5, N'Thái Lan')
INSERT [dbo].[hangphim] ([ID], [Ten_HangPhim]) VALUES (6, N'Việt Nam')
SET IDENTITY_INSERT [dbo].[hangphim] OFF
GO
SET IDENTITY_INSERT [dbo].[hoadonnhap] ON 

INSERT [dbo].[hoadonnhap] ([ID], [NgayNhap]) VALUES (4, CAST(N'2024-04-01T14:54:59.543' AS DateTime))
INSERT [dbo].[hoadonnhap] ([ID], [NgayNhap]) VALUES (5, CAST(N'2024-04-08T17:14:47.583' AS DateTime))
INSERT [dbo].[hoadonnhap] ([ID], [NgayNhap]) VALUES (6, CAST(N'2024-04-08T17:14:57.487' AS DateTime))
INSERT [dbo].[hoadonnhap] ([ID], [NgayNhap]) VALUES (7, CAST(N'2024-04-08T17:25:45.533' AS DateTime))
INSERT [dbo].[hoadonnhap] ([ID], [NgayNhap]) VALUES (16, CAST(N'2024-04-09T09:31:42.720' AS DateTime))
SET IDENTITY_INSERT [dbo].[hoadonnhap] OFF
GO
SET IDENTITY_INSERT [dbo].[lichsuphim] ON 

INSERT [dbo].[lichsuphim] ([ID], [ID_Tapphim], [ID_TK], [create_at]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[lichsuphim] ([ID], [ID_Tapphim], [ID_TK], [create_at]) VALUES (2, 1, 1, CAST(N'2024-03-26T15:36:29.413' AS DateTime))
INSERT [dbo].[lichsuphim] ([ID], [ID_Tapphim], [ID_TK], [create_at]) VALUES (3, 3, 1, CAST(N'2024-03-26T16:03:54.980' AS DateTime))
INSERT [dbo].[lichsuphim] ([ID], [ID_Tapphim], [ID_TK], [create_at]) VALUES (8, 5, 1, CAST(N'2024-03-27T09:20:04.840' AS DateTime))
SET IDENTITY_INSERT [dbo].[lichsuphim] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiphim] ON 

INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (1, N'Tu Tiên')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (2, N'Trùng sinh')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (3, N'Anime')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (4, N'Hiện đại')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (5, N'cổ Trang')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (6, N'Cổ Tích')
INSERT [dbo].[loaiphim] ([ID], [Ten_LP]) VALUES (7, N'Truyền Hình')
SET IDENTITY_INSERT [dbo].[loaiphim] OFF
GO
SET IDENTITY_INSERT [dbo].[phim] ON 

INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (1, N'Nghịch Thiên Tà Thần', N'NghichThienTaThan.jpg', CAST(N'2023-12-02T22:44:00.000' AS DateTime), N'20p', N'combat nhi', NULL, 1, 1, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (2, N'Thái Cổ Tinh Thần Quyết', N'ThaiCoTinhThanQuyet.jpg', CAST(N'2023-12-07T22:48:00.000' AS DateTime), N'20p', N'combat nhi', NULL, 6, 2, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (3, N'Thôn Phệ Tinh Không', N'ThonPheTinhKhong.jpg', CAST(N'2023-12-05T22:49:00.000' AS DateTime), N'20p', N'rất hay', NULL, 2, 3, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (4, N'Tiên Nghịch', N'TienNghich.jpg', CAST(N'2023-12-02T22:50:00.000' AS DateTime), N'20p', N'Đồ họa đẹp', NULL, 1, 2, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (5, N'Tiên Võ Đế', N'TienVoDe.jpg', CAST(N'2023-12-05T22:50:00.000' AS DateTime), N'20p', N'Nội dung h', NULL, 1, 1, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (6, N'Vạn Cổ Cuồng Đế', N'VanCoCuongDe.jpg', CAST(N'2024-01-07T20:00:56.000' AS DateTime), N'20p', NULL, NULL, 1, 3, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (7, N'Đấu Phá Thương Khung', N'DauPhaThuongKhung.jpg', CAST(N'2024-01-30T14:00:55.000' AS DateTime), N'20 phút', NULL, NULL, 4, 5, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (11, N'Tuyển tập phim Việt Nam', N'Screenshot (56).png', CAST(N'2024-04-01T00:00:00.000' AS DateTime), N'20 phút', N'hay', NULL, 3, 5, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (12, N'Ty xoa', N'Screenshot (59).png', CAST(N'2024-04-02T09:59:00.000' AS DateTime), N'20 phut', N'Nội dung hay', NULL, 3, 1, 0)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (16, N'Đại chúa tể', N'DaiChuaTe.jpg', CAST(N'2024-04-08T03:18:03.073' AS DateTime), N'20 phút', N'phim rất nhiều phân đoạn hay', NULL, 1, 1, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (17, N'Độc Bộ Tiêu Dao', N'Screenshot 2024-04-04 101841.png', CAST(N'2024-04-08T00:00:00.000' AS DateTime), NULL, N'rất hay', NULL, 1, 1, 100)
INSERT [dbo].[phim] ([ID], [Ten_Phim], [Anh_Phim], [NgayPhatHanh], [ThoiLuongPhim], [MoTa], [DanhGia], [ID_HangPhim], [ID_LP], [TongSoTap]) VALUES (19, N'Thế Giới Hoàn Mỹ', N'Screenshot 2024-04-04 143848.png', CAST(N'2024-04-18T00:00:00.000' AS DateTime), NULL, N'hay', NULL, 1, 1, 1000)
SET IDENTITY_INSERT [dbo].[phim] OFF
GO
SET IDENTITY_INSERT [dbo].[taikhoan] ON 

INSERT [dbo].[taikhoan] ([ID], [Ten_TK], [MatKhau], [Email], [Loai_TK], [RefreshToken]) VALUES (1, N'Phạm Công Định', N'18042002', N'pcd@gmail.com', 1, NULL)
INSERT [dbo].[taikhoan] ([ID], [Ten_TK], [MatKhau], [Email], [Loai_TK], [RefreshToken]) VALUES (2, N'Trần Hoàng Đạt', N'03012002', N'dat@gmail.com', 1, NULL)
INSERT [dbo].[taikhoan] ([ID], [Ten_TK], [MatKhau], [Email], [Loai_TK], [RefreshToken]) VALUES (3, N'Đoàn Thị Mai Anh', N'123456', N'Manh@gmail.com', 0, N'W/xbzfuOROwnYrHFRhDVBxHyhPEGBhSx2U9UlwMRNCE=')
SET IDENTITY_INSERT [dbo].[taikhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[tapphim] ON 

INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (1, CAST(N'2023-12-14T22:45:00.000' AS DateTime), 2, CAST(N'2023-11-29T22:44:00.000' AS DateTime), N'20p', N'https://www.dailymotion.com/embed/video/x8rujy7?autoplay=1&quality=1080&queue-autoplay-next=false&qu', N'1234567asdfgyu', 1)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (2, CAST(N'2023-12-29T22:51:00.000' AS DateTime), 1, CAST(N'2023-11-29T22:51:00.000' AS DateTime), N'20p', N'quertyufghj', N'1234567asdfgyu', 2)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (3, CAST(N'2023-12-29T22:51:00.000' AS DateTime), 2, CAST(N'2023-11-29T22:51:00.000' AS DateTime), N'20', N'quertyufghj', N'1234567asdfgyu', 5)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (4, CAST(N'2023-12-29T22:51:00.000' AS DateTime), 1, CAST(N'2023-11-29T22:51:00.000' AS DateTime), N'20p', N'quertyufghj', N'1234567asdfgyu', 3)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (5, CAST(N'2023-12-01T15:36:00.000' AS DateTime), 2, CAST(N'2023-12-09T15:36:00.000' AS DateTime), N'20 phu', N'iiyytrewdgjj', N'ádfg', 4)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (6, CAST(N'2023-12-01T14:47:00.000' AS DateTime), 27, CAST(N'2023-12-14T14:47:00.000' AS DateTime), N'20p', N'ádfghjk7654ew', N'1234567asdfgyu', 1)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (7, CAST(N'2023-12-08T15:20:00.000' AS DateTime), 1, CAST(N'2023-12-02T15:20:00.000' AS DateTime), N'20', N'https://player.phimapi.com/player/?url=https://s2.phim1280.tv/20231231/Kl6YsRIK/index.m3u8', N'lkjhhgfda', 1)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (8, CAST(N'2023-12-07T15:32:00.000' AS DateTime), 12, CAST(N'2023-12-08T15:32:00.000' AS DateTime), N'20', N'iiyytrewdgjj', N'lkjhhgfda', 1)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (9, CAST(N'2023-12-07T15:32:00.000' AS DateTime), 12, CAST(N'2023-12-08T15:32:00.000' AS DateTime), N'20', N'iiyytrewdgjj', N'lkjhhgfda', 3)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (10, CAST(N'2023-12-01T15:36:00.000' AS DateTime), 1, CAST(N'2023-12-09T15:36:00.000' AS DateTime), N'20 phút', N'iiyytrewdgjj', N'ádfg', 5)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (11, CAST(N'2023-12-01T15:36:00.000' AS DateTime), 2, CAST(N'2023-12-09T15:36:00.000' AS DateTime), N'20 phút', N'iiyytrewdgjj', N'ádfg', 4)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (14, CAST(N'2024-04-03T14:54:00.000' AS DateTime), 5, CAST(N'2024-04-10T14:54:00.000' AS DateTime), N'20p', N'ádfghjk7654ew', N'1234567asdfgyu', 5)
INSERT [dbo].[tapphim] ([ID], [ThoiHan], [TapSo], [ThoiGianChieu], [ThoiLuong], [URL_Phim], [URL_Trailer], [ID_Phim]) VALUES (15, CAST(N'2024-04-08T10:22:36.607' AS DateTime), 3, CAST(N'2024-04-08T10:22:36.607' AS DateTime), N'20 phút', N's?p có', N'không có', 1)
SET IDENTITY_INSERT [dbo].[tapphim] OFF
GO
ALTER TABLE [dbo].[binhluan] ADD  CONSTRAINT [DF__binhluan__NoiDun__6D0D32F4]  DEFAULT (NULL) FOR [NoiDung]
GO
ALTER TABLE [dbo].[binhluan] ADD  CONSTRAINT [DF__binhluan__ThoiGi__6E01572D]  DEFAULT (NULL) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[chitiethd] ADD  DEFAULT (NULL) FOR [SoTien]
GO
ALTER TABLE [dbo].[chitiethd] ADD  DEFAULT (NULL) FOR [ID_TK]
GO
ALTER TABLE [dbo].[chitiethd] ADD  DEFAULT (NULL) FOR [ID_HD]
GO
ALTER TABLE [dbo].[chitiethdn] ADD  DEFAULT (NULL) FOR [GiaPhim]
GO
ALTER TABLE [dbo].[chitiethdn] ADD  DEFAULT (NULL) FOR [ID_PNK]
GO
ALTER TABLE [dbo].[chitiethdn] ADD  DEFAULT (NULL) FOR [ID_TapPhim]
GO
ALTER TABLE [dbo].[danhgia] ADD  DEFAULT (NULL) FOR [SoDiem]
GO
ALTER TABLE [dbo].[danhgia] ADD  DEFAULT (NULL) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[phim] ADD  CONSTRAINT [DF__phim__ThoiLuongP__5812160E]  DEFAULT (NULL) FOR [ThoiLuongPhim]
GO
ALTER TABLE [dbo].[phim] ADD  CONSTRAINT [DF__phim__MoTa__59063A47]  DEFAULT (NULL) FOR [MoTa]
GO
ALTER TABLE [dbo].[phim] ADD  CONSTRAINT [DF__phim__DanhGia__59FA5E80]  DEFAULT (NULL) FOR [DanhGia]
GO
ALTER TABLE [dbo].[phim] ADD  CONSTRAINT [DF__phim__ID_HangPhi__5AEE82B9]  DEFAULT (NULL) FOR [ID_HangPhim]
GO
ALTER TABLE [dbo].[phim] ADD  CONSTRAINT [DF__phim__ID_LP__5BE2A6F2]  DEFAULT (NULL) FOR [ID_LP]
GO
ALTER TABLE [dbo].[tapphim] ADD  CONSTRAINT [DF__tapphim__ThoiLuo__60A75C0F]  DEFAULT (NULL) FOR [ThoiLuong]
GO
ALTER TABLE [dbo].[tapphim] ADD  CONSTRAINT [DF__tapphim__URL_Phi__619B8048]  DEFAULT (NULL) FOR [URL_Phim]
GO
ALTER TABLE [dbo].[tapphim] ADD  CONSTRAINT [DF__tapphim__URL_Tra__628FA481]  DEFAULT (NULL) FOR [URL_Trailer]
GO
ALTER TABLE [dbo].[tapphim] ADD  CONSTRAINT [DF__tapphim__ID_Phim__6383C8BA]  DEFAULT (NULL) FOR [ID_Phim]
GO
ALTER TABLE [dbo].[binhluan]  WITH CHECK ADD  CONSTRAINT [FK__binhluan__ID_Tap__6EF57B66] FOREIGN KEY([ID_TapPhim])
REFERENCES [dbo].[tapphim] ([ID])
GO
ALTER TABLE [dbo].[binhluan] CHECK CONSTRAINT [FK__binhluan__ID_Tap__6EF57B66]
GO
ALTER TABLE [dbo].[binhluan]  WITH CHECK ADD  CONSTRAINT [FK__binhluan__ID_TK__6FE99F9F] FOREIGN KEY([ID_TK])
REFERENCES [dbo].[taikhoan] ([ID])
GO
ALTER TABLE [dbo].[binhluan] CHECK CONSTRAINT [FK__binhluan__ID_TK__6FE99F9F]
GO
ALTER TABLE [dbo].[chitiethd]  WITH CHECK ADD FOREIGN KEY([ID_HD])
REFERENCES [dbo].[hoadon] ([ID])
GO
ALTER TABLE [dbo].[chitiethd]  WITH CHECK ADD  CONSTRAINT [FK__chitiethd__ID_TK__75A278F5] FOREIGN KEY([ID_TK])
REFERENCES [dbo].[taikhoan] ([ID])
GO
ALTER TABLE [dbo].[chitiethd] CHECK CONSTRAINT [FK__chitiethd__ID_TK__75A278F5]
GO
ALTER TABLE [dbo].[chitiethdn]  WITH CHECK ADD FOREIGN KEY([ID_PNK])
REFERENCES [dbo].[hoadonnhap] ([ID])
GO
ALTER TABLE [dbo].[chitiethdn]  WITH CHECK ADD  CONSTRAINT [FK__chitiethd__ID_Ta__7D439ABD] FOREIGN KEY([ID_TapPhim])
REFERENCES [dbo].[tapphim] ([ID])
GO
ALTER TABLE [dbo].[chitiethdn] CHECK CONSTRAINT [FK__chitiethd__ID_Ta__7D439ABD]
GO
ALTER TABLE [dbo].[danhgia]  WITH CHECK ADD  CONSTRAINT [FK__danhgia__ID_TapP__693CA210] FOREIGN KEY([ID_TapPhim])
REFERENCES [dbo].[tapphim] ([ID])
GO
ALTER TABLE [dbo].[danhgia] CHECK CONSTRAINT [FK__danhgia__ID_TapP__693CA210]
GO
ALTER TABLE [dbo].[danhgia]  WITH CHECK ADD  CONSTRAINT [FK__danhgia__ID_TK__6A30C649] FOREIGN KEY([ID_TK])
REFERENCES [dbo].[taikhoan] ([ID])
GO
ALTER TABLE [dbo].[danhgia] CHECK CONSTRAINT [FK__danhgia__ID_TK__6A30C649]
GO
ALTER TABLE [dbo].[lichsuphim]  WITH CHECK ADD FOREIGN KEY([ID_Tapphim])
REFERENCES [dbo].[tapphim] ([ID])
GO
ALTER TABLE [dbo].[lichsuphim]  WITH CHECK ADD  CONSTRAINT [FK__lichsuphi__ID_TK__41EDCAC5] FOREIGN KEY([ID_TK])
REFERENCES [dbo].[taikhoan] ([ID])
GO
ALTER TABLE [dbo].[lichsuphim] CHECK CONSTRAINT [FK__lichsuphi__ID_TK__41EDCAC5]
GO
ALTER TABLE [dbo].[phim]  WITH CHECK ADD  CONSTRAINT [FK__phim__ID_HangPhi__5CD6CB2B] FOREIGN KEY([ID_HangPhim])
REFERENCES [dbo].[hangphim] ([ID])
GO
ALTER TABLE [dbo].[phim] CHECK CONSTRAINT [FK__phim__ID_HangPhi__5CD6CB2B]
GO
ALTER TABLE [dbo].[phim]  WITH CHECK ADD  CONSTRAINT [FK__phim__ID_LP__5DCAEF64] FOREIGN KEY([ID_LP])
REFERENCES [dbo].[loaiphim] ([ID])
GO
ALTER TABLE [dbo].[phim] CHECK CONSTRAINT [FK__phim__ID_LP__5DCAEF64]
GO
ALTER TABLE [dbo].[tapphim]  WITH CHECK ADD  CONSTRAINT [FK__tapphim__ID_Phim__6477ECF3] FOREIGN KEY([ID_Phim])
REFERENCES [dbo].[phim] ([ID])
GO
ALTER TABLE [dbo].[tapphim] CHECK CONSTRAINT [FK__tapphim__ID_Phim__6477ECF3]
GO
/****** Object:  StoredProcedure [dbo].[GetPhimTongSoTapByNgayTrongTuan]    Script Date: 4/16/2024 1:17:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    CREATE PROCEDURE [dbo].[GetPhimTongSoTapByNgayTrongTuan]
    @NgayTrongTuan INT
AS
BEGIN
    WITH NumberedTaps AS (
        SELECT 
            ID_Phim,
            TapSo,
            ROW_NUMBER() OVER (PARTITION BY ID_Phim ORDER BY ThoiGianChieu) AS RowNumber
        FROM 
            tapphim
    )
    SELECT 
        phim.ID, 
        phim.Ten_Phim, 
        phim.TongSoTap, 
        phim.Anh_Phim,
        phim.DanhGia,
        phim.MoTa,
       
        COUNT(DISTINCT NumberedTaps.RowNumber) AS solg
    FROM 
        phim 
    INNER JOIN 
        tapphim ON phim.ID = tapphim.ID_Phim
    INNER JOIN 
        NumberedTaps ON tapphim.ID_Phim = NumberedTaps.ID_Phim
    WHERE 
        DATEPART(dw, tapphim.ThoiGianChieu) = @NgayTrongTuan
    GROUP BY 
        phim.ID, 
        phim.Ten_Phim, 
        phim.TongSoTap, 
        phim.Anh_Phim,
        phim.DanhGia,
        phim.MoTa
        



END
GO
USE [master]
GO
ALTER DATABASE [webphimonline] SET  READ_WRITE 
GO

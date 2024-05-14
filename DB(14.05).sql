/****** Object:  Table [dbo].[Actors]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorID] [int] IDENTITY(1,1) NOT NULL,
	[ActorFullName] [varchar](500) NOT NULL,
	[ActorPhoto] [varchar](max) NULL,
	[ActorBirthday] [date] NULL,
	[ActorCountry] [varchar](500) NULL,
	[ActorHeight] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[DirectorID] [int] IDENTITY(1,1) NOT NULL,
	[DirectorFullName] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DirectorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[HallID] [int] IDENTITY(1,1) NOT NULL,
	[HallName] [varchar](100) NOT NULL,
	[HallType] [varchar](20) NOT NULL,
	[NumberOfRows] [int] NOT NULL,
	[NumberOfSeats] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HallID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[MediaID] [int] IDENTITY(1,1) NOT NULL,
	[MovieDescription] [varchar](4000) NOT NULL,
	[MoviePhoto] [varchar](max) NOT NULL,
	[MovieTrailer] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MediaID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Actor]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Actor](
	[MovieActorID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[ActorID] [int] NOT NULL,
	[ActorNickname] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieActorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Director]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Director](
	[MovieID] [int] NOT NULL,
	[DirectorID] [int] NOT NULL,
	[MovieDirectorID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieDirectorID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[MovieID] [int] NOT NULL,
	[GenreID] [int] NOT NULL,
	[MovieGenreID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieGenreID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Screenwriter]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Screenwriter](
	[MovieID] [int] NOT NULL,
	[ScreenwriterID] [int] NOT NULL,
	[MovieScreenwriterID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieScreenwriterID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[MovieTitle] [varchar](255) NOT NULL,
	[MediaID] [int] NOT NULL,
	[Duration] [time](7) NOT NULL,
	[Country] [text] NOT NULL,
	[WorldPremiere] [date] NOT NULL,
	[UkrainePremiere] [date] NOT NULL,
	[Rating] [varchar](50) NOT NULL,
	[EndOfShow] [date] NOT NULL,
	[Limitations] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieSessions]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieSessions](
	[MovieSessionID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[StartTime] [time](7) NULL,
	[TheLowestPrice] [int] NULL,
	[MiddlePrice] [int] NULL,
	[TheHighestPrice] [int] NULL,
	[HallID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieSessionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[PriceID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[SeatReservationID] [int] NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PriceID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[MovieSessionID] [int] NOT NULL,
	[PriceID] [int] NOT NULL,
	[Discount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Screenwriters]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screenwriters](
	[ScreenwriterID] [int] IDENTITY(1,1) NOT NULL,
	[ScreenwriterFullName] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ScreenwriterID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeatReservation]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeatReservation](
	[SeatReservationID] [int] IDENTITY(1,1) NOT NULL,
	[HallID] [int] NOT NULL,
	[RowNumber] [int] NOT NULL,
	[SeatNumber] [int] NOT NULL,
	[IsReserved] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SeatReservationID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/14/2024 8:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](200) NOT NULL,
	[UserEmail] [varchar](200) NOT NULL,
	[UserPassword] [varchar](200) NOT NULL,
	[IsReserved] [bit] NOT NULL,
	[isActive] [bit] NULL,
	[Token] [varchar](50) NULL,
	[UserRole] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (1, N'Ryan Reynolds', N'https://drive.google.com/file/d/1cVSen0qaEGHvz4HUa5mJvFIuHFK9eEZE/view?usp=sharing', CAST(N'1976-10-23' AS Date), N'Vancouver, Canada', 188)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (2, N'Morena Baccarin', N'https://drive.google.com/file/d/1vapDao4Y63ktEtdpKNdmpRewMUOvs2WF/view?usp=sharing', CAST(N'1979-06-02' AS Date), N'Rio de Janeiro, Brazil', 171)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (3, N'T.J. Miller', N'https://drive.google.com/file/d/1u9NvfkXXnLDrA4o3D2KZoio5DYat61mw/view?usp=sharing', CAST(N'1981-06-04' AS Date), N'Denver, Colorado, USA', 188)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (4, N'Benedict Cumberbatch', N'https://drive.google.com/file/d/1paTEKXdJPqKpwnP8p-zeY2lQnU7Ei3Oq/view?usp=sharing', CAST(N'1976-07-19' AS Date), N'Hammersmith, London, England, UK', 183)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (5, N'Chiwetel Ejiofor', N'https://drive.google.com/file/d/1sZkaq6kkR7P8nEK4nmdFZmcSmMVCXvB7/view?usp=sharing', CAST(N'1977-07-10' AS Date), N'Forest Gate, London, England, UK', 178)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (6, N'Rachel McAdams', N'https://drive.google.com/file/d/1J404DoXeHfGN5cLOPCa7rQ8C9lyLQn9Q/view?usp=sharing', CAST(N'1978-11-17' AS Date), N'London, Ontario, Canada', 163)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (7, N'Timothee Chalamet', N'https://drive.google.com/file/d/1g3k1Hbl1ADkWPNxa9lm6RhGKOaYKJEOo/view?usp=sharing', CAST(N'1995-12-27' AS Date), N'New York City, New York, USA', 178)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (8, N'Rebecca Ferguson', N'https://drive.google.com/file/d/1v6FOZYI6_Q4P2J5XpCmfiXp4dsJN5U_g/view?usp=sharing', CAST(N'1983-10-19' AS Date), N'Sweden', 165)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (9, N'Zendaya', N'https://drive.google.com/file/d/1h4h8Mr4q3YrBaGTYxEEoB8VwXc-FChdO/view?usp=sharing', CAST(N'1996-09-01' AS Date), N'Oakland, California, USA', 178)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (10, N'Olivia Colman', N'https://drive.google.com/file/d/1iXnCcTN9oRyGz4tjm-rPMsXOR5hVftQb/view?usp=sharing', CAST(N'1974-01-30' AS Date), N'Norwich, Norfolk, England, UK', 170)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (11, N'Hugh Grant', N'https://drive.google.com/file/d/1qT25fDLNHV5PNkJmud-Zn6IuZAOBIUZn/view?usp=sharing', CAST(N'1960-09-09' AS Date), N'Hammersmith, London, England, UK', 180)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (12, N'Matthew McConaughey', N'https://drive.google.com/file/d/1KaEHGzZ_odDHzSUtzx91B_GMB8-dvEeO/view?usp=sharing', CAST(N'1969-11-04' AS Date), N'Uvalde, Texas, USA', 182)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (13, N'Charlie Hunnam', N'https://drive.google.com/file/d/1YMlrf9Wi03g03mDTPajuTVTEe2kK9TMd/view?usp=sharing', CAST(N'1980-04-10' AS Date), N'Newcastle upon Tyne, Tyne and Wear, England, UK', 183)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (14, N'Michelle Dockery', N'https://drive.google.com/file/d/1NS-N5WR5A2cSKG0l8FBxB-wgL4iMSpTY/view?usp=sharing', CAST(N'1981-12-15' AS Date), N'Barking, Essex, England, UK', 173)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (15, N'Shameik Moore', N'https://drive.google.com/file/d/14tmW_vAVJ3i-MCdiNO04s4byuMI2ziyA/view?usp=sharing', CAST(N'1995-05-04' AS Date), N'Atlanta, Georgia, USA', 170)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (16, N'Hailee Steinfeld', N'https://drive.google.com/file/d/1faBpgyAvK1DYYcLSivyIF0KLpb60bxO8/view?usp=sharing', CAST(N'1996-12-11' AS Date), N'Tarzana, Los Angeles, California, USA', 174)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (17, N'Brian Tyree Henry', N'https://drive.google.com/file/d/1ILzo1Wvvy1PluNSosMhyb3cwmo0vneqP/view?usp=sharing', CAST(N'1982-03-31' AS Date), N'Fayetteville, North Carolina, USA', 188)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (18, N'Stephanie Beatriz', N'https://drive.google.com/file/d/19V9khJI-ZhiDMhEXahgzGnqk-lsd89xI/view?usp=sharing', CAST(N'1981-12-10' AS Date), N'Neuquen, Argentina', 168)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (19, N'John Leguizamo', N'https://drive.google.com/file/d/1KXPknqOOoKORjihSPDdCMNBUDvm5b2-h/view?usp=sharing', CAST(N'1960-07-22' AS Date), N'Bogota, Colombia', 169)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (20, N'Ryan Gosling', N'https://drive.google.com/file/d/1Poo45Fkcq8Rov838N6H_1w9eWzKXP7ux/view?usp=sharing', CAST(N'1980-11-12' AS Date), N'London, Ontario, Canada', 184)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (21, N'Carey Mulligan', N'https://drive.google.com/file/d/1njcPJadsBUDMrF9ndEvpEtVQPMi-5Tze/view?usp=sharing', CAST(N'1985-05-28' AS Date), N'Westminster, London, England, UK', 170)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (22, N'Bryan Cranston', N'https://drive.google.com/file/d/1eZvzzz1BCeXGBYHYki4uTmZx6cYQTjDr/view?usp=sharing', CAST(N'1956-03-07' AS Date), N'Hollywood, California, USA', 179)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (23, N'Matt Damon', N'https://drive.google.com/file/d/18gtcxg5hQu7WEzt-1JhXm13ZdWk6_HCp/view?usp=sharing', CAST(N'1970-10-08' AS Date), N'Boston, Massachusetts, USA', 178)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (24, N'Christian Bale', N'https://drive.google.com/file/d/1PJAmpMJAAnS9OY7CA5jkcDuBdIM6lW_6/view?usp=sharing', CAST(N'1974-01-30' AS Date), N'Haverfordwest, Pembrokeshire, Wales, UK', 183)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (25, N'John Travolta', N'https://drive.google.com/file/d/1vEORaSqx0oiNf0jEErBlHWE4-_XyWUOw/view?usp=sharing', CAST(N'1954-02-18' AS Date), N'Englewood, New Jersey, USA', 188)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (26, N'Uma Thurman', N'https://drive.google.com/file/d/1RAZv5Jck1aVax9WKPqAd5zhzNsmOGM6Y/view?usp=sharing', CAST(N'1970-04-29' AS Date), N'Boston, Massachusetts, USA', 181)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (27, N'Samuel L. Jackson', N'https://drive.google.com/file/d/1wT6hnC3Fm5pttxQ_g4jNY0pTI5dwPLGi/view?usp=sharing', CAST(N'1948-12-21' AS Date), N'Washington D.C., USA', 189)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (28, N'Brad Pitt', N'https://drive.google.com/file/d/1yoly-xdlNF7xifXfi20-XRiz_lXWUFhw/view?usp=sharing', CAST(N'1963-12-18' AS Date), N'Shawnee, Oklahoma, USA', 180)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (29, N'Diane Kruger', N'https://drive.google.com/file/d/1gklwXTEOHMCYZKQECuFWiPsEL6KyQUpS/view?usp=sharing', CAST(N'1976-07-15' AS Date), N'Algermissen, Lower Saxony, West Germany', 170)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (30, N'Maria Ehrich', N'https://drive.google.com/file/d/17QYoz9Eb-CQa7EMpT8cBTKBRZE9dITxr/view?usp=sharing', CAST(N'1993-02-26' AS Date), N'Erfurt, Germany', 174)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (31, N'Jannis Niewohner', N'https://drive.google.com/file/d/1mfXuQQiSvGWdRTzdPiLJLk9VfPw3YO_4/view?usp=sharing', CAST(N'1992-03-30' AS Date), N'Krefeld, North Rhine-Westphalia, Germany', 185)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (32, N'Tom Hanks', N'https://drive.google.com/file/d/1YdOQkIUDdH7JBLWy0NYv_v_ath4Jqwe5/view?usp=sharing', CAST(N'1956-07-09' AS Date), N'Concord, California, USA', 183)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (33, N'Robin Wright', N'https://drive.google.com/file/d/1kF6fDtKNSM4Jsw6Jz-_YX3GyLCwxxFi2/view?usp=sharing', CAST(N'1966-04-08' AS Date), N'Dallas, Texas, USA', 165)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (34, N'Mario Casas', N'https://drive.google.com/file/d/1VpkDccZLUcq97cJc7xIe6U96_14nwsWa/view?usp=sharing', CAST(N'1986-06-12' AS Date), N'A Coruna, A Coruna, Galicia, Spain', 180)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (35, N'Maria Valverde', N'https://drive.google.com/file/d/13zp768D0jDKr3-K52wZf7Le7oo6QV6eZ/view?usp=sharing', CAST(N'1987-03-24' AS Date), N'Madrid, Spain', 165)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (36, N'Mila Kunis', N'https://drive.google.com/file/d/10WtRsi92x0m8whZxE7bhHdNB8axc4O52/view?usp=sharing', CAST(N'1983-08-14' AS Date), N'Chernivtsi, Ukraine', 163)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (37, N'Kathryn Hahn', N'https://drive.google.com/file/d/18DGE0CehGP-h9VmqEA-3M54vPrE30pmQ/view?usp=sharing', CAST(N'1973-07-23' AS Date), N'Westchester, Illinois, USA', 165)
INSERT [dbo].[Actors] ([ActorID], [ActorFullName], [ActorPhoto], [ActorBirthday], [ActorCountry], [ActorHeight]) VALUES (38, N'Kristen Bell', N'https://drive.google.com/file/d/1zxfVqS4uNLY1CRr7vmSrePUbBNX6d6g0/view?usp=sharing', CAST(N'1980-07-18' AS Date), N'Huntington Woods, Michigan, USA', 155)
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 

INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (1, N'Tim Miller')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (2, N'Scott Derrickson')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (3, N'Denis Villeneuve')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (4, N'Paul King')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (5, N'Guy Ritchie')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (6, N'Joaquim Dos Santos')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (7, N'Kemp Powers')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (8, N'Justin K. Thompson')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (9, N'Jared Bush')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (10, N'Byron Howard')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (11, N'Charise Castro Smith')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (12, N'Nicolas Winding Refn')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (13, N'James Mangold')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (14, N'Quentin Tarantino')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (15, N'Felix Fuchssteiner')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (16, N'Robert Zemeckis')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (17, N'Fernando Gonzalez Molina')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (18, N'Jon Lucas')
INSERT [dbo].[Directors] ([DirectorID], [DirectorFullName]) VALUES (19, N'Scott Moore')
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (1, N'Action')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (2, N'Comedy')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (3, N'Adventure')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (4, N'Fantasy')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (5, N'Drama')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (6, N'Family')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (7, N'Crime')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (8, N'Animation')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (9, N'Musical')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (10, N'Biography')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (11, N'War')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (12, N'Romance')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Halls] ON 

INSERT [dbo].[Halls] ([HallID], [HallName], [HallType], [NumberOfRows], [NumberOfSeats]) VALUES (1, N'Hall #1', N'2D', 4, 20)
INSERT [dbo].[Halls] ([HallID], [HallName], [HallType], [NumberOfRows], [NumberOfSeats]) VALUES (2, N'Hall #2', N'3D', 5, 30)
INSERT [dbo].[Halls] ([HallID], [HallName], [HallType], [NumberOfRows], [NumberOfSeats]) VALUES (3, N'Hall #3', N'3D', 5, 50)
INSERT [dbo].[Halls] ([HallID], [HallName], [HallType], [NumberOfRows], [NumberOfSeats]) VALUES (4, N'Hall #4', N'2D', 4, 40)
INSERT [dbo].[Halls] ([HallID], [HallName], [HallType], [NumberOfRows], [NumberOfSeats]) VALUES (5, N'Hall #5', N'2D', 5, 50)
SET IDENTITY_INSERT [dbo].[Halls] OFF
GO
SET IDENTITY_INSERT [dbo].[Media] ON 

INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (1, N'Witness the origin story of Wade Wilson, who adopts the alter ego Deadpool after a rogue experiment leaves him with accelerated healing powers...and a dark, twisted sense of humor.', N'https://drive.google.com/file/d/1rlsnc2VnRvPWMG_Cbx_vmNkDbvCpFeQO/view?usp=sharing', N'https://www.youtube.com/watch?v=Xithigfg7dA')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (2, N'In Marvel Studios’ Doctor Strange, a world-famous neurosurgeon seeking a cure finds powerful magic in a mysterious place known as Kamar-Taj – the front line of a battle against unseen dark forces bent on destroying our reality.', N'https://drive.google.com/file/d/1whG5kJULPcoaa7EZLM4I3wCKxwDxrbGi/view?usp=sharing', N'https://www.youtube.com/watch?v=aWzlQ2N6qqg')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (3, N'The son of a noble family travels to a dangerous planet to ensure the future of his people in this visually stunning sci-fi epic.', N'https://drive.google.com/file/d/1pgDsV11DIwpFQrfGEue3x43E6cRCzt1W/view?usp=sharing', N'https://www.youtube.com/watch?v=8g18jFHCLXk')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (4, N'Armed with nothing but a hatful of dreams, young chocolatier Willy Wonka manages to change the world, one delectable bite at a time.', N'https://drive.google.com/file/d/1xvzDo0kOpCZR1yRtWCA5RmZaqEd8css9/view?usp=sharing', N'https://www.youtube.com/watch?v=otNh9bTjXWg')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (5, N'MICHAEL, a successful British businessman in the illegal weed market, is looking for a way out of his lucrative trade. Making money is getting tougher. It’s not the ride it once was. A savvy operator, he casts a wide net looking for buyers to take over his empire, chancing on a pair of likely lads from across the Atlantic.', N'https://drive.google.com/file/d/1vqbRXfS1UUH7PbHSEK_7RqW0nqDCwENm/view?usp=sharing', N'https://www.youtube.com/watch?v=2B0RpUGss2c')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (6, N'Miles Morales catapults across the multiverse, where he encounters a team of Spider-People charged with protecting its very existence. When the heroes clash on how to handle a new threat, Miles must redefine what it means to be a hero.', N'https://drive.google.com/file/d/1Ssg9k9PdErS4qaVsOfMsJb9m6vKtB5KQ/view?usp=sharing', N'https://www.youtube.com/watch?v=shW9i6k8cB0')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (7, N'A Colombian teenage girl has to face the frustration of being the only member of her family without magical powers.', N'https://drive.google.com/file/d/1AEykofa_XXBo77JoRns0ktb7qvFMhl0G/view?usp=sharing', N'https://www.youtube.com/watch?v=CaimKeDcudo')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (8, N'A mysterious Hollywood action film stuntman gets in trouble with gangsters when he tries to help his neighbor is husband rob a pawn shop while serving as his getaway driver.', N'https://drive.google.com/file/d/1KEiz8OsAs9hDIS3jqkPoAvyf43wiRtjA/view?usp=sharing', N'https://www.youtube.com/watch?v=KBiOF3y1W0Y')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (9, N'American car designer Carroll Shelby and driver Ken Miles battle corporate interference and the laws of physics to build a revolutionary race car for Ford in order to defeat Ferrari at the 24 Hours of Le Mans in 1966.', N'https://drive.google.com/file/d/1Q9kJFpbUA72Xmqu6BPTJYCQbVGtkyIBw/view?usp=sharing', N'https://www.youtube.com/watch?v=zyYgDtY2AMY')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (10, N'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', N'https://drive.google.com/file/d/164qXe6N9D05HB2U4eu_I0KPsS1-YHoaI/view?usp=sharing', N'https://www.youtube.com/watch?v=s7EdQ4FqbhY')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (11, N'In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner is vengeful plans for the same.', N'https://drive.google.com/file/d/1FU1zru4w2bO5ZzfoZy4BrHVBI4L7dBZB/view?usp=sharing', N'https://www.youtube.com/watch?v=sE8hc4gVyGo')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (12, N'On her 16th birthday, Gwendolyn Shepherd finds out that instead of her cousin, she has inherited a rare gene that allows her to travel through time.', N'https://drive.google.com/file/d/1ZE0lJtUiFV2jmYn-9Q-u1BL0hEZVyGk-/view?usp=sharing', N'https://www.youtube.com/watch?v=Q1rexXXgibk')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (13, N'The history of the United States from the 1950s to the 1970s unfolds from the perspective of an Alabama man with an IQ of 75, who yearns to be reunited with his childhood sweetheart.', N'https://drive.google.com/file/d/1As32HjBwNa6E-7LlQycmeVVy1KiBkXcH/view?usp=sharing', N'https://www.youtube.com/watch?v=bLvqoHBptjg')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (14, N'A privileged woman and a reckless man fall in love despite their different social classes.', N'https://drive.google.com/file/d/1zDbA_DPu98VF9OjrMXQVgbYkds3R4xs1/view?usp=sharing', N'https://www.youtube.com/watch?v=aQauUbrwlqA')
INSERT [dbo].[Media] ([MediaID], [MovieDescription], [MoviePhoto], [MovieTrailer]) VALUES (15, N'When three overworked and under-appreciated moms are pushed beyond their limits, they ditch their conventional responsibilities for a jolt of long overdue freedom, fun and comedic self-indulgence.', N'https://drive.google.com/file/d/1fyrvuEIXyReARFhWZEohCi-eBTGyMq-w/view?usp=sharing', N'https://www.youtube.com/watch?v=iKCw-kqo3cs')
SET IDENTITY_INSERT [dbo].[Media] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie_Actor] ON 

INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (1, 1, 1, N'Wade / Deadpool')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (2, 1, 2, N'Vanessa')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (3, 1, 3, N'Weasel')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (4, 2, 4, N'Dr. Stephen Strange')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (5, 2, 5, N'Mordo')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (6, 2, 6, N'Christine Palmer')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (7, 3, 7, N'Paul Atreides')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (8, 3, 8, N'Lady Jessica')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (9, 3, 9, N'Chani')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (10, 4, 7, N'Willy Wonka')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (11, 4, 10, N'Mrs. Scrubitt')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (12, 4, 11, N'Oompa Loompa')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (13, 5, 12, N'Michael Pearson')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (14, 5, 13, N'Ray')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (15, 5, 14, N'Rosalind Pearson')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (16, 6, 15, N'Miles Morales')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (17, 6, 16, N'Gwen Stacy')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (18, 6, 17, N'Jeff Morales')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (19, 7, 18, N'Mirabel')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (20, 7, 19, N'Bruno')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (21, 8, 20, N'Driver')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (22, 8, 21, N'Irene')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (23, 8, 22, N'Shannon')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (24, 9, 23, N'Carroll Shelby')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (25, 9, 24, N'Ken Miles')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (26, 10, 25, N'Vincent Vega')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (27, 10, 26, N'Mia Wallace')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (28, 10, 27, N'Jules Winnfield')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (29, 11, 28, N'Lt. Aldo Raine')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (30, 11, 29, N'Bridget von Hammersmark')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (31, 12, 30, N'Gwendolyn Shepherd')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (32, 12, 31, N'Gideon de Villiers')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (33, 13, 32, N'Forrest Gump')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (34, 13, 33, N'Jenny Curran')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (35, 14, 34, N'Hugo')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (36, 14, 35, N'Babi')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (37, 15, 36, N'Amy')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (38, 15, 37, N'Carla')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (39, 15, 38, N'Kiki')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (41, 69, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (42, 70, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (43, 71, 1, N'Alfred Schmidt')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (44, 2, 1, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (45, 2, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (46, 2, 3, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (47, 2, 1, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (48, 2, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (49, 2, 3, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (50, 2, 4, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (51, 74, 1, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (52, 74, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (53, 74, 3, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (54, 74, 4, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (55, 75, 1, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (56, 75, 2, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (57, 75, 3, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (58, 75, 4, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (59, 76, 1, N'ACtornickname1')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (60, 76, 2, N'ActrNickname2')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (61, 76, 3, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (62, 76, 4, NULL)
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (63, 76, 5, N'string')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (64, 78, 1, N'string')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (65, 78, 2, N'string123123')
INSERT [dbo].[Movie_Actor] ([MovieActorID], [MovieID], [ActorID], [ActorNickname]) VALUES (66, 76, 6, N'string123123')
SET IDENTITY_INSERT [dbo].[Movie_Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie_Director] ON 

INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (1, 1, 1)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (2, 2, 2)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (3, 3, 3)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (4, 4, 4)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (5, 5, 5)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (6, 6, 6)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (6, 7, 7)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (6, 8, 8)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (7, 9, 9)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (7, 10, 10)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (7, 11, 11)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (8, 12, 12)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (9, 13, 13)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (10, 14, 14)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (11, 14, 15)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (12, 15, 16)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (13, 16, 17)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (14, 17, 18)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (15, 18, 19)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (15, 19, 20)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (75, 1, 21)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (76, 1, 22)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (78, 1, 23)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (78, 2, 24)
INSERT [dbo].[Movie_Director] ([MovieID], [DirectorID], [MovieDirectorID]) VALUES (76, 2, 25)
SET IDENTITY_INSERT [dbo].[Movie_Director] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie_Genre] ON 

INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (1, 1, 1)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (1, 2, 2)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (2, 1, 3)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (2, 3, 4)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (2, 4, 5)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (3, 1, 6)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (3, 3, 7)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (3, 5, 8)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (4, 2, 9)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (4, 3, 10)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (4, 6, 11)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (5, 1, 12)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (5, 7, 13)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (6, 1, 14)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (6, 8, 15)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (6, 3, 16)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (6, 4, 17)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (7, 8, 18)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (7, 2, 19)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (7, 6, 20)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (7, 4, 21)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (7, 9, 22)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (8, 1, 23)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (8, 5, 24)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (9, 1, 25)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (9, 10, 26)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (10, 7, 27)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (10, 5, 28)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (11, 3, 29)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (11, 5, 30)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (11, 11, 31)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (12, 1, 32)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (12, 3, 33)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (12, 5, 34)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (12, 4, 35)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (13, 5, 36)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (13, 12, 37)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (14, 1, 38)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (14, 5, 39)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (14, 12, 40)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (15, 2, 41)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (75, 1, 42)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (75, 2, 43)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (75, 3, 44)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (76, 1, 45)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (76, 2, 46)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (76, 3, 47)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (78, 1, 48)
INSERT [dbo].[Movie_Genre] ([MovieID], [GenreID], [MovieGenreID]) VALUES (78, 2, 49)
SET IDENTITY_INSERT [dbo].[Movie_Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie_Screenwriter] ON 

INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (1, 1, 1)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (1, 2, 2)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (2, 3, 3)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (2, 4, 4)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (2, 5, 5)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (3, 3, 6)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (3, 6, 7)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (3, 7, 8)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (4, 8, 9)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (4, 9, 10)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (4, 10, 11)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (5, 11, 12)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (5, 12, 13)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (5, 13, 14)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (6, 14, 15)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (6, 15, 16)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (6, 16, 17)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (7, 17, 18)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (7, 18, 19)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (7, 19, 20)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (8, 20, 21)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (8, 21, 22)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (9, 22, 23)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (9, 23, 24)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (9, 24, 25)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (10, 25, 26)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (10, 26, 27)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (11, 25, 28)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (12, 27, 29)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (12, 28, 30)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (13, 7, 31)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (13, 29, 32)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (14, 30, 33)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (14, 31, 34)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (15, 32, 35)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (15, 33, 36)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (75, 2, 37)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (75, 3, 38)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (76, 2, 39)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (76, 3, 40)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (78, 1, 41)
INSERT [dbo].[Movie_Screenwriter] ([MovieID], [ScreenwriterID], [MovieScreenwriterID]) VALUES (76, 1, 42)
SET IDENTITY_INSERT [dbo].[Movie_Screenwriter] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (1, N'Deadpool', 1, CAST(N'01:48:00' AS Time), N'USA', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'8.0/10', CAST(N'2024-05-25' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (2, N'Doctor Strange', 2, CAST(N'01:55:00' AS Time), N'USA', CAST(N'2016-10-13' AS Date), CAST(N'2016-10-28' AS Date), N'7.5/10', CAST(N'2024-06-01' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (3, N'Dune', 3, CAST(N'02:35:00' AS Time), N'USA, Canada, Hungary', CAST(N'2021-09-03' AS Date), CAST(N'2021-09-16' AS Date), N'8.0/10', CAST(N'2024-06-05' AS Date), N'12+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (4, N'Wonka', 4, CAST(N'01:56:00' AS Time), N'USA, UK, Canada', CAST(N'2023-11-28' AS Date), CAST(N'2023-12-14' AS Date), N'7.0/10', CAST(N'2024-06-23' AS Date), N'0+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (5, N'The Gentlemen', 5, CAST(N'01:53:00' AS Time), N'USA', CAST(N'2019-12-03' AS Date), CAST(N'2020-01-30' AS Date), N'7.8/10', CAST(N'2024-06-02' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (6, N'Spider-Man: Across the Spider-Verse', 6, CAST(N'02:20:00' AS Time), N'USA', CAST(N'2023-05-31' AS Date), CAST(N'2023-06-01' AS Date), N'8.6/10', CAST(N'2024-07-02' AS Date), N'12+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (7, N'Encanto', 7, CAST(N'01:42:00' AS Time), N'USA, Colombia', CAST(N'2021-11-03' AS Date), CAST(N'2021-11-25' AS Date), N'7.2/10', CAST(N'2024-07-09' AS Date), N'0+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (8, N'Drive', 8, CAST(N'01:40:00' AS Time), N'USA', CAST(N'2011-05-20' AS Date), CAST(N'2011-06-05' AS Date), N'7.8/10', CAST(N'2024-06-01' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (9, N'Ford v Ferrari', 9, CAST(N'02:32:00' AS Time), N'USA, France', CAST(N'2019-08-30' AS Date), CAST(N'2019-11-14' AS Date), N'8.1/10', CAST(N'2024-06-25' AS Date), N'12+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (10, N'Pulp Fiction', 10, CAST(N'02:34:00' AS Time), N'USA', CAST(N'1994-05-21' AS Date), CAST(N'1994-06-30' AS Date), N'8.9/10', CAST(N'2024-08-09' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (11, N'Inglourious Basterds', 11, CAST(N'02:33:00' AS Time), N'Germany, USA', CAST(N'2009-07-23' AS Date), CAST(N'2009-08-20' AS Date), N'8.4/10', CAST(N'2024-06-02' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (12, N'Rubinrot', 12, CAST(N'02:02:00' AS Time), N'Germany', CAST(N'2013-03-05' AS Date), CAST(N'2013-03-14' AS Date), N'6.0/10', CAST(N'2024-06-06' AS Date), N'12+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (13, N'Forest Gump', 13, CAST(N'02:22:00' AS Time), N'USA', CAST(N'1994-07-06' AS Date), CAST(N'2019-05-30' AS Date), N'8.8/10', CAST(N'2024-07-25' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (14, N'Three steps above heaven', 14, CAST(N'01:58:00' AS Time), N'Spain', CAST(N'2010-12-03' AS Date), CAST(N'2011-11-03' AS Date), N'6.8/10', CAST(N'2024-06-12' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (15, N'Bad moms', 15, CAST(N'01:40:00' AS Time), N'USA, China', CAST(N'2016-07-28' AS Date), CAST(N'2016-08-25' AS Date), N'6.2/10', CAST(N'2024-06-02' AS Date), N'16+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (21, N'string', 1, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (33, N'string1123123', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (48, N'string1323132', 1, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (49, N'string1323132123123', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (50, N'string13231321231231321', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (61, N'string132313212', 1, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (62, N'string1323132124', 1, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (63, N'string1323132123121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (64, N'string1323132123123123121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (65, N'string13231321231231231214214214221231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (66, N'string132313212312312312123121221333', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (67, N'string1323132123123123124214124124124121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (68, N'string1323132123123123112421424121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (69, N'string13231321231231212512412123243121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (70, N'string1323132123123121251241212321242141241243121231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'18+')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (71, N'string13231321dasdas231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (72, N'string13231jfajsdssad231233', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (73, N'test2', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (74, N'test221312', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (75, N'test212323', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (76, N'teststringPatch', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MediaID], [Duration], [Country], [WorldPremiere], [UkrainePremiere], [Rating], [EndOfShow], [Limitations]) VALUES (78, N'test21231312323', 2, CAST(N'01:48:00' AS Time), N'string', CAST(N'2016-02-08' AS Date), CAST(N'2016-02-11' AS Date), N'string', CAST(N'2024-05-25' AS Date), N'string')
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieSessions] ON 

INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (1, 1, CAST(N'19:40:00' AS Time), 180, 200, 220, 2)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (2, 2, CAST(N'20:30:00' AS Time), 120, 140, 160, 3)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (3, 3, CAST(N'17:50:00' AS Time), 130, 150, 170, 3)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (4, 4, CAST(N'16:20:00' AS Time), 160, 175, 190, 2)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (5, 5, CAST(N'15:30:00' AS Time), 150, 170, 190, 1)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (6, 6, CAST(N'14:10:00' AS Time), 140, 160, 180, 3)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (7, 7, CAST(N'13:10:00' AS Time), 170, 190, 210, 2)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (8, 8, CAST(N'17:20:00' AS Time), 150, 165, 180, 4)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (9, 9, CAST(N'13:40:00' AS Time), 160, 180, 200, 5)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (10, 10, CAST(N'20:20:00' AS Time), 160, 175, 190, 4)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (11, 11, CAST(N'16:30:00' AS Time), 140, 155, 170, 5)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (12, 12, CAST(N'12:40:00' AS Time), 160, 180, 200, 1)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (13, 13, CAST(N'14:20:00' AS Time), 140, 155, 170, 4)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (14, 14, CAST(N'20:20:00' AS Time), 170, 185, 200, 1)
INSERT [dbo].[MovieSessions] ([MovieSessionID], [MovieID], [StartTime], [TheLowestPrice], [MiddlePrice], [TheHighestPrice], [HallID]) VALUES (15, 15, CAST(N'19:50:00' AS Time), 110, 130, 150, 5)
SET IDENTITY_INSERT [dbo].[MovieSessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (1, 1, 21, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (2, 1, 22, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (3, 1, 23, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (4, 1, 24, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (5, 1, 25, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (6, 1, 26, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (7, 1, 27, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (8, 1, 28, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (9, 1, 29, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (10, 1, 30, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (11, 1, 31, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (12, 1, 32, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (13, 1, 33, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (14, 1, 34, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (15, 1, 35, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (16, 1, 36, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (17, 1, 37, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (18, 1, 38, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (19, 1, 39, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (20, 1, 40, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (21, 1, 41, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (22, 1, 42, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (23, 1, 43, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (24, 1, 44, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (25, 1, 45, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (26, 1, 46, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (27, 1, 47, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (28, 1, 48, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (29, 1, 49, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (30, 1, 50, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (31, 2, 51, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (32, 2, 52, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (33, 2, 53, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (34, 2, 54, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (35, 2, 55, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (36, 2, 56, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (37, 2, 57, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (38, 2, 58, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (39, 2, 59, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (40, 2, 60, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (41, 2, 61, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (42, 2, 62, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (43, 2, 63, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (44, 2, 64, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (45, 2, 65, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (46, 2, 66, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (47, 2, 67, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (48, 2, 68, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (49, 2, 69, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (50, 2, 70, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (51, 2, 71, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (52, 2, 72, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (53, 2, 73, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (54, 2, 74, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (55, 2, 75, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (56, 2, 76, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (57, 2, 77, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (58, 2, 78, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (59, 2, 79, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (60, 2, 80, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (61, 2, 81, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (62, 2, 82, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (63, 2, 83, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (64, 2, 84, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (65, 2, 85, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (66, 2, 86, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (67, 2, 87, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (68, 2, 88, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (69, 2, 89, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (70, 2, 90, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (71, 2, 91, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (72, 2, 92, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (73, 2, 93, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (74, 2, 94, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (75, 2, 95, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (76, 2, 96, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (77, 2, 97, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (78, 2, 98, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (79, 2, 99, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (80, 2, 100, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (81, 3, 51, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (82, 3, 52, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (83, 3, 53, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (84, 3, 54, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (85, 3, 55, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (86, 3, 56, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (87, 3, 57, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (88, 3, 58, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (89, 3, 59, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (90, 3, 60, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (91, 3, 61, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (92, 3, 62, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (93, 3, 63, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (94, 3, 64, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (95, 3, 65, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (96, 3, 66, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (97, 3, 67, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (98, 3, 68, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (99, 3, 69, 180)
GO
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (100, 3, 70, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (101, 3, 71, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (102, 3, 72, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (103, 3, 73, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (104, 3, 74, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (105, 3, 75, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (106, 3, 76, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (107, 3, 77, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (108, 3, 78, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (109, 3, 79, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (110, 3, 80, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (111, 3, 81, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (112, 3, 82, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (113, 3, 83, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (114, 3, 84, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (115, 3, 85, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (116, 3, 86, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (117, 3, 87, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (118, 3, 88, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (119, 3, 89, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (120, 3, 90, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (121, 3, 91, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (122, 3, 92, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (123, 3, 93, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (124, 3, 94, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (125, 3, 95, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (126, 3, 96, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (127, 3, 97, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (128, 3, 98, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (129, 3, 99, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (130, 3, 100, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (131, 4, 21, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (132, 4, 22, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (133, 4, 23, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (134, 4, 24, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (135, 4, 25, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (136, 4, 26, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (137, 4, 27, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (138, 4, 28, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (139, 4, 29, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (140, 4, 30, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (141, 4, 31, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (142, 4, 32, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (143, 4, 33, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (144, 4, 34, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (145, 4, 35, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (146, 4, 36, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (147, 4, 37, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (148, 4, 38, 130)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (149, 4, 39, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (150, 4, 40, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (151, 4, 41, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (152, 4, 42, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (153, 4, 43, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (154, 4, 44, 120)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (155, 4, 45, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (156, 4, 46, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (157, 4, 47, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (158, 4, 48, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (159, 4, 49, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (160, 4, 50, 110)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (161, 5, 1, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (162, 5, 2, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (163, 5, 3, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (164, 5, 4, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (165, 5, 5, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (166, 5, 6, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (167, 5, 7, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (168, 5, 8, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (169, 5, 9, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (170, 5, 10, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (171, 5, 11, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (172, 5, 12, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (173, 5, 13, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (174, 5, 14, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (175, 5, 15, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (176, 5, 16, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (177, 5, 17, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (178, 5, 18, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (179, 5, 19, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (180, 5, 20, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (181, 6, 51, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (182, 6, 52, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (183, 6, 53, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (184, 6, 54, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (185, 6, 55, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (186, 6, 56, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (187, 6, 57, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (188, 6, 58, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (189, 6, 59, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (190, 6, 60, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (191, 6, 61, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (192, 6, 62, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (193, 6, 63, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (194, 6, 64, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (195, 6, 65, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (196, 6, 66, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (197, 6, 67, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (198, 6, 68, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (199, 6, 69, 190)
GO
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (200, 6, 70, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (201, 6, 71, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (202, 6, 72, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (203, 6, 73, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (204, 6, 74, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (205, 6, 75, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (206, 6, 76, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (207, 6, 77, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (208, 6, 78, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (209, 6, 79, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (210, 6, 80, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (211, 6, 81, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (212, 6, 82, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (213, 6, 83, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (214, 6, 84, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (215, 6, 85, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (216, 6, 86, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (217, 6, 87, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (218, 6, 88, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (219, 6, 89, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (220, 6, 90, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (221, 6, 91, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (222, 6, 92, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (223, 6, 93, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (224, 6, 94, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (225, 6, 95, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (226, 6, 96, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (227, 6, 97, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (228, 6, 98, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (229, 6, 99, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (230, 6, 100, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (231, 7, 21, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (232, 7, 22, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (233, 7, 23, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (234, 7, 24, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (235, 7, 25, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (236, 7, 26, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (237, 7, 27, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (238, 7, 28, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (239, 7, 29, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (240, 7, 30, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (241, 7, 31, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (242, 7, 32, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (243, 7, 33, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (244, 7, 34, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (245, 7, 35, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (246, 7, 36, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (247, 7, 37, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (248, 7, 38, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (249, 7, 39, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (250, 7, 40, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (251, 7, 41, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (252, 7, 42, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (253, 7, 43, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (254, 7, 44, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (255, 7, 45, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (256, 7, 46, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (257, 7, 47, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (258, 7, 48, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (259, 7, 49, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (260, 7, 50, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (261, 8, 101, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (262, 8, 102, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (263, 8, 103, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (264, 8, 104, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (265, 8, 105, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (266, 8, 106, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (267, 8, 107, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (268, 8, 108, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (269, 8, 109, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (270, 8, 110, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (271, 8, 111, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (272, 8, 112, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (273, 8, 113, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (274, 8, 114, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (275, 8, 115, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (276, 8, 116, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (277, 8, 117, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (278, 8, 118, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (279, 8, 119, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (280, 8, 120, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (281, 8, 121, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (282, 8, 122, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (283, 8, 123, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (284, 8, 124, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (285, 8, 125, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (286, 8, 126, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (287, 8, 127, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (288, 8, 128, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (289, 8, 129, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (290, 8, 130, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (291, 8, 131, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (292, 8, 132, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (293, 8, 133, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (294, 8, 134, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (295, 8, 135, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (296, 8, 136, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (297, 8, 137, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (298, 8, 138, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (299, 8, 139, 160)
GO
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (300, 8, 140, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (301, 9, 141, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (302, 9, 142, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (303, 9, 143, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (304, 9, 144, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (305, 9, 145, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (306, 9, 146, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (307, 9, 147, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (308, 9, 148, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (309, 9, 149, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (310, 9, 150, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (311, 9, 151, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (312, 9, 152, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (313, 9, 153, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (314, 9, 154, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (315, 9, 155, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (316, 9, 156, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (317, 9, 157, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (318, 9, 158, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (319, 9, 159, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (320, 9, 160, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (321, 9, 161, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (322, 9, 162, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (323, 9, 163, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (324, 9, 164, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (325, 9, 165, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (326, 9, 166, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (327, 9, 167, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (328, 9, 168, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (329, 9, 169, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (330, 9, 170, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (331, 9, 171, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (332, 9, 172, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (333, 9, 173, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (334, 9, 174, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (335, 9, 175, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (336, 9, 176, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (337, 9, 177, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (338, 9, 178, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (339, 9, 179, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (340, 9, 180, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (341, 9, 181, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (342, 9, 182, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (343, 9, 183, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (344, 9, 184, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (345, 9, 185, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (346, 9, 186, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (347, 9, 187, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (348, 9, 188, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (349, 9, 189, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (350, 9, 190, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (351, 10, 101, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (352, 10, 102, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (353, 10, 103, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (354, 10, 104, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (355, 10, 105, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (356, 10, 106, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (357, 10, 107, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (358, 10, 108, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (359, 10, 109, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (360, 10, 110, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (361, 10, 111, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (362, 10, 112, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (363, 10, 113, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (364, 10, 114, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (365, 10, 115, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (366, 10, 116, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (367, 10, 117, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (368, 10, 118, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (369, 10, 119, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (370, 10, 120, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (371, 10, 121, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (372, 10, 122, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (373, 10, 123, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (374, 10, 124, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (375, 10, 125, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (376, 10, 126, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (377, 10, 127, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (378, 10, 128, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (379, 10, 129, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (380, 10, 130, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (381, 10, 131, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (382, 10, 132, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (383, 10, 133, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (384, 10, 134, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (385, 10, 135, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (386, 10, 136, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (387, 10, 137, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (388, 10, 138, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (389, 10, 139, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (390, 10, 140, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (391, 11, 141, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (392, 11, 142, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (393, 11, 143, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (394, 11, 144, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (395, 11, 145, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (396, 11, 146, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (397, 11, 147, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (398, 11, 148, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (399, 11, 149, 200)
GO
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (400, 11, 150, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (401, 11, 151, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (402, 11, 152, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (403, 11, 153, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (404, 11, 154, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (405, 11, 155, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (406, 11, 156, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (407, 11, 157, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (408, 11, 158, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (409, 11, 159, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (410, 11, 160, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (411, 11, 161, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (412, 11, 162, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (413, 11, 163, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (414, 11, 164, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (415, 11, 165, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (416, 11, 166, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (417, 11, 167, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (418, 11, 168, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (419, 11, 169, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (420, 11, 170, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (421, 11, 171, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (422, 11, 172, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (423, 11, 173, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (424, 11, 174, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (425, 11, 175, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (426, 11, 176, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (427, 11, 177, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (428, 11, 178, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (429, 11, 179, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (430, 11, 180, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (431, 11, 181, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (432, 11, 182, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (433, 11, 183, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (434, 11, 184, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (435, 11, 185, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (436, 11, 186, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (437, 11, 187, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (438, 11, 188, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (439, 11, 189, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (440, 11, 190, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (441, 12, 1, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (442, 12, 2, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (443, 12, 3, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (444, 12, 4, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (445, 12, 5, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (446, 12, 6, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (447, 12, 7, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (448, 12, 8, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (449, 12, 9, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (450, 12, 10, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (451, 12, 11, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (452, 12, 12, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (453, 12, 13, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (454, 12, 14, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (455, 12, 15, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (456, 12, 16, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (457, 12, 17, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (458, 12, 18, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (459, 12, 19, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (460, 12, 20, 140)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (461, 13, 101, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (462, 13, 102, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (463, 13, 103, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (464, 13, 104, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (465, 13, 105, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (466, 13, 106, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (467, 13, 107, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (468, 13, 108, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (469, 13, 109, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (470, 13, 110, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (471, 13, 111, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (472, 13, 112, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (473, 13, 113, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (474, 13, 114, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (475, 13, 115, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (476, 13, 116, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (477, 13, 117, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (478, 13, 118, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (479, 13, 119, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (480, 13, 120, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (481, 13, 121, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (482, 13, 122, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (483, 13, 123, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (484, 13, 124, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (485, 13, 125, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (486, 13, 126, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (487, 13, 127, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (488, 13, 128, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (489, 13, 129, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (490, 13, 130, 160)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (491, 13, 131, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (492, 13, 132, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (493, 13, 133, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (494, 13, 134, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (495, 13, 135, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (496, 13, 136, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (497, 13, 137, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (498, 13, 138, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (499, 13, 139, 150)
GO
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (500, 13, 140, 150)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (501, 14, 1, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (502, 14, 2, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (503, 14, 3, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (504, 14, 4, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (505, 14, 5, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (506, 14, 6, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (507, 14, 7, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (508, 14, 8, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (509, 14, 9, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (510, 14, 10, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (511, 14, 11, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (512, 14, 12, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (513, 14, 13, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (514, 14, 14, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (515, 14, 15, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (516, 14, 16, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (517, 14, 17, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (518, 14, 18, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (519, 14, 19, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (520, 14, 20, 170)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (521, 15, 141, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (522, 15, 142, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (523, 15, 143, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (524, 15, 144, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (525, 15, 145, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (526, 15, 146, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (527, 15, 147, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (528, 15, 148, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (529, 15, 149, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (530, 15, 150, 220)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (531, 15, 151, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (532, 15, 152, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (533, 15, 153, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (534, 15, 154, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (535, 15, 155, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (536, 15, 156, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (537, 15, 157, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (538, 15, 158, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (539, 15, 159, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (540, 15, 160, 210)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (541, 15, 161, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (542, 15, 162, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (543, 15, 163, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (544, 15, 164, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (545, 15, 165, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (546, 15, 166, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (547, 15, 167, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (548, 15, 168, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (549, 15, 169, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (550, 15, 170, 200)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (551, 15, 171, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (552, 15, 172, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (553, 15, 173, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (554, 15, 174, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (555, 15, 175, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (556, 15, 176, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (557, 15, 177, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (558, 15, 178, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (559, 15, 179, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (560, 15, 180, 190)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (561, 15, 181, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (562, 15, 182, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (563, 15, 183, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (564, 15, 184, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (565, 15, 185, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (566, 15, 186, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (567, 15, 187, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (568, 15, 188, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (569, 15, 189, 180)
INSERT [dbo].[Prices] ([PriceID], [MovieID], [SeatReservationID], [Price]) VALUES (570, 15, 190, 180)
SET IDENTITY_INSERT [dbo].[Prices] OFF
GO
SET IDENTITY_INSERT [dbo].[Screenwriters] ON 

INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (1, N'Rhett Reese')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (2, N'Paul Wernick')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (3, N'Jon Spaihts')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (4, N'Scott Derrickson')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (5, N'C.Robert Cargill')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (6, N'Denis Villeneuve')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (7, N'Eric Roth')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (8, N'Roald Dahl')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (9, N'Paul King')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (10, N'Simon Farnaby')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (11, N'Guy Ritchie')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (12, N'Ivan Atkinson')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (13, N'Marn Davies')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (14, N'Phil Lord')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (15, N'Christopher Miller')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (16, N'Dave Callaham')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (17, N'Charise Castro Smith')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (18, N'Jared Bush')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (19, N'Byron Howard')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (20, N'Hossein Amini')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (21, N'James Sallis')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (22, N'Jez Butterworth')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (23, N'John-Henry Butterworth')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (24, N'Jason Keller')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (25, N'Quentin Tarantino')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (26, N'Roger Avary')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (27, N'Katharina Schode')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (28, N'Kerstin Gier')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (29, N'Winston Groom')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (30, N'Federico Moccia')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (31, N'Ramon Salazar')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (32, N'Jon Lucas')
INSERT [dbo].[Screenwriters] ([ScreenwriterID], [ScreenwriterFullName]) VALUES (33, N'Scott Moore')
SET IDENTITY_INSERT [dbo].[Screenwriters] OFF
GO
SET IDENTITY_INSERT [dbo].[SeatReservation] ON 

INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (1, 1, 1, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (2, 1, 1, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (3, 1, 1, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (4, 1, 1, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (5, 1, 1, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (6, 1, 2, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (7, 1, 2, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (8, 1, 2, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (9, 1, 2, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (10, 1, 2, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (11, 1, 3, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (12, 1, 3, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (13, 1, 3, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (14, 1, 3, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (15, 1, 3, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (16, 1, 4, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (17, 1, 4, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (18, 1, 4, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (19, 1, 4, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (20, 1, 4, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (21, 2, 1, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (22, 2, 1, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (23, 2, 1, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (24, 2, 1, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (25, 2, 1, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (26, 2, 1, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (27, 2, 2, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (28, 2, 2, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (29, 2, 2, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (30, 2, 2, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (31, 2, 2, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (32, 2, 2, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (33, 2, 3, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (34, 2, 3, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (35, 2, 3, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (36, 2, 3, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (37, 2, 3, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (38, 2, 3, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (39, 2, 4, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (40, 2, 4, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (41, 2, 4, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (42, 2, 4, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (43, 2, 4, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (44, 2, 4, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (45, 2, 5, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (46, 2, 5, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (47, 2, 5, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (48, 2, 5, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (49, 2, 5, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (50, 2, 5, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (51, 3, 1, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (52, 3, 1, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (53, 3, 1, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (54, 3, 1, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (55, 3, 1, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (56, 3, 1, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (57, 3, 1, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (58, 3, 1, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (59, 3, 1, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (60, 3, 1, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (61, 3, 2, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (62, 3, 2, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (63, 3, 2, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (64, 3, 2, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (65, 3, 2, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (66, 3, 2, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (67, 3, 2, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (68, 3, 2, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (69, 3, 2, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (70, 3, 2, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (71, 3, 3, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (72, 3, 3, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (73, 3, 3, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (74, 3, 3, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (75, 3, 3, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (76, 3, 3, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (77, 3, 3, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (78, 3, 3, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (79, 3, 3, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (80, 3, 3, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (81, 3, 4, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (82, 3, 4, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (83, 3, 4, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (84, 3, 4, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (85, 3, 4, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (86, 3, 4, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (87, 3, 4, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (88, 3, 4, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (89, 3, 4, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (90, 3, 4, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (91, 3, 5, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (92, 3, 5, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (93, 3, 5, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (94, 3, 5, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (95, 3, 5, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (96, 3, 5, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (97, 3, 5, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (98, 3, 5, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (99, 3, 5, 9, 0)
GO
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (100, 3, 5, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (101, 4, 1, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (102, 4, 1, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (103, 4, 1, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (104, 4, 1, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (105, 4, 1, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (106, 4, 1, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (107, 4, 1, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (108, 4, 1, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (109, 4, 1, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (110, 4, 1, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (111, 4, 2, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (112, 4, 2, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (113, 4, 2, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (114, 4, 2, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (115, 4, 2, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (116, 4, 2, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (117, 4, 2, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (118, 4, 2, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (119, 4, 2, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (120, 4, 2, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (121, 4, 3, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (122, 4, 3, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (123, 4, 3, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (124, 4, 3, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (125, 4, 3, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (126, 4, 3, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (127, 4, 3, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (128, 4, 3, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (129, 4, 3, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (130, 4, 3, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (131, 4, 4, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (132, 4, 4, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (133, 4, 4, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (134, 4, 4, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (135, 4, 4, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (136, 4, 4, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (137, 4, 4, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (138, 4, 4, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (139, 4, 4, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (140, 4, 4, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (141, 5, 1, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (142, 5, 1, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (143, 5, 1, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (144, 5, 1, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (145, 5, 1, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (146, 5, 1, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (147, 5, 1, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (148, 5, 1, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (149, 5, 1, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (150, 5, 1, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (151, 5, 2, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (152, 5, 2, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (153, 5, 2, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (154, 5, 2, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (155, 5, 2, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (156, 5, 2, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (157, 5, 2, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (158, 5, 2, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (159, 5, 2, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (160, 5, 2, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (161, 5, 3, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (162, 5, 3, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (163, 5, 3, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (164, 5, 3, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (165, 5, 3, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (166, 5, 3, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (167, 5, 3, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (168, 5, 3, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (169, 5, 3, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (170, 5, 3, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (171, 5, 4, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (172, 5, 4, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (173, 5, 4, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (174, 5, 4, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (175, 5, 4, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (176, 5, 4, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (177, 5, 4, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (178, 5, 4, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (179, 5, 4, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (180, 5, 4, 10, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (181, 5, 5, 1, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (182, 5, 5, 2, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (183, 5, 5, 3, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (184, 5, 5, 4, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (185, 5, 5, 5, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (186, 5, 5, 6, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (187, 5, 5, 7, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (188, 5, 5, 8, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (189, 5, 5, 9, 0)
INSERT [dbo].[SeatReservation] ([SeatReservationID], [HallID], [RowNumber], [SeatNumber], [IsReserved]) VALUES (190, 5, 5, 10, 0)
SET IDENTITY_INSERT [dbo].[SeatReservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [UserEmail], [UserPassword], [IsReserved], [isActive], [Token], [UserRole]) VALUES (2, N'OmarADmin', N'adminOmar@gmail.com', N'$argon2id$v=19$m=65536,t=3,p=1$KHkIv1PYendI+ft8NgF/gA$k99TBNmrzDllgoxbCE3WJoGNlXEWxg16TL+Gq9LEQ2c', 0, 0, NULL, N'admin')
INSERT [dbo].[Users] ([UserID], [UserName], [UserEmail], [UserPassword], [IsReserved], [isActive], [Token], [UserRole]) VALUES (3, N'OmarUser', N'userOmar@gmail.com', N'$argon2id$v=19$m=65536,t=3,p=1$aQQ+XYbmkCpsFegHha6TIQ$vdNm/tTlH2gtE8hXIlPnifxz0I+FUEjz+UZp5Pm8yTc', 0, 0, NULL, N'user')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[SeatReservation] ADD  DEFAULT ((0)) FOR [IsReserved]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsReserved]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actors] ([ActorID])
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movie_Director]  WITH CHECK ADD FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Directors] ([DirectorID])
GO
ALTER TABLE [dbo].[Movie_Director]  WITH CHECK ADD FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movie_Screenwriter]  WITH CHECK ADD FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Movie_Screenwriter]  WITH CHECK ADD FOREIGN KEY([ScreenwriterID])
REFERENCES [dbo].[Screenwriters] ([ScreenwriterID])
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD FOREIGN KEY([MediaID])
REFERENCES [dbo].[Media] ([MediaID])
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD FOREIGN KEY([SeatReservationID])
REFERENCES [dbo].[SeatReservation] ([SeatReservationID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([MovieSessionID])
REFERENCES [dbo].[MovieSessions] ([MovieSessionID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([PriceID])
REFERENCES [dbo].[Prices] ([PriceID])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[SeatReservation]  WITH CHECK ADD FOREIGN KEY([HallID])
REFERENCES [dbo].[Halls] ([HallID])
GO

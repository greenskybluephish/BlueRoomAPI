USE [BlueShades]
GO
/****** Object:  Table [dbo].[artist]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artist](
	[artist_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_artist] PRIMARY KEY CLUSTERED 
(
	[artist_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[show]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[show](
	[show_id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[venue_id] [int] NOT NULL,
	[performing_artist_id] [int] NOT NULL,
 CONSTRAINT [PK_show] PRIMARY KEY CLUSTERED 
(
	[show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venue]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venue](
	[venue_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[city] [nvarchar](255) NOT NULL,
	[state] [nvarchar](55) NOT NULL,
	[country] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_venue] PRIMARY KEY CLUSTERED 
(
	[venue_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwShow]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwShow]
AS
SELECT        dbo.show.show_id, dbo.show.date, dbo.artist.name AS artist_name, dbo.artist.artist_id, dbo.venue.venue_id, dbo.venue.name AS venue_name, dbo.venue.city, dbo.venue.state
FROM            dbo.show INNER JOIN
                         dbo.artist ON dbo.show.performing_artist_id = dbo.artist.artist_id INNER JOIN
                         dbo.venue ON dbo.show.venue_id = dbo.venue.venue_id
GO
/****** Object:  Table [dbo].[set_number]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_number](
	[set_number_id] [int] IDENTITY(1,1) NOT NULL,
	[set_index] [int] NOT NULL,
	[set_name] [nvarchar](255) NULL,
	[full_set] [bit] NOT NULL,
 CONSTRAINT [PK_set_number] PRIMARY KEY CLUSTERED 
(
	[set_number_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[song]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[song](
	[song_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](max) NULL,
	[original_artist_id] [int] NULL,
	[original_artist_name] [nvarchar](255) NULL,
 CONSTRAINT [PK_song] PRIMARY KEY CLUSTERED 
(
	[song_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[song_performance]    Script Date: 6/18/2021 6:07:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[song_performance](
	[song_performance_id] [int] IDENTITY(1,1) NOT NULL,
	[set_number_id] [int] NOT NULL,
	[song_performance_note] [nvarchar](255) NULL,
	[set_song_index] [int] NOT NULL,
	[duration_in_sec] [int] NULL,
	[media_link_id] [int] NULL,
	[show_id] [int] NOT NULL,
	[song_id] [int] NOT NULL,
	[segue_out] [bit] NOT NULL,
	[set_opener] [bit] NOT NULL,
	[set_closer] [bit] NOT NULL,
 CONSTRAINT [PK_SongPerformance] PRIMARY KEY CLUSTERED 
(
	[song_performance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[artist] ON 

INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (1, N'Airshow', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (2, N'Phish', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (3, N'Widespread Panic', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (4, N'Grateful Dead', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (5, N'Tony Rice', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (6, N'BB King', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (7, N'John Hartford', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (8, N'Bela Fleck', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (9, N'Norman Blake', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (10, N'(Traditional)', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (11, N'The Stanley Brothers', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (12, N'Gillian Welch', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (13, N'Townes van Zandt', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (14, N'Bill Monroe', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (15, N'Woody Guthrie', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (16, N'Frankie Lane', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (17, N'Waylon Jennings', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (18, N'Dierks Bentley', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (19, N'Tom Paxton', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (20, N'Bobby Bare', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (21, N'Asleep at the Wheel', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (22, N'Alan Jackson', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (23, N'Tyler Childers', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (24, N'Allman Brothers Band', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (25, N'Bruce Hornsby', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (26, N'Jerry Garcia', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (27, N'New Orleans Rhythm Kings', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (28, N'Neil Young', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (29, N'The Rolling Stones', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (30, N'Hot Chocolate', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (31, N'Stevie Wonder', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (32, N'Pink Floyd', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (33, N'Joe Cocker', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (34, N'The Bangles', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (35, N'Dr. Dre', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (36, N'Railroad Earth', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (37, N'Stevie Ray Vaughn', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (38, N'Taj Mahal', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (39, N'Paul Simon', NULL)
INSERT [dbo].[artist] ([artist_id], [name], [description]) VALUES (40, N'Chuck Berry', NULL)
SET IDENTITY_INSERT [dbo].[artist] OFF
GO
SET IDENTITY_INSERT [dbo].[set_number] ON 

INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (1, 1, N'Set I', 1)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (2, 2, N'Set II', 1)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (3, 3, N'Set III', 1)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (4, 4, N'Set IV', 1)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (5, 5, N'Encore', 0)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (6, 6, N'Second Encore', 0)
INSERT [dbo].[set_number] ([set_number_id], [set_index], [set_name], [full_set]) VALUES (7, 0, N'Soundcheck', 0)
SET IDENTITY_INSERT [dbo].[set_number] OFF
GO
SET IDENTITY_INSERT [dbo].[show] ON 

INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (2, CAST(N'2017-09-24T00:00:00.0000000' AS DateTime2), 42, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (3, CAST(N'2018-01-28T00:00:00.0000000' AS DateTime2), 42, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (4, CAST(N'2018-02-25T00:00:00.0000000' AS DateTime2), 42, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (5, CAST(N'2018-03-25T00:00:00.0000000' AS DateTime2), 42, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (6, CAST(N'2020-05-30T00:00:00.0000000' AS DateTime2), 23, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (7, CAST(N'2020-06-06T00:00:00.0000000' AS DateTime2), 23, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (8, CAST(N'2020-07-18T00:00:00.0000000' AS DateTime2), 23, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (9, CAST(N'2020-08-08T00:00:00.0000000' AS DateTime2), 23, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (10, CAST(N'2020-03-07T00:00:00.0000000' AS DateTime2), 53, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (11, CAST(N'2020-10-31T00:00:00.0000000' AS DateTime2), 53, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (12, CAST(N'2020-01-18T00:00:00.0000000' AS DateTime2), 9, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (13, CAST(N'2019-07-05T00:00:00.0000000' AS DateTime2), 27, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (14, CAST(N'2019-02-15T00:00:00.0000000' AS DateTime2), 27, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (15, CAST(N'2020-02-07T00:00:00.0000000' AS DateTime2), 66, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (16, CAST(N'2020-02-01T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (17, CAST(N'2019-11-07T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (18, CAST(N'2019-10-12T00:00:00.0000000' AS DateTime2), 28, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (19, CAST(N'2019-11-14T00:00:00.0000000' AS DateTime2), 70, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (20, CAST(N'2020-09-26T00:00:00.0000000' AS DateTime2), 8, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (21, CAST(N'2020-03-04T00:00:00.0000000' AS DateTime2), 62, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (22, CAST(N'2019-03-11T00:00:00.0000000' AS DateTime2), 62, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (23, CAST(N'2018-10-27T00:00:00.0000000' AS DateTime2), 13, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (24, CAST(N'2017-12-22T00:00:00.0000000' AS DateTime2), 13, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (25, CAST(N'2019-04-25T00:00:00.0000000' AS DateTime2), 11, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (26, CAST(N'2020-02-08T00:00:00.0000000' AS DateTime2), 35, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (27, CAST(N'2019-11-09T00:00:00.0000000' AS DateTime2), 12, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (28, CAST(N'2019-05-11T00:00:00.0000000' AS DateTime2), 55, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (29, CAST(N'2019-06-28T00:00:00.0000000' AS DateTime2), 55, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (30, CAST(N'2019-02-23T00:00:00.0000000' AS DateTime2), 55, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (31, CAST(N'2018-10-23T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (32, CAST(N'2018-01-20T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (33, CAST(N'2018-04-02T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (34, CAST(N'2018-09-02T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (35, CAST(N'2017-10-20T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (36, CAST(N'2019-08-25T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (37, CAST(N'2020-08-28T00:00:00.0000000' AS DateTime2), 31, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (38, CAST(N'2019-11-08T00:00:00.0000000' AS DateTime2), 19, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (39, CAST(N'2019-07-06T00:00:00.0000000' AS DateTime2), 51, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (40, CAST(N'2017-06-29T00:00:00.0000000' AS DateTime2), 41, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (41, CAST(N'2017-08-26T00:00:00.0000000' AS DateTime2), 18, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (42, CAST(N'2019-04-27T00:00:00.0000000' AS DateTime2), 3, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (43, CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), 48, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (44, CAST(N'2020-12-31T00:00:00.0000000' AS DateTime2), 6, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (45, CAST(N'2018-09-28T00:00:00.0000000' AS DateTime2), 49, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (46, CAST(N'2019-03-09T00:00:00.0000000' AS DateTime2), 21, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (47, CAST(N'2019-11-15T00:00:00.0000000' AS DateTime2), 21, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (48, CAST(N'2020-03-01T00:00:00.0000000' AS DateTime2), 17, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (49, CAST(N'2019-03-08T00:00:00.0000000' AS DateTime2), 14, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (50, CAST(N'2019-02-22T00:00:00.0000000' AS DateTime2), 34, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (51, CAST(N'2019-06-29T00:00:00.0000000' AS DateTime2), 34, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (52, CAST(N'2018-09-30T00:00:00.0000000' AS DateTime2), 34, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (53, CAST(N'2019-10-06T00:00:00.0000000' AS DateTime2), 34, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (54, CAST(N'2016-12-31T00:00:00.0000000' AS DateTime2), 38, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (55, CAST(N'2018-07-19T00:00:00.0000000' AS DateTime2), 25, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (56, CAST(N'2019-04-24T00:00:00.0000000' AS DateTime2), 25, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (57, CAST(N'2018-07-21T00:00:00.0000000' AS DateTime2), 37, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (58, CAST(N'2016-07-04T00:00:00.0000000' AS DateTime2), 37, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (59, CAST(N'2017-05-13T00:00:00.0000000' AS DateTime2), 37, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (60, CAST(N'2019-04-24T00:00:00.0000000' AS DateTime2), 63, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (61, CAST(N'2020-02-26T00:00:00.0000000' AS DateTime2), 63, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (62, CAST(N'2020-02-22T00:00:00.0000000' AS DateTime2), 30, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (63, CAST(N'2020-09-06T00:00:00.0000000' AS DateTime2), 30, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (64, CAST(N'2020-12-31T00:00:00.0000000' AS DateTime2), 30, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (65, CAST(N'2020-02-25T00:00:00.0000000' AS DateTime2), 52, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (66, CAST(N'2019-11-11T00:00:00.0000000' AS DateTime2), 60, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (67, CAST(N'2019-03-17T00:00:00.0000000' AS DateTime2), 69, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (68, CAST(N'2019-10-11T00:00:00.0000000' AS DateTime2), 65, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (69, CAST(N'2018-02-10T00:00:00.0000000' AS DateTime2), 46, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (70, CAST(N'2017-03-25T00:00:00.0000000' AS DateTime2), 33, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (71, CAST(N'2017-05-06T00:00:00.0000000' AS DateTime2), 33, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (72, CAST(N'2017-07-21T00:00:00.0000000' AS DateTime2), 33, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (73, CAST(N'2019-03-28T00:00:00.0000000' AS DateTime2), 4, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (74, CAST(N'2019-10-18T00:00:00.0000000' AS DateTime2), 29, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (75, CAST(N'2020-02-28T00:00:00.0000000' AS DateTime2), 59, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (76, CAST(N'2019-03-15T00:00:00.0000000' AS DateTime2), 59, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (77, CAST(N'2019-10-05T00:00:00.0000000' AS DateTime2), 56, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (78, CAST(N'2019-10-04T00:00:00.0000000' AS DateTime2), 64, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (79, CAST(N'2019-11-16T00:00:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (80, CAST(N'2020-01-29T00:00:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (81, CAST(N'2019-04-23T00:00:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (82, CAST(N'2018-01-25T00:00:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (83, CAST(N'2018-07-19T00:00:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (84, CAST(N'2018-10-26T00:00:00.0000000' AS DateTime2), 26, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (85, CAST(N'2018-11-02T00:00:00.0000000' AS DateTime2), 22, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (86, CAST(N'2019-03-07T00:00:00.0000000' AS DateTime2), 22, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (87, CAST(N'2020-01-16T00:00:00.0000000' AS DateTime2), 22, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (88, CAST(N'2020-01-30T00:00:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (89, CAST(N'2020-09-19T00:00:00.0000000' AS DateTime2), 32, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (90, CAST(N'2020-02-29T00:00:00.0000000' AS DateTime2), 68, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (91, CAST(N'2019-03-14T00:00:00.0000000' AS DateTime2), 68, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (92, CAST(N'2018-11-09T00:00:00.0000000' AS DateTime2), 16, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (93, CAST(N'2020-02-21T00:00:00.0000000' AS DateTime2), 16, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (94, CAST(N'2019-06-06T00:00:00.0000000' AS DateTime2), 61, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (95, CAST(N'2018-06-22T00:00:00.0000000' AS DateTime2), 61, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (96, CAST(N'2017-06-16T00:00:00.0000000' AS DateTime2), 61, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (97, CAST(N'2017-11-15T00:00:00.0000000' AS DateTime2), 43, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (98, CAST(N'2017-07-08T00:00:00.0000000' AS DateTime2), 40, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (99, CAST(N'2017-03-15T00:00:00.0000000' AS DateTime2), 40, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (100, CAST(N'2018-08-11T00:00:00.0000000' AS DateTime2), 57, 1)
GO
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (101, CAST(N'2017-02-18T00:00:00.0000000' AS DateTime2), 39, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (102, CAST(N'2020-01-17T00:00:00.0000000' AS DateTime2), 15, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (103, CAST(N'2017-12-18T00:00:00.0000000' AS DateTime2), 44, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (104, CAST(N'2018-11-01T00:00:00.0000000' AS DateTime2), 44, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (105, CAST(N'2019-03-05T00:00:00.0000000' AS DateTime2), 48, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (106, CAST(N'2018-03-16T00:00:00.0000000' AS DateTime2), 48, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (107, CAST(N'2019-11-18T00:00:00.0000000' AS DateTime2), 48, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (108, CAST(N'2018-03-07T00:00:00.0000000' AS DateTime2), 47, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (109, CAST(N'2020-03-03T00:00:00.0000000' AS DateTime2), 54, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (110, CAST(N'2020-01-31T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (111, CAST(N'2019-02-16T00:00:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (112, CAST(N'2019-03-10T00:00:00.0000000' AS DateTime2), 58, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (113, CAST(N'2018-06-06T00:00:00.0000000' AS DateTime2), 36, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (114, CAST(N'2019-03-13T00:00:00.0000000' AS DateTime2), 67, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (115, CAST(N'2019-11-13T00:00:00.0000000' AS DateTime2), 67, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (116, CAST(N'2020-02-27T00:00:00.0000000' AS DateTime2), 7, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (117, CAST(N'2020-03-06T00:00:00.0000000' AS DateTime2), 20, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (118, CAST(N'2019-04-26T00:00:00.0000000' AS DateTime2), 20, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (119, CAST(N'2019-03-16T00:00:00.0000000' AS DateTime2), 10, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (120, CAST(N'2020-03-05T00:00:00.0000000' AS DateTime2), 10, 1)
INSERT [dbo].[show] ([show_id], [date], [venue_id], [performing_artist_id]) VALUES (121, CAST(N'2018-12-14T00:00:00.0000000' AS DateTime2), 50, 1)
SET IDENTITY_INSERT [dbo].[show] OFF
GO
SET IDENTITY_INSERT [dbo].[song] ON 

INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (1, N'Lightbulb', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (2, N'East Due West', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (3, N'Hurts Me Too', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (4, N'Future Plan B.', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (5, N'Traveling Through', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (6, N'Edge of Silence', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (7, N'Spider Bite', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (8, N'Rising Sun', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (9, N'Friends In Places', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (10, N'Unknown Spaces', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (11, N'Nursery Rhyme', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (12, N'Oh King', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (13, N'Up in the Clouds', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (14, N'Fish and a Rice Cake', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (15, N'Four Chord Song', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (16, N'Needed', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (17, N'So Far', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (18, N'Outro(Secret Place Reprise)', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (19, N'The Unexpected', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (20, N'Fear', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (21, N'Secret Place', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (22, N'Stevie', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (23, N'Dirt Devil', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (24, N'Riddle of the Sphinx', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (25, N'Ruby', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (26, N'Coming Home', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (27, N'Skydiver', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (28, N'Another Time', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (29, N'Fly Away', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (30, N'Taking Over', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (31, N'Western Song', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (32, N'Crosstie Serenade', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (33, N'Burning the Hardwood Floor', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (34, N'Well Said and Done', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (35, N'Hold On', NULL, 1, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (36, N'Althea', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (37, N'Rubin & Cherise', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (38, N'Turn on your Love Light', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (39, N'Brown Eyed Women', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (40, N'I Know You Rider', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (41, N'Bertha', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (42, N'Feel Like a Stranger', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (43, N'China Cat Sunflower', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (44, N'Going Down the Road', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (45, N'Jack Straw', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (46, N'Sugar Magnolia', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (47, N'Foolish Heart', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (48, N'Estimated Prophet', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (49, N'Eyes of the World', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (50, N'Truckin’', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (51, N'Wharf Rat', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (52, N'Music Never Stopped', NULL, 4, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (53, N'46 Days', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (54, N'Birds of a Feather', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (55, N'Back on the Train', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (56, N'Auld Lang Syne', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (57, N'Sand', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (58, N'Say it to me S.A.N.T.O.S.', NULL, 2, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (59, N'Imitation Leather Shoes', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (60, N'Take Out', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (61, N'Porch Song', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (62, N'Blackout Blues', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (63, N'Airplane', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (64, N'The Waker', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (65, N'You Should Be Glad', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (66, N'Ain’t Life Grand', NULL, 3, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (67, N'Every1’s a Winner', NULL, 30, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (68, N'Boogie On', NULL, 31, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (69, N'Hey You', NULL, 32, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (70, N'Feeling Alright', NULL, 33, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (71, N'Walk Like an Egyptian', NULL, 34, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (72, N'Thunder Clouds Of Love', NULL, 5, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (73, N'Waited as Long as I Can', NULL, 5, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (74, N'Tell Me Baby', NULL, 6, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (75, N'Cuckoo’s Nest', NULL, 7, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (76, N'Overgrown Waltz', NULL, 8, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (77, N'Ginseng Sullivan', NULL, 9, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (78, N'Up on the Hill', NULL, 7, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (79, N'Musical Priest', NULL, 10, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (80, N'How Mountain Girls', NULL, 11, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (81, N'Wayside', NULL, 12, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (82, N'White Freight Liner', NULL, 13, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (83, N'Love Please Come Home', NULL, 14, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (84, N'Way Over Yonder', NULL, 15, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (85, N'Shady Grove', NULL, 10, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (86, N'Theme from Rawhide', NULL, 16, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (87, N'Lonesome On’ry & Mean', NULL, 17, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (88, N'Up on the Ridge', NULL, 18, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (89, N'Last Thing on my Mind', NULL, 19, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (90, N'Streets of Baltimore', NULL, 20, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (91, N'Dance With Who Brung You', NULL, 21, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (92, N'Chattahoochee', NULL, 22, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (93, N'Whitehouse Road', NULL, 23, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (94, N'Storms', NULL, 36, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (95, N'Sweet Melinda', NULL, 24, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (96, N'The Way It Is', NULL, 25, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (97, N'Ain’t No Bugs on Me', NULL, 26, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (98, N'Gold Strut', NULL, 27, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (99, N'Ohio', NULL, 28, NULL)
GO
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (100, N'Dead Flowers', NULL, 29, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (101, N'Memphis Tennessee', NULL, 40, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (102, N'Mary Had a Little Lamb', NULL, 37, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (103, N'Fearless', NULL, 32, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (104, N'Take a Giant Step', NULL, 38, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (105, N'Kodachrome', NULL, 39, NULL)
INSERT [dbo].[song] ([song_id], [name], [description], [original_artist_id], [original_artist_name]) VALUES (106, N'The Next Episode', NULL, 35, NULL)
SET IDENTITY_INSERT [dbo].[song] OFF
GO
SET IDENTITY_INSERT [dbo].[song_performance] ON 

INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (2, 1, NULL, 1, NULL, NULL, 58, 1, 0, 1, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (3, 1, NULL, 2, NULL, NULL, 58, 2, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (4, 1, NULL, 3, NULL, NULL, 58, 3, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (5, 1, NULL, 4, NULL, NULL, 58, 4, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (6, 1, NULL, 5, NULL, NULL, 58, 5, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (7, 1, NULL, 6, NULL, NULL, 58, 6, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (8, 1, NULL, 7, NULL, NULL, 58, 36, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (9, 1, NULL, 8, NULL, NULL, 58, 7, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (10, 1, NULL, 9, NULL, NULL, 58, 8, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (11, 1, NULL, 10, NULL, NULL, 58, 59, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (12, 1, NULL, 11, NULL, NULL, 58, 9, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (13, 1, NULL, 12, NULL, NULL, 58, 99, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (14, 1, NULL, 13, NULL, NULL, 58, 10, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (15, 1, NULL, 14, NULL, NULL, 58, 100, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (16, 1, NULL, 15, NULL, NULL, 58, 11, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (17, 1, NULL, 16, NULL, NULL, 58, 12, 0, 0, 1)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (18, 1, NULL, 1, NULL, NULL, 54, 12, 0, 1, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (19, 1, NULL, 2, NULL, NULL, 54, 1, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (20, 1, NULL, 3, NULL, NULL, 54, 7, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (21, 1, NULL, 4, NULL, NULL, 54, 100, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (22, 1, NULL, 5, NULL, NULL, 54, 5, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (23, 1, NULL, 6, NULL, NULL, 54, 99, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (24, 1, NULL, 7, NULL, NULL, 54, 3, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (25, 1, NULL, 8, NULL, NULL, 54, 2, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (26, 1, NULL, 9, NULL, NULL, 54, 10, 0, 0, 0)
INSERT [dbo].[song_performance] ([song_performance_id], [set_number_id], [song_performance_note], [set_song_index], [duration_in_sec], [media_link_id], [show_id], [song_id], [segue_out], [set_opener], [set_closer]) VALUES (27, 1, NULL, 10, NULL, NULL, 54, 11, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[song_performance] OFF
GO
SET IDENTITY_INSERT [dbo].[venue] ON 

INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (1, N'BoneFire SmokeHouse', NULL, N'Abingdon', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (2, N'The One Stop', NULL, N'Asheville', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (3, N'Foggy Mountain Brewpub', NULL, N'Asheville', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (4, N'Nowhere Bar', NULL, N'Athens', N'GA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (5, N'Smith’s Olde Bar (Atlanta Room)', NULL, N'Atlanta', N'GA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (6, N'Frazie’s NYE Party', NULL, N'Atlanta', N'GA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (7, N'Tin Roof', NULL, N'Baltimore', N'MD', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (8, N'Carter’s Bachelor Party', NULL, N'Baxter', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (9, N'Avondale Brewing (upstairs)', NULL, N'Birmingham', N'AL', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (10, N'Whiskey Jar', NULL, N'Charlottesville', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (11, N'Coupe’s', NULL, N'Charlottesville', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (12, N'Crozet Pizza Buddhist Biker Bar', NULL, N'Charlottesville', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (13, N'Clyde’s on Main', NULL, N'Chattanooga', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (14, N'HiFi Clyde’s', NULL, N'Chattanooga', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (15, N'The Dark Roast', NULL, N'Chattanooga', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (16, N'Stanley’s Pub', NULL, N'Cincinnati', N'OH', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (17, N'Hidden River Brewing', NULL, N'Douglasville', N'PA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (18, N'First District Coffee Co.', NULL, N'Fairview', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (19, N'Dogtown Roadhouse', NULL, N'Floyd', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (20, N'Wahoo’s Tavern', NULL, N'Greensboro', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (21, N'GOTTROCKS', NULL, N'Greenville', N'SC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (22, N'SideTracks Music Hall', NULL, N'Huntsville', N'AL', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (23, N'Airshow Headquarters', NULL, N'Joelton', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (24, N'Preservation Pub', NULL, N'Knoxville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (25, N'Knoxville Visitor’s Center', NULL, N'Knoxville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (26, N'Scruffy city Hall', NULL, N'Knoxville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (27, N'Barley’s', NULL, N'Knoxville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (28, N'Boyd’s Jig & Reel', NULL, N'Knoxville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (29, N'Odeon', NULL, N'Louisville', N'KY', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (30, N'Mellwood Tavern', NULL, N'Louisville', N'KY', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (31, N'Dee’s Country Cocktail Lounge', NULL, N'Madison', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (32, N'Smooth Rapids Campground', NULL, N'McMinnville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (33, N'Newby’s', NULL, N'Memphis', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (34, N'High Cotten Brewing', NULL, N'Memphis', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (35, N'Crosstown Brewing', NULL, N'Memphis', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (36, N'The V', NULL, N'Monteagle', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (37, N'Little Harpeth Brewing', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (38, N'Honky Tonk Brewery', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (39, N'The Cobra', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (40, N'The Basement', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (41, N'Family Wash', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (42, N'Acme Feed & Seed', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (43, N'The 5 Spot', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (44, N'The East Room', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (45, N'Neighbors of Sylvan Park', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (46, N'The Local', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (47, N'The High Watt', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (48, N'Food Truck City', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (49, N'Further Fest', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (50, N'World Music', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (51, N'Exit/In', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (52, N'Mercy Lounge', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (53, N'Alley Taps', NULL, N'Nashville', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (54, N'The Map Room at Bowery Electric', NULL, N'New York', N'NY', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (55, N'CYO Brewing', NULL, N'Owensboro', N'KY', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (56, N'Paducah Brew Werks', NULL, N'Paducah', N'KY', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (57, N'The Caverns', NULL, N'Pelham', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (58, N'The Pour House Music Hall', NULL, N'Raleigh', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (59, N'P.J. Whelihan’s', NULL, N'Reading', N'PA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (60, N'Mike’s Tavern', NULL, N'Reading', N'PA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (61, N'Summer Solstice Festival & Family Gathering', NULL, N'Red Boiling Springs', N'TN', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (62, N'Cary St. Cafe', NULL, N'Richmond', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (63, N'Martin’s Downtown', NULL, N'Roanoke', N'VA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (64, N'Pop’s Blue Moon', NULL, N'St. Louis', N'MO', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (65, N'Nantahala Brewing', NULL, N'Sylva', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (66, N'Blue Canoe', NULL, N'Tupelo', N'MS', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (67, N'The Vinyl Lounge', NULL, N'Washington ', N'DC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (68, N'Sprout Music Collective', NULL, N'West Chester', N'PA', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (69, N'Muddy Creek Cafe & Music Hall', NULL, N'Winston-Salem', N'NC', N'USA')
INSERT [dbo].[venue] ([venue_id], [name], [description], [city], [state], [country]) VALUES (70, N'Bull’s Tavern', NULL, N'Winston-Salem', N'NC', N'USA')
SET IDENTITY_INSERT [dbo].[venue] OFF
GO
ALTER TABLE [dbo].[song_performance] ADD  DEFAULT ((0)) FOR [segue_out]
GO
ALTER TABLE [dbo].[song_performance] ADD  DEFAULT ((0)) FOR [set_opener]
GO
ALTER TABLE [dbo].[song_performance] ADD  DEFAULT ((0)) FOR [set_closer]
GO
ALTER TABLE [dbo].[show]  WITH CHECK ADD  CONSTRAINT [FK_Show_Artist_performing_artist_id] FOREIGN KEY([performing_artist_id])
REFERENCES [dbo].[artist] ([artist_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[show] CHECK CONSTRAINT [FK_Show_Artist_performing_artist_id]
GO
ALTER TABLE [dbo].[show]  WITH CHECK ADD  CONSTRAINT [FK_show_venue] FOREIGN KEY([venue_id])
REFERENCES [dbo].[venue] ([venue_id])
GO
ALTER TABLE [dbo].[show] CHECK CONSTRAINT [FK_show_venue]
GO
ALTER TABLE [dbo].[song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Artist_original_artist_id] FOREIGN KEY([original_artist_id])
REFERENCES [dbo].[artist] ([artist_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[song] CHECK CONSTRAINT [FK_Song_Artist_original_artist_id]
GO
ALTER TABLE [dbo].[song_performance]  WITH CHECK ADD  CONSTRAINT [FK_song_performance_set_number] FOREIGN KEY([set_number_id])
REFERENCES [dbo].[set_number] ([set_number_id])
GO
ALTER TABLE [dbo].[song_performance] CHECK CONSTRAINT [FK_song_performance_set_number]
GO
ALTER TABLE [dbo].[song_performance]  WITH CHECK ADD  CONSTRAINT [FK_song_performance_show] FOREIGN KEY([show_id])
REFERENCES [dbo].[show] ([show_id])
GO
ALTER TABLE [dbo].[song_performance] CHECK CONSTRAINT [FK_song_performance_show]
GO
ALTER TABLE [dbo].[song_performance]  WITH CHECK ADD  CONSTRAINT [FK_Song_Performance_Song_song_id] FOREIGN KEY([song_id])
REFERENCES [dbo].[song] ([song_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[song_performance] CHECK CONSTRAINT [FK_Song_Performance_Song_song_id]
GO
ALTER TABLE [dbo].[song_performance]  WITH CHECK ADD  CONSTRAINT [CK_Song_performance_Col] CHECK  (([set_song_index]>=(1)))
GO
ALTER TABLE [dbo].[song_performance] CHECK CONSTRAINT [CK_Song_performance_Col]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "show"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 233
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "artist"
            Begin Extent = 
               Top = 6
               Left = 474
               Bottom = 119
               Right = 644
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "venue"
            Begin Extent = 
               Top = 155
               Left = 597
               Bottom = 285
               Right = 767
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwShow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwShow'
GO

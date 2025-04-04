Please log on to your local instance of sql express, open a new query and run the following script to create the database, table, plus some sample data:

CREATE DATABASE InfoTrackRankingDB;
GO

USE InfoTrackRankingDB;
GO

CREATE TABLE [dbo].[RankHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ranks] [nvarchar](255) NOT NULL,
	[URL] [nvarchar](255) NOT NULL,
	[Keywords] [nvarchar](255) NOT NULL,
	[NumberOfSearchResults] [int] NOT NULL,
	[SearchDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[RankHistory]
           ([Ranks]
           ,[URL]
           ,[Keywords]
           ,[NumberOfSearchResults]
           ,[SearchDate])
     VALUES
           (18
           ,'https://www.google.co.uk/search?num=100&q=land+registry+search'
           ,'land registry search'
           ,100
           ,'01-Apr-2025')

INSERT INTO [dbo].[RankHistory]
           ([Ranks]
           ,[URL]
           ,[Keywords]
           ,[NumberOfSearchResults]
           ,[SearchDate])
     VALUES
           (14
           ,'https://www.google.co.uk/search?num=100&q=conveyancing'
           ,'conveyancing'
           ,150
           ,'04-Apr-2025')

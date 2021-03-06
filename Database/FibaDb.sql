USE [master]
GO
/****** Object:  Database [Fiba]    Script Date: 14-08-21 12:09:34 ******/
CREATE DATABASE [Fiba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fiba', FILENAME = N'C:\Users\Ppeycker\Fiba.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fiba_log', FILENAME = N'C:\Users\Ppeycker\Fiba_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Fiba] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fiba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fiba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fiba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fiba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fiba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fiba] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fiba] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Fiba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fiba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fiba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fiba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fiba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fiba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fiba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fiba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fiba] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Fiba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fiba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fiba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fiba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fiba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fiba] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Fiba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fiba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fiba] SET  MULTI_USER 
GO
ALTER DATABASE [Fiba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fiba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fiba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fiba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fiba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fiba] SET QUERY_STORE = OFF
GO
USE [Fiba]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Fiba]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14-08-21 12:09:34 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](450) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[MatchId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[HomeTeamScore] [int] NOT NULL,
	[Period] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Time] [datetime2](7) NOT NULL,
	[VisitorTeamScore] [int] NOT NULL,
	[Postseason] [bit] NOT NULL,
	[SeasonId] [uniqueidentifier] NOT NULL,
	[HomeTeamId] [int] NOT NULL,
	[VisitorTeamId] [int] NOT NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[GenderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayersTeams]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayersTeams](
	[PlayerId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[StartOfContract] [datetime2](7) NOT NULL,
	[EndOfContract] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PlayersTeams] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seasons]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seasons](
	[SeasonId] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
	[GenderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Seasons] PRIMARY KEY CLUSTERED 
(
	[SeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeasonsTeams]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeasonsTeams](
	[SeasonId] [uniqueidentifier] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_SeasonsTeams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[SeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistics]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistics](
	[StatisticId] [int] NOT NULL,
	[Assist] [int] NOT NULL,
	[Block] [int] NOT NULL,
	[DefensiveRebound] [int] NOT NULL,
	[ThreePointsFieldGoalPourcentage] [decimal](18, 2) NOT NULL,
	[ThreePointsFieldGoalAttempted] [int] NOT NULL,
	[ThreePointsFieldGoalMade] [int] NOT NULL,
	[FieldGoalPourcentage] [decimal](18, 2) NOT NULL,
	[FieldGoalAttempted] [int] NOT NULL,
	[FieldGoalMade] [int] NOT NULL,
	[FreeTrowPourcentage] [decimal](18, 2) NOT NULL,
	[FreeTrowAttempted] [int] NOT NULL,
	[FreeTrowMade] [int] NOT NULL,
	[Minutes] [datetime2](7) NOT NULL,
	[OffensiveRebound] [int] NOT NULL,
	[PersonnalFoul] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[Rebound] [int] NOT NULL,
	[Steal] [int] NOT NULL,
	[Turnover] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
 CONSTRAINT [PK_Statistics] PRIMARY KEY CLUSTERED 
(
	[StatisticId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 14-08-21 12:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] NOT NULL,
	[Name] [nvarchar](450) NULL,
	[City] [nvarchar](max) NULL,
	[Abbreviation] [nvarchar](max) NULL,
	[ThumbUrl] [nvarchar](max) NULL,
	[GenderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Genders_Name]    Script Date: 14-08-21 12:09:34 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Genders_Name] ON [dbo].[Genders]
(
	[Name] ASC
)
WHERE ([Name] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_HomeTeamId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Matches_HomeTeamId] ON [dbo].[Matches]
(
	[HomeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_SeasonId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Matches_SeasonId] ON [dbo].[Matches]
(
	[SeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_VisitorTeamId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Matches_VisitorTeamId] ON [dbo].[Matches]
(
	[VisitorTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Players_GenderId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Players_GenderId] ON [dbo].[Players]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayersTeams_TeamId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_PlayersTeams_TeamId] ON [dbo].[PlayersTeams]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seasons_GenderId_Year]    Script Date: 14-08-21 12:09:34 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Seasons_GenderId_Year] ON [dbo].[Seasons]
(
	[GenderId] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SeasonsTeams_SeasonId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_SeasonsTeams_SeasonId] ON [dbo].[SeasonsTeams]
(
	[SeasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Statistics_MatchId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Statistics_MatchId] ON [dbo].[Statistics]
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Statistics_PlayerId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Statistics_PlayerId] ON [dbo].[Statistics]
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Statistics_TeamId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Statistics_TeamId] ON [dbo].[Statistics]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teams_GenderId]    Script Date: 14-08-21 12:09:34 ******/
CREATE NONCLUSTERED INDEX [IX_Teams_GenderId] ON [dbo].[Teams]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Teams_Name_GenderId]    Script Date: 14-08-21 12:09:34 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teams_Name_GenderId] ON [dbo].[Teams]
(
	[Name] ASC,
	[GenderId] ASC
)
WHERE ([Name] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Seasons_SeasonId] FOREIGN KEY([SeasonId])
REFERENCES [dbo].[Seasons] ([SeasonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Seasons_SeasonId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_HomeTeamId] FOREIGN KEY([HomeTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_HomeTeamId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_VisitorTeamId] FOREIGN KEY([VisitorTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_VisitorTeamId]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Genders_GenderId]
GO
ALTER TABLE [dbo].[PlayersTeams]  WITH CHECK ADD  CONSTRAINT [FK_PlayersTeams_Players_PlayerId] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Players] ([PlayerId])
GO
ALTER TABLE [dbo].[PlayersTeams] CHECK CONSTRAINT [FK_PlayersTeams_Players_PlayerId]
GO
ALTER TABLE [dbo].[PlayersTeams]  WITH CHECK ADD  CONSTRAINT [FK_PlayersTeams_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[PlayersTeams] CHECK CONSTRAINT [FK_PlayersTeams_Teams_TeamId]
GO
ALTER TABLE [dbo].[Seasons]  WITH CHECK ADD  CONSTRAINT [FK_Seasons_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seasons] CHECK CONSTRAINT [FK_Seasons_Genders_GenderId]
GO
ALTER TABLE [dbo].[SeasonsTeams]  WITH CHECK ADD  CONSTRAINT [FK_SeasonsTeams_Seasons_SeasonId] FOREIGN KEY([SeasonId])
REFERENCES [dbo].[Seasons] ([SeasonId])
GO
ALTER TABLE [dbo].[SeasonsTeams] CHECK CONSTRAINT [FK_SeasonsTeams_Seasons_SeasonId]
GO
ALTER TABLE [dbo].[SeasonsTeams]  WITH CHECK ADD  CONSTRAINT [FK_SeasonsTeams_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[SeasonsTeams] CHECK CONSTRAINT [FK_SeasonsTeams_Teams_TeamId]
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD  CONSTRAINT [FK_Statistics_Matches_MatchId] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Matches] ([MatchId])
GO
ALTER TABLE [dbo].[Statistics] CHECK CONSTRAINT [FK_Statistics_Matches_MatchId]
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD  CONSTRAINT [FK_Statistics_Players_PlayerId] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Players] ([PlayerId])
GO
ALTER TABLE [dbo].[Statistics] CHECK CONSTRAINT [FK_Statistics_Players_PlayerId]
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD  CONSTRAINT [FK_Statistics_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Statistics] CHECK CONSTRAINT [FK_Statistics_Teams_TeamId]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Genders_GenderId]
GO
USE [master]
GO
ALTER DATABASE [Fiba] SET  READ_WRITE 
GO

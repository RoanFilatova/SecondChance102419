USE [master]
GO
/****** Object:  Database [SecondChance]    Script Date: 24-Oct-19 03:09:23 PM ******/
CREATE DATABASE [SecondChance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SecondChance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SecondChance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SecondChance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SecondChance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SecondChance] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SecondChance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SecondChance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SecondChance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SecondChance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SecondChance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SecondChance] SET ARITHABORT OFF 
GO
ALTER DATABASE [SecondChance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SecondChance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SecondChance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SecondChance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SecondChance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SecondChance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SecondChance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SecondChance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SecondChance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SecondChance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SecondChance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SecondChance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SecondChance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SecondChance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SecondChance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SecondChance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SecondChance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SecondChance] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SecondChance] SET  MULTI_USER 
GO
ALTER DATABASE [SecondChance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SecondChance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SecondChance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SecondChance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SecondChance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SecondChance] SET QUERY_STORE = OFF
GO
USE [SecondChance]
GO
/****** Object:  Table [dbo].[Breeds]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breeds](
	[BreedID] [int] IDENTITY(1,1) NOT NULL,
	[BreedName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DogBreedsID] PRIMARY KEY CLUSTERED 
(
	[BreedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dogs]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dogs](
	[DogID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BreedID] [int] NOT NULL,
	[IsSmallBreed] [bit] NOT NULL,
	[IsDogHairless] [bit] NOT NULL,
	[Medical] [nvarchar](max) NOT NULL,
	[AdoptDate] [date] NOT NULL,
	[SurrenderDate] [date] NOT NULL,
 CONSTRAINT [PK_DogsID] PRIMARY KEY CLUSTERED 
(
	[DogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRolesID] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDogs]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDogs](
	[UserID] [int] NOT NULL,
	[DogID] [int] NOT NULL,
 CONSTRAINT [PK_UserDogs_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[DogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Hash] [nvarchar](200) NOT NULL,
	[Salt] [nvarchar](200) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserInfoID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Breeds] ON 

INSERT [dbo].[Breeds] ([BreedID], [BreedName]) VALUES (1, N'Chocolate Lab')
INSERT [dbo].[Breeds] ([BreedID], [BreedName]) VALUES (2, N'Shiba Inu')
INSERT [dbo].[Breeds] ([BreedID], [BreedName]) VALUES (3, N'St Bernard')
SET IDENTITY_INSERT [dbo].[Breeds] OFF
SET IDENTITY_INSERT [dbo].[Dogs] ON 

INSERT [dbo].[Dogs] ([DogID], [Name], [BreedID], [IsSmallBreed], [IsDogHairless], [Medical], [AdoptDate], [SurrenderDate]) VALUES (1, N'Schatzi', 1, 0, 0, N'Bratty Teenager', CAST(N'2017-06-06' AS Date), CAST(N'2000-01-01' AS Date))
INSERT [dbo].[Dogs] ([DogID], [Name], [BreedID], [IsSmallBreed], [IsDogHairless], [Medical], [AdoptDate], [SurrenderDate]) VALUES (2, N'Milo', 2, 1, 0, N'None', CAST(N'2019-09-19' AS Date), CAST(N'2019-09-14' AS Date))
SET IDENTITY_INSERT [dbo].[Dogs] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'PowerUser')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Normie')
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[UserDogs] ([UserID], [DogID]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Name], [Address], [Email], [Hash], [Salt], [RoleID]) VALUES (1, N'Jeff', N'Jeff Brink', N'2000 SE Loop 304, Crockett TX 75835', N'jeff@secondchance.org', N'XXX', N'YYY', 1)
INSERT [dbo].[Users] ([UserID], [UserName], [Name], [Address], [Email], [Hash], [Salt], [RoleID]) VALUES (2, N'Keven', N'Keven Brink', N'2000 SE Loop 304, Crockett TX 75835', N'kev@secondchance.org', N'XXX', N'YYY', 1)
INSERT [dbo].[Users] ([UserID], [UserName], [Name], [Address], [Email], [Hash], [Salt], [RoleID]) VALUES (3, N'Punky', N'Garrett Council', N'557 Autumn PL, Fountain CO 80817', N'garrett@secondchance.org', N'XXX', N'YYY', 2)
INSERT [dbo].[Users] ([UserID], [UserName], [Name], [Address], [Email], [Hash], [Salt], [RoleID]) VALUES (4, N'Mary', N'Mary Council', N'10 Elm St, Bluewater, NM 87005', N'mary@gmail.com', N'XXX', N'YYY', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Dogs]  WITH CHECK ADD  CONSTRAINT [FK_DogsID_DogBreedsID] FOREIGN KEY([BreedID])
REFERENCES [dbo].[Breeds] ([BreedID])
GO
ALTER TABLE [dbo].[Dogs] CHECK CONSTRAINT [FK_DogsID_DogBreedsID]
GO
ALTER TABLE [dbo].[UserDogs]  WITH CHECK ADD  CONSTRAINT [FK_UserDogs_Dogs] FOREIGN KEY([DogID])
REFERENCES [dbo].[Dogs] ([DogID])
GO
ALTER TABLE [dbo].[UserDogs] CHECK CONSTRAINT [FK_UserDogs_Dogs]
GO
ALTER TABLE [dbo].[UserDogs]  WITH CHECK ADD  CONSTRAINT [FK_UserDogs_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserDogs] CHECK CONSTRAINT [FK_UserDogs_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UserInfoID_UserRolesID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UserInfoID_UserRolesID]
GO
/****** Object:  StoredProcedure [dbo].[BreedCreate]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BreedCreate]
@BreedID int output,
@BreedName nvarchar(50)
as
begin
insert into Breeds (BreedName)
values (@BreedName);
select @BreedID = @@IDENTITY;

end
GO
/****** Object:  StoredProcedure [dbo].[BreedDelete]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BreedDelete]
@BreedID int
as begin
set nocount on;
delete from [dbo].[Breeds]
where  BreedID = @BreedID
end
GO
/****** Object:  StoredProcedure [dbo].[BreedFindByID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BreedFindByID]
@BreedID int
as
begin
select BreedID, BreedName from Breeds
where BreedID = @BreedID
end
GO
/****** Object:  StoredProcedure [dbo].[BreedGetAll]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BreedGetAll]
@skip int,
@take int
as
begin
select BreedID, BreedName from Breeds
order by BreedID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[BreedUpdateJust]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BreedUpdateJust]
@BreedID int output,
@BreedName nvarchar(50)
as 
begin
update Breeds set BreedName = @BreedName
where BreedID = @BreedID
end
GO
/****** Object:  StoredProcedure [dbo].[DogCreate]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogCreate]
@DogID int output,
@Name nvarchar(50),
@IsSmallBreed bit,
@IsDogHairless bit,
@Medical nvarchar(Max),
@AdoptDate datetime,
@SurrenderDate datetime,
@BreedID int
as
begin
insert into Dogs (Name, [BreedID], IsSmallBreed, IsDogHairless, Medical, AdoptDate, SurrenderDate)
values (@Name, @BreedID, @IsSmallBreed, @IsDogHairless, @Medical, @AdoptDate, @SurrenderDate);
select @DogID = @@IDENTITY;

end
GO
/****** Object:  StoredProcedure [dbo].[DogDelete]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogDelete]
@DogID int
as
begin
set nocount on;
delete from [dbo].[Dogs]
where  DogID = @DogID
end
GO
/****** Object:  StoredProcedure [dbo].[DogFindByBreed]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[DogFindByBreed]
@BreedID int
as
begin
select BreedName from Breeds
inner join Dogs on Dogs.BreedID = Breeds.BreedID
where DogID = @BreedID
end
GO
/****** Object:  StoredProcedure [dbo].[DogFindByID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogFindByID]
@DogID int
as
begin
select DogID, Name, BreedID, IsSmallBreed, IsDogHairless, Medical, AdoptDate, SurrenderDate  from Dogs
where DogID = @DogID
end
GO
/****** Object:  StoredProcedure [dbo].[DogObtainCount]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogObtainCount]
as
begin
select count(*) from Dogs
end
GO
/****** Object:  StoredProcedure [dbo].[DogsGetAll]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogsGetAll]
@skip int,
@take int
as
begin
select DogID, Name, BreedID, IsSmallBreed, IsDogHairless,Medical,AdoptDate,SurrenderDate from Dogs
order by DogID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[DogUpdateJust]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogUpdateJust]
@DogID int,
@Name nvarchar(50),
@IsSmallBreed bit,
@IsDogHairless bit,
@Medical nvarchar(MAX),
@AdoptDate datetime,
@SurrenderDate datetime
as 
begin
update Dogs set Name = @Name, 
IsSmallBreed = @IsSmallBreed,
IsDogHairless = @IsDogHairless,
Medical = @Medical,
AdoptDate = @AdoptDate, 
SurrenderDate = @SurrenderDate
 where DogID = @DogID 
end
GO
/****** Object:  StoredProcedure [dbo].[DogUpdateSafe]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DogUpdateSafe]
@DogID int,
@SurrenderDate datetime,
@AdoptDate datetime,
@OldMedical nvarchar(max),
@NewMedical nvarchar(Max),
@Medical nvarchar(200)
as 
begin
update Dogs set SurrenderDate = @AdoptDate, @OldMedical = @NewMedical
where DogID = @DogID and 
	AdoptDate = @AdoptDate and
	@NewMedical = @Medical
end
GO
/****** Object:  StoredProcedure [dbo].[GetDogsByUserID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetDogsByUserID]
@UserID int
as
begin
select Dogs.DogID, Name, BreedID, IsSmallBreed, IsDogHairless, Medical, AdoptDate, SurrenderDate from Dogs
inner join UserDogs on @UserID = UserDogs.UserID 

Where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[GetUsersByDogID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetUsersByDogID]
@DogID int
as
begin
select  Users.UserID, UserName, Name, Address,Email, Hash, Salt, RoleID from Users
inner join UserDogs on @DogID = UserDogs.DogID 

Where DogID = @DogID
end
GO
/****** Object:  StoredProcedure [dbo].[ResetData]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ResetData]
as
begin
    delete from Roles;
	delete from Users;
	delete from Dogs;
	delete from Breeds;
	
	DBCC CHECKIDENT ('Users', RESEED, 0)
	DBCC CHECKIDENT ('Roles', RESEED, 0)
	DBCC CHECKIDENT ('Dogs', RESEED, 0)
	DBCC Checkident ('Breeds', RESEED, 0)
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreate]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RoleCreate]
@RoleID int output,
@RoleName nvarchar(50)
as
begin
insert into Roles (RoleName) 
values (@RoleName)
select @RoleID = @@IDENTITY;

end
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RoleDelete]
@RoleID int
as
begin
set nocount on;
delete from [dbo].[Roles]
where  RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleFindByID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RoleFindByID]
@RoleID int
as
begin
select RoleID, RoleName from Roles
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleGetAll]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RoleGetAll]
@skip int,
@take int
as
begin
select RoleID, RoleName from Roles
order by RoleID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[RoleObtainCount]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RoleObtainCount]
as
begin
select count(*) from Roles
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateJust]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleUpdateJust]
@RoleID int output,
@RoleName nvarchar(50)
as 
begin
update Roles set RoleName = @RoleName
where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateSafe]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RoleUpdateSafe]
@RoleID int,
@OldRoleName nvarchar(50),
@NewRoleName nvarchar(50)
as 
begin
update Roles set RoleName = @NewRoleName
where RoleName = @OldRoleName	
end
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UserCreate]
@UserID int output,
@UserName nvarchar(50),
@Name nvarchar(50),
@Address nvarchar (200),
@Email nvarchar(200),
@Hash nvarchar(200),
@Salt nvarchar(200),
@RoleID int
as
begin
insert into  Users (UserName, Name, Address, Email, Hash, Salt, RoleID)
values (@UserName, @Name, @Address, @Email, @Hash, @Salt, @RoleID)
select @UserID = @@IDENTITY;

end
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserDelete]
@UserID int
as
begin
set nocount on;
delete from [dbo].[Users]
where  UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UserDogsCreate]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserDogsCreate]
@UserID int,
@DogID int
as begin
insert into UserDogs (UserID, DogID)
values (@UserID, @DogID)
end
GO
/****** Object:  StoredProcedure [dbo].[UserDogsDelete]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserDogsDelete]
@UserID int,
@DogID int
as
begin
set nocount on;
delete from UserDogs
where  UserID = @UserID and
DogID = @DogID
end
GO
/****** Object:  StoredProcedure [dbo].[UserFindByEmail]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserFindByEmail]
@Email nvarchar(200)
as
begin
select UserID, UserName, Name, Address, Email, Hash, Salt, RoleID from Users
where Email = @Email
end
GO
/****** Object:  StoredProcedure [dbo].[UserFindByID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserFindByID]
@UserID int
as
begin
select UserID, UserName, Name, Address,Email, Hash, Salt, RoleID from Users
where UserID = @UserID
end
GO
/****** Object:  StoredProcedure [dbo].[UserGetAll]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserGetAll]
@skip int,
@take int
as
begin
select UserID, UserName, Name,Address, Email, Hash, Salt, RoleID from Users
order by UserID
offset @skip rows
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[UserObtainCount]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UserObtainCount]
as
begin
select * from Users
end
GO
/****** Object:  StoredProcedure [dbo].[UsersGetRelatedToRoleID]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UsersGetRelatedToRoleID]
@skip int,
@take int,
@RoleID int
as
begin
select UserID, Email from Users
inner join Roles on Roles.RoleID = Users.RoleID
Where @RoleID = @RoleID
Order by UserID
offset @skip rows
fetch next @take rows only
end

GO
/****** Object:  StoredProcedure [dbo].[UserUpdateJust]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UserUpdateJust]
@UserID int,
@UserName nvarchar(50),
@Email nvarchar(200),
@Address nvarchar(200),
@Hash nvarchar(200),
@Salt nvarchar(200),
@RoleID int
as 
begin
update Users set UserName = @UserName, 
Email = @Email, 
Address = @Address, 
Hash = @Hash, 
Salt = @Salt, 
RoleID = @RoleID
 where UserID = @UserID 
end
GO
/****** Object:  StoredProcedure [dbo].[UserUpdateSafe]    Script Date: 24-Oct-19 03:09:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[UserUpdateSafe]
@UserID int,
@OldUserName nvarchar(50),
@NewUserName nvarchar(50),
@OldEmail nvarchar(200),
@NewEmail nvarchar(200),
@OldAddress nvarchar(200),
@NewAddress nvarchar(200),
@OldHash nvarchar(200),
@NewHash nvarchar(200),
@OldSalt nvarchar(200),
@NewSalt nvarchar(200),
@OldRoleID int,
@NewRoleID int
as 
begin
update Users set UserName = @NewUserName, 
Email = @NewEmail, 
Address = @NewAddress, 
Hash = @NewHash, 
Salt = @NewSalt,
RoleID = @NewRoleID
where UserID = @UserID and 
	UserName = @OldUserName and 
	Email = @OldEmail and 
	Address = @OldAddress and 
	Hash = @OldHash and	
	Salt = @OldSalt and
	RoleID = @OldRoleID
 
end
GO
USE [master]
GO
ALTER DATABASE [SecondChance] SET  READ_WRITE 
GO

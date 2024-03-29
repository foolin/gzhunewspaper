/*==============================================================*/
/* Purpose:        Procedure For Datebase                       */
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Author:         Foolin (Foolin@126.com)                      */
/* Created on:     2009-6-1 15:44:21                            */
/* Updated on:     2009-6-14 13:57:38                           */
/*==============================================================*/
if exists (select 1
            from  sysobjects
           where  id = object_id('GetSiteInfo')
            and   xtype='P')
   drop procedure GetSiteInfo
go

--检查管理员登录
if exists (select 1
            from  sysobjects
           where  id = object_id('ChkAdminLogin')
            and   xtype='P')
   drop procedure ChkAdminLogin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GetSystemConfig')
            and   xtype='P')
   drop procedure GetSystemConfig
go
if exists (select 1
            from  sysobjects
           where  id = object_id('UpdateSystemConfig')
            and   xtype='P')
   drop procedure UpdateSystemConfig
go
if exists (select 1
            from  sysobjects
           where  id = object_id('InitSystemConfig')
            and   xtype='P')
   drop procedure InitSystemConfig
go

--如果已经存在存储过程，则先删除--
if exists (select 1
            from  sysobjects
           where  id = object_id('GetAdminList')
            and   xtype='P')
   drop procedure GetAdminList
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetAdminInfo')
            and   xtype='P')
   drop procedure GetAdminInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('AddAdmin')
            and   xtype='P')
   drop procedure AddAdmin
go
if exists (select 1
            from  sysobjects
           where  id = object_id('UpdateAdminInfo')
            and   xtype='P')
   drop procedure UpdateAdminInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('DeleteAdmin')
            and   xtype='P')
   drop procedure DeleteAdmin
if exists (select 1
            from  sysobjects
           where  id = object_id('InitAdmin')
            and   xtype='P')
   drop procedure InitAdmin
go

--如果已经存在存储过程，则先删除--
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsPaperList')
            and   xtype='P')
   drop procedure GetNewsPaperList
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsPaperInfo')
            and   xtype='P')
   drop procedure GetNewsPaperInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsPaperByNO')
            and   xtype='P')
   drop procedure GetNewsPaperByNO
go
if exists (select 1
            from  sysobjects
           where  id = object_id('AddNewsPaper')
            and   xtype='P')
   drop procedure AddNewsPaper
go
if exists (select 1
            from  sysobjects
           where  id = object_id('UpdateNewsPaperInfo')
            and   xtype='P')
   drop procedure UpdateNewsPaperInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('DeleteNewsPaper')
            and   xtype='P')
   drop procedure DeleteNewsPaper
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetFirstPaperID')
            and   xtype='P')
   drop procedure GetFirstPaperID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetLastPaperID')
            and   xtype='P')
   drop procedure GetLastPaperID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetPrePaperID')
            and   xtype='P')
   drop procedure GetPrePaperID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNextPaperID')
            and   xtype='P')
   drop procedure GetNextPaperID
go

--如果已经存在存储过程，则先删除--
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsList')
            and   xtype='P')
   drop procedure GetNewsList
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsListByPaperID')
            and   xtype='P')
   drop procedure GetNewsListByPaperID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsListByPID')
            and   xtype='P')
   drop procedure GetNewsListByPID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsListByKeyword')
            and   xtype='P')
   drop procedure GetNewsListByKeyword
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsInfo')
            and   xtype='P')
   drop procedure GetNewsInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('AddNews')
            and   xtype='P')
   drop procedure AddNews
go
if exists (select 1
            from  sysobjects
           where  id = object_id('UpdateNewsInfo')
            and   xtype='P')
   drop procedure UpdateNewsInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('DeleteNews')
            and   xtype='P')
   drop procedure DeleteNews
go

--如果已经存在存储过程，则先删除--
if exists (select 1
            from  sysobjects
           where  id = object_id('GetPaperPageList')
            and   xtype='P')
   drop procedure GetPaperPageList
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetPaperPageListByPaperID')
            and   xtype='P')
   drop procedure GetPaperPageListByPaperID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetPaperPageInfo')
            and   xtype='P')
   drop procedure GetPaperPageInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('AddPaperPage')
            and   xtype='P')
   drop procedure AddPaperPage
go
if exists (select 1
            from  sysobjects
           where  id = object_id('UpdatePaperPageInfo')
            and   xtype='P')
   drop procedure UpdatePaperPageInfo
go
if exists (select 1
            from  sysobjects
           where  id = object_id('DeletePaperPage')
            and   xtype='P')
   drop procedure DeletePaperPage
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetLastPageID')
            and   xtype='P')
   drop procedure GetLastPageID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetFirstPageID')
            and   xtype='P')
   drop procedure GetFirstPageID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetPrePageID')
            and   xtype='P')
   drop procedure GetPrePageID
go
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNextPageID')
            and   xtype='P')
   drop procedure GetNextPageID
go


--获取站点信息

CREATE PROCEDURE GetSiteInfo
AS
BEGIN
	SELECT * FROM SystemConfig
	SELECT * FROM Admin
END
Go


CREATE PROCEDURE ChkAdminLogin
(
  @AdminName VARCHAR(20),
  @Password VARCHAR(20)
)
AS
BEGIN
	DECLARE @AdminID INT
	DECLARE @AdminPwd VARCHAR(20)
	SELECT @AdminID=AdminID,@AdminPwd=Password FROM [Admin] WHERE AdminName=@AdminName
	IF(ISNULL(@AdminID,0)=0)
		RETURN 0
	IF(@Password<>@AdminPwd)
		RETURN -1
	RETURN @AdminID
END
Go

/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/
--系统配置信息


--创建存储过程--

CREATE PROCEDURE GetSystemConfig
AS
SELECT TOP 1 * FROM SystemConfig
GO

CREATE PROCEDURE UpdateSystemConfig
( 
  @PaperName VARCHAR(255),
  @SiteName VARCHAR(255),
  @SiteUrl VARCHAR(255),
  @PaperInfo VARCHAR(255),
  @IsOpenRegister BIT,
  @EditorName VARCHAR(255),
  @EditorAddrs VARCHAR(255),
  @EditorPhone VARCHAR(20),
  @EditorFax VARCHAR(20),
  @EditorEmail VARCHAR(50),
  @EditorPostCode VARCHAR(20)
)
AS

UPDATE SystemConfig
SET PaperName=@PaperName, SiteName=@SiteName,SiteUrl=@SiteUrl, PaperInfo=@PaperInfo, IsOpenRegister=@IsOpenRegister,
    EditorName=@EditorName, EditorAddrs=@EditorAddrs, EditorPhone=@EditorPhone, EditorFax=@EditorFax, EditorEmail=@EditorEmail, EditorPostCode=@EditorPostCode
GO
 
CREATE PROCEDURE InitSystemConfig
AS
BEGIN
    --初始化系统配置--
	DELETE FROM SystemConfig
    INSERT INTO SystemConfig(PaperName, SiteName, SiteUrl,PaperInfo, IsOpenRegister, EditorName, EditorAddrs, EditorPhone, EditorFax, EditorEmail, EditorPostCode)
    VALUES('广州大学报', '广州大学报在线阅读系统',  'http://xb.gzhu.edu.cn', '中共广州大学委员会主管主办 国内统一刊号：CN44-0803/（G）',
            0, '广州大学校报编辑部', '广州大学行政A楼后座612室', '02039341141', '02039341141', 'gdnews@126.com', '51006')
END
GO
EXEC InitSystemConfig
GO
  
/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/

--创建存储过程--

CREATE PROCEDURE GetAdminList
AS
SELECT * FROM Admin
ORDER BY AdminID DESC
GO

CREATE PROCEDURE GetAdminInfo(@AdminID INT)
AS
SELECT * FROM Admin
WHERE AdminID = @AdminID
GO


CREATE PROCEDURE AddAdmin
(
  @AdminName VARCHAR(20),
  @Password VARCHAR(20),
  @Power INT
)
AS
INSERT INTO Admin(AdminName, Password, Power, LoginCount, LastLoginTime, LastLoginIP) VALUES(@AdminName, @Password, @Power, 0, getdate(), '127.0.0.1')
Go


CREATE PROCEDURE UpdateAdminInfo
( @AdminID INT,
  @AdminName VARCHAR(20),
  @Password VARCHAR(20),
  @Power INT,
  @LoginCount INT,
  @LastLoginTime DateTime,
  @LastLoginIP VARCHAR(20)
)
AS
UPDATE Admin
SET AdminName=@AdminName, Password=@Password, Power=@Power, LoginCount=@LoginCount, LastLoginTime=@LastLoginTime, LastLoginIP=@LastLoginIP
WHERE AdminID=@AdminID
GO

CREATE PROCEDURE DeleteAdmin(@AdminID INT)
AS
DELETE Admin WHERE AdminID = @AdminID
GO

--初始化管理员 帐号:admin,密码：123456 --
CREATE PROCEDURE InitAdmin
AS
BEGIN
	DELETE FROM Admin
	EXEC AddAdmin 'admin','E10ADC3949BA59ABBE56',3
END
GO

EXEC InitAdmin
Go

/*==============================================================*/
/* Table: NewsPaper                                             */
/*==============================================================*/

--创建存储过程--

CREATE PROCEDURE GetNewsPaperList
AS
SELECT * FROM NewsPaper
ORDER BY PaperID DESC
GO

CREATE PROCEDURE GetNewsPaperInfo(@PaperID INT)
AS
SELECT * FROM NewsPaper
WHERE PaperID = @PaperID
GO


CREATE PROCEDURE AddNewsPaper
(
  @PaperID INT,
  @PublishDate DateTime,
  @NumOfPage INT,
  @IsShow BIT
)
AS
INSERT INTO NewsPaper(PaperID, PublishDate, NumOfPage, IsShow) VALUES(@PaperID, @PublishDate, @NumOfPage, @IsShow)
Go


CREATE PROCEDURE UpdateNewsPaperInfo
( @PaperID INT,
  @PublishDate DateTime,
  @NumOfPage INT,
  @IsShow BIT
)
AS
UPDATE NewsPaper
SET PublishDate = @PublishDate, NumOfPage = @NumOfPage,IsShow = @IsShow
WHERE PaperID=@PaperID
GO

CREATE PROCEDURE DeleteNewsPaper(@PaperID INT)
AS
DELETE News WHERE PaperID = @PaperID
DELETE PaperPage WHERE PaperID = @PaperID
DELETE NewsPaper WHERE PaperID = @PaperID
GO

CREATE PROCEDURE GetFirstPaperID
AS
BEGIN
	DECLARE @PaperID INT
	SELECT Top 1 @PaperID=PaperID FROM NewsPaper
	IF(ISNULL(@PaperID, 0)=0)
		RETURN 0
	RETURN @PaperID
END
GO

CREATE PROCEDURE GetLastPaperID
AS
BEGIN
	DECLARE @PaperID INT
	SELECT Top 1 @PaperID=PaperID FROM NewsPaper ORDER BY PaperID DESC
	IF(ISNULL(@PaperID, 0)=0)
		RETURN 0
	RETURN @PaperID
END
GO

CREATE PROCEDURE GetPrePaperID(@PaperID INT)
AS
BEGIN
	DECLARE @PrePaperID INT
	SELECT Top 1 @PrePaperID=PaperID FROM NewsPaper WHERE PaperID < @PaperID ORDER BY PaperID DESC
	IF(ISNULL(@PrePaperID, 0)=0)
		RETURN 0
	RETURN @PrePaperID
END
GO

CREATE PROCEDURE GetNextPaperID(@PaperID INT)
AS
BEGIN
	DECLARE @NextPaperID INT
	SELECT Top 1 @NextPaperID=PaperID FROM NewsPaper WHERE PaperID > @PaperID
	IF(ISNULL(@NextPaperID, 0)=0)
		RETURN 0
	RETURN @NextPaperID
END
GO

/*==============================================================*/
/* Table: PaperPage                                             */
/*==============================================================*/

--创建存储过程--

CREATE PROCEDURE GetPaperPageList
AS
SELECT * FROM PaperPage
ORDER BY PaperID DESC,PageID
GO

CREATE PROCEDURE GetPaperPageListByPaperID(@PaperID INT)
AS
SELECT * FROM PaperPage
WHERE PaperID = @PaperID
ORDER BY PageID
GO

CREATE PROCEDURE GetPaperPageInfo(@PaperID INT, @PageID INT)
AS
SELECT * FROM PaperPage
WHERE PaperID = @PaperID AND PageID = @PageID
GO


CREATE PROCEDURE AddPaperPage
(
  @PaperID INT,
  @PageID INT,
  @PageName VARCHAR(255),
  @PageImage VARCHAR(255)
)
AS
INSERT INTO PaperPage(PaperID, PageID, PageName, PageImage) VALUES(@PaperID, @PageID, @PageName, @PageImage)
Go


CREATE PROCEDURE UpdatePaperPageInfo
(
  @oldPaperID INT,
  @oldPageID INT,
  @PaperID INT,
  @PageID INT,
  @PageName VARCHAR(255),
  @PageImage VARCHAR(256)
)
AS
UPDATE PaperPage
SET PaperID=@PaperID, PageID = @PageID, PageName = @PageName, PageImage = @PageImage
WHERE PaperID = @oldPaperID AND PageID = @oldPageID
GO

CREATE PROCEDURE DeletePaperPage(@PaperID INT, @PageID INT)
AS
DELETE News WHERE PaperID = @PaperID AND PageID = @PageID
DELETE PaperPage WHERE PaperID = @PaperID AND PageID = @PageID
GO

CREATE PROCEDURE GetFirstPageID(@PaperID INT)
AS
BEGIN
	DECLARE @PageID INT 
	SELECT TOP 1 @PageID=PageID FROM PaperPage WHERE PaperID = @PaperID
	IF(IsNull(@PageID,0) = 0)
		RETURN 0
	RETURN @PageID
END
GO

CREATE PROCEDURE GetLastPageID(@PaperID INT)
AS
BEGIN
	DECLARE @PageID INT 
	SELECT TOP 1 @PageID=PageID FROM PaperPage WHERE PaperID = @PaperID ORDER BY PageID DESC
	IF(IsNull(@PageID,0) = 0)
		RETURN 0
	RETURN @PageID
END
GO

CREATE PROCEDURE GetPrePageID(@PaperID INT, @PageID INT)
AS
BEGIN
	DECLARE @PrePageID INT
	SELECT Top 1 @PrePageID=PageID FROM PaperPage WHERE PaperID = @PaperID AND PageID < @PageID ORDER BY PageID DESC
	IF(ISNULL(@PrePageID, 0)=0)
		RETURN 0
	RETURN @PrePageID
END
GO

CREATE PROCEDURE GetNextPageID(@PaperID INT, @PageID INT)
AS
BEGIN
	DECLARE @NextPageID INT
	SELECT Top 1 @NextPageID=PageID FROM PaperPage WHERE PaperID = @PaperID AND PageID > @PageID
	IF(ISNULL(@NextPageID, 0)=0)
		RETURN 0
	RETURN @NextPageID
END
GO

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/

--创建存储过程--

CREATE PROCEDURE GetNewsList
AS
SELECT * FROM News
ORDER BY NewsID DESC
GO

CREATE PROCEDURE GetNewsListByPaperID(@PaperID INT)
AS
BEGIN
	SELECT * FROM News
	WHERE PaperID = @PaperID
	ORDER BY NewsID DESC
END
GO

CREATE PROCEDURE GetNewsListByPID(@PaperID INT, @PageID INT)
AS
BEGIN
	SELECT * FROM News
	WHERE PaperID = @PaperID AND PageID=@PageID
	ORDER BY NewsID DESC
END
GO


CREATE PROCEDURE GetNewsListByKeyword(
	@Keyword VARCHAR(255),
	@PageSize INT,
	@PageNo INT,
	@RecordCount INT OUT
)
AS
BEGIN
	DECLARE @TempTable TABLE
	(
		AutoID INT IDENTITY(1,1) NOT NULL,
		ArtID BIGINT NOT NULL
	)

	INSERT INTO @TempTable(ArtID)
	SELECT NewsID FROM News
	WHERE Title LIKE  '%' + @Keyword + '%'
	ORDER BY NewsID DESC

	SELECT @RecordCount=@@IDENTITY
	SET @RecordCount=ISNULL(@RecordCount,0)

	DECLARE @MaxID BIGINT
	DECLARE @MinID BIGINT

	SET @MinID = (@PageNo -1) * @PageSize +1
	SET @MaxID = @PageNo * @PageSize

	SELECT NewsID, PaperID, PageID, Title,Author, Content, PositionOfPage, AddUser, AddTime, ViewCount
	FROM News, @TempTable
	WHERE NewsID=ArtID  AND AutoID BETWEEN @MinID AND @MaxID
END
GO

CREATE PROCEDURE GetNewsInfo(@NewsID INT)
AS
SELECT * FROM News
WHERE NewsID = @NewsID
GO


CREATE PROCEDURE AddNews
(
  @PaperID INT,
  @PageID INT,
  @Title VARCHAR(255),
  @Author VARCHAR(20),
  @Content Text,
  @PositionOfPage TEXT,
  @AddUser VARCHAR(20),
  @AddTime DATETIME
)
AS
INSERT INTO News(PaperID, PageID, Title, Author, Content, PositionOfPage, AddUser, AddTime, ViewCount)
VALUES(@PaperID, @PageID, @Title, @Author, @Content, @PositionOfPage, @AddUser, @AddTime, 0)
Go


CREATE PROCEDURE UpdateNewsInfo
(
  @NewsID INT,
  @PaperID INT,
  @PageID INT,
  @Title VARCHAR(255),
  @Author VARCHAR(20),
  @Content Text,
  @PositionOfPage TEXT
)
AS
UPDATE News
SET PaperID = @PaperID, PageID = @PageID, Title = @Title, Author = @Author, Content = @Content, PositionOfPage = @PositionOfPage
WHERE NewsID=@NewsID
GO

CREATE PROCEDURE DeleteNews(@NewsID INT)
AS
DELETE News WHERE NewsID = @NewsID
GO

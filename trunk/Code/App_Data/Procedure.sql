/*==============================================================*/
/* Purpose:        Procedure For Datebase                       */
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Author:         Foolin (Foolin@126.com)                      */
/* Created on:     2009-6-1 15:44:21                            */
/* Updated on:     2009-6-7 1:05:39                             */
/*==============================================================*/

--��ȡվ����Ϣ
if exists (select 1
            from  sysobjects
           where  id = object_id('GetSiteInfo')
            and   xtype='P')
   drop procedure GetSiteInfo
go

CREATE PROCEDURE GetSiteInfo
AS
BEGIN
	SELECT * FROM SystemConfig
	SELECT * FROM Admin
END
Go

--������Ա��¼
if exists (select 1
            from  sysobjects
           where  id = object_id('ChkAdminLogin')
            and   xtype='P')
   drop procedure ChkAdminLogin
go

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
--ϵͳ������Ϣ
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

--�����洢����--

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
  @EditorEmail VARCHAR(50)
)
AS

UPDATE SystemConfig
SET PaperName=@PaperName, SiteName=@SiteName, PaperInfo=@PaperInfo, IsOpenRegister=@IsOpenRegister,
    EditorName=@EditorName, EditorAddrs=@EditorAddrs, EditorPhone=@EditorPhone, EditorFax=@EditorFax, EditorEmail=@EditorEmail
GO
 
CREATE PROCEDURE InitSystemConfig
AS
BEGIN
    --��ʼ��ϵͳ����--
	DELETE FROM SystemConfig
    INSERT INTO SystemConfig(PaperName, SiteName, SiteUrl,PaperInfo, IsOpenRegister, EditorName, EditorAddrs, EditorPhone, EditorFax, EditorEmail)
    VALUES('���ݴ�ѧ��', '���ݴ�ѧ�������Ķ�ϵͳ',  'http://xb.gzhu.edu.cn', '�й����ݴ�ѧίԱ���������� ����ͳһ���ţ�CN44-0803/��G��',
            'TRUE', '���ݴ�ѧУ���༭��', '���ݴ�ѧ�༭��', '02039341141', '02039341141', 'gdnews@126.com')
END
GO
EXEC InitSystemConfig
GO
  
/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/
--����Ѿ����ڴ洢���̣�����ɾ��--
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

--�����洢����--

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
INSERT INTO Admin(AdminName, Password, Power) VALUES(@AdminName, @Password, @Power)
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

--��ʼ������Ա �ʺ�:admin,���룺123456 --
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
--����Ѿ����ڴ洢���̣�����ɾ��--
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

--�����洢����--

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
  @NumOfPage INT
)
AS
INSERT INTO NewsPaper(PaperID, PublishDate, NumOfPage) VALUES(@PaperID, @PublishDate, @NumOfPage)
Go


CREATE PROCEDURE UpdateNewsPaperInfo
( @PaperID INT,
  @PublishDate DateTime,
  @NumOfPage INT
)
AS
UPDATE NewsPaper
SET PublishDate = @PublishDate, NumOfPage = @NumOfPage
WHERE PaperID=@PaperID
GO

CREATE PROCEDURE DeleteNewsPaper(@PaperID INT)
AS
DELETE PaperPage WHERE PaperID = @PaperID
DELETE NewsPaper WHERE PaperID = @PaperID
GO


/*==============================================================*/
/* Table: PaperPage                                             */
/*==============================================================*/
--����Ѿ����ڴ洢���̣�����ɾ��--
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

--�����洢����--

CREATE PROCEDURE GetPaperPageList
AS
SELECT * FROM PaperPage
ORDER BY PageID DESC
GO

CREATE PROCEDURE GetPaperPageListByPaperID(@PaperID INT)
AS
SELECT * FROM PaperPage
WHERE PaperID = @PaperID
ORDER BY PaperID
GO

CREATE PROCEDURE GetPaperPageInfo(@PageID INT)
AS
SELECT * FROM PaperPage
WHERE PageID = @PageID
GO


CREATE PROCEDURE AddPaperPage
(
  @PaperID INT,
  @PageNO INT,
  @PageName VARCHAR(255),
  @PageImage VARCHAR(255)
)
AS
INSERT INTO PaperPage(PaperID, PageNO, PageName, PageImage) VALUES(@PaperID, @PageNO, @PageName, @PageImage)
Go


CREATE PROCEDURE UpdatePaperPageInfo
( @PageID INT,
  @PageNO INT,
  @PageName VARCHAR(255),
  @PageImage VARCHAR(256)
)
AS
UPDATE PaperPage
SET PageNO = @PageNO, PageName = @PageName, PageImage = @PageImage
WHERE PageID=@PageID
GO

CREATE PROCEDURE DeletePaperPage(@PageID INT)
AS
DELETE News WHERE PageID = @PageID
DELETE PaperPage WHERE PageID = @PageID
GO

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/
--����Ѿ����ڴ洢���̣�����ɾ��--
if exists (select 1
            from  sysobjects
           where  id = object_id('GetNewsList')
            and   xtype='P')
   drop procedure GetNewsList
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

--�����洢����--

CREATE PROCEDURE GetNewsList
AS
SELECT * FROM News
ORDER BY NewsID DESC
GO

CREATE PROCEDURE GetNewsInfo(@NewsID INT)
AS
SELECT * FROM News
WHERE NewsID = @NewsID
GO


CREATE PROCEDURE AddNews
(
  @PageID INT,
  @Title VARCHAR(255),
  @Author VARCHAR(20),
  @Content Text,
  @PositionOfPage TEXT,
  @AddUser VARCHAR(20),
  @AddTime DATETIME
)
AS
INSERT INTO News(PageID, Title, Author, Content, PositionOfPage, AddUser, AddTime, ViewCount)
VALUES(@PageID, @Title, @Author, @Content, @PositionOfPage, @AddUser, @AddTime, 0)
Go


CREATE PROCEDURE UpdateNewsInfo
(
  @NewsID INT,
  @PageID INT,
  @Title VARCHAR(255),
  @Author VARCHAR(20),
  @Content Text,
  @PositionOfPage TEXT,
  @ViewCount INT
)
AS
UPDATE News
SET PageID = @PageID, Title = @Title, Author = @Author, Content = @Content, PositionOfPage = @PositionOfPage, ViewCount = @ViewCount
WHERE NewsID=@NewsID
GO

CREATE PROCEDURE DeleteNews(@NewsID INT)
AS
DELETE News WHERE NewsID = @NewsID
GO
/*==============================================================*/
/* Purpose:        Procedure For Datebase                       */
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2009-6-1 15:44:21                            */
/*==============================================================*/




/*==============================================================*/
/* Table: NewsPaper                                             */
/*==============================================================*/
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
  @PaperNO INT,
  @PublishDate DateTime,
  @NumOfPage INT
)
AS
INSERT NewsPaper(PaperNO, PublishDate, NumOfPage) VALUES(@PaperNO, @PublishDate, @NumOfPage)
Go


CREATE PROCEDURE UpdateNewsPaperInfo
( @PaperID INT,
  @PaperNO INT,
  @PublishDate DateTime,
  @NumOfPage INT
)
AS
UPDATE NewsPaper
SET PaperNO = @PaperNO, PublishDate = @PublishDate, NumOfPage = @NumOfPage
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
CREATE PROCEDURE GetPaperPageList
AS
SELECT * FROM PaperPage
ORDER BY PageID DESC
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
  @PageName VARCHAR(20),
  @PageImage Text
)
AS
INSERT NewsPaper(PaperNO, PublishDate, NumOfPage) VALUES(@PaperNO, @PublishDate, @NumOfPage)
Go


CREATE PROCEDURE UpdateNewsPaperInfo
( @PaperID INT,
  @PaperNO INT,
  @PublishDate DateTime,
  @NumOfPage INT
)
AS
UPDATE NewsPaper
SET PaperNO = @PaperNO, PublishDate = @PublishDate, NumOfPage = @NumOfPage
WHERE PaperID=@PaperID
GO

CREATE PROCEDURE DeleteNewsPaper(@PaperID INT)
AS
DELETE PaperPage WHERE PaperID = @PaperID
DELETE NewsPaper WHERE PaperID = @PaperID
GO
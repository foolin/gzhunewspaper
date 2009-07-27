if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('News') and o.name = 'FK_NEWS_R2_PAPERPAG')
alter table News
   drop constraint FK_NEWS_R2_PAPERPAG
go

if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('News') and o.name = 'FK_NEWS_R4_NEWSPAPE')
alter table News
   drop constraint FK_NEWS_R4_NEWSPAPE
go

if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PaperPage') and o.name = 'FK_PAPERPAG_R1_NEWSPAPE')
alter table PaperPage
   drop constraint FK_PAPERPAG_R1_NEWSPAPE
go

if exists (select 1
   from dbo.sysreferences r join dbo.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserFavorites') and o.name = 'FK_USERFAVO_R3_USERS')
alter table UserFavorites
   drop constraint FK_USERFAVO_R3_USERS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Admin')
            and   type = 'U')
   drop table Admin
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('News')
            and   name  = 'R4_FK'
            and   indid > 0
            and   indid < 255)
   drop index News.R4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('News')
            and   name  = 'R2_FK'
            and   indid > 0
            and   indid < 255)
   drop index News.R2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('News')
            and   type = 'U')
   drop table News
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NewsPaper')
            and   type = 'U')
   drop table NewsPaper
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PaperPage')
            and   name  = 'R1_FK'
            and   indid > 0
            and   indid < 255)
   drop index PaperPage.R1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PaperPage')
            and   type = 'U')
   drop table PaperPage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SystemConfig')
            and   type = 'U')
   drop table SystemConfig
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UserFavorites')
            and   name  = 'R3_FK'
            and   indid > 0
            and   indid < 255)
   drop index UserFavorites.R3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserFavorites')
            and   type = 'U')
   drop table UserFavorites
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Users')
            and   type = 'U')
   drop table Users
go


/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/
create table Admin (
   AdminID              int                  identity,
   AdminName            varchar(20)          not null,
   Password             varchar(20)          not null,
   Power                int                  null,
   LoginCount           int                  null,
   LastLoginTime        datetime             null,
   LastLoginIP          varchar(20)          null,
   constraint PK_ADMIN primary key nonclustered (AdminID)
)
go

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/
create table News (
   NewsID               int                  identity,
   PaperID              int                  null,
   PageID               int                  null,
   Title                varchar(255)         not null,
   Author               varchar(20)          null,
   Content              text                 not null,
   PositionOfPage       text                 not null,
   AddUser              varchar(20)          null,
   AddTime              datetime             null,
   ViewCount            int                  null,
   constraint PK_NEWS primary key nonclustered (NewsID)
)
go

/*==============================================================*/
/* Index: R2_FK                                                 */
/*==============================================================*/
create index R2_FK on News (
PageID ASC,
PaperID ASC
)
go

/*==============================================================*/
/* Index: R4_FK                                                 */
/*==============================================================*/
create index R4_FK on News (
PaperID ASC
)
go

/*==============================================================*/
/* Table: NewsPaper                                             */
/*==============================================================*/
create table NewsPaper (
   PaperID              int                  not null,
   PublishDate          datetime             not null,
   NumOfPage            int                  not null,
   IsShow               bit                  null,
   constraint PK_NEWSPAPER primary key nonclustered (PaperID)
)
go

/*==============================================================*/
/* Table: PaperPage                                             */
/*==============================================================*/
create table PaperPage (
   PageID               int                  not null,
   PaperID              int                  not null,
   PageName             varchar(255)         not null,
   PageImage            varchar(255)         not null,
   constraint PK_PAPERPAGE primary key nonclustered (PageID, PaperID)
)
go

/*==============================================================*/
/* Index: R1_FK                                                 */
/*==============================================================*/
create index R1_FK on PaperPage (
PaperID ASC
)
go

/*==============================================================*/
/* Table: SystemConfig                                          */
/*==============================================================*/
create table SystemConfig (
   PaperName            varchar(255)         not null,
   SiteName             varchar(255)         null,
   SiteUrl              varchar(255)         null,
   PaperInfo            text                 null,
   IsOpenRegister       bit                  null,
   EditorName           varchar(255)         null,
   EditorAddrs          varchar(255)         null,
   EditorPhone          varchar(20)          null,
   EditorFax            varchar(20)          null,
   EditorEmail          varchar(50)          null,
   EditorPostCode       varchar(20)          null
)
go

/*==============================================================*/
/* Table: UserFavorites                                         */
/*==============================================================*/
create table UserFavorites (
   FavID                int                  identity,
   UserID               int                  null,
   FavName              varchar(20)          not null,
   FavUrl               varchar(255)         not null,
   FavTime              datetime             null,
   FavType              int                  null,
   constraint PK_USERFAVORITES primary key nonclustered (FavID)
)
go

/*==============================================================*/
/* Index: R3_FK                                                 */
/*==============================================================*/
create index R3_FK on UserFavorites (
UserID ASC
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserID               int                  identity,
   UserName             varchar(20)          not null,
   Password             varchar(20)          not null,
   NickName             varchar(20)          null,
   Email                varchar(50)          null,
   LoginCount           int                  null,
   LastLoginTime        datetime             null,
   LastLoginIP          varchar(20)          null,
   constraint PK_USERS primary key nonclustered (UserID)
)
go

alter table News
   add constraint FK_NEWS_R2_PAPERPAG foreign key (PageID, PaperID)
      references PaperPage (PageID, PaperID)
go

alter table News
   add constraint FK_NEWS_R4_NEWSPAPE foreign key (PaperID)
      references NewsPaper (PaperID)
go

alter table PaperPage
   add constraint FK_PAPERPAG_R1_NEWSPAPE foreign key (PaperID)
      references NewsPaper (PaperID)
go

alter table UserFavorites
   add constraint FK_USERFAVO_R3_USERS foreign key (UserID)
      references Users (UserID)
go


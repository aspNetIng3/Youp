
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2014 16:06:57
-- Generated from EDMX file: G:\school\ingesup\asp\SearchModule\Youp\YoupRepository\Youp.edmx
-- --------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
USE [Youp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Blog_fkBlogUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blogs] DROP CONSTRAINT [FK_Blog_fkBlogUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_fkPostBlog1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Post_fkPostBlog1];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogComment_fkBlogCommentPost1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [FK_BlogComment_fkBlogCommentPost1];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogComment_fkBlogCommentUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BlogComments] DROP CONSTRAINT [FK_BlogComment_fkBlogCommentUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Card_fkCardEvent1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cards] DROP CONSTRAINT [FK_Card_fkCardEvent1];
GO
IF OBJECT_ID(N'[dbo].[FK_Card_fkCardUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cards] DROP CONSTRAINT [FK_Card_fkCardUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_fkEventTheme1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Event_fkEventTheme1];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_fkEventUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Event_fkEventUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_EventComment_fkCommentEvent1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventComments] DROP CONSTRAINT [FK_EventComment_fkCommentEvent1];
GO
IF OBJECT_ID(N'[dbo].[FK_Rating_fkRatingEvent1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [FK_Rating_fkRatingEvent1];
GO
IF OBJECT_ID(N'[dbo].[FK_Thread_fkThreadEvent1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Threads] DROP CONSTRAINT [FK_Thread_fkThreadEvent1];
GO
IF OBJECT_ID(N'[dbo].[FK_EventComment_fkCommentUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventComments] DROP CONSTRAINT [FK_EventComment_fkCommentUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Favorite_fkFavoriteThread1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Favorites] DROP CONSTRAINT [FK_Favorite_fkFavoriteThread1];
GO
IF OBJECT_ID(N'[dbo].[FK_Favorite_fkFavoriteUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Favorites] DROP CONSTRAINT [FK_Favorite_fkFavoriteUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_fkMessageThread1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Message_fkMessageThread1];
GO
IF OBJECT_ID(N'[dbo].[FK_Message_fkMessageUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_Message_fkMessageUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Photo_fkPhotoUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photos] DROP CONSTRAINT [FK_Photo_fkPhotoUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Post_fkPostTheme1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Post_fkPostTheme1];
GO
IF OBJECT_ID(N'[dbo].[FK_User_fkUserRank1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_fkUserRank1];
GO
IF OBJECT_ID(N'[dbo].[FK_Rating_fkRatingUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [FK_Rating_fkRatingUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_User_fkUserRole1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_fkUserRole1];
GO
IF OBJECT_ID(N'[dbo].[FK_Theme_fkThemeTheme1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Themes] DROP CONSTRAINT [FK_Theme_fkThemeTheme1];
GO
IF OBJECT_ID(N'[dbo].[FK_Thread_fkThreadTheme1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Threads] DROP CONSTRAINT [FK_Thread_fkThreadTheme1];
GO
IF OBJECT_ID(N'[dbo].[FK_Participate_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participate] DROP CONSTRAINT [FK_Participate_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_Participate_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participate] DROP CONSTRAINT [FK_Participate_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTheme_Theme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserTheme] DROP CONSTRAINT [FK_UserTheme_Theme];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTheme_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserTheme] DROP CONSTRAINT [FK_UserTheme_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Blogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blogs];
GO
IF OBJECT_ID(N'[dbo].[BlogComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogComments];
GO
IF OBJECT_ID(N'[dbo].[Cards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cards];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[EventComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventComments];
GO
IF OBJECT_ID(N'[dbo].[Favorites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Favorites];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Photos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photos];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Ranks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ranks];
GO
IF OBJECT_ID(N'[dbo].[Ratings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ratings];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Themes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Themes];
GO
IF OBJECT_ID(N'[dbo].[Threads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Threads];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Participate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Participate];
GO
IF OBJECT_ID(N'[dbo].[UserTheme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserTheme];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [IsActive] smallint  NULL,
    [CreatedAt] datetime  NULL,
    [UpdatedAt] datetime  NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'BlogComments'
CREATE TABLE [dbo].[BlogComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [PostId] int  NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Cards'
CREATE TABLE [dbo].[Cards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Colour] nvarchar(255)  NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [EventId] nvarchar(36)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] nvarchar(36)  NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Slots] int  NOT NULL,
    [Cost] float  NULL,
    [Public] smallint  NULL,
    [Description] nvarchar(max)  NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [ThemeId] int  NOT NULL,
    [Address] nvarchar(255)  NOT NULL,
    [Lattitude] real  NULL,
    [Longitude] real  NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'EventComments'
CREATE TABLE [dbo].[EventComments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [EventId] nvarchar(36)  NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Favorites'
CREATE TABLE [dbo].[Favorites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [ThreadId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [ThreadId] int  NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [Url] nvarchar(255)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Visibility] int  NULL,
    [ThemeId] int  NOT NULL,
    [BlogId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Ranks'
CREATE TABLE [dbo].[Ranks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LevelRank] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating1] int  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [UserId] nvarchar(36)  NOT NULL,
    [EventId] nvarchar(36)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Label] nvarchar(255)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Themes'
CREATE TABLE [dbo].[Themes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ThemeId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Threads'
CREATE TABLE [dbo].[Threads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NULL,
    [IsSharable] smallint  NULL,
    [ThemeId] int  NOT NULL,
    [EventId] nvarchar(36)  NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] nvarchar(36)  NOT NULL,
    [UserName] nvarchar(255)  NOT NULL,
    [Email] nvarchar(255)  NOT NULL,
    [Password] nvarchar(255)  NULL,
    [GuidFacebook] nvarchar(255)  NULL,
    [IsActive] smallint  NULL,
    [Gender] nchar(1)  NULL,
    [Birthday] datetime  NULL,
    [Address] nvarchar(255)  NULL,
    [RankId] int  NOT NULL,
    [RoleId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [UpdatedAt] datetime  NOT NULL,
    [DeletedAt] datetime  NULL
);
GO

-- Creating table 'Participate'
CREATE TABLE [dbo].[Participate] (
    [Events1_Id] nvarchar(36)  NOT NULL,
    [Users_Id] nvarchar(36)  NOT NULL
);
GO

-- Creating table 'UserTheme'
CREATE TABLE [dbo].[UserTheme] (
    [Themes_Id] int  NOT NULL,
    [Users_Id] nvarchar(36)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [PK_BlogComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [PK_Cards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [PK_EventComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Favorites'
ALTER TABLE [dbo].[Favorites]
ADD CONSTRAINT [PK_Favorites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ranks'
ALTER TABLE [dbo].[Ranks]
ADD CONSTRAINT [PK_Ranks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [PK_Ratings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Themes'
ALTER TABLE [dbo].[Themes]
ADD CONSTRAINT [PK_Themes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Threads'
ALTER TABLE [dbo].[Threads]
ADD CONSTRAINT [PK_Threads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Events1_Id], [Users_Id] in table 'Participate'
ALTER TABLE [dbo].[Participate]
ADD CONSTRAINT [PK_Participate]
    PRIMARY KEY CLUSTERED ([Events1_Id], [Users_Id] ASC);
GO

-- Creating primary key on [Themes_Id], [Users_Id] in table 'UserTheme'
ALTER TABLE [dbo].[UserTheme]
ADD CONSTRAINT [PK_UserTheme]
    PRIMARY KEY CLUSTERED ([Themes_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_Blog_fkBlogUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Blog_fkBlogUser1'
CREATE INDEX [IX_FK_Blog_fkBlogUser1]
ON [dbo].[Blogs]
    ([UserId]);
GO

-- Creating foreign key on [BlogId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_fkPostBlog1]
    FOREIGN KEY ([BlogId])
    REFERENCES [dbo].[Blogs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_fkPostBlog1'
CREATE INDEX [IX_FK_Post_fkPostBlog1]
ON [dbo].[Posts]
    ([BlogId]);
GO

-- Creating foreign key on [PostId] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [FK_BlogComment_fkBlogCommentPost1]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[Posts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogComment_fkBlogCommentPost1'
CREATE INDEX [IX_FK_BlogComment_fkBlogCommentPost1]
ON [dbo].[BlogComments]
    ([PostId]);
GO

-- Creating foreign key on [UserId] in table 'BlogComments'
ALTER TABLE [dbo].[BlogComments]
ADD CONSTRAINT [FK_BlogComment_fkBlogCommentUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogComment_fkBlogCommentUser1'
CREATE INDEX [IX_FK_BlogComment_fkBlogCommentUser1]
ON [dbo].[BlogComments]
    ([UserId]);
GO

-- Creating foreign key on [EventId] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [FK_Card_fkCardEvent1]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Card_fkCardEvent1'
CREATE INDEX [IX_FK_Card_fkCardEvent1]
ON [dbo].[Cards]
    ([EventId]);
GO

-- Creating foreign key on [UserId] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [FK_Card_fkCardUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Card_fkCardUser1'
CREATE INDEX [IX_FK_Card_fkCardUser1]
ON [dbo].[Cards]
    ([UserId]);
GO

-- Creating foreign key on [ThemeId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_fkEventTheme1]
    FOREIGN KEY ([ThemeId])
    REFERENCES [dbo].[Themes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_fkEventTheme1'
CREATE INDEX [IX_FK_Event_fkEventTheme1]
ON [dbo].[Events]
    ([ThemeId]);
GO

-- Creating foreign key on [UserId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_fkEventUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_fkEventUser1'
CREATE INDEX [IX_FK_Event_fkEventUser1]
ON [dbo].[Events]
    ([UserId]);
GO

-- Creating foreign key on [EventId] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [FK_EventComment_fkCommentEvent1]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventComment_fkCommentEvent1'
CREATE INDEX [IX_FK_EventComment_fkCommentEvent1]
ON [dbo].[EventComments]
    ([EventId]);
GO

-- Creating foreign key on [EventId] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [FK_Rating_fkRatingEvent1]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Rating_fkRatingEvent1'
CREATE INDEX [IX_FK_Rating_fkRatingEvent1]
ON [dbo].[Ratings]
    ([EventId]);
GO

-- Creating foreign key on [EventId] in table 'Threads'
ALTER TABLE [dbo].[Threads]
ADD CONSTRAINT [FK_Thread_fkThreadEvent1]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Thread_fkThreadEvent1'
CREATE INDEX [IX_FK_Thread_fkThreadEvent1]
ON [dbo].[Threads]
    ([EventId]);
GO

-- Creating foreign key on [UserId] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [FK_EventComment_fkCommentUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventComment_fkCommentUser1'
CREATE INDEX [IX_FK_EventComment_fkCommentUser1]
ON [dbo].[EventComments]
    ([UserId]);
GO

-- Creating foreign key on [ThreadId] in table 'Favorites'
ALTER TABLE [dbo].[Favorites]
ADD CONSTRAINT [FK_Favorite_fkFavoriteThread1]
    FOREIGN KEY ([ThreadId])
    REFERENCES [dbo].[Threads]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Favorite_fkFavoriteThread1'
CREATE INDEX [IX_FK_Favorite_fkFavoriteThread1]
ON [dbo].[Favorites]
    ([ThreadId]);
GO

-- Creating foreign key on [UserId] in table 'Favorites'
ALTER TABLE [dbo].[Favorites]
ADD CONSTRAINT [FK_Favorite_fkFavoriteUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Favorite_fkFavoriteUser1'
CREATE INDEX [IX_FK_Favorite_fkFavoriteUser1]
ON [dbo].[Favorites]
    ([UserId]);
GO

-- Creating foreign key on [ThreadId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_fkMessageThread1]
    FOREIGN KEY ([ThreadId])
    REFERENCES [dbo].[Threads]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_fkMessageThread1'
CREATE INDEX [IX_FK_Message_fkMessageThread1]
ON [dbo].[Messages]
    ([ThreadId]);
GO

-- Creating foreign key on [UserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_Message_fkMessageUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Message_fkMessageUser1'
CREATE INDEX [IX_FK_Message_fkMessageUser1]
ON [dbo].[Messages]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [FK_Photo_fkPhotoUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Photo_fkPhotoUser1'
CREATE INDEX [IX_FK_Photo_fkPhotoUser1]
ON [dbo].[Photos]
    ([UserId]);
GO

-- Creating foreign key on [ThemeId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_fkPostTheme1]
    FOREIGN KEY ([ThemeId])
    REFERENCES [dbo].[Themes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_fkPostTheme1'
CREATE INDEX [IX_FK_Post_fkPostTheme1]
ON [dbo].[Posts]
    ([ThemeId]);
GO

-- Creating foreign key on [RankId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_fkUserRank1]
    FOREIGN KEY ([RankId])
    REFERENCES [dbo].[Ranks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_fkUserRank1'
CREATE INDEX [IX_FK_User_fkUserRank1]
ON [dbo].[Users]
    ([RankId]);
GO

-- Creating foreign key on [UserId] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [FK_Rating_fkRatingUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Rating_fkRatingUser1'
CREATE INDEX [IX_FK_Rating_fkRatingUser1]
ON [dbo].[Ratings]
    ([UserId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_fkUserRole1]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_fkUserRole1'
CREATE INDEX [IX_FK_User_fkUserRole1]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [ThemeId] in table 'Themes'
ALTER TABLE [dbo].[Themes]
ADD CONSTRAINT [FK_Theme_fkThemeTheme1]
    FOREIGN KEY ([ThemeId])
    REFERENCES [dbo].[Themes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Theme_fkThemeTheme1'
CREATE INDEX [IX_FK_Theme_fkThemeTheme1]
ON [dbo].[Themes]
    ([ThemeId]);
GO

-- Creating foreign key on [ThemeId] in table 'Threads'
ALTER TABLE [dbo].[Threads]
ADD CONSTRAINT [FK_Thread_fkThreadTheme1]
    FOREIGN KEY ([ThemeId])
    REFERENCES [dbo].[Themes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Thread_fkThreadTheme1'
CREATE INDEX [IX_FK_Thread_fkThreadTheme1]
ON [dbo].[Threads]
    ([ThemeId]);
GO

-- Creating foreign key on [Events1_Id] in table 'Participate'
ALTER TABLE [dbo].[Participate]
ADD CONSTRAINT [FK_Participate_Event]
    FOREIGN KEY ([Events1_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'Participate'
ALTER TABLE [dbo].[Participate]
ADD CONSTRAINT [FK_Participate_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Participate_User'
CREATE INDEX [IX_FK_Participate_User]
ON [dbo].[Participate]
    ([Users_Id]);
GO

-- Creating foreign key on [Themes_Id] in table 'UserTheme'
ALTER TABLE [dbo].[UserTheme]
ADD CONSTRAINT [FK_UserTheme_Theme]
    FOREIGN KEY ([Themes_Id])
    REFERENCES [dbo].[Themes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UserTheme'
ALTER TABLE [dbo].[UserTheme]
ADD CONSTRAINT [FK_UserTheme_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTheme_User'
CREATE INDEX [IX_FK_UserTheme_User]
ON [dbo].[UserTheme]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2017 17:10:30
-- Generated from EDMX file: C:\Users\claudine.bael\Documents\Visual Studio 2012\Projects\ESB OPC\Businessmall\Businessmall.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ebs.businessmall];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderProducts_orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderProducts] DROP CONSTRAINT [FK_OrderProducts_orders];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderProducts_products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderProducts] DROP CONSTRAINT [FK_OrderProducts_products];
GO
IF OBJECT_ID(N'[dbo].[FK_orders_users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[orders] DROP CONSTRAINT [FK_orders_users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrderProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderProducts];
GO
IF OBJECT_ID(N'[dbo].[orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[orders];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrderProducts'
CREATE TABLE [dbo].[OrderProducts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [order_id] int  NOT NULL,
    [product_id] int  NOT NULL,
    [qty] int  NOT NULL
);
GO

-- Creating table 'Orders1'
CREATE TABLE [dbo].[Orders1] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [date_ordered] datetime  NOT NULL
);
GO

-- Creating table 'Products1'
CREATE TABLE [dbo].[Products1] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(255)  NOT NULL,
    [price] decimal(18,2)  NOT NULL,
    [qty_at_hand] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users1'
CREATE TABLE [dbo].[Users1] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [first_name] nvarchar(255)  NULL,
    [last_name] nvarchar(255)  NULL,
    [is_admin] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'OrderProducts'
ALTER TABLE [dbo].[OrderProducts]
ADD CONSTRAINT [PK_OrderProducts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Orders1'
ALTER TABLE [dbo].[Orders1]
ADD CONSTRAINT [PK_Orders1]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Products1'
ALTER TABLE [dbo].[Products1]
ADD CONSTRAINT [PK_Products1]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Users1'
ALTER TABLE [dbo].[Users1]
ADD CONSTRAINT [PK_Users1]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [order_id] in table 'OrderProducts'
ALTER TABLE [dbo].[OrderProducts]
ADD CONSTRAINT [FK_OrderProducts_orders]
    FOREIGN KEY ([order_id])
    REFERENCES [dbo].[Orders1]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderProducts_orders'
CREATE INDEX [IX_FK_OrderProducts_orders]
ON [dbo].[OrderProducts]
    ([order_id]);
GO

-- Creating foreign key on [product_id] in table 'OrderProducts'
ALTER TABLE [dbo].[OrderProducts]
ADD CONSTRAINT [FK_OrderProducts_products]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Products1]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderProducts_products'
CREATE INDEX [IX_FK_OrderProducts_products]
ON [dbo].[OrderProducts]
    ([product_id]);
GO

-- Creating foreign key on [user_id] in table 'Orders1'
ALTER TABLE [dbo].[Orders1]
ADD CONSTRAINT [FK_orders_users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users1]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_orders_users'
CREATE INDEX [IX_FK_orders_users]
ON [dbo].[Orders1]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
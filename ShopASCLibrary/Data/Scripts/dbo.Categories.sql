USE [ShopASCDB]
GO

/****** Objeto: Table [dbo].[Categories] Data do Script: 15/12/2023 18:05:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL
);



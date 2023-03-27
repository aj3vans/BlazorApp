USE [BlazorApp.Database]
GO

/****** Object: Table [dbo].[Files] Script Date: 27/03/2023 12:22:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Files] (
    [FileId]     INT             IDENTITY (1, 1) NOT NULL,
    [FileName]   VARCHAR (4000)  NOT NULL,
    [FileBinary] VARBINARY (MAX) NOT NULL
);



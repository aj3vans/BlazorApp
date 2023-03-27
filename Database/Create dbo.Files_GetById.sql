USE [BlazorApp.Database]
GO

/****** Object: SqlProcedure [dbo].[Files-GetById] Script Date: 27/03/2023 12:23:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Files-GetById]
@FileId INT
AS
	SELECT *
	FROM [dbo].[Files]
	WHERE [FileId] = @FileId
RETURN 0

USE [BlazorApp.Database]
GO

/****** Object: SqlProcedure [dbo].[Files-Save] Script Date: 27/03/2023 12:23:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Files-Save]
@FileId INT, 
@FileName VARCHAR(4000),
@FileBinary VARBINARY(MAX)
AS
	IF EXISTS(SELECT * FROM [dbo].[Files] WHERE [FileId] = @FileId)
		BEGIN
			UPDATE [dbo].[Files] 			
			SET 
				[FileName] = @FileName,
				[FileBinary] = @FileBinary
			OUTPUT inserted.FileId
			WHERE [FileId] = @FileId
		END
	ELSE 
		BEGIN
			INSERT INTO [dbo].[Files]([FileName],[FileBinary])
			OUTPUT inserted.FileId
			VALUES(@FileName,@FileBinary)
		END 
RETURN 0

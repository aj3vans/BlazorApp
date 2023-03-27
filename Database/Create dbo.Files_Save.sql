USE [BlazorApp.Database]
GO

/****** Object: SqlProcedure [dbo].[Files-Save] Script Date: 27/03/2023 13:47:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Files-Save]
@FileId INT, 
@FileName VARCHAR(4000),
@FileType VARCHAR(4000),
@FileBinary VARBINARY(MAX)
AS
	IF EXISTS(SELECT * FROM [dbo].[Files] WHERE [FileId] = @FileId)
		BEGIN
			UPDATE [dbo].[Files] 			
			SET 
				[FileName] = @FileName,
				[FileType] = @FileType,
				[FileBinary] = @FileBinary
			OUTPUT inserted.FileId
			WHERE [FileId] = @FileId
		END
	ELSE 
		BEGIN
			INSERT INTO [dbo].[Files]([FileName],[FileType],[FileBinary])
			OUTPUT inserted.FileId
			VALUES(@FileName,@FileType,@FileBinary)
		END 
RETURN 0

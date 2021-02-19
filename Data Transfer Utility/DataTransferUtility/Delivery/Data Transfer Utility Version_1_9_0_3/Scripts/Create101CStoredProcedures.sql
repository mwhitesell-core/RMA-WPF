USE [%DatabaseName%]

/****** Object:  StoredProcedure [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101_TO_101C]    Script Date: 2019-10-03 11:51:13 AM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
/* ========================================================================================== */
/* Entity Name:	sp_COPY_F040_OMA_FEE_MSTR_FROM_101_TO_101C                                    */
/* Create date:	7/24/2017 10:32:31 AM                                                         */
/* Description:	This stored procedure copies F040_OMA_FEE_MSTR to 101C database               */
/* ========================================================================================== */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_COPY_F040_OMA_FEE_MSTR_FROM_101_TO_101C')
	DROP PROCEDURE [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101_TO_101C]

EXECUTE sp_executesql N'
Create Procedure [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101_TO_101C]
As
Begin
	/* Copy F040_OMA_FEE_MASTER to 101C */
	IF EXISTS (SELECT * FROM [101C].[sys].[objects] WHERE object_id = OBJECT_ID(N''[101C].[INDEXED].[F040_OMA_FEE_MSTR]'') AND type in (N''U''))
		DROP TABLE [101C].[INDEXED].[F040_OMA_FEE_MSTR]

	SELECT * INTO [101C].[INDEXED].[F040_OMA_FEE_MSTR] FROM [101].[INDEXED].[F040_OMA_FEE_MSTR]
End
';

/****** Object:  StoredProcedure [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101C_TO_101]    Script Date: 2019-10-03 11:51:13 AM ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
/* ==========================================================================================   */
/* Entity Name:	sp_COPY_F040_OMA_FEE_MSTR_FROM_101C_TO_101                                      */
/* Create date:	7/24/2017 10:32:31 AM                                                           */
/* Description:	This stored procedure copies F040_OMA_FEE_MSTR to 101C_BACKUP and 101 databases */
/* ==========================================================================================   */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_COPY_F040_OMA_FEE_MSTR_FROM_101C_TO_101')
	DROP PROCEDURE [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101C_TO_101]
	
EXECUTE sp_executesql N'
Create Procedure [INDEXED].[sp_COPY_F040_OMA_FEE_MSTR_FROM_101C_TO_101]
As
Begin
	/* Backup F040_OMA_FEE_MSTR to 101C_BACKUP */
	IF EXISTS (SELECT * FROM [101C_BACKUP].sys.objects WHERE object_id = OBJECT_ID(N''[101C_BACKUP].[dbo].[F040_OMA_FEE_MSTR]'') AND type in (N''U''))
		DROP TABLE [101C_BACKUP].[dbo].[F040_OMA_FEE_MSTR]
	    
	SELECT * INTO [101C_BACKUP].[dbo].[F040_OMA_FEE_MSTR] FROM [101C].[INDEXED].[F040_OMA_FEE_MSTR]
	
	/* Copy F040_OMA_FEE_MASTER to 101 */
	IF EXISTS (SELECT * FROM [101].sys.objects WHERE object_id = OBJECT_ID(N''[101].[INDEXED].[F040_OMA_FEE_MSTR]'') AND type in (N''U''))
		DROP TABLE [101].[INDEXED].[F040_OMA_FEE_MSTR]
	
	SELECT * INTO [101].[INDEXED].[F040_OMA_FEE_MSTR] FROM [101C].[INDEXED].[F040_OMA_FEE_MSTR]
End
';

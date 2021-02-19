USE [%DatabaseName%]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

IF OBJECT_ID('[INDEXED].[EXTF002HDR]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[EXTF002HDR]

IF OBJECT_ID('[INDEXED].[F002_ORIG_DTL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[F002_ORIG_DTL]

IF OBJECT_ID('[INDEXED].[DIFF_SV_DATE_SEL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[DIFF_SV_DATE_SEL]

IF OBJECT_ID('[INDEXED].[DIFF_AMTS_SEL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[DIFF_AMTS_SEL]

IF OBJECT_ID('[INDEXED].[vw_OUTSTANDING_CLAIMS]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[vw_OUTSTANDING_CLAIMS]

SET NOCOUNT ON  
EXEC master.dbo.sp_configure 'show advanced options', 1 
RECONFIGURE 
EXEC master.dbo.sp_configure 'xp_cmdshell', 1 
RECONFIGURE 

DECLARE @sql AS varchar(300)

SET @sql = 'sqlcmd -S %SQLServer% -d %DatabaseName% -i "%ScriptLocation%CreateView_EXTF002HDR.sql"'
EXEC xp_cmdshell @sql

SET @sql = 'sqlcmd -S %SQLServer% -d %DatabaseName% -i "%ScriptLocation%CreateView_F002_ORIG_DTL.sql"'
EXEC xp_cmdshell @sql

SET @sql = 'sqlcmd -S %SQLServer% -d %DatabaseName% -i "%ScriptLocation%CreateView_DIFF_SV_DATE_SEL.sql"'
EXEC xp_cmdshell @sql

SET @sql = 'sqlcmd -S %SQLServer% -d %DatabaseName% -i "%ScriptLocation%CreateView_DIFF_AMTS_SEL.sql"'
EXEC xp_cmdshell @sql

SET @sql = 'sqlcmd -S %SQLServer% -d %DatabaseName% -i "%ScriptLocation%CreateView_OUTSTANDING_CLAIMS.sql"'
EXEC xp_cmdshell @sql

EXEC master.dbo.sp_configure 'xp_cmdshell', 0 
RECONFIGURE 
EXEC master.dbo.sp_configure 'show advanced options', 0 
RECONFIGURE  
SET NOCOUNT OFF 
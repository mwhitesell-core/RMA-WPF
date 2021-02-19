-- This script file will be used to replace the 
-- F113_DEFAULT_COMP_BLANK_DOC dat file
-- It can be used to insert a doc record into the F113_DEFAULT_COMP table
-- To use this script:

-- 1. Open SQL Studio
-- 2. Connect to the MP database
-- 3. Copy and paste this script into SQL studio
-- 4. Run the script.

USE [MP]
GO

INSERT INTO [INDEXED].[F113_DEFAULT_COMP]
           ([DOC_NBR]
           ,[EP_NBR_FROM]
           ,[COMP_CODE]
           ,[EP_NBR_TO]
           ,[FACTOR]
           ,[FACTOR_OVERRIDE]
           ,[COMP_UNITS]
           ,[AMT_GROSS]
           ,[AMT_NET]
           ,[EP_NBR_ENTRY]
           ,[LAST_MOD_DATE]
           ,[LAST_MOD_TIME]
           ,[LAST_MOD_USER_ID])
     VALUES
           ('   '
           ,200801
           ,'TAX'
           ,200815
           ,0.4
           ,''
           ,0
           ,0
           ,0
           ,200715
           ,20080709
           ,1015
           ,'Comp.YrEndRoll')
GO



---------------------------------------------------------------------
-- CORE SOFTWARE CORP. (R) 32-bit PowerHouse Preprocessor for 80x86
-- CORE Migration API Loader Script
-- Copyright (C) CORE SOFTWARE CORP. 1997-1999. Patent Pending.
-- All rights reserved.
---------------------------------------------------------------------
-- Clean The Repository.

@@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\Tools\Truncate_Application.sql
@@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\Tools\Truncate_Metadata.sql

-- Load the Dictionary.

@@T:\CLIENTS\RMA\GoldApr282017\ParsedCode\pdl\rmabill.api
@@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\Tools\Metadata_views

-- Load the Screens.

@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\LoadAllQuick.sql

-- Load the QTP.

@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\LoadAllQTP.sql

-- Load the QUIZ.
@T:\Clients\RMA\GoldApr282017\RepositoryLoadScripts\LoadAllQuiz.sql

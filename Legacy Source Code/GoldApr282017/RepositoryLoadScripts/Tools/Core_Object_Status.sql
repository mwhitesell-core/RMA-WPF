--  Program Name     	 : Core_Object_Status.sql
--  Program Function 	 : Check for all invalid repository objects are 
--			   recompile them to set the status to valid.
--  Version	     	 : 1.0.39
--  Author      	 : Rolf C. Christensen.  
--  Date Created         : June 27th, 2000
--  Modification History :
--  Programs Referenced  : None.
--  
SET TERMOUT ON
column nl newline

PROMPT ***************************************************************
PROMPT * Recompiling invalid Repository objects...
PROMPT *
PROMPT ***************************************************************

set heading off 
set feedback off 
set termout off 
set pages 0

spool coreapicom.tmp

PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Repository views...
PROMPT PROMPT

select 'PROMPT Compiling View '||object_name nl
,      'alter view '||object_name||' compile;' nl
from  user_objects
where object_type = 'VIEW'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%')
order by created
/


PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Repository functions...
PROMPT PROMPT

select 'PROMPT Compiling function '||object_name nl
,      'alter function '||object_name||' compile	;' nl
from  user_objects
where object_type = 'FUNCTION'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%' or object_name like 'GET_%' or object_name like 'VB%')
order by created
/

PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Procedures...
PROMPT PROMPT

select 'PROMPT Compiling Procedure '||object_name nl
,      'alter Procedure '||object_name||' compile;' nl
from  user_objects
where object_type = 'PROCEDURE'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%' or object_name like 'VB%')
order by created
/

PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Repository package specifications...
PROMPT PROMPT

select 'PROMPT Compiling Package  '||object_name nl
,      'alter package '||object_name||' compile package;' nl
from  user_objects
where object_type = 'PACKAGE'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%' or object_name like 'VB%')
order by created
/

PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Repository package Body specifications...
PROMPT PROMPT

select 'PROMPT Compiling Package Body '||object_name nl
,      'alter package '||object_name||' compile body;' nl
from  user_objects
where object_type = 'PACKAGE BODY'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%' or object_name like 'VB%')
order by created
/


PROMPT PROMPT
PROMPT PROMPT Re-compiling invalid Repository Triggers...
PROMPT PROMPT

select 'PROMPT Compiling Trigger '||object_name nl
,      'alter Trigger '||object_name||' compile	;' nl
from  user_objects
where object_type = 'TRIGGER'
and   status      =  'INVALID'
and (object_name like 'RP%' or object_name like 'DB%' or object_name like 'PLGEN%' or object_name like 'CORE_%' or object_name like 'VB%')
order by created
/

spool off

set termout on 
spool coreapicom.lis

start coreapicom.tmp

spool off


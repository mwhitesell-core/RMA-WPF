* versions.ws
* Purpose: allows applications to determine if they are running
*	   in the normal "live" or "production" system as compared
*	   to one of the other 'special payroll' or 'testing' subsystems
*	   This information is used to blink a warning on the top of the
*	   menu screens to remind the user they are in a "non-normal"
*	   version of the application.
*
*  note: keep versions.def in sync! 

77  version-live		pic x(10) value "101c".
			

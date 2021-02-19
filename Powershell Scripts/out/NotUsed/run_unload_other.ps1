#-------------------------------------------------------------------------------
# File 'run_unload_other.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_unload_other'
#-------------------------------------------------------------------------------

# RUN_UNLOAD_OTHER
# RMA Physician Other QUIZ and QTP.
# This script runs the QUIZ and QTP unload programs that create the 
# portable subfiles from production to be put into the test system.
# Created by S. Bachmann on Feb. 2, 1999.

&$env:QUIZ unlof001
&$env:QUIZ unlof010
&$env:QUIZ unlof021
&$env:QUIZ unlof022
&$env:QUIZ unlof040
&$env:QUIZ unlof119hst

&$env:QTP unlof002

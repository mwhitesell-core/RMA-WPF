#-------------------------------------------------------------------------------
# File 'run_reload_other.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_reload_other'
#-------------------------------------------------------------------------------

# RUN_RELOAD_OTHER
# RMA Physician Other QTP reload programs.
# This script runs the QTP reload programs that reload the 
# portable subfiles from production into the test system.
# Created by S. Bachmann on Feb. 3, 1999.

&$env:QTP relof001
&$env:QTP relof002
&$env:QTP relof010
&$env:QTP relof021
&$env:QTP relof022
&$env:QTP relof040
&$env:QTP relof119hst

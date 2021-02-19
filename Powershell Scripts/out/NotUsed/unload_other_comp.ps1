#-------------------------------------------------------------------------------
# File 'unload_other_comp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'unload_other_comp'
#-------------------------------------------------------------------------------

# UNLOAD_OTHER_COMP
# RMA Physician Other QUIZ compile.
# This script is used to compile the QUIZ unload programs that create the 
# portable subfiles needed to reload into the test system.
# Created by S. Bachmann on Feb. 2, 1999.

&$env:QUIZ unlof001
&$env:QUIZ unlof010
&$env:QUIZ unlof021
&$env:QUIZ unlof022
&$env:QUIZ unlof040
&$env:QUIZ unlof119hst

&$env:QTP unlof002

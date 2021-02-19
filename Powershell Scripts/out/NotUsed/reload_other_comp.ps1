#-------------------------------------------------------------------------------
# File 'reload_other_comp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_other_comp'
#-------------------------------------------------------------------------------

# RELOAD_OTHER_COMP
# RMA Physician Other QTP compile.
# This script compile's the QTP reload programs that reload 
#  the production data into the files in test.
# Created by S. Bachmann on Feb. 2, 1999.

&$env:QTP relof001
&$env:QTP relof002
&$env:QTP relof010
&$env:QTP relof021
&$env:QTP relof022
&$env:QTP relof040
&$env:QTP relof119hst

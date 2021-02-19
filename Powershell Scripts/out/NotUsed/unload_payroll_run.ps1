#-------------------------------------------------------------------------------
# File 'unload_payroll_run.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'unload_payroll_run'
#-------------------------------------------------------------------------------

# UNLOAD_PAYROLL_COMP
# RMA Physician Payroll QUIZ compile.
# This script is used to compile the QUIZ unload programs that create the 
# portable subfiles needed to reload into test system.
# Created by S. Bachmann on Jan. 27, 1999.
# REMOVED: 'USE $SRC/UNLOF060 '   - not needed.
echo "Physician Payroll QUIZ compiles."

&$env:QTP unlof020
&$env:QTP unlof020hst
&$env:QTP unlof090_1
&$env:QTP unlof090_2
&$env:QTP unlof090_3
&$env:QTP unlof090_4
&$env:QTP unlof090_5
&$env:QTP unlof090_6
&$env:QTP unlof090_iconst
&$env:QTP unlof110
&$env:QTP unlof110hst
&$env:QTP unlof112
&$env:QTP unlof112hst
&$env:QTP unlof113
&$env:QTP unlof113hst
&$env:QTP unlof190
&$env:QTP unlof191
&$env:QTP unlof199

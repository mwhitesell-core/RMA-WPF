#-------------------------------------------------------------------------------
# File 'unload_payroll_comp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'unload_payroll_comp'
#-------------------------------------------------------------------------------

# UNLOAD_PAYROLL_COMP
# RMA Physician Payroll QUIZ compile.
# This script is used to compile the QUIZ unload programs that create the 
# portable subfiles needed to reload into test system.
# Created by S. Bachmann on Jan. 27, 1999.
# REMOVED: 'USE $SRC/UNLOF060 nolist'   - not needed.
echo "Physician Payroll QUIZ compiles."

&$env:QUIZ unlof020
&$env:QUIZ unlof020hst
&$env:QUIZ unlof090_1
&$env:QUIZ unlof090_2
&$env:QUIZ unlof090_3
&$env:QUIZ unlof090_4
&$env:QUIZ unlof090_5
&$env:QUIZ unlof090_6
&$env:QUIZ unlof090_iconst
&$env:QUIZ unlof110
&$env:QUIZ unlof110hst
&$env:QUIZ unlof112
&$env:QUIZ unlof112hst
&$env:QUIZ unlof113
&$env:QUIZ unlof113hst
&$env:QUIZ unlof190
&$env:QUIZ unlof191
&$env:QUIZ unlof199

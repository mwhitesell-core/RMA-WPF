#-------------------------------------------------------------------------------
# File 'run_unload_payroll.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_unload_payroll'
#-------------------------------------------------------------------------------

# RUN_UNLOAD_PAYROLL
# RMA Physician Payroll QUIZ compile.
# This script runs the QUIZ unload programs that create the portable subfiles
# from production to be put into the test system.
# Created by S. Bachmann on Jan. 27, 1999.

echo "Physician Payroll QUIZ compiles."
echo "Don't forget to copy the f020_doctor_extra and f050* files by hand."

&$env:QUIZ unlof020
&$env:QUIZ unlof020hst
&$env:QUIZ unlof060
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

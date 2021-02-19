#-------------------------------------------------------------------------------
# File 'reload_payroll_comp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_payroll_comp'
#-------------------------------------------------------------------------------

# RELOAD_PAYROLL_COMP
# RMA Physician Payroll QTP compile.
# This script compiles the QTP reload programs used to reload the production
# data into the files in test.
# Created on Jan. 27, 1999 by S. Bachmann

echo "Physician Payroll QTP compiles."

&$env:QTP relof020
&$env:QTP relof020hist
&$env:QTP relof090_1
&$env:QTP relof090_2
&$env:QTP relof090_3
&$env:QTP relof090_4
&$env:QTP relof090_5
&$env:QTP relof090_6
&$env:QTP relof090_iconst
&$env:QTP relof110
&$env:QTP relof110hst
&$env:QTP relof112
&$env:QTP relof112hst
&$env:QTP relof113
&$env:QTP relof113hst
&$env:QTP relof190
&$env:QTP relof191
&$env:QTP relof199

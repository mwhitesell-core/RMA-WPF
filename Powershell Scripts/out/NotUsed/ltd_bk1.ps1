#-------------------------------------------------------------------------------
# File 'ltd_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'ltd_bk1'
#-------------------------------------------------------------------------------

# file: ltd - upload LTD premiums to f113 in payroll
&$env:cmd\u132 100 $1
&$env:QUIZ maryltd
Get-Content ltd.txt

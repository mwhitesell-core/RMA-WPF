#-------------------------------------------------------------------------------
# File 'run_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_reports'
#-------------------------------------------------------------------------------

## $cmd/run_monthend_reports
echo ""
echo ""
echo ""
echo "RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE"
echo "r004a\b\c, r005, r011\r012\r013, r051a\b\c, r070a\b\c"
echo "for selected clinic"
echo ""


&$env:COBOL r004a $1 Y

&$env:COBOL r004b

&$env:COBOL r004c Y

&$env:COBOL r005 $1 Y

&$env:COBOL r011 $1 Y

&$env:COBOL r012 $1 Y

&$env:COBOL r013 $1 Y


&$env:COBOL r051a $1 Y

&$env:COBOL r051b

&$env:COBOL r051c


&$env:COBOL r051b

&$env:COBOL r051c


&$env:COBOL r070a $1 Y Y

&$env:COBOL r070b

&$env:COBOL r070c N

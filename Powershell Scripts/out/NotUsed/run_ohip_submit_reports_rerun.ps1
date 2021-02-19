#-------------------------------------------------------------------------------
# File 'run_ohip_submit_reports_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_submit_reports_rerun'
#-------------------------------------------------------------------------------

echo ""
echo ""

&$env:cmd\all_batches

echo ""
echo "HIT `"NEWLINE`" TO RUN `"BATCH SUMMARY REPORT`" ..."
echo ""
#read garbage

echo "PROGRAM `"R001`" NOW LOADING ..."

Set-Location $env:application_production
&$env:COBOL r001

echo ""

Get-ChildItem r001

echo ""
echo "HIT  `"NEWLINE`"  TO PRINT REPORT ..."
echo ""
#read garbage

Get-Content r001 | Out-Printer

echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO CREATE `"DETAIL BATCH REPORTS`" ..."
#read garbage
echo ""
echo "PROGRAM `"R002A`" NOW LOADING ..."
&$env:COBOL r002a
echo ""

Get-ChildItem r002a*

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
#read garbage
echo ""

#lp r002ab

echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO RUN `"TRANSACTION SUMMARY CYCLE REPORT`" ..."
#read garbage

echo ""
echo "PROGRAM `"R004_CYCLE`" NOW LOADING ..."
&$env:COBOL r004_cycle
echo ""

#ls -l r004_c

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
echo ""
#read garbage

#lp r004_c


echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO RUN `"AGENT SUMMARY REPORT`" ..."
#read garbage

echo ""
echo "PROGRAM `"R014`" NOW LOADING ...(CLINIC 60 TO 61)"
echo "AND R014SUM  (CLINIC 60 TO 61 TOTALS)"
&$env:COBOL r014sum
&$env:COBOL r014

echo ""

Get-ChildItem r014*

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
echo ""
#read garbage

#lp r014sm
Get-Content r014 | Out-Printer
#lp r801a.txt
#lp r801c.txt

echo ""
echo ""
echo "FINISHED AT $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') ...."

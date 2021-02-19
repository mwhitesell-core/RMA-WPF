#-------------------------------------------------------------------------------
# File 'yas_cycle_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_cycle_reports'
#-------------------------------------------------------------------------------

# RUN_OHIP_SUBMIT_REPORTS

echo "PRINT THE BALANCED BATCH DETAIL REPORT"
echo ""
echo "NOTE !! NO ONE MUST BE ACCESSING THE BATCH CONTROL AND CLAIMS MASTER"
echo ""
echo "HIT `"NEWLINE`" TO RUN `"ALL BATCHES`" REPORT ..."
$garbage = Read-Host
echo ""
echo ""

&$env:cmd\all_batches

echo ""
echo "HIT `"NEWLINE`" TO RUN `"BATCH SUMMARY REPORT`" ..."
echo ""
$garbage = Read-Host

echo "PROGRAM `"R001`" NOW LOADING ..."

Set-Location $env:application_production
&$env:COBOL r001

echo ""

Get-ChildItem r001

echo ""
echo "HIT  `"NEWLINE`"  TO PRINT REPORT ..."
echo ""
$garbage = Read-Host

Get-Content r001 | Out-Printer

echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO CREATE `"DETAIL BATCH REPORTS`" ..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"R002A`" NOW LOADING ..."
&$env:COBOL r002a
echo ""

Get-ChildItem r002a*

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
$garbage = Read-Host
echo ""

#lp r002ab

echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO RUN `"TRANSACTION SUMMARY CYCLE REPORT`" ..."
$garbage = Read-Host

echo ""
echo "PROGRAM `"R004_CYCLE`" NOW LOADING ..."
&$env:COBOL r004_cycle
echo ""

#ls -l r004_c

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
echo ""
$garbage = Read-Host

#lp r004_c


echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO RUN `"AGENT SUMMARY REPORT`" ..."
$garbage = Read-Host

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
$garbage = Read-Host

#lp r014sm
Get-Content r014 | Out-Printer
#lp r801a.txt
#lp r801c.txt

echo ""
echo ""
echo "FINISHED AT $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') ...."

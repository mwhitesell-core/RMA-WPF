#-------------------------------------------------------------------------------
# File 'run_ohip_submit_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_ohip_submit_reports'
#-------------------------------------------------------------------------------


# 15/Apr/14 MC1  - add the new program r018.qzc

#RUN_OHIP_SUBMIT_REPORTS
echo ""
echo ""
echo "Runcreate adjustment claims andOhip submittal reports ..."
echo "HitNEWLINE to continue ..."
$garbage = Read-Host

$cmd\create_adj_claims

echo ""
echo "PRINT THE BALANCED BATCH DETAIL REPORT"
echo ""
echo "NOTE !! NO ONE MUST BE ACCESSING THE BATCH CONTROL AND CLAIMS MASTER"
echo ""
echo "HIT `"NEWLINE`" TO RUN `"ALL BATCHES`" REPORT ..."
#read garbage
echo ""
echo ""

$cmd\all_batches

echo ""
echo "HIT `"NEWLINE`" TO RUN `"BATCH SUMMARY REPORT`" ..."
echo ""
#read garbage

echo "PROGRAM `"R001`" NOW LOADING ..."

Set-Location $application_production
cobrun++ $obj\r001

echo ""

Get-ChildItem r001

echo ""
echo "HIT  `"NEWLINE`"  TO PRINT REPORT ..."
echo ""
#read garbage

#lp r001

echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO CREATE `"DETAIL BATCH REPORTS`" ..."
#read garbage
echo ""
echo "PROGRAM `"R002A`" NOW LOADING ..."
cobrun++ $obj\r002a
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
cobrun++ $obj\r004_cycle
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
cobrun++ $obj\r014sum
cobrun++ $obj\r014

echo ""

Get-ChildItem r014*

echo ""
echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
echo ""
#read garbage

#lp r014sm
#lp r014
#lp r801a.txt
#lp r801c.txt

# MC1
Remove-Item r018.txt
quiz++ $obj\r018
Move-Item r018.txt r018_${1}.txt

echo ""
echo " COPY r018_yyyymmdd.txt  to Helena's directory  "
echo ""
Get-Date
echo ""
echo ""
echo "FINISHED AT$(udate) ...."

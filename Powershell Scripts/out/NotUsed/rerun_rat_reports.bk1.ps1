#-------------------------------------------------------------------------------
# File 'rerun_rat_reports.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_rat_reports.bk1'
#-------------------------------------------------------------------------------


# 2013/Nov/07 - add the run of $cmd/u030_clinic_dtl_part2 HERE
echo ""
echo "Start  the run for u030_clinic_dtl_part.qts"
echo ""

####$cmd/u030_clinic_dtl_part2

&$env:QUIZ r030i_2
&$env:QUIZ r030i_3

Get-Content ru030f2.txt | Out-Printer
Get-Content ru030f3.txt | Out-Printer

echo ""
echo ""
Get-Date

Move-Item -Force part_adj_batch.dat part_adj_batch_part2.dat
Move-Item -Force part_adj_batch.idx part_adj_batch_part2.idx

Copy-Item part_adj_batch_orig.dat part_adj_batch.dat
Copy-Item part_adj_batch_orig.idx part_adj_batch.idx

echo "Generate Unmatched Report ru030a.txt  Unadjusted\Partial Payment"
echo "report ru030b.txt and Automatic Adjusted Partial Payment report"
echo "ru030c.txt"
echo ""

echo "Running r030.qzu ..."
Remove-Item ru030[a-z0-9].txt *> $null
&$env:QUIZ r030

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat

echo ""
echo "run ra report r997.txt"
echo ""

Remove-Item r997.ls *> $null
echo "Running run_ra_report ..."
&$env:cmd\run_ra_report *> r997.ls

echo ""
echo "end of the run for u030"
echo ""
Get-Date

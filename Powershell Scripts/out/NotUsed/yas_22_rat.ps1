#-------------------------------------------------------------------------------
# File 'yas_22_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_22_rat'
#-------------------------------------------------------------------------------

echo ""
echo "APPEND RMB FILE TO THE END OF 145 FILE BEFORE RUNNING U030B.QTC"
echo ""

#cd $application_production
#rm u030_tape_145_file_bkp.dat 1>/dev/null 2>&1
#cp      u030_tape_145_file.dat u030_tape_145_file_bkp.dat 
#cat    u030_tape_145_file.dat  \
#       u030_tape_rmb_file.dat  > /usr/tmp/u030_tape_145_file.dat.tmp  
#mv /usr/tmp/u030_tape_145_file.dat.tmp  u030_tape_145_file.dat

Set-Location $env:application_production
Remove-Item u030_tape_145_file_bkp.dat *> $null
Copy-Item u030_tape_145_file.dat u030_tape_145_file_bkp.dat
Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

echo ""
echo ""
echo "DELETE $Env:root\ RECREATE PART_PAID_HDR  PART_PAID_DTL AND PART_ADJ_BATCH FILES"
echo "NEED TO UNCOMMMENT THE FOLLOWING CODE !!!!!!"
echo "NEED TO UNCOMMMENT THE FOLLOWING CODE !!!!!!"
echo "NEED TO UNCOMMMENT THE FOLLOWING CODE !!!!!!"
echo "NEED TO UNCOMMMENT THE FOLLOWING CODE !!!!!!"
echo "NEED TO UNCOMMMENT THE FOLLOWING CODE !!!!!!"
echo ""
echo ""
#rm part_paid_hdr  1>/dev/null 2>&1
#rm part_paid_dtl  1>/dev/null 2>&1
#rm part_adj_batch 1>/dev/null 2>&1
#
#qutil 1>/dev/null 2>&1 << QUTIL_EXIT
#create file part-paid-hdr
#create file part-paid-dtl
#create file part-adj-batch
#QUTIL_EXIT

echo ""
echo "EXECUTE POWERHOUSE PROGRAM U030B.QTC  FOR CLAIM RECONCILIATION"
echo ""

&$env:QTP u030b
echo ""
echo "WRITE INVERTED CLAIM DETAIL KEY TO THE ADJUSTING CLAIM DETAIL RECORD"
echo ""
&$env:COBOL u030c
echo ""
echo "GENERATE UNMATCH REPORT RU030A.TXT  UNADJUSTED\PARTIAL PAYMENT"
echo "REPORT RU030B.TXT AND AUTOMATIC ADJUSTED PARTIAL PAYMENT REPORT"
echo "RU030C.TXT"
echo ""

Remove-Item ru030[a-z0-9].txt *> $null

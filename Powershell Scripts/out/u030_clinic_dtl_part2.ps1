#-------------------------------------------------------------------------------
# File 'u030_clinic_dtl_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u030_clinic_dtl_part2'
#-------------------------------------------------------------------------------

# 2012/Jan/30 - M.C.    - original
#                       - clone from $cmd/u030_clinic_88_part2       
#                       - this can be run for any clinic to create auto adjustment at detail level from u030_no_adj.sf

echo ""
echo ""
echo "save the original part_adj_batch and recreate an empty one"
echo ""
echo ""

<#Move-Item -Force part_adj_batch.dat part_adj_batch_orig.dat
Move-Item -Force part_adj_batch.idx part_adj_batch_orig.idx#>

#$pipedInput = @"
#create file part-adj-batch
#"@

#$pipedInput | qutil++ *> $null
$rcmd = $env:TRUNCATE+ "part_adj_batch"
Invoke-Expression $rcmd


echo ""
echo "execute program u030b_autoadj_clinic_dtl"
echo ""

$rcmd = $env:QTP + "u030b_autoadj_clinic_dtl"
invoke-expression $rcmd

Move-Item -Force u030_dtl_key.sf u030_dtl_key_orig.sf
Copy-Item u030_88_dtl_key.sf u030_dtl_key.sf


echo ""
echo "write inverted claim detail key to the adjusting claim detail record"
echo ""
$rcmd = $env:COBOL + "u030c"
invoke-expression $rcmd
echo ""

$rcmd = $env:QUIZ + "r030i_2 disc_ru030f2"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r030i_3 disc_ru030f3"
invoke-expression $rcmd

Get-Content ru030f2.txt | Out-Printer
Get-Content ru030f3.txt | Out-Printer

echo ""
echo "end of the run for u030b auto adj for clinic detail"
echo ""
Get-Date

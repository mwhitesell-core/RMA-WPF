#-------------------------------------------------------------------------------
# File 'u030_clinic88_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u030_clinic88_part2'
#-------------------------------------------------------------------------------

# 2009/mar/02 - M.C.    - original
#                       - additional part to run for clinic 88 only

echo ""
echo ""
echo "save the original part_adj_batch and recreate an empty one"
echo ""
echo ""

<#Move-Item -Force part_adj_batch.dat part_adj_batch_orig.dat
Move-Item -Force part_adj_batch.idx part_adj_batch_orig.idx

$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++ *> $null#>

$rcmd = $env:TRUNCATE+ "part_adj_batch"
Invoke-Expression $rcmd

echo ""
echo "execute program u030b_autoadj_clinic_88"
echo ""

$rcmd = $env:QTP + "u030b_autoadj_clinic_88"
Invoke-Expression $rcmd

Move-Item -Force u030_dtl_key.sf u030_dtl_key_orig.sf
Copy-Item u030_88_dtl_key.sf u030_dtl_key.sf


echo ""
echo "write inverted claim detail key to the adjusting claim detail record"
echo ""
$rcmd = $env:COBOL + "u030c"
Invoke-Expression $rcmd
echo ""

$rcmd = $env:QUIZ + "r030i_2 disc_ru030f2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r030i_3 disc_ru030f3"
Invoke-Expression $rcmd

Get-Content ru030f2.txt | Out-Printer
Get-Content ru030f3.txt | Out-Printer

echo ""
echo "end of the run for u030b auto adj for clinic 88"
echo ""
Get-Date

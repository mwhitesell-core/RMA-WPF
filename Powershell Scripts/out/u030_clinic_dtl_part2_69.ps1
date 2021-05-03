#-------------------------------------------------------------------------------
# File 'u030_clinic_dtl_part2_69.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u030_clinic_dtl_part2_69'
#-------------------------------------------------------------------------------

# 2014/Aug/19 - M.C.    - original
#                       - clone from $cmd/u030_clinic_dtl_part2 
#                       - this can be run for clinic 69 only at detail level from u030_no_adj.sf

echo ""
echo ""
echo "save the original part_adj_batch and recreate an empty one"
echo ""
echo ""

<#Move-Item -Force part_adj_batch.dat part_adj_batch_orig_2.dat
Move-Item -Force part_adj_batch.idx part_adj_batch_orig_2.idx

$pipedInput = @"
create file part-adj-batch
"@

$pipedInput | qutil++ *> $null#>

$rcmd = $env:TRUNCATE+ "part_adj_batch"
Invoke-Expression $rcmd

echo ""
echo "execute program u030b_autoadj_clinic_dtl_69"
echo ""

&$env:QTP u030b_autoadj_clinic_dtl_69

Move-Item -Force u030_dtl_key.sf u030_dtl_key_orig_2.sf
Copy-Item u030_69_dtl_key.sf u030_dtl_key.sf


echo ""
echo "write inverted claim detail key to the adjusting claim detail record"
echo ""
&$env:COBOL u030c
echo ""

&$env:QUIZ r030i_2 disc_ru030f2
&$env:QUIZ r030i_3 disc_ru030f3

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030f2.txt | Out-Printer -Name $env:networkprinter
   Get-Content ru030f3.txt | Out-Printer -Name $env:networkprinter
}

echo ""
echo "end of the run for u030b auto adj for clinic detail 69"
echo ""
Get-Date

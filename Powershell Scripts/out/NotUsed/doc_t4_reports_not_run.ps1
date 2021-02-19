#-------------------------------------------------------------------------------
# File 'doc_t4_reports_not_run.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_t4_reports_not_run'
#-------------------------------------------------------------------------------

echo ""
echo "Create Doctor T4 Reports"
echo ""

Set-Location $env:application_production
Remove-Item r150* *> $null

&$env:QTP r150a 201401 201406 201307 201313

&$env:QUIZ r150b
&$env:QUIZ r150b_part2
&$env:QUIZ r150c
&$env:QUIZ r150d

#lp r150a.txt
#lp r150b.txt

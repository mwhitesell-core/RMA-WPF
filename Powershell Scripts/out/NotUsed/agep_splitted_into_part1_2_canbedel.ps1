#-------------------------------------------------------------------------------
# File 'agep_splitted_into_part1_2_canbedel.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'agep_splitted_into_part1_2_canbedel'
#-------------------------------------------------------------------------------


# macro: agep
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#                  add run of r030n.qzc and append ru030n.txt to the end of
#                  ru030k.txt and ru030m.txt

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-ChildItem r031a.dat
Remove-Item r031*.sf* *> $null

echo "recreate the empty temporary scratch file tmp-counters-alpha"

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++

echo ""
echo "execute powerhouse program u030b_part3.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3.qtc ..."
&$env:QTP u030b_part3

echo ""
echo "execute powerhouse program r030k and r030l  for age premium payment reports"
echo ""
&$env:QUIZ r030k
&$env:QUIZ r030l
&$env:QUIZ r030m
&$env:QUIZ r030n

Get-Content ru030n.txt | Add-Content ru030k.txt
Get-Content ru030n.txt | Add-Content ru030m.txt

Get-Content ru030k.txt | Out-Printer
Get-Content ru030m.txt | Out-Printer
Get-Content ru030l.txt | Out-Printer

echo ""
echo "end of the run for age premium payment"
echo ""
Get-Date

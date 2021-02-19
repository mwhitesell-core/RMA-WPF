#-------------------------------------------------------------------------------
# File 'agep_part1.bk3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'agep_part1.bk3'
#-------------------------------------------------------------------------------


# macro: agep_part1
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#                  add run of r030n.qzc and append ru030n.txt to the end of
#                  ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2   
# 2013/Mar/27 M.C. add qutil to tmp-doctor-alpha

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-ChildItem r031a.dat
Remove-Item r031*.sf* *> $null

echo "recreate the empty temporary scratch file tmp-counters-alpha"

$pipedInput = @"
create file tmp-counters-alpha
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

echo ""
echo "execute powerhouse program u030b_part3_a.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3_a.qtc ..."
&$env:QTP u030b_part3_a

&$env:QUIZ r031c

Get-Content r031c.txt | Out-Printer

echo ""
echo "end of the run for age premium payment PART 1"
echo ""
Get-Date
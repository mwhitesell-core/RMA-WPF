#-------------------------------------------------------------------------------
# File 'agep_part2.bk3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'agep_part2.bk3'
#-------------------------------------------------------------------------------


# macro: agep_part2
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#                  add run of r030n.qzc and append ru030n.txt to the end of
#                  ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2
# 2011/Jul/28 M.C. add run of r030q.qzc                     


Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
&$env:QTP u030b_part3_b

echo ""
echo "execute powerhouse program r030k and r030l  for age premium payment reports"
echo ""
&$env:QUIZ r030k
&$env:QUIZ r030l
&$env:QUIZ r030m
&$env:QUIZ r030n
&$env:QUIZ r030q

Get-Content ru030n.txt | Add-Content ru030k.txt
Get-Content ru030n.txt | Add-Content ru030m.txt

Get-Content ru030k.txt | Out-Printer
Get-Content ru030m.txt | Out-Printer
Get-Content ru030l.txt | Out-Printer
# lp ru030q.txt  ## Mary does not want it

echo ""
echo "end of the run for age premium payment PART 2"
echo ""
Get-Date

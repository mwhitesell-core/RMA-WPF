#-------------------------------------------------------------------------------
# File 'agep_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'agep_part1'
#-------------------------------------------------------------------------------


# macro: agep_part1
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#                  add run of r030n.qzc and append ru030n.txt to the end of
#                  ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2   
# 2013/Mar/27 M.C. add qutil to tmp-doctor-alpha
# 2016/Jul/28 MC1  transfer the run of r030n.qzc from $cmd/agep_part2 to here
# 2016/Aug/25 MC2  change from ru030k.txt to ru030k*.txt from rm 
Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location

Get-ChildItem r031a.dat
Remove-Item r031*.sf*, ru030k*.txt, ru030l.txt, ru030m.txt, ru030n.txt, ru030q.txt, ru030r.txt *> $null

echo "recreate the empty temporary scratch file tmp-counters-alpha"

#$pipedInput = @"
#create file tmp-counters-alpha
#create file tmp-doctor-alpha
#"@



$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"tmp_doctor_alpha"
Invoke-Expression $rcmd

echo ""
echo "execute powerhouse program u030b_part3_a.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3_a.qtc ..."
$rcmd = $env:QTP + "u030b_part3_a"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r031c_1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r031c_2"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r031c_1.txt, r031c_2.txt | Set-Content r031c.txt

Get-Content r031c.txt | Out-Printer

# MC1
$rcmd = $env:QUIZ + "r030n"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030n.txt > ru030n.txt

Get-Content ru030n.txt | Out-Printer

echo ""
echo "end of the run for age premium payment PART 1"
echo ""
Get-Date

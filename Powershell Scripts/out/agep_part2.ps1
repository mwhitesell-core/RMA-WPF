#-------------------------------------------------------------------------------
# File 'agep_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'agep_part2'
#-------------------------------------------------------------------------------


# macro: agep_part2
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#                  add run of r030n.qzc and append ru030n.txt to the end of
#                  ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2
# 2011/Jul/28 M.C. add run of r030q.qzc                     
# 2013/Sep/11 M.C. add run of r030r.qzu and append ru030r.txt to the end of                    
#                  ru030k.txt and ru030m.txt where r030r.qzu consists of 3 passes r030r1/2/3.qzc
# 2016/Jul/28 MC1  exclude the run of ru030n.qzc as it transfers to run in $cmd/agep_part1
# 2016/Aug/25 MC2  add run of r030k_csv.qzc for Helena      

Get-Date

Set-Location $env:application_production

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
$rcmd = $env:QTP + "u030b_part3_b"
invoke-expression $rcmd

echo ""
echo "execute powerhouse program r030k and r030l  for age premium payment reports"
echo ""
$rcmd = $env:QUIZ + "r030k"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030k.txt > ru030k.txt

# MC2 
$rcmd = $env:QUIZ + "r030k_csv"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030k_csv.txt > ru030k_csv.txt

$rcmd = $env:QUIZ + "r030l"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030l.txt > ru030l.txt

$rcmd = $env:QUIZ + "r030m"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030m.txt > ru030m.txt

# MC1
# quiz auto=$obj/r030n.qzc
$rcmd = $env:QUIZ + "r030q"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030q.txt > ru030q.txt

$rcmd = $env:QUIZ + "r030r1"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r030r2"
invoke-expression $rcmd

$rcmd = $env:QUIZ + "r030r3"
invoke-expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r030r1.txt > ru030r.txt
Get-Content r030r3.txt >> ru030r.txt

Get-Content ru030n.txt >> ru030k.txt
Get-Content ru030n.txt >> ru030m.txt

Get-Content ru030r.txt >> ru030k.txt
Get-Content ru030r.txt >> ru030m.txt

#lp ru030k.txt
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030m.txt | Out-Printer -Name $env:networkprinter
   Get-Content ru030l.txt | Out-Printer -Name $env:networkprinter
}
# lp ru030q.txt  ## Mary does not want it

echo ""
echo "end of the run for age premium payment PART 2"
echo ""
Get-Date

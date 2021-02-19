#-------------------------------------------------------------------------------
# File 'mohd_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'mohd_part2'
#-------------------------------------------------------------------------------


# macro: mohd_part2
# 2013/May/15 M.C. clone from agep_part2 for MOHD  
# 2013/Sep/11 M.C. add run of r030r.qzu and append ru030r.txt to the end of
#                  ru030k.txt and ru030m.txt where r030r.qzu consists of 3 passes r030r1/2/3.qzc
# 2016/Jul/28 MC1  exclude the run of ru030n.qzc as it transfers to run in $cmd/mohd_part1
# 2016/Aug/25 MC2  add run of r030k_csv.qzc

Get-Date

Set-Location $env:application_production\22

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for MOHD payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
$rcmd = $env:QTP + "u030b_part3_b"
invoke-expression $rcmd

echo ""
echo "execute powerhouse program r030k and r030l  for MOHD  payment reports"
echo ""
$rcmd = $env:QUIZ + "r030k"
invoke-expression $rcmd
# MC2
$rcmd = $env:QUIZ + "r030k_csv"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r030l"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r030m"
invoke-expression $rcmd
# MC1
# quiz auto=$obj/r030n.qzc
$rcmd = $env:QUIZ + "r030q"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r030r"
invoke-expression $rcmd

Get-Content r030n.txt >> r030k.txt
Get-Content r030n.txt >> r030m.txt

Get-Content r030r.txt >> r030k.txt
Get-Content r030r.txt >> r030m.txt

Move-Item -Force r030k.txt ru030k_mohd.txt
Move-Item -Force r030l.txt ru030l_mohd.txt
Move-Item -Force r030m.txt ru030m_mohd.txt
Move-Item -Force r030n.txt ru030n_mohd.txt
Move-Item -Force r030q.txt ru030q_mohd.txt
Move-Item -Force r030r.txt ru030r_mohd.txt

# MC2
Move-Item -Force r030k_csv.txt ru030k_mohd_csv.txt

#lp ru030k_mohd.txt
Get-Content ru030m_mohd.txt | Out-Printer
Get-Content ru030l_mohd.txt | Out-Printer

echo ""
echo "end of the run for MOHD payment PART 2"
echo ""
Get-Date

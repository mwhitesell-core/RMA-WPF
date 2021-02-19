#-------------------------------------------------------------------------------
# File 'mohd_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'mohd_part2'
#-------------------------------------------------------------------------------


# macro: mohd_part2
# 2013/May/15 M.C. clone from agep_part2 for MOHD  
# 2013/Sep/11 M.C. add run of r030r.qzu and append ru030r.txt to the end of
#                  ru030k.txt and ru030m.txt where r030r.qzu consists of 3 passes r030r1/2/3.qzc
# 2016/Jul/28 MC1  exclude the run of ru030n.qzc as it transfers to run in $cmd/mohd_part1
# 2016/Aug/25 MC2  add run of r030k_csv.qzc

Get-Date

Set-Location $application_production\22

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for MOHD payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
qtp++ $obj\u030b_part3_b

echo ""
echo "execute powerhouse program r030k and r030l  for MOHD  payment reports"
echo ""
quiz++ $obj\r030k
# MC2
quiz++ $obj\r030k_csv
quiz++ $obj\r030l
quiz++ $obj\r030m
# MC1
# quiz auto=$obj/r030n.qzc
quiz++ $obj\r030q
quiz++ $obj\r030r

Get-Content ru030n.txt  >> ru030k.txt
Get-Content ru030n.txt  >> ru030m.txt

Get-Content ru030r.txt  >> ru030k.txt
Get-Content ru030r.txt  >> ru030m.txt

Move-Item ru030k.txt ru030k_mohd.txt
Move-Item ru030l.txt ru030l_mohd.txt
Move-Item ru030m.txt ru030m_mohd.txt
Move-Item ru030n.txt ru030n_mohd.txt
Move-Item ru030q.txt ru030q_mohd.txt
Move-Item ru030r.txt ru030r_mohd.txt

# MC2
Move-Item ru030k_csv.txt ru030k_mohd_csv.txt

#lp ru030k_mohd.txt
Get-Contents ru030m_mohd.txt| Out-Printer
Get-Contents ru030l_mohd.txt| Out-Printer

echo ""
echo "end of the run for MOHD payment PART 2"
echo ""
Get-Date

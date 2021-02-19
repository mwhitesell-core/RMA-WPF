#-------------------------------------------------------------------------------
# File 'agep_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $application_production

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for age premium payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
qtp++ $obj\u030b_part3_b

echo ""
echo "execute powerhouse program r030k and r030l  for age premium payment reports"
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

#lp ru030k.txt
Get-Contents ru030m.txt| Out-Printer
Get-Contents ru030l.txt| Out-Printer
# lp ru030q.txt  ## Mary does not want it

echo ""
echo "end of the run for age premium payment PART 2"
echo ""
Get-Date

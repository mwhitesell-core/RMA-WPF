#-------------------------------------------------------------------------------
# File 'mohd_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'mohd_part1'
#-------------------------------------------------------------------------------


# macro: mohd_part1
# 2013/May/15 M.C. clone from agep_part1   for MOHD payments  
# 2016/Jul/28 MC1  transfer the run of r030n.qzc from $cmd/mohd_part2 to here
# 2016/Aug/25 MC2  change from ru031?mohd.txt to ru030*mohd*txt

Get-Date

Set-Location $application_production\22

echo "Current Directory:"
Get-Location

Get-ChildItem r031a.dat
Remove-Item r031*.sf*, r031*txt, ru030*mohd*txt  > $null

echo "recreate the empty temporary scratch file tmp-counters-alpha"

$pipedInput = @"
create file tmp-counters-alpha
create file tmp-doctor-alpha
"@

$pipedInput | qutil++

echo ""
echo "execute powerhouse program u030b_part3_a.qtc  for MOHD  payment creation"
echo ""

echo "Running u030b_part3_a.qtc ..."
qtp++ $obj\u030b_part3_a

quiz++ $obj\r031c

Move-Item r031c.txt r031c_mohd.txt
Get-Contents r031c_mohd.txt| Out-Printer

# MC1
quiz++ $obj\r030n
Copy-Item ru030n.txt ru030n_mohd.txt
Get-Contents ru030n_mohd.txt| Out-Printer

echo "save tmp_counter_alpha created from u030b_part3_a to production\22"

Set-Location $pb_data
Copy-Item tmp_doctor_alpha.* $application_production\22

echo "copy tmp_doctor_alpha_mohd back before running r031_part3_before_update"

Copy-Item tmp_doctor_alpha_mohd.dat tmp_doctor_alpha.dat
Copy-Item tmp_doctor_alpha_mohd.idx tmp_doctor_alpha.idx

Set-Location $application_production\22

quiz++ $obj\r031_part3_before_update
#lp r031b_part3.txt 

echo ""
echo "end of the run for MOHD payment PART 1"
echo ""
Get-Date

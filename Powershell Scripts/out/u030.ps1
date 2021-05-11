#-------------------------------------------------------------------------------
# File 'u030.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'u030'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# macro: u030
# 00/jul/13 B.E. added calls to u030bb.qtc and u030bb_1.qtc
# 00/aug/10 B.E. consolidated all u030bb_xxx into this one macro and force
#                passing of 2 digit clinic nbr as parameter to this macro
#                which is then passed to u030bb and u030bb_1
# 00/sep/14 B.E. allow clinic 90 as parameter
#                if running clinic 90 pass clinic as 22 to u030
# 03/jun/11 yas  add clnics 91,92,93,94,96         
# 04/jul/13 M.C. change from u030b to run u030b_part1 and u030b_part2
#                it was mysterious and do not know why the sort on the
#                second request does not sort properly
# 07/may/16 M.C. add clnics 71 to 75  
# 2007/NOv  yas. add clnic 87           
# 2008/Oct  yas. add clnic 88
# 2009/Apr  yas. add clnic 89
# 2009/Jun  yas. add clnic 79
# 2009/Jun  yas. add clnic 78
# 2010/feb  yas  add clinic 66
# 2011/Jan  yas  add clinic 23
# 2012/Jan  yas  add clinic 24
# 2012/Jun  yas  add clinic 25
# 2013/Nov/07 MC include the run of $cmd/u030_clinic_dtl_part2 at the end
# 2014/Apr/04 yas add clinic 69                                            
# 2014/May/04 yas add clinic 68
# 2014/Oct/17 yas add clinic 30
# 2015/Mar/10 yas add clinic 26
# 2015/Jul/08 MC1 add the run of unlof002_rat_payment.qtc at the end of the macro for BI purpose
# 2015/Aug/06 MC2 transfer 'fi' on line 172 to the end of the macro, also remove the last MYSTERY line
#                 which might have caused the error from last night run


#  (clinic must be passed as single parameter)
if (($1 -ne 22) -and ($1 -ne 23) -and ($1 -ne 24) -and ($1 -ne 25) -and ($1 -ne 26) -and ($1 -ne 30) -and
     ($1 -ne 31) -and ($1 -ne 32) -and ($1 -ne 33) -and ($1 -ne 34) -and ($1 -ne 35) -and ($1 -ne 36) -and
     ($1 -ne 37) -and ($1 -ne 41) -and ($1 -ne 42) -and ($1 -ne 43) -and ($1 -ne 44) -and
     ($1 -ne 45) -and ($1 -ne 46) -and ($1 -ne 60) -and ($1 -ne 61) -and ($1 -ne 62) -and
     ($1 -ne 63) -and ($1 -ne 64) -and ($1 -ne 65) -and ($1 -ne 66) -and 
     ($1 -ne 68) -and ($1 -ne 69) -and ($1 -ne 71) -and ($1 -ne 72) -and ($1 -ne 73) -and
     ($1 -ne 74) -and ($1 -ne 75) -and ($1 -ne 78) -and ($1 -ne 79) -and
     ($1 -ne 80) -and ($1 -ne 82) -and ($1 -ne 84) -and ($1 -ne 86) -and
     ($1 -ne 87) -and ($1 -ne 88) -and ($1 -ne 89) -and ($1 -ne 90) -and
     ($1 -ne 91) -and ($1 -ne 92) -and ($1 -ne 93) -and ($1 -ne 94) -and
     ($1 -ne 95) -and ($1 -ne 96))
 {
  echo "*ERROR*  -  Usage: u030 <2 digit clinic nbr>"
} else {

if ($1 -eq 22)
{
   Set-Location $env:application_production
} else {
   Set-Location $env:application_production\$1
}

echo "Current Directory:"
Get-Location

echo ""
echo "append rmb file to the end of 145 file before running u030b.qtc"
echo ""

#cd $application_production
#rm u030_tape_145_file_bkp.dat 1>/dev/null 2>&1
#cp     u030_tape_145_file.dat u030_tape_145_file_bkp.dat 
#cat    u030_tape_145_file.dat  \
#       u030_tape_rmb_file.dat  > /usr/tmp/u030_tape_145_file.dat.tmp  
#mv /usr/tmp/u030_tape_145_file.dat.tmp  u030_tape_145_file.dat

#######cd $application_production
Remove-Item u030_tape_145_file_bkp.dat *> $null
Copy-Item u030_tape_145_file.dat u030_tape_145_file_bkp.dat
Remove-Item u030_tape_RMB_file_bkp.dat *> $null
Copy-Item u030_tape_RMB_file.dat u030_tape_RMB_file_bkp.dat

$filein = "u030_tape_145_file.dat"
$fileout = "u030_tape_145_file2.dat"
&$env:cmd\lf $filein $fileout 167

$filein = "U030_TAPE_RMB_FILE.dat"
$fileout = "U030_TAPE_RMB_FILE2.dat"
&$env:cmd\lf $filein $fileout 167

Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

echo ""
echo ""
echo "delete $Env:root\ recreate part_paid_hdr  part_paid_dtl and part_adj_batch files"
echo ""
echo ""
Remove-Item part_paid_hdr.*
Remove-Item part_paid_dtl.*
Remove-Item part_adj_batch.*

#$pipedInput = @"
#create file part-paid-hdr
#create file part-paid-dtl
#create file part-adj-batch
#"@

#$pipedInput | qutil++ *> $null


$rcmd = $env:TRUNCATE+"part_paid_hdr"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"part_paid_dtl"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+"part_adj_batch"
Invoke-Expression $rcmd

echo ""
echo "execute powerhouse program u030b.qtc  for claim reconciliation"
echo ""

echo "Running u030b.qtc ..."
#qtp auto=$obj/u030b.qtc

$rcmd = $env:QTP + "u030b_part1"
invoke-expression $rcmd
$rcmd = $env:QTP + "u030b_part2"
invoke-expression $rcmd
#qtp auto=$obj/u030b_special1.qtc
#qtp auto=$obj/u030b_special2.qtc

if (($1 -eq 60 -or  $1 -eq 61 -or  $1 -eq 62 -or  $1 -eq 63 -or  $1 -eq 64 -or  $1 -eq 65 -or  $1 -eq 66))
{
  echo "Running u030b_60.qtc ..."
  &$env:QTP u030b_60
}

if (($1 -eq 71 -or  $1 -eq 72 -or  $1 -eq 73 -or  $1 -eq 74 -or  $1 -eq 75))
{
  echo "Running u030b_60.qtc ..."
  $rcmd = $env:QTP + "u030b_60"
  invoke-expression $rcmd
}

# clinic 90 must be run with 22 as parm
if (($1 -ne 90))
{
echo "Running u030bb.qtc for clinic $1..."
$rcmd = $env:QTP + "u030bb $1"
invoke-expression $rcmd
echo "Running u030bb_1.qtc for clinic $1 ..."
$rcmd = $env:QTP + "u030bb_1 $1 $1"
invoke-expression $rcmd
} else {
echo "Running u030bb.qtc for clinic $1..."
$rcmd = $env:QTP + "u030bb 22"
invoke-expression $rcmd
echo "Running u030bb_1.qtc for clinic $1 ..."
$rcmd = $env:QTP + "u030bb_1 22 22"
invoke-expression $rcmd
}


echo ""
echo "write inverted claim detail key to the adjusting claim detail record"
echo ""
$rcmd = $env:COBOL + "u030c"
invoke-expression $rcmd
echo ""

echo "Generate Unmatched Report ru030a.txt  Unadjusted\Partial Payment"
echo "report ru030b.txt and Automatic Adjusted Partial Payment report"
echo "ru030c.txt"
echo ""

echo "Running r030.qzu ..."
Remove-Item ru030[a-z0-9].txt *> $null
&$env:cmd\r030
invoke-expression $rcmd

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
Remove-Item u030_tape_RMB_file.dat *> $null
Copy-Item u030_tape_RMB_file_bkp.dat u030_tape_RMB_file.dat

echo ""
echo "run ra report r997.txt"
echo ""

$filein = "u030_tape_145_file.dat"
$fileout = "u030_tape_145_file2.dat"
&$env:cmd\lf $filein $fileout 167

Remove-Item r997.ls *> $null
echo "Running run_ra_report ..."
&$env:cmd\run_ra_report *> r997.ls

echo ""
echo "end of the run for u030"
echo ""
Get-Date

#MC2  fi  - transfer to the end as Brad suggested

# 2013/Nov/07 - add the run of $cmd/u030_clinic_dtl_part2 HERE
echo ""
echo "Start  the run for u030_clinic_dtl_part.qts"
echo ""

&$env:cmd\u030_clinic_dtl_part2

echo ""
echo "Finish the run for u030_clinic_dtl_part.qts"
echo ""
Get-Date

# MC1

$rcmd = $env:QTP + "unlof002_rat_payment"
invoke-expression $rcmd

echo ""
echo "End of unlof002_rat_payment run"
echo ""
Get-Date

}

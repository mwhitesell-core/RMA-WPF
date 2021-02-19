#-------------------------------------------------------------------------------
# File 'delete_f001_adj_pay_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_f001_adj_pay_batches'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  2001/jul/09 B.E. added renames to backup subfiles for each clinic
#  2003/Jul/16 yas. added clinics 91,92,93,94 and 96
#  2012/Jul/05 MC   copy f002-claims-mstr   to /foxtrot/purge
#  2015/Feb/17 Yas  add new group H290 clinic 30             
#  2015/Jun/10 Yas  add new clinic 26                        

echo "DELETE_F001_ADJ_PAY_BATCHES"
echo ""

echo "DELETE THE ADJUSTMENT AND PAYMENT BATCHES FOR THE CLINIC"
echo ""
echo "N O T E : ! ! !  F001 AND F002 MUST HAVE BE BACKED UP before THIS RUN ..."
echo ""
echo ""
echo "STAGE 1A - RUN VERIFY OF CLAIMS  FOR A REPORT OF FILE BEFORE DELETION .."

#Set-Location $env:pb_data

#Copy-Item f002_claims_mstr \\$Env:root\foxtrot\purge\f002_claims_mstr_orig
#Copy-Item f002_claims_mstr.idx \\$Env:root\foxtrot\purge\f002_claims_mstr_orig.idx

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 delete_f001_adj_pay_batches"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

#Set-Location $Env:root\charly\purge

$rcmd = $env:COBOL + "r071 $1 Y" 2>&1
Invoke-Expression $rcmd

Remove-Item r071_before *> $null
Move-Item -Force r071 r071_before

echo ""
Get-ChildItem -Force r071_before
echo ""

Get-Date

#lp r071_before

echo ""
echo "STAGE 1B - RUN `"ALL_BATCHES`" ON ALL CLINICS BEFORE DELETION ..."

$rcmd = $env:COBOL + "r001b"
Invoke-Expression $rcmd

Remove-Item r001b_before_r093 *> $null
Move-Item -Force r001b r001b_before_r093

echo ""
Get-ChildItem -Force r001b_before_r093
echo ""



##lp     r001b_before_r093

Remove-Item u093_retain_batch.sf* *> $null
Remove-Item u093_delete_batch.sf* *> $null
Remove-Item u093_purge_validate.sf* *> $null
Remove-Item u093*.txt *> $null

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 22 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."


echo " --- u093   (QTP) --- "
$rcmd = $env:QTP + "u093 22000000 22ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 22"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 22"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_22.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_22.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_22.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_22.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_22 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_22
#lp                           r093_22

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 23 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 23000000 23ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 23"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 23"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_23.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_23.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_23.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_23.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_23 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_23
#lp                           r093_23

echo ""
echo "STAGE 2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 24 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 24000000 24ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 24"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 24"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_24.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_24.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_24.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_24.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_24 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_24
#lp                           r093_24


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 25 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 25000000 25ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 25"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 25"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_25.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_25.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_25.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_25.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_25 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_25
#lp                           r093_25


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 26 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 26000000 26ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 26"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 26"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_26.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_26.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_26.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_26.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_26 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_26
#lp                           r093_26


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 30 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 30000000 30ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 30"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 30"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_30.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_30.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_30.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_30.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

Remove-Item r093_30 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_30
#lp                           r093_30

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 31 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 31000000 31ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 31"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 31"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_31.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_31.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_31.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_31.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_31 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_31
#lp                           r093_31

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 32 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 32000000 32ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 32"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 32"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_32.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_32.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_32.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_32.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_32 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_32
#lp                           r093_32

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 33 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 33000000 33ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 33"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 33"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_33.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_33.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_33.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_33.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_33 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_33
#lp                           r093_33

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 34 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 34000000 34ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 34"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 34"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_34.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_34.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_34.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch-34.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_34 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_34
#lp                           r093_34

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 35 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 35000000 35ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 35"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 35"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_35.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_35.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_35.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_35.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_35 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_35
#lp                           r093_35


echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 36 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 36000000 36ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 36"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 36"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_36.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_36.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_36.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_36.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_36 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_36
#lp                           r093_36


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 37 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 37000000 37ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 37"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 37"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_37.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_37.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_37.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_37.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_37 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_37
#lp                           r093_37

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 41 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 41000000 41ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 41"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 41"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_41.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_41.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_41.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_41.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_41 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_41
#lp                           r093_41


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 42 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 42000000 42ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 42"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 42"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_42.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_42.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_42.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_42.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_42 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_42
#lp                           r093_42

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 43 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 43000000 43ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 43"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 43"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_43.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_43.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_43.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_43.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_43 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_43
#lp                           r093_43


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 44 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 44000000 44ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 44"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 44"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_44.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_44.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_44.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_44.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_44 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_44
#lp                           r093_44


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 45 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 45000000 45ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 45"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 45"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_45.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_45.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_45.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_45.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_45 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_45
#lp                           r093_45


echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 46 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 46000000 46ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 46"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 46"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_46.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch_46.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_46.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_46.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_46 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_46
#lp                           r093_46


echo ""
echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 60000000 66ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 60"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 60"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_60.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_60.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_60.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_60.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""


Remove-Item r093_60 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_60
#lp                           r093_60

echo ""
echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 68 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 68000000 68ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 68"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 68"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_68.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_68.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_68.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_68.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_68 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_68
#lp                           r093_68

echo ""
echo ""


echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 69 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 69000000 69ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 69"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 69"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_69.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_69.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_69.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_69.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_69 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_69
#lp                           r093_69

echo ""
echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 70000000 75ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 70"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_70.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_70.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_70.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_70.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""


Remove-Item r093_70 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_70
#lp                           r093_70


echo ""
echo "STAGE  2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 78 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 78000000 78ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 78"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 78"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_78.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_78.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_78.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_78.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_78 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_78
#lp                           r093_78




echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 79 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 79000000 79ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 79"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 79"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_79.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_79.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_79.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_79.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_79 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_79
#lp                           r093_79

echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 80 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 80000000 80ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 80"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 80"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_80.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_80.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_80.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_80.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_80 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_80
#lp                           r093_80


echo ""
echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 82 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 82000000 82ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 82"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 82"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_82.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_82.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_82.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_82.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_82 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_82
#lp                           r093_82

echo ""

echo ""
echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 84 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 84000000 84ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 84"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 84"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_84.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_84.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_84.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_84.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_84 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_84
#lp                           r093_84


echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 86 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 86000000 86ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 86"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 86"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_86.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_86.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_86.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_86.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_86 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_86
#lp                           r093_86

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --87 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 87000000 87ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 87"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 87"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_87.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_87.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_87.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_87.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_87 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_87 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_87
#lp                           r093_87

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC --88 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 88000000 88ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 88"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 88"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_88.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_88.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_88.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_88.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_88 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_88 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_88
#lp                           r093_88

echo ""
echo "STAGE 2 - RUN BATCH DELETION PROGRAM FOR CLINIC --89 --"
echo ""

echo ""
echo "PROGRAMU093 NOW LOADING ..."

$rcmd = $env:QTP + "u093 89000000 89ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 89"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 89"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_89.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_89.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_89.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_89.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_89 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_89 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_89
#lp                           r093_89

echo ""
echo "STAGE 2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 91 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 91000000 91ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 91"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 91"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_91.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_91.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_91.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_91.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_91 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_91
#lp                           r093_91



echo ""
echo "STAGE  2   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 92 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 92000000 92ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 92"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 92"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_92.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_92.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_92.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_92.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_92 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_92
#lp                           r093_92



echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 93 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 93000000 93ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 93"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 93"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_93.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_93.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_93.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_93.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_93 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_93
#lp                           r093_93


echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 94 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 94000000 94ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 94"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 94"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_94.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_94.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_94.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_94.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_94 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_94
#lp                           r093_94


echo ""
echo "STAGE   2 - RUN BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 95000000 95ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 95"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 95"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_95.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_95.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_95.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_95.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_95 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_95
#lp                           r093_95


echo ""
echo "STAGE  2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 96000000 96ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 96"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 96"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_96.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_96.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_96.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_96.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_96 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_96
#lp                           r093_96


echo ""
echo "STAGE   2  - RUN BATCH DELETION PROGRAM FOR CLINIC -- 98 --"
echo ""

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

$rcmd = $env:QTP + "u093 98000000 98ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r093a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093c DISC_r093a 98"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r093d DISC_r093b 98"
Invoke-Expression $rcmd
Move-Item -Force u093_delete_batch.sf u093_delete_batch_98.sf
Move-Item -Force u093_delete_batch.sfd u093_delete_batch_98.sfd
Move-Item -Force u093_retain_batch.sf u093_retain_batch_98.sf
Move-Item -Force u093_retain_batch.sfd u093_retain_batch_98.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date


Remove-Item r093_98 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_98
#lp                           r093_98



echo ""
echo "STAGE  3A - RUN VERIFY OF CLAIMS FOR A REPORT OF FILE AFTER DELETION ."

$rcmd = $env:COBOL + "r071 $1 Y" 2>&1
Invoke-Expression $rcmd

Remove-Item r071_after *> $null
Move-Item -Force r071 r071_after

echo ""
Get-ChildItem -Force r071_after
echo ""
#lp      r071_after

echo ""
Get-Date
echo ""
echo "STAGE   3B    - RUN `"ALL_BATCHES`" FOR REPORT OF FILE AFTER REPORT ..."

$rcmd = $env:COBOL + "r001b"
Invoke-Expression $rcmd

Remove-Item r001b_after_r093 *> $null
Move-Item -Force r001b r001b_after_r093

echo ""
Get-ChildItem -Force r001b_after_r093
echo ""
##lp      r001b_after_r093


echo ""
echo "FINISHED ..."

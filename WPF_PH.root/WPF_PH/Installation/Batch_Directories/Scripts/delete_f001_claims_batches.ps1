#-------------------------------------------------------------------------------
# File 'delete_f001_claims_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_f001_claims_batches'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

echo "DELETE_F001_CLAIMS_BATCHES"
echo ""

echo "DELETE THE CLAIMS BATCHES FOR THE CLINIC"
echo ""
echo ""
echo "N O T E : ! ! !  F001 MUST HAVE BEEN BACKED UP PRIOR TO THIS RUN ..."
echo ""
echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE PROCEDURE ..."
$garbage = Read-Host
echo ""
echo "STAGE  1  - RUN `"ALL_BATCHES`" FOR DUMP OF FILE BEFORE DELETION ..."

#Set-Location $env:pb_data

#Copy-Item f001_batch_control_file \\$Env:root\foxtrot\purge\f001_batch_control_file_orig
#Copy-Item f001_batch_control_file.idx \\$Env:root\foxtrot\purge\f001_batch_control_file_orig.idx

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 delete_f001_claims_batches"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

#Set-Location $Env:root\charly\purge

$rcmd = $env:COBOL + "r001b"
Invoke-Expression $rcmd

Remove-Item r001b_before_r095 *> $null
Move-Item -Force r001b r001b_before_r095

echo ""
Get-ChildItem -Force r001b_before_r095
echo ""
echo "HIT `"NEWLINE`" TO PRINT BEFORE REPORT ..."
 $garbage = Read-Host

##lp r001b_before_r095

Remove-Item u095-retain-batch.sf* *> $null
Remove-Item u095-delete-batch.sf* *> $null
Remove-Item u095-purge-validate.sf* *> $null

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 22 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 22000000 22ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 22"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_22 *> $null
Move-Item -Force r095.txt r095_22
#lp   r095_22

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 23 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 23000000 23ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 23"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_23 *> $null
Move-Item -Force r095.txt r095_23
#lp   r095_23

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 24 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 24000000 24ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 24"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_24 *> $null
Move-Item -Force r095.txt r095_24
#lp   r095_24

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 25 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 25000000 25ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 25"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_25 *> $null
Move-Item -Force r095.txt r095_25
#lp   r095_25

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 26 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 26000000 26ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 26"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_26 *> $null
Move-Item -Force r095.txt r095_26
#lp   r095_26


echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 30 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 30000000 30ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 30"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_30 *> $null
Move-Item -Force r095.txt r095_30
#lp   r095_30


echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 31 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 31000000 31ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 31"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_31 *> $null
Move-Item -Force r095.txt r095_31
#lp   r095_31

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 32 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 32000000 32ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 32"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_32 *> $null
Move-Item -Force r095.txt r095_32
#lp   r095_32

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 33 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 33000000 33ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 33"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_33 *> $null
Move-Item -Force r095.txt r095_33
#lp   r095_33

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 34 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 34000000 34ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 34"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_34 *> $null
Move-Item -Force r095.txt r095_34
#lp   r095_34

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 35 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 35000000 35ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 35"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_35 *> $null
Move-Item -Force r095.txt r095_35
#lp   r095_35

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 36 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 36000000 36ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 36"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_36 *> $null
Move-Item -Force r095.txt r095_36
#lp   r095_36


echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 37 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 37000000 37ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 37"
Invoke-Expression $rcmd


echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_37 *> $null
Move-Item -Force r095.txt r095_37
#lp   r095_37

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 41 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 41000000 41ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 41"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_41 *> $null
Move-Item -Force r095.txt r095_41
#lp   r095_41

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 42 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 42000000 42ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 42"
Invoke-Expression $rcmd
echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_42 *> $null
Move-Item -Force r095.txt r095_42
#lp   r095_42

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 43 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 43000000 43ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 43"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_43 *> $null
Move-Item -Force r095.txt r095_43
#lp   r095_43

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 44 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 44000000 44ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 44"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_44 *> $null
Move-Item -Force r095.txt r095_44
#lp   r095_44

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 45 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 45000000 45ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 45"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_45 *> $null
Move-Item -Force r095.txt r095_45
#lp   r095_45

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 46 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 46000000 46ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 46"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_46 *> $null
Move-Item -Force r095.txt r095_46
#lp   r095_46

echo ""
echo ""
echo "STAGE 2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 60000000 66ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 60"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_60 *> $null
Move-Item -Force r095.txt r095_60
#lp   r095_60

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 68 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 68000000 68ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 68"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_68 *> $null
Move-Item -Force r095.txt r095_68
#lp   r095_68

echo ""
echo ""

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 69 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 69000000 69ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 69"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_69 *> $null
Move-Item -Force r095.txt r095_69
#lp   r095_69

echo ""
echo ""
echo "STAGE 2 - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 70000000 75ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 70"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_70 *> $null
Move-Item -Force r095.txt r095_70
#lp   r095_70

echo ""
echo "STAGE 2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 78 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 78000000 78ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 78"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_78 *> $null
Move-Item -Force r095.txt r095_78
#lp   r095_78

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 79 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 79000000 79ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 79"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_79 *> $null
Move-Item -Force r095.txt r095_79
#lp   r095_79

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 80 --"
echo ""

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 80000000 80ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 80"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_80 *> $null
Move-Item -Force r095.txt r095_80
#lp   r095_80

echo ""
echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 82 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 82000000 82ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 82"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_82 *> $null
Move-Item -Force r095.txt r095_82
#lp   r095_82

echo ""
echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 84 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 84000000 84ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 84"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_84 *> $null
Move-Item -Force r095.txt r095_84
#lp   r095_84

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 86 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 86000000 86ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 86"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_86 *> $null
Move-Item -Force r095.txt r095_86
#lp   r095_86

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 87 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 87000000 87ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 87"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_87 *> $null
Move-Item -Force r095.txt r095_87
#lp   r095_87

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 88 --"
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 88000000 88ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 88"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_88 *> $null
Move-Item -Force r095.txt r095_88
#lp   r095_88

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 89 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 89000000 89ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 89"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_89 *> $null
Move-Item -Force r095.txt r095_89
#lp   r095_89

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 91 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 91000000 91ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 91"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_91 *> $null
Move-Item -Force r095.txt r095_91
#lp   r095_91

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 92 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 92000000 92ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 92"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_92 *> $null
Move-Item -Force r095.txt r095_92
#lp   r095_92

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 93 --"
echo ""
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 93000000 93ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 93"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_93 *> $null
Move-Item -Force r095.txt r095_93
#lp   r095_93

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 94 --"
echo ""

echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 94000000 94ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 94"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_94 *> $null
Move-Item -Force r095.txt r095_94
#lp   r095_94

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""

echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 95000000 95ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 95"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_95 *> $null
Move-Item -Force r095.txt r095_95
#lp   r095_95

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""

echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 96000000 96ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 96"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_96 *> $null
Move-Item -Force r095.txt r095_96
#lp   r095_96

echo ""
echo "STAGE  2  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 98 --"
echo ""

echo "PROGRAM `"U095`" NOW LOADING ..."

$rcmd = $env:QTP + "u095 98000000 98ZZZ999 $1"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r095a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r095c DISC_r095 98"
Invoke-Expression $rcmd

echo ""
Get-ChildItem -Force r095.txt
echo ""

Remove-Item r095_98 *> $null
Move-Item -Force r095.txt r095_98
#lp   r095_98

echo ""
echo "STAGE   3   - RUN `"ALL_BATCHES`" FOR DUMP OF FILE AFTER DELETION ..."

$rcmd = $env:COBOL + "r001b"
Invoke-Expression $rcmd

Remove-Item r001b_after_r095 *> $null
Move-Item -Force r001b r001b_after_r095

echo ""
Get-ChildItem -Force r001b_after_r095
echo ""

##lp         r001b_after_r095
echo ""
echo "FINISHED ..."

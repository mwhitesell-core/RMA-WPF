#-------------------------------------------------------------------------------
# File 'delete_f001_claims_batches.bkp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_f001_claims_batches.bkp'
#-------------------------------------------------------------------------------

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
echo "STAGE    #1    - RUN `"ALL_BATCHES`" FOR DUMP OF FILE BEFORE DELETION ..."

Set-Location $pb_data

Copy-Item f001_batch_control_file $Env:root\charly\purge\f001_batch_control_file_orig
Copy-Item f001_batch_control_file.idx $Env:root\charly\purge\f001_batch_control_file_orig.idx

Set-Location $Env:root\charly\purge

&$env:COBOL r001b

Remove-Item r001b_before_r095 *> $null
Move-Item -Force r001b r001b_before_r095

echo ""
Get-ChildItem -Force r001b_before_r095
echo ""

echo "HIT `"NEWLINE`" TO PRINT BEFORE REPORT ..."
 $garbage = Read-Host
#lp r001b_before_r095

Remove-Item u095-retain-batch.sf* *> $null
Remove-Item u095-delete-batch.sf* *> $null
Remove-Item u095-purge-validate.sf* *> $null

echo ""
echo "STAGE  #2-A  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 22 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
$garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095 22000000 22ZZZ999 20090630

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 22

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_22 *> $null
Move-Item -Force r095.txt r095_22
Get-Content r095_22 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 31 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 31

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_31 *> $null
Move-Item -Force r095.txt r095_31
Get-Content r095_31 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 32 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 32

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_32 *> $null
Move-Item -Force r095.txt r095_32
Get-Content r095_32 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 33 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 33

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_33 *> $null
Move-Item -Force r095.txt r095_33
Get-Content r095_33 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 34 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 34

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_34 *> $null
Move-Item -Force r095.txt r095_34
Get-Content r095_34 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 35 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 35

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_35 *> $null
Move-Item -Force r095.txt r095_35
Get-Content r095_35 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 36 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 36

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_36 *> $null
Move-Item -Force r095.txt r095_36
Get-Content r095_36 | Out-Printer


echo ""
echo "STAGE  #2-C  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 37 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 37


echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_37 *> $null
Move-Item -Force r095.txt r095_37
Get-Content r095_37 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 41 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 41

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_41 *> $null
Move-Item -Force r095.txt r095_41
Get-Content r095_41 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 42 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 42

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_42 *> $null
Move-Item -Force r095.txt r095_42
Get-Content r095_42 | Out-Printer

echo ""
echo "STAGE  #2-A  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 43 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
$garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 43

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_43 *> $null
Move-Item -Force r095.txt r095_43
Get-Content r095_43 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 44 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 44

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_44 *> $null
Move-Item -Force r095.txt r095_44
Get-Content r095_44 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 45 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 45

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_45 *> $null
Move-Item -Force r095.txt r095_45
Get-Content r095_45 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 46 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 46

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_46 *> $null
Move-Item -Force r095.txt r095_46
Get-Content r095_46 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 48 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 48

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_48 *> $null
Move-Item -Force r095.txt r095_48
Get-Content r095_48 | Out-Printer

echo ""
echo ""
echo "STAGE #2-B  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 60

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_60 *> $null
Move-Item -Force r095.txt r095_60
Get-Content r095_60 | Out-Printer

echo ""
echo "STAGE #2-B  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 70

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_70 *> $null
Move-Item -Force r095.txt r095_70
Get-Content r095_70 | Out-Printer

echo ""
echo "STAGE  #2-C  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 78 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 78


echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_78 *> $null
Move-Item -Force r095.txt r095_78
Get-Content r095_78 | Out-Printer

echo ""
echo "STAGE  #2-C  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 79 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 79


echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_79 *> $null
Move-Item -Force r095.txt r095_79
Get-Content r095_79 | Out-Printer

echo ""
echo "STAGE  #2-C  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 80 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 80


echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_80 *> $null
Move-Item -Force r095.txt r095_80
Get-Content r095_80 | Out-Printer

echo ""
echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 82 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 82

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_82 *> $null
Move-Item -Force r095.txt r095_82
Get-Content r095_82 | Out-Printer

echo ""
echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 84 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 84

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_84 *> $null
Move-Item -Force r095.txt r095_84
Get-Content r095_84 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 86 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 86

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_86 *> $null
Move-Item -Force r095.txt r095_86
Get-Content r095_86 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 87 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 87

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_87 *> $null
Move-Item -Force r095.txt r095_87
Get-Content r095_87 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 88 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 88

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_88 *> $null
Move-Item -Force r095.txt r095_88
Get-Content r095_88 | Out-Printer

echo ""
echo "STAGE  #2-E  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 89 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 89

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_89 *> $null
Move-Item -Force r095.txt r095_89
Get-Content r095_89 | Out-Printer

echo ""
echo "STAGE  #2-F  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 91 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 91

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_91 *> $null
Move-Item -Force r095.txt r095_91
Get-Content r095_91 | Out-Printer

echo ""
echo "STAGE  #2-G  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 92 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 92

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_92 *> $null
Move-Item -Force r095.txt r095_92
Get-Content r095_92 | Out-Printer

echo ""
echo "STAGE  #2-H  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 93 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 93

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_93 *> $null
Move-Item -Force r095.txt r095_93
Get-Content r095_93 | Out-Printer

echo ""
echo "STAGE  #2-I  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 94 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 94

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_94 *> $null
Move-Item -Force r095.txt r095_94
Get-Content r095_94 | Out-Printer

echo ""
echo "STAGE  #2-J  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 95

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_95 *> $null
Move-Item -Force r095.txt r095_95
Get-Content r095_95 | Out-Printer

echo ""
echo "STAGE  #2-K  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 96

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_96 *> $null
Move-Item -Force r095.txt r095_96
Get-Content r095_96 | Out-Printer

echo ""
echo "STAGE  #2-K  - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 98 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c 98

echo ""
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_98 *> $null
Move-Item -Force r095.txt r095_98
Get-Content r095_98 | Out-Printer

echo ""
echo "STAGE    #3    - RUN `"ALL_BATCHES`" FOR DUMP OF FILE AFTER DELETION ..."

&$env:COBOL r001b

Remove-Item r001b_after_r095 *> $null
Move-Item -Force r001b r001b_after_r095

echo ""
Get-ChildItem -Force r001b_after_r095
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

#lp         r001b_after_r095
echo ""
echo "FINISHED ..."

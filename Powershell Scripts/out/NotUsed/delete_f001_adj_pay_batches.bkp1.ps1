#-------------------------------------------------------------------------------
# File 'delete_f001_adj_pay_batches.bkp1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_f001_adj_pay_batches.bkp1'
#-------------------------------------------------------------------------------

#  2001/jul/09 B.E. added renames to backup subfiles for each clinic
#  2003/Jul/16 yas. added clinics 91,92,93,94 and 96

echo "DELETE_F001_ADJ_PAY_BATCHES"
echo ""

echo "DELETE THE ADJUSTMENT AND PAYMENT BATCHES FOR THE CLINIC"
echo ""
echo "N O T E : ! ! !  F001 AND F002 MUST HAVE BE BACKED UP before THIS RUN ..."
echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE PROCEDURE ..."
$garbage = Read-Host
echo ""
echo "STAGE #1A - RUN VERIFY OF CLAIMS  FOR A REPORT OF FILE BEFORE DELETION .."

Set-Location $Env:root\charly\purge

&$env:COBOL r071
Remove-Item r071_before *> $null
Move-Item -Force r071 r071_before

echo ""
Get-ChildItem -Force r071_before
echo ""

Get-Date

echo "HIT   `"NEWLINE`"  TO PRINT BEFORE REPORT ..."
$garbage = Read-Host

#lp r071_before

echo ""
echo " STAGE #1B - RUN `"ALL_BATCHES`" ON ALL CLINICS BEFORE DELETION ..."

&$env:COBOL r001b

Remove-Item r001b_before_r093 *> $null
Move-Item -Force r001b r001b_before_r093

echo ""
Get-ChildItem -Force r001b_before_r093
echo ""

echo "HIT `"NEWLINE`" TO PRINT BEFORE REPORT ..."
 $garbage = Read-Host


##lp     r001b_before_r093

Remove-Item u093-retain-batch.sf* *> $null
Remove-Item u093-delete-batch.sf* *> $null
Remove-Item u093-purge-validate.sf* *> $null
Remove-Item u093*.txt *> $null

echo ""
echo "STAGE #2A    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 22 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."


echo " --- u093   (QTP) --- "
&$env:QTP u093 22000000 22ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 22
&$env:QUIZ r093d 22
Move-Item -Force u093-delete-batch.sf u093-delete-batch-22.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-22.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-22.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-22.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_22 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_22
#lp                           r093_22

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 31 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 31000000 31ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 31
&$env:QUIZ r093d 31
Move-Item -Force u093-delete-batch.sf u093-delete-batch-31.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-31.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-31.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-31.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_31 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_31
#lp                           r093_31

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 32 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 32000000 32ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 32
&$env:QUIZ r093d 32
Move-Item -Force u093-delete-batch.sf u093-delete-batch-32.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-32.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-32.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-32.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_32 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_32
#lp                           r093_32

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 33 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 33000000 33ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 33
&$env:QUIZ r093d 33
Move-Item -Force u093-delete-batch.sf u093-delete-batch-33.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-33.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-33.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-33.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_33 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_33
#lp                           r093_33

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 34 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 34000000 34ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 34
&$env:QUIZ r093d 34
Move-Item -Force u093-delete-batch.sf u093-delete-batch-34.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-34.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-34.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-34.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_34 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_34
#lp                           r093_34

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 35 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 35000000 35ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 35
&$env:QUIZ r093d 35
Move-Item -Force u093-delete-batch.sf u093-delete-batch-35.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-35.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-35.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-35.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_35 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_35
#lp                           r093_35


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 36 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 36000000 36ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 36
&$env:QUIZ r093d 36
Move-Item -Force u093-delete-batch.sf u093-delete-batch-36.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-36.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-36.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-36.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_36 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_36
#lp                           r093_36


echo ""
echo "STAGE    #2-C    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 37 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 37000000 37ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 37
&$env:QUIZ r093d 37
Move-Item -Force u093-delete-batch.sf u093-delete-batch-37.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-37.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-37.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-37.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_37 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_37
#lp                           r093_37

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 41 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 41000000 41ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 41
&$env:QUIZ r093d 41
Move-Item -Force u093-delete-batch.sf u093-delete-batch-41.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-41.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-41.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-41.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_41 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_41
#lp                           r093_41


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 42 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 42000000 42ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 42
&$env:QUIZ r093d 42
Move-Item -Force u093-delete-batch.sf u093-delete-batch-42.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-42.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-42.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-42.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_42 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_42
#lp                           r093_42

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 43 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 43000000 43ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 43
&$env:QUIZ r093d 43
Move-Item -Force u093-delete-batch.sf u093-delete-batch-43.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-43.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-43.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-43.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_43 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_43
#lp                           r093_43


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 44 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 44000000 44ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 44
&$env:QUIZ r093d 44
Move-Item -Force u093-delete-batch.sf u093-delete-batch-44.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-44.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-44.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-44.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_44 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_44
#lp                           r093_44


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 45 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 45000000 45ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 45
&$env:QUIZ r093d 45
Move-Item -Force u093-delete-batch.sf u093-delete-batch-45.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-45.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-45.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-45.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_45 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_45
#lp                           r093_45


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 46 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 46000000 46ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 46
&$env:QUIZ r093d 46
Move-Item -Force u093-delete-batch.sf u093-delete-batch-46.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-46.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-46.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-46.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_46 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_46
#lp                           r093_46


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 48 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 48000000 48ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 48
&$env:QUIZ r093d 48
Move-Item -Force u093-delete-batch.sf u093-delete-batch-48.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-48.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-48.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-48.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_48 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_48
#lp                           r093_48

echo ""
echo "STAGE    #2-B    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 60000000 65ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 60
&$env:QUIZ r093d 60
Move-Item -Force u093-delete-batch.sf u093-delete-batch-60.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-60.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-60.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-60.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_60 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_60
#lp                           r093_60


echo ""
echo "STAGE    #2-B    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 70000000 75ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 70
&$env:QUIZ r093d 70
Move-Item -Force u093-delete-batch.sf u093-delete-batch-70.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-70.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-70.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-70.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""
Get-Date
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_70 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_70
#lp                           r093_70


echo ""
echo "STAGE    #2-C    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 78 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 78000000 78ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 78
&$env:QUIZ r093d 78
Move-Item -Force u093-delete-batch.sf u093-delete-batch-78.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-78.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-78.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-78.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_78 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_78
#lp                           r093_78




echo ""
echo "STAGE    #2-C    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 79 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 79000000 79ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 79
&$env:QUIZ r093d 79
Move-Item -Force u093-delete-batch.sf u093-delete-batch-79.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-79.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-79.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-79.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_79 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_79
#lp                           r093_79

echo ""
echo "STAGE    #2-C    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 80 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 80000000 80ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 80
&$env:QUIZ r093d 80
Move-Item -Force u093-delete-batch.sf u093-delete-batch-80.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-80.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-80.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-80.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_80 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_80
#lp                           r093_80


echo ""
echo ""
echo "STAGE    #2-E    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 82 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 82000000 82ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 82
&$env:QUIZ r093d 82
Move-Item -Force u093-delete-batch.sf u093-delete-batch-82.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-82.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-82.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-82.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_82 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_82
#lp                           r093_82

echo ""

echo ""
echo ""
echo "STAGE    #2-E    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 84 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 84000000 84ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 84
&$env:QUIZ r093d 84
Move-Item -Force u093-delete-batch.sf u093-delete-batch-84.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-84.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-84.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-84.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_84 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_84
#lp                           r093_84


echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 86 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 86000000 86ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 86
&$env:QUIZ r093d 86
Move-Item -Force u093-delete-batch.sf u093-delete-batch-86.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-86.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-86.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-86.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_86 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_86
#lp                           r093_86

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC --87 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 87000000 87ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 87
&$env:QUIZ r093d 87
Move-Item -Force u093-delete-batch.sf u093-delete-batch-87.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-87.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-87.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-87.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_87 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_87 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_87
#lp                           r093_87

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC --88 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 88000000 88ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 88
&$env:QUIZ r093d 88
Move-Item -Force u093-delete-batch.sf u093-delete-batch-88.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-88.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-88.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-88.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_88 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_88 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_88
#lp                           r093_88

echo ""
echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC --89 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093 89000000 89ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 89
&$env:QUIZ r093d 89
Move-Item -Force u093-delete-batch.sf u093-delete-batch-89.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-89.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-89.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-89.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_89 *> $null

Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_89 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_89
#lp                           r093_89

echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 91 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 91000000 91ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 91
&$env:QUIZ r093d 91
Move-Item -Force u093-delete-batch.sf u093-delete-batch-91.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-91.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-91.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-91.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_91 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_91
#lp                           r093_91



echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 92 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 92000000 92ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 92
&$env:QUIZ r093d 92
Move-Item -Force u093-delete-batch.sf u093-delete-batch-92.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-92.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-92.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-92.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_92 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_92
#lp                           r093_92



echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 93 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 93000000 93ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 93
&$env:QUIZ r093d 93
Move-Item -Force u093-delete-batch.sf u093-delete-batch-93.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-93.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-93.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-93.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_93 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_93
#lp                           r093_93


echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 94 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 94000000 94ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 94
&$env:QUIZ r093d 94
Move-Item -Force u093-delete-batch.sf u093-delete-batch-94.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-94.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-94.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-94.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_94 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_94
#lp                           r093_94


echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 95000000 95ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 95
&$env:QUIZ r093d 95
Move-Item -Force u093-delete-batch.sf u093-delete-batch-95.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-95.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-95.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-95.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_95 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_95
#lp                           r093_95


echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 96000000 96ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 96
&$env:QUIZ r093d 96
Move-Item -Force u093-delete-batch.sf u093-delete-batch-96.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-96.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-96.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-96.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_96 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_96
#lp                           r093_96


echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 98 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093 98000000 98ZZZ999 20090630

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 98
&$env:QUIZ r093d 98
Move-Item -Force u093-delete-batch.sf u093-delete-batch-98.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-98.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-98.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-98.sfd


echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_98 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_98
#lp                           r093_98



echo ""
echo "STAGE  #3A  - RUN VERIFY OF CLAIMS FOR A REPORT OF FILE AFTER DELETION ."

&$env:COBOL r071
Remove-Item r071_after *> $null
Move-Item -Force r071 r071_after

echo ""
Get-ChildItem -Force r071_after
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

#lp      r071_after

echo ""
Get-Date
echo ""
echo "STAGE    #3B    - RUN `"ALL_BATCHES`" FOR REPORT OF FILE AFTER REPORT ..."

&$env:COBOL r001b

Remove-Item r001b_after_r093 *> $null
Move-Item -Force r001b r001b_after_r093

echo ""
Get-ChildItem -Force r001b_after_r093
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

##lp      r001b_after_r093


echo ""
echo "FINISHED ..."

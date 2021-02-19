#-------------------------------------------------------------------------------
# File 'del_f001_adj_pay_batches_83.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'del_f001_adj_pay_batches_83'
#-------------------------------------------------------------------------------

echo "DELETE_F001_ADJ_PAY_BATCHES"
echo ""

echo "DELETE THE ADJUSTMENT AND PAYMENT BATCHES FOR THE CLINIC"
echo ""
echo "N O T E : ! ! !  F001 AND F002 MUST HAVE BEEN BACKED UP PRIOR TO THIS RUN..."
echo ""
echo "HIT   `"NEWLINE`"   TO COMMENCE PROCEDURE ..."
$garbage = Read-Host
echo ""
echo "STAGE #1A - RUN VERIFY OF CLAIMS MASTER FOR A REPORT OF FILE BEFORE DELETION ..."

&$env:COBOL r071
Remove-Item r071_before *> $null
Move-Item -Force r071 r071_before

echo ""
Get-ChildItem -Force r071_before
echo ""

Get-Date

echo "HIT   `"NEWLINE`"  TO PRINT BEFORE REPORT ..."
$garbage = Read-Host

Get-Content r071_before | Out-Printer

echo ""
echo "STAGE #1B - RUN `"ALL_BATCHES`" ON ALL CLINICS FOR REPORT OF FILE"
echo "            BEFORE DELETION ..."

&$env:COBOL r001b

Remove-Item r001b_before_r093 *> $null
Move-Item -Force r001b r001b_before_r093

echo ""
Get-ChildItem -Force r001b_before_r093
echo ""

echo "HIT `"NEWLINE`" TO PRINT BEFORE REPORT ..."
 $garbage = Read-Host


#lp         r001b_before_r093

Remove-Item u093-retain-batch.sf* *> $null
Remove-Item u093-delete-batch.sf* *> $null
Remove-Item u093-purge-validate.sf* *> $null
Remove-Item u093*.txt *> $null

echo ""
echo "STAGE #2A    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 83 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."

&$env:QTP u093

&$env:QUIZ r093a
&$env:QUIZ r093b
&$env:QUIZ r093c 83
&$env:QUIZ r093d 83
Move-Item -Force u093-delete-batch.sf u093-delete-batch-83.sf
Move-Item -Force u093-delete-batch.sfd u093-delete-batch-83.sfd
Move-Item -Force u093-retain-batch.sf u093-retain-batch-83.sf
Move-Item -Force u093-retain-batch.sfd u093-retain-batch-83.sfd

echo ""
Get-ChildItem -Force r093a.txt
Get-ChildItem -Force r093b.txt
echo ""

Get-Date

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r093_83 *> $null
Get-Content r093a.txt, r093b.txt | Set-Content r093_83
Get-Content r093_83 | Out-Printer

echo ""

echo ""
echo "STAGE,,,,#3A,,,,- RUN VERIFY OF CLAIMS MASTER FOR A REPORT OF FILE AFTER DELETION"

&$env:COBOL r071
Remove-Item r071_after *> $null
Move-Item -Force r071 r071_after

echo ""
Get-ChildItem r071_after
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
$garbage = Read-Host

Get-Content r071_after | Out-Printer

echo ""
Get-Date
echo ""

echo "STAGE,,,,#3B,,,,- RUN 'ALL_BATCHES' FOR REPORT OF FILE AFTER REPORT ..."

&$env:COBOL r001b

Remove-Item r001b_after_r093 *> $null
Move-Item -Force r001b r001b_after_r093

echo ""

Get-ChildItem -Force r001b_after_r093
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
 $garbage = Read-Host

Get-Content r001b_after_r093 | Out-Printer


echo ""
echo "FINISHED ..."

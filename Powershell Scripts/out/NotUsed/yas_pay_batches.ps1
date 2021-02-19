#-------------------------------------------------------------------------------
# File 'yas_pay_batches.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_pay_batches'
#-------------------------------------------------------------------------------

echo ""
echo "STAGE    #2-B    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 60 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."


&$env:QTP u093

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
Get-Content r093_60 | Out-Printer

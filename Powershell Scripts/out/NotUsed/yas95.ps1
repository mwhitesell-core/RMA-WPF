#-------------------------------------------------------------------------------
# File 'yas95.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas95'
#-------------------------------------------------------------------------------

echo ""
echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 95 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."


&$env:QTP u093

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
Get-Content r093_95 | Out-Printer

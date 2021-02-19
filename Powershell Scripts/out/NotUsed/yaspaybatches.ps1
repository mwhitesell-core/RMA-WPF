#-------------------------------------------------------------------------------
# File 'yaspaybatches.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yaspaybatches'
#-------------------------------------------------------------------------------

echo "STAGE    #2-F   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 96 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."


&$env:QTP u093

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
Get-Content r093_96 | Out-Printer

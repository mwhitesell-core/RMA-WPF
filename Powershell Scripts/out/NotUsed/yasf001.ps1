#-------------------------------------------------------------------------------
# File 'yasf001.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasf001'
#-------------------------------------------------------------------------------

echo "STAGE #2A1   - RUN BATCH DELETION PROGRAM FOR CLINIC -- 48 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAMU093 NOW LOADING ..."

&$env:QTP u093

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
Get-Content r093_48 | Out-Printer


echo ""
echo "STAGE    #2-B    - RUN BATCH DELETION PROGRAM FOR CLINIC -- 70 --"
echo ""
echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U093`" NOW LOADING ..."


&$env:QTP u093

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
Get-Content r093_70 | Out-Printer


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

Get-Content r071_after | Out-Printer

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

#lp      r001b_after_r093


echo ""
echo "FINISHED ..."

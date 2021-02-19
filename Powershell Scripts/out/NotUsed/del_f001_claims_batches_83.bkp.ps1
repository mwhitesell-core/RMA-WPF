#-------------------------------------------------------------------------------
# File 'del_f001_claims_batches_83.bkp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'del_f001_claims_batches_83.bkp'
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

&$env:COBOL r001b

Remove-Item r001b_before_r095 *> $null
Move-Item -Force r001b r001b_before_r095

echo ""
Get-ChildItem -Force r001b_before_r095
echo ""

echo "HIT `"NEWLINE`" TO PRINT BEFORE REPORT ..."
 $garbage = Read-Host
#lp r001b_before_r095

echo ""
echo "STAGE    #2-A    - RUN `"CLAIMS`" BATCH DELETION PROGRAM FOR CLINIC -- 83 --"
echo ""

echo "HIT `"NEWLINE`" TO START DELETE PROGRAM..."
 $garbage = Read-Host

echo ""
echo "PROGRAM `"U095`" NOW LOADING ..."

#cobrun $obj/u095
&$env:QTP u095

&$env:QUIZ r095a
&$env:QUIZ r095b
&$env:QUIZ r095c

echo ""
#ls -laF r095
Get-ChildItem -Force r095.txt
echo ""

echo "HIT `"NEWLINE`" TO PRINT AUDIT REPORT ..."
 $garbage = Read-Host

Remove-Item r095_83 *> $null
#mv  r095 r095_22
Move-Item -Force r095.txt r095_83
Get-Content r095_83 | Out-Printer

echo ""
echo "STAGE,,,,#3,,,,- RUN `"ALL_BATCHES`" FOR DUMP OF FILE AFTER DELETION ..."

&$env:COBOL r001b

Remove-Item r001b_after_r095
Move-Item -Force r001b r001b_after_r095

echo ""
#ls r001b_after_r095
echo ""

echo "HIT `"NEWLINE`" TO PRINT AFTER REPORT ..."
$garbage = Read-Host

#lp         r001b_after_r095

echo "FINISHED ..."

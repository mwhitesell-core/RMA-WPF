#-------------------------------------------------------------------------------
# File 'create_new_claims_mstr_OLD_COBOL_PGMS.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_new_claims_mstr_OLD_COBOL_PGMS'
#-------------------------------------------------------------------------------

echo "CREATE_NEW_CLAIMS_MSTR"
echo ""

echo "A\R FILE PURGE STAGE" # 2
echo "NOTE -- THE PREVIOUS STAGE(S) MUST HAVE BEEN RUN !!!"
echo ""
echo "CREATE NEW FILE AND MOVE 'BALANCE-OWING' CLAIMS FROM OLD TO NEW FILE"
echo ""
echo "NOTE !!"
echo "NO ONE MUST BE ACCESSING THE CLAIMS FILE !!!"

echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE PROCEDURE ..."
$garbage = Read-Host
echo ""

echo "CREATING THE NEW CLAIMS MASTER FILE `"F002_CLAIMS_MSTR_NEW`" ..."
echo ""


echo "CREATING THE NEW CLAIM SHADOW  FILE `"F002_CLAIM_SHADOW_NEW`" ..."
echo ""


echo "ENSURE THAT NO EXISTINGNEW FILES EXIST BEFORE CREATING THEM AGAIN ..."

Remove-Item f002_claims_extra_new.*

echo ""
echo "RE-CREATING THE NEW CLAIMS EXTRA FILE .."
echo ""


echo "HIT `"NEWLINE`" TO COPY CLAIMS FROM `"OLD`" TO `"NEW`" FILE ..."
$garbage = Read-Host
echo ""
echo "PROGRAM `"U072`" NOW LOADING ..."

&$env:COBOL u072
Get-ChildItem ru072
Get-Date

Get-Content ru072 | Out-Printer

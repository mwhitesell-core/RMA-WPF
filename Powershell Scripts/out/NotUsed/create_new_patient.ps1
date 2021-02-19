#-------------------------------------------------------------------------------
# File 'create_new_patient.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_new_patient'
#-------------------------------------------------------------------------------

echo "CREATE_NEW_PATIENT"

echo ""

echo "PATIENT FILE PURGE STAGE" # 3
echo "NOTE -- THE PREVIOUS STAGE(S) MUST HAVE BEEN RUN !!"
echo ""
echo "'NEW' PATIENT MASTER FILE  WILL BE CREATED ..."
echo "HITNEWLINE  TO COMMENCE PROCEDURE ..."
$garbage = Read-Host
echo ""

echo ""
echo "RECREATING THE NEW PATIENT MASTER FILE ..."
echo ""

Set-Location $pb_data

echo "ENSURE THAT NO EXISTINGNEW FILES EXIST BEFORE CREATING THEM AGAIN ..."

Get-ChildItem f010_pat_mstr_new*

echo ""
echo "RE-CREATING THE NEW PATIENT MASTER FILE ..."
echo ""

Remove-Item f010_pat_mstr_new*

# PHDFM F010-PAT-MSTR

Move-Item -Force f010_pat_mstr f010_pat_mstr_new
Move-Item -Force f010_pat_mstr.dat f010_pat_mstr_new.dat
Move-Item -Force f010_pat_mstr.idx f010_pat_mstr_new.idx

#-------------------------------------------------------------------------------
# File 'rename_f010.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rename_f010'
#-------------------------------------------------------------------------------

echo ""
echo "RENAME 'NEW' PATIENT MASTER TO PRODUCTION NAME ..."
echo ""

Set-Location $pb_data
Move-Item -Force f010_pat_mstr_new.dat f010_pat_mstr.dat
Move-Item -Force f010_pat_mstr_new f010_pat_mstr
Move-Item -Force f010_pat_mstr_new.01.idx f010_pat_mstr.01.idx

Get-Date

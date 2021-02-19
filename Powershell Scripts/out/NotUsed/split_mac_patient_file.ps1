#-------------------------------------------------------------------------------
# File 'split_mac_patient_file.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'split_mac_patient_file'
#-------------------------------------------------------------------------------

Copy-Item mac_patient_file mac_patient_file.orig
echo "Ensure the $env:cmd\split_mac.awk has the correct macxx filenames !"
echo "Press newline to continue ..."
$garbage = Read-Host

Remove-Item mac.???

# CONVERSION ERROR (expected, #8): awk.
# awk -f $cmd/split_mac.awk < mac_patient_file

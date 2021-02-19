#-------------------------------------------------------------------------------
# File 'delete_ohip_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_ohip_files'
#-------------------------------------------------------------------------------

echo "********************************************************************"
echo "THIS WILL DELETE ALL THE REPORTS INCLUDING RU020MR AND RU022MR"
echo "AND OHIP TAPE MAKE SURE ALL THE EXTRA COPPIES ARE PRINTED"
echo "********************************************************************"
echo "PRESS `"NEWLINE`"  TO DELETE OHIP REPORTS AND TAPE"
$garbage = Read-Host

Remove-Item r001b
Remove-Item r002aa
Remove-Item r002ab
Remove-Item r004_c
Remove-Item r014
Remove-Item ru022
Remove-Item ru022a*
Remove-Item ru022b*
Remove-Item ru022_sd
Remove-Item ru022a_sd
Remove-Item ru022b_sd
Remove-Item ru020a*
Remove-Item ru020b*
Remove-Item ru020c*
Remove-Item ru022c*
Remove-Item ru022c_sd
Remove-Item r010
Remove-Item ru020mr*
Remove-Item ru022mr*
Remove-Item ru022mr_sd
Remove-Item u020*.sf*
Remove-Item u022*.sf*
Remove-Item sd_u022*.sf*
# CONVERSION ERROR (expected, #31): EBCDIC.
# rm ohip_tape_converted_to_ebcdic
#rm *u035*
Remove-Item ru011a
Remove-Item ru011b
Remove-Item mac_patient_tape

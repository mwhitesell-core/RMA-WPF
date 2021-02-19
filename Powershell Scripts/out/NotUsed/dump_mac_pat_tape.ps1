#-------------------------------------------------------------------------------
# File 'dump_mac_pat_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_mac_pat_tape'
#-------------------------------------------------------------------------------

Remove-Item dump_mac_pat_tape.ls
# CONVERSION ERROR (unexpected, #2): Unsupported parameters: [other:|, id:awk, string:{ printf"%157s\n", $0 }]
# cat mac_patient_tape |awk '{ printf"%157s\n", $0 }' > dump_mac_pat_tape.ls
Get-Content dump_mac_pat_tape.ls | Out-Printer

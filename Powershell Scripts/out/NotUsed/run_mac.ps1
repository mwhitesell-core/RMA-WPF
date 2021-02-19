#-------------------------------------------------------------------------------
# File 'run_mac.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_mac'
#-------------------------------------------------------------------------------

&$env:COBOL u993

Move-Item -Force mac.${1} mac_patient_file
&$env:COBOL u011
Move-Item -Force mac_patient_file mac.${1}

Move-Item -Force ru011a ru011a.${1}
Move-Item -Force ru011b ru011b.${1}
Move-Item -Force ru011c ru011c.${1}

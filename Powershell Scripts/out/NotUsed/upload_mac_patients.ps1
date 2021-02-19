#-------------------------------------------------------------------------------
# File 'upload_mac_patients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'upload_mac_patients'
#-------------------------------------------------------------------------------

# upload_mac_patient

# obtain file from hospital system
#ftp -v ihis << E_O_F
#get rma.out
#quit
#E_O_F           

# rename file to match what program expects
Remove-Item mac_patient_file_bkp *> $null
Move-Item -Force mac_patient_file mac_patient_file_bkp *> $null

Move-Item -Force rma.out mac_patient_file

#echo "Temporarily u011 commented out..."
#echo "Run the $cmd/split_mac_patient_file and"
#echo "        $cmd/run_all_mac_files "

# run upload
&$env:COBOL u993
&$env:COBOL u011

# print reports
#lp ru011a
#lp ru011b
#lp ru011c

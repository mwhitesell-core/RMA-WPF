#-------------------------------------------------------------------------------
# File 'newu701_3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701_3'
#-------------------------------------------------------------------------------

#   NAME: newu701
# 
#   PURPOSE: OHIP DISKETTE INPUT INTO RMA SYSTEM
#            THIS MACRO WILL TAKE A FILE FOR A SPECIFIED DOCTOR
#                 AND MOVE ALL CLAIMS INTO THE SUSPENSE FILES, APPLY
#                 THE PATIENTS WITHIN BATCH AGAINST THE PATIENT/SUBSCRIBER
#                 MASTERS, AND FINALLY UPDATE THE SUSPENSE RECORDS WITH THE
#                 ID's OF THE PATIENTS.
#   MODIFICATION HISTORY
#      DATE   PERSON        DESCRIPTION (PDR/SMS #)
#   90/JUL/01 B. ELLIOTT    ORIGINAL
#   90/OCT/31 Y. BOCCIA     ADD QPRINT R707.TXT
#   98/JAN/21 KEVIN MILES   MODIFIED FOR UNIX

                echo "Process batch`'s Patient data against RMA`'s patient\subsc riber database"
                echo ""
                Remove-Item submit_disk_pat_out *> $null
                &$env:COBOL newu703
                Get-ChildItem -Force ru703[a-z0-9]
                Get-Content ru703a | Out-Printer
                Get-Content ru703c | Out-Printer *> $null
#               lp ru703c.txt 1>/dev/null 2>&1
                echo ""
                echo "Processed patient data:"
                Get-ChildItem -Force submit_disk_pat_out
                echo ""
                echo ""
                echo "Apply processed patients against suspense files"
                echo ""
                &$env:QTP u704
                echo ""
                Remove-Item r707.txt *> $null
                &$env:QUIZ r707
                Get-Content r707.txt | Out-Printer
                echo ""
#               qtp auto=$obj/u705.qtc
#               echo 
#               echo  cleanup: rename input file as successfully processed
#               mv submit_disk_susp.in submit_disk_${1}.out
echo "Continue ?"
&$Garbage = Read-Host
echo ""

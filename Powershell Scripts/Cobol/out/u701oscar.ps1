#-------------------------------------------------------------------------------
# File 'u701oscar.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u701oscar'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#   NAME: u701oscar
# 
#   PURPOSE: OHIP DISKETTE (from OSCAR EMR) INPUT INTO RMA SYSTEM
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
#   00/sep/21 B.E.          - added processing of 'description' records
#   May/25/2010 Yas         - Add ru701_acr sorted by pat acrynm then by accounting number
#   2011/jan/30 brad1     - cloned from newu701

if ("$1" -eq "")
{
        echo "`a"
        echo ""
        echo "**ERROR**"
        echo "You must supply the 6 digit Doctor OHIP number for the batch to be processed!"
        echo ""
        echo "Valid Format:      u701oscar       bx999999"
        exit
} else {
        if (-not(Test-Path  f002_submit_disk_${1}.in))
        {
                echo "`a"
                echo "**ERROR** No such batch found!"
                echo ""
                exit
        } else {
if ((Test-Path submit_disk_susp.in) -or (Test-Path submit_disk_desc.in))
        {
                echo "`a"
                echo ""
                echo "**ERROR** Unprocessed suspense batch found !"
                echo "You must manually re-process the batch"
                echo "submit_disk_susp.in $root\ submit_disk_mr.in"
                echo "before re-running u701oscar"
                echo ""
                exit
        } else {
                Move-Item f002_submit_disk_${1}.in submit_disk_susp.in
                Move-Item f002_submit_desc_${1}.in submit_disk_desc.in  > $null
                echo ""
                echo ""
                echo "Place claims into suspense files ..."
                cobrun++ $obj\u701oscar
                echo ""
                echo "print status report ..."
                Get-ChildItem -Force ru701_oscar  > $null
#               lp ru701_oscar
                if (Test-Path submit_disk_desc.in)
                {
                  echo "Continue ? "
                  $garbage = Read-Host
                  echo "Place Description records into suspense ..."
                  qtp++ $obj\newu701
                } else {
                  echo "No Description records to process"
                }

                #cat ru701_cycle ru701_oscar >/usr/tmp/ru701_cycle.tmp  
                #mv /usr/tmp/ru701_cycle.tmp  ru701_cycle
                Get-Content ru701_cycle, ru701_oscar  > newu701.tmp
                Move-Item newu701.tmp ru701_cycle
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                echo ""
                                $cmd\check_for_resubmits

                echo ""
#               echo  Select special oma codes
#               qtp auto=$obj/u710.qtc
#               echo 
#               echo  Report selected special oma codes
#               rm r711.txt 1>/dev/null 2>&1
#               quiz auto=$obj/r711.qzc
#               echo 
#               ls -laF r711.txt 1>/dev/null 2>&1
#               lp r711.txt 1>/dev/null 2>&1
                echo ""
                echo ""
                echo "Report duplicate claims"
                Remove-Item r712.txt  > $null

                quiz++ $obj\r712
                echo ""
                Get-ChildItem -Force r712.txt  > $null
#               lp r712.txt
                echo ""
                echo ""
                echo "Extract batch`'s Patient data"
                Remove-Item submit_disk_pat_in.sf*  > $null
                quiz++ $obj\r702
#               #quiz auto=$obj/me.qzc
                echo ""
                echo "Extracted patient data file:"
                Get-ChildItem -Force submit_disk_pat_in.sf*
#b              echo "Continue ? "
#b              read garbage
                echo ""
                echo ""
                echo "Process batch`'s Patient data against RMA`'s patient\subscriber database"
                echo ""
                Remove-Item submit_disk_pat_out  > $null
                cobrun++ $obj\u703oscar
# CONVERSION WARNING; Line was useless (error and output sent to /dev/null, exit code not checked).
#                 ls -laF ru703[a-z0-9] 1>/dev/null 2>&1
#               lp ru703a
#               lp ru703c
#b              echo "Continue ? "
#b              read garbage
                echo ""
                echo "Processed patient data:"
                Get-ChildItem -Force submit_disk_pat_out  > $null
                echo ""
                echo ""
                echo "Apply processed patients against suspense files"
                echo ""
                qtp++ $obj\u704
                echo ""
                Remove-Item r707.txt  > $null
                quiz++ $obj\r707
#               lp r707.txt
#b              echo "Continue ? "
#b              read garbage
                echo ""
                qtp++ $obj\u705
                echo ""
                echo "cleanup: rename input file as successfully processed"
                Move-Item submit_disk_susp.in submit_disk_${1}.out
                Move-Item submit_disk_desc.in submit_desc_${1}.out  > $null
#               lp ru703c.txt 1>/dev/null 2>&1
                echo "running r710 to highlight claims with Percentage add-ons"
                echo "    that will likely need pricing attention..."
                quiz++ $obj\r710
#               lp r710.txt

######### Add ru701_acr May 25, 2010  sorted by pat acronym  then by accounting number
                quiz++ $obj\ru701_acr

                }
        }
}
echo ""
echo ""
#b echo "Continue ? "
#b read garbage
echo ""
echo ""

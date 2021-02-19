#-------------------------------------------------------------------------------
# File 'newu701.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701.bk1'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

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
#   00/sep/21 B.E.          - added processing of 'description' records
#   May/25/2010 Yas         - Add ru701_acr sorted by pat acrynm then by accounting number
#   Jun/11/2013 MC          - Add a temporary run of $obj/temp_ignore_agent6_susp_hdr at the end of the macro
#   Apr/03/2014 MC1         - add grep for checking invalid clinic for doctor in ru701 at the end of the macro

if ("$1" -eq "")
{
        echo "`a"
        echo ""
        echo "**ERROR**"
        echo "You must supply the 6 digit Doctor OHIP number for the batch to be processed!"
        echo ""
        echo "Valid Format:      newu701 bx999999"
        exit
} else {
        if (-not(Test-Path f002_submit_disk_${1}.in ))
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
                echo "submit_disk_susp.in $Env:root\ submit_disk_mr.in"
                echo "before re-running newu701"
                echo ""
                exit
        } else {
                Move-Item -Force f002_submit_disk_${1}.in submit_disk_susp.in
                Move-Item -Force f002_submit_desc_${1}.in submit_disk_desc.in *> $null
                echo ""
                echo ""
                echo "Place claims into suspense files ..."
                &$env:COBOL newu701
                echo ""
                echo "print status report ..."
                Get-ChildItem -Force ru701 *> $null
#               lp ru701
                if (Test-Path submit_disk_desc.in)
                {
                  echo "Continue ? "
                  $garbage = Read-Host
                  echo "Place Description records into suspense ..."
                  &$env:QTP newu701
                } else {
                  echo "No Description records to process"
                }

                #cat ru701_cycle ru701 >/usr/tmp/ru701_cycle.tmp  
                #mv /usr/tmp/ru701_cycle.tmp  ru701_cycle
                Get-Content ru701_cycle, ru701 | Set-Content newu701.tmp
                Move-Item -Force newu701.tmp ru701_cycle
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                echo ""
                                &$env:cmd\check_for_resubmits

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
                Remove-Item r712.txt *> $null

                &$env:QUIZ r712
                echo ""
                Get-ChildItem -Force r712.txt *> $null
#               lp r712.txt
                echo ""
                echo ""
                echo "Extract batch`'s Patient data"
                Remove-Item submit_disk_pat_in.sf* *> $null
                &$env:QUIZ r702
                echo ""
                echo "Extracted patient data file:"
                Get-ChildItem -Force submit_disk_pat_in.sf*
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                echo ""
                echo "Process batch`'s Patient data against RMA`'s patient\subscriber database"
                echo ""
                Remove-Item submit_disk_pat_out *> $null
                &$env:COBOL newu703
# CONVERSION ERROR (expected, #112): Line was useless (error and output sent to /dev/null, exit code not checked).
#                 ls -laF ru703[a-z0-9] 1>/dev/null 2>&1
#               lp ru703a
#               lp ru703c
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                echo "Processed patient data:"
                Get-ChildItem -Force submit_disk_pat_out *> $null
                echo ""
                echo ""
                echo "Apply processed patients against suspense files"
                echo ""
                &$env:QTP u704
                echo ""
                Remove-Item r707.txt *> $null
                &$env:QUIZ r707
#               lp r707.txt
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                &$env:QTP u705
                echo ""
                echo "cleanup: rename input file as successfully processed"
                Move-Item -Force submit_disk_susp.in submit_disk_${1}.out
                Move-Item -Force submit_disk_desc.in submit_desc_${1}.out *> $null
#               lp ru703c.txt 1>/dev/null 2>&1
                echo "running r710 to highlight claims with Percentage add-ons"
                echo "    that will likely need pricing attention..."
                &$env:QUIZ r710
#               lp r710.txt

######### Add ru701_acr May 25, 2010  sorted by pat acrynm then by accounting number
                &$env:QUIZ ru701_acr

                echo " temporary run to ignore agent 6 claims ... "
                &$env:QTP temp_ignore_agent6_susp_hdr

                }
        }
}

Get-Content ru701 | Select-String -Pattern "INVALID CLINIC NBR FOR THE DOCTOR"


echo ""
echo ""
echo "Continue ? "
$garbage = Read-Host
echo ""
echo ""

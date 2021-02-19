#-------------------------------------------------------------------------------
# File 'newu701_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701_1'
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
        if (Test-Path submit_disk_susp.in)
        {
                echo "`a"
                echo ""
                echo "**ERROR** Unprocessed suspense batch found !"
                echo "You must manually re-process the batch submit_disk_susp.in"
                echo "before re-running newu701"
                echo ""
                exit
        } else {
                Move-Item -Force f002_submit_disk_${1}.in submit_disk_susp.in
                echo ""
                echo ""
                echo "Place claims into suspense files ..."
                &$env:COBOL newu701
                echo ""
                echo "print status report ..."
                Get-ChildItem -Force ru701
#               lp ru701
                Get-Content ru701_cycle, ru701 | Set-Content $Env:root\usr\tmp\ru701_cycle.tmp
                Move-Item -Force $Env:root\usr\tmp\ru701_cycle.tmp ru701_cycle
                Write-Host -NoNewline  "Continue ? "
                $garbage = Read-Host
                echo ""
                echo ""
                echo "Select resubmit claims"
                echo ""
                &$env:QTP u714
                echo ""
                echo "Report selected resubmit claims"
                echo ""
                Remove-Item r715.txt *> $null
                &$env:QUIZ r715
#               lp r715.txt
                echo ""
                echo "Select special oma codes"
                &$env:QTP u710
                echo ""
                echo "Report selected special oma codes"
                Remove-Item r711.txt *> $null
                &$env:QUIZ r711
                echo ""
                Get-ChildItem -Force r711.txt
#               lp r711.txt
                echo ""
                echo ""
                echo "Report duplicate claims"
                Remove-Item r712.txt *> $null
                &$env:QUIZ r712
                echo ""
                Get-ChildItem -Force r712.txt
#               lp r712.txt
                echo ""
                echo ""
                echo "Extract batch`'s Patient data"
                Remove-Item submit_disk_pat_in.sf* *> $null
                &$env:QUIZ r702
                echo ""
                echo "Extracted patient data file:"
                Get-ChildItem -Force submit_disk_pat_in.sf*
                Write-Host -NoNewline  "Continue ? "
                $garbage = Read-Host
                echo ""
                echo "Now run newu701_2"
                }
        }
}
echo ""
echo ""
Write-Host -NoNewline  "Continue ? "
$garbage = Read-Host
echo ""
echo ""

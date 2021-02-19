#-------------------------------------------------------------------------------
# File 'u701_CANBDEL.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u701_CANBDEL'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#   NAME: u701
# 
#   PURPOSE: OHIP DISKETTE INPUT INTO RMA SYSTEM
#            THIS MACRO WILL TAKE A FILE FOR A SPECIFIED DOCTOR
#                 AND MOVE ALL CLAIMS INTO THE SUSPENSE FILES, APPLY
#                 THE PATIENTS WITHIN BATCH AGAINST THE PATIENT/SUBSCRIBER
#                 MASTERS, AND FINALLY UPDATE THE SUSPENSE RECORDS WITH THE
#                 ID'S OF THE PATIENTS.
#
#   MODIFICATION HISTORY
#      DATE   PERSON        DESCRIPTION (PDR/SMS #)
#   90/jul/01 B. ELLIOTT    - ORIGINAL
#   90/oct/31 Y. BOCCIA     - ADD QPRINT R707.TXt
#   98/Jan/21 KEVIN MILES   - CONVERTED TO UNIX
#   98/Aug/11 B. E.         - incoming file is variable length and must be
#                             converted to fixed length records. Added
#                             pad_to_240_bytes.awk command


if ("$1" -eq "")
{
        echo "`a"
        echo ""
        echo "**ERROR**"
        echo "You must supply the 6 digit doctor ohip number for the batch to be processed!"
        echo ""
        echo "Valid format:   u701  bx999999"
        exit
} else {
        if (-not(Test-Path f002_submit_disk_${1}.in ))
        {
                echo "`a"
                echo ""
                echo "**ERROR** No such batch found!"
                echo ""
                exit
        } else {
                if (Test-Path submit_disk_susp.in)
                {
                  echo "`a"
                  echo ""
                  echo ""
                  echo "**ERROR** Unprocessed suspense batch found !"
                  echo "You must manually re-process the batch submit_disk_susp.in"
                  echo "before re-running u701"
                  echo ""
                  exit
                } else {
#                 (incoming file is variable length - pad to 240 bytes)
#                 mv f002_submit_disk_${1}.in submit_disk_susp.in
                  Remove-Item submit_disk_susp.var *> $null
                  Move-Item -Force f002_submit_disk_${1}.in submit_disk_susp.var
Get-Content submit_disk_susp.var |                  awk++ $env:cmd\pad_to_240_bytes.awk > submit_disk_susp.in
                  echo ""
                  echo ""
                  echo "place claims into suspense files ..."
                  &$env:COBOL u701
                  echo ""
                  echo "print status report ..."
                  Get-ChildItem -Force ru701
#                 lp ru701
# CONVERSION ERROR (unexpected, #62): Unsupported parameters: [redir:1/false, id:/usr/tmp/ru701_cycle.tmp]
#                   cat  >/dev/null  2>/dev/null ru701_cycle ru701 >/usr/tmp/ru701_cycle.tmp  
                  Move-Item -Force $Env:root\usr\tmp\ru701_cycle.tmp ru701_cycle
                  Write-Host -NoNewline  "Continue? "
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
#                 lp r715.txt 
                  echo ""
                  echo ""
                  echo "Select special oma codes"
                  &$env:QTP u710
                  echo ""
                  echo "report selected special oma codes"
                  Remove-Item r711.txt *> $null
                  &$env:QUIZ r711
                  echo ""
                  Get-ChildItem -Force r711.txt
#                 lp      r711.txt
                  echo ""
                  echo ""
                  echo "report duplicate claims"
                  Remove-Item r712.txt *> $null
                  &$env:QUIZ r712
                  echo ""
                  Get-ChildItem -Force r712.txt
#                 lp      r712.txt
                  echo ""
                  echo ""
                  echo "extract batch`'s Patient data"
                  Remove-Item submit_disk_pat_in.sf* *> $null
                  &$env:QUIZ r702
                  echo ""
                  echo "extracted patient data file:"
                  Get-ChildItem -Force submit_disk_pat_in.sf*
                  Write-Host -NoNewline  "Continue? "
                  $garbage = Read-Host
                  echo ""
                  echo ""
                  echo "Process batch`'s Patient data against RMA`'s patient\subscriber database"
                  echo ""
                  Remove-Item submit_disk_pat_out *> $null
                  &$env:COBOL u703
                  Get-ChildItem -Force ru703*
#                 lp ru703a
#                 lp ru703c
                  Write-Host -NoNewline  "Continue? "
                  $garbage = Read-Host
                  echo ""
                  echo "processed patient data:"
                  Get-ChildItem -Force submit_disk_pat_out
                  echo ""
                  echo ""
                  echo "Apply processed patients against suspense files"
                  echo ""
                  &$env:QTP u704
                  echo ""
                  Remove-Item r707.txt *> $null
                  &$env:QUIZ r707
#                 lp r707.txt
                  Write-Host -NoNewline  "Continue? "
                  $garbage = Read-Host
                  echo ""
                  &$env:QTP u705
                  echo ""
                  echo "Cleanup: rename input file as successfully processed"
                  Move-Item -Force submit_disk_susp.in submit_disk_${1}.out
                  Get-Content ru703c.txt | Out-Printer *> $null
                }
        }
}
echo ""
echo ""
Write-Host -NoNewline  "Continue? "
$garbage = Read-Host
echo ""
echo ""

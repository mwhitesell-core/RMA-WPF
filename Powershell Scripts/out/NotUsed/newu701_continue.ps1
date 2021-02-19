#-------------------------------------------------------------------------------
# File 'newu701_continue.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701_continue'
#-------------------------------------------------------------------------------

param(
  [string] $1
)


                Get-Content ru701_cycle, ru701 | Set-Content newu701.tmp
                Move-Item -Force newu701.tmp ru701_cycle
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                echo ""
                                &$env:cmd\check_for_resubmits

                echo ""
                echo ""
                echo ""
                echo "Report duplicate claims"
                Remove-Item r712.txt *> $null

                &$env:QUIZ r712
                echo ""
                Get-ChildItem -Force r712.txt *> $null
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
# CONVERSION ERROR (expected, #35): Line was useless (error and output sent to /dev/null, exit code not checked).
#                 ls -laF ru703[a-z0-9] 1>/dev/null 2>&1
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
                echo "Continue ? "
                $garbage = Read-Host
                echo ""
                &$env:QTP u705
                echo ""
                echo "cleanup: rename input file as successfully processed"
                Move-Item -Force submit_disk_susp.in submit_disk_${1}.out
                Move-Item -Force submit_disk_desc.in submit_desc_${1}.out *> $null
                echo "running r710 to highlight claims with Percentage add-ons"
                echo "    that will likely need pricing attention..."
                &$env:QUIZ r710

                &$env:QUIZ ru701_acr

                echo " temporary run to ignore agent 6 claims ... "
                &$env:QTP temp_ignore_agent6_susp_hdr

Get-Content ru701 | Select-String -Pattern "INVALID CLINIC NBR FOR THE DOCTOR"


echo ""
echo ""
echo "Continue ? "
$garbage = Read-Host
echo ""
echo ""

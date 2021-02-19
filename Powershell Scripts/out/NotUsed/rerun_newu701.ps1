#-------------------------------------------------------------------------------
# File 'rerun_newu701.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_newu701'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

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
# CONVERSION ERROR (expected, #16): Line was useless (error and output sent to /dev/null, exit code not checked).
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
                Get-Content r710.txt | Out-Printer
                }
        }
}
echo ""
echo ""
echo "Continue ? "
$garbage = Read-Host
echo ""
echo ""

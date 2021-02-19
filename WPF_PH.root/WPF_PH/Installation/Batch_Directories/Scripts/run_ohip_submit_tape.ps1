#-------------------------------------------------------------------------------
# File 'run_ohip_submit_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_submit_tape'
#-------------------------------------------------------------------------------

# run_ohip_submit_tape

# 98/Jun/29 B.E. - added 2>/dev/null to #lp statements
# 99/feb/08 B.E. - added logic to create 2nd ohip tape file in y2k V03  format
# 99/feb/12 B.E. - change call to quiz for r085/6/7 pgms 
# 99/feb/22 B.E. - fixed problem with file naming of y2k file
# 99/may/18 B.E. - changed so that y2k version of code is 'normal' file
#
param(
	[string]$1
     )
echo "Runningrun_ohip_submit_tape ..."

# backup_ohip_tape


&$env:cmd\run_ohip_submit_tape_no_directs  ${1}

echo "U035 IN PROGRESS $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd= $env:QTP + "u035a"
Invoke-Expression $rcmd
#quiz auto=$obj/r035b.qzc
$rcmd= $env:QUIZ + "r035b DISC_r035b.ff 1"
Invoke-Expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r035b.txt | Out-File -FilePath r035b1.txt -Encoding ASCII

$rcmd= $env:QUIZ + "r035b DISC_r035b.ff 2"
Invoke-Expression $rcmd

#Core - Added to save file with ansi encoding
Get-Content r035b.txt | Out-File -FilePath r035b2.txt -Encoding ASCII

$rcmd=$env:QTP +"u035c"
Invoke-Expression $rcmd


echo "U035 ENDING $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
Get-Date
echo ""
echo "Donerun_ohip_submit_tape"

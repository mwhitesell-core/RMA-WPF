#-------------------------------------------------------------------------------
# File 'u021.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021'
#-------------------------------------------------------------------------------

# purpose: create macro to process all files thru the u021 processing
# 2006/aug/17 M.C. - include new report r021a.txt
# 2013/jan/08 MC1  - include report r021bb.txt r021bc.txt r021c.txt to the u021_logs subfolder
# 2014/Mar/06 BE1  - change the line for calling u021.awk to pass the fixed timestamp            
#param(
#    [string]$wildcard
#    )

$wildcard = "E*"
echo "recreate the empty temporary scratch file tmp-serv-err-claim"

<#$pipedInput = @"
create file tmp-serv-err-claim
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+"tmp_serv_err_claim"
Invoke-Expression $rcmd

$files = Get-ChildItem $wildcard | Select-Object -ExpandProperty Name

Remove-Item u021_ph.log, u021_cb.log *> $null
"#!$Env:root\bin\ksh" | Set-Content u021.tmp.com.ps1
"# this batch file auto-created by u021.com\u021.awk" | Add-Content u021.tmp.com.ps1
" " | Add-Content u021.tmp.com.ps1

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H_%M`")"

Remove-Item u021a_edt_1ht_file.dat *> $null
Remove-Item u021a_edt_rmb_file.dat *> $null
Remove-Item r021*.txt *> $null

foreach ($fname in $files)
{
  $dy_time = Get-Date -uformat %T
  echo "$dy_time $env:RMABILL_VERS Building macro for Error file .. $fname"
# BE1
#  awk -v timeStamp=20`date +%y_%m_%d.%H:%M` -f $cmd/u021.awk $fname < $fname 
#  awk -v $timeStamp -f $cmd/u021.awk $fname < $fname 
# CONVERSION ERROR (unexpected, #32): Unknown command.
#    awk -v timeStamp=$timeStamp -f $cmd/u021.awk $fname < $fname
  &$env:cmd/u021.awk $fname $timeStamp
}

Get-Content u021.tmp.com.ps1, $env:cmd\u021_last.ps1 | Set-Content u021.tmp.com2.ps1
Move-Item -Force u021.tmp.com2.ps1 u021.tmp.com.ps1
# CONVERSION ERROR (unexpected, #37): Unsupported chmod 'x'.
# chmod +x         u021.tmp.com

echo ""
echo "Now running u021.tmp.com - VERIFY results in:  u021.log.$timeStamp.done"
echo ""
#echo "hit enter to continue"
#read garbage

New-Item -ItemType directory -Path u021_logs/$timeStamp
# CONVERSION ERROR (unexpected, #46): Unknown command.
.\u021.tmp.com.ps1 >  u021_cb.log

echo "backup of reports generated"
Copy-Item r021a.txt u021_logs\$timeStamp
Copy-Item r021b.txt u021_logs\$timeStamp
Copy-Item r021ba.txt u021_logs\$timeStamp
# MC1
Copy-Item r021bb.txt u021_logs\$timeStamp
Copy-Item r021bc.txt u021_logs\$timeStamp
Copy-Item r021c.txt u021_logs\$timeStamp
echo "print reports generated"
#lpc r021*.txt

# save run commands as backup
#mv u021.tmp.com u021_logs/u021.$timeStamp.done
#mv u021.log     u021_logs/u021.log.$timeStamp.done
Move-Item -Force u021.tmp.com.ps1 u021_logs\$timeStamp\u021.done
Get-Content u021_cb.log, u021_ph.log | Set-Content u021.log
Move-Item -Force u021.log u021_logs\$timeStamp\u021.log.done
echo ""
echo "Done!"

#-------------------------------------------------------------------------------
# File 'u021_brad.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021_brad'
#-------------------------------------------------------------------------------

# purpose: create macro to process all files thru the u021 processing
# 2006/aug/17 M.C. - include new report r021a.txt
# 2013/jan/08 MC1  - include report r021bb.txt r021bc.txt r021c.txt to the u021_logs subfolder


echo "recreate the empty temporary scratch file tmp-serv-err-claim"

$pipedInput = @"
create file tmp-serv-err-claim
"@

$pipedInput | qutil++


Remove-Item u021_ph.log, u021_cb.log *> $null
echo "#!$Env:root\bin\ksh" > u021.tmp.com
echo "# this batch file auto-created by u021.com\u021.awk" >> u021.tmp.com
echo " " >> u021.tmp.com

&$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H:%M`")"

Remove-Item u021a_edt_1ht_file.dat *> $null
Remove-Item u021a_edt_rmb_file.dat *> $null
Remove-Item r021*.txt *> $null

foreach ($fname in $args)
{
  &$env:root\macros\dy_time "Building macro for Error file .. $fname"
#  awk -v timeStamp=20`date +%y_%m_%d.%H:%M` -f $cmd/u021.awk $fname < $fname 
Get-Content $fname |echo "awk -v timeStamp=$timeStamp -f $env:cmd\u021.awk $fname"
}

#-------------------------------------------------------------------------------
# File 'u021_old.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021_old'
#-------------------------------------------------------------------------------

# pupose: create macro to process all files specified thru u031 and u021 pgms

Remove-Item u021.log, u031.log *> $null
echo "#!$Env:root\bin\ksh" > u021.tmp.com
echo "# this batch file auto-created by u021.com\u021.awk" >> u021.tmp.com
echo " " >> u021.tmp.com

&$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H:%M`")"


foreach ($fname in $args)
{
  &$env:root\macros\dy_time "Building macro for Error file .. $fname"
# CONVERSION ERROR (unexpected, #15): Unknown command.
#   awk -v timeStamp=20`date +%y_%m_%d.%H:%M` -f $cmd/u021.awk $fname < $fname 
}
# CONVERSION ERROR (unexpected, #17): Unsupported chmod 'x'.
# chmod +x u021.tmp.com

echo ""
echo "Now running u021.tmp.com - VERIFY results in:  u021.log.$timeStamp.done"
echo ""
#echo "hit enter to continue"
#read garbage

New-Item -ItemType directory -Path u021_logs/$timeStamp
Remove-Item r031*.lp
# CONVERSION ERROR (unexpected, #27): Unknown command.
# ./u021.tmp.com >  u021.log
Get-Content u031.log | Add-Content u021.log
Remove-Item u031.log

#lpc r031*.lp 

# save run commands as backup
#mv u021.tmp.com u021_logs/u021.$timeStamp.done
#mv u021.log     u021_logs/u021.log.$timeStamp.done
Move-Item -Force u021.tmp.com u021_logs\$timeStamp\u021.done
Move-Item -Force u021.log u021_logs\$timeStamp\u021.log.done
echo ""
echo "Done!"

#-------------------------------------------------------------------------------
# File 'batch_copy_bank_info_out_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_copy_bank_info_out_bk1'
#-------------------------------------------------------------------------------

# batch_copy_bank_info_out
# copies doctor banking info, passed from online pgm to /temp/transferarea
# from which is can be imported in from another system

#datestampe incorporates userid passed in parm#1 and current date
# parm 1 = user logon id
# parm 2 = type of info being passed (eg. "payroll")
# parm 3.. dependent upon type of info being passed

$user = "$1"
$infotype = "$2"

&$datestamp=$(Get-Date -uformat "%y%m%d_%H%M%S") + "_" + $user + "_" + $infotype
# write audit record
echo "$3" > $Env:root\temp\transfer_area\rmabill\$infotype.$datestamp

#echo $* >> /temp/transfer_area/rmabill/transfer.dat
# write out the first 3 parms which are required and then loop shifting
# parameters past 3 into the 3rd position until all parms have been processed
#  
echo "$*" > $Env:root\temp\transfer_area\rmabill\brad
echo "$1" > $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$2" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$3" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$4" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$5" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$6" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$7" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$8" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
echo "$9" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
# CONVERSION ERROR (unexpected, #31): Unknown command.
# shift
# CONVERSION ERROR (unexpected, #32): Unknown command.
# while [ "$9" ]
{
  echo "`" $9 `"" >> $Env:root\temp\transfer_area\rmabill\transfer.dat
# CONVERSION ERROR (unexpected, #35): Unknown command.
#   shift
}

# convert the transfer file from variable length to fixed 80 byte records
Move-Item -Force $Env:root\temp\transfer_area\rmabill\transfer.dat $Env:root\temp\transfer_area\rmabill\transfer.tmp
# CONVERSION ERROR (expected, #41): awk.
# awk -f $cmd/pad_to_80_bytes.awk < /temp/transfer_area/rmabill/transfer.tmp \                                > /temp/transfer_area/rmabill/transfer.dat 
Remove-Item $Env:root\temp\transfer_area\rmabill\transfer.tmp

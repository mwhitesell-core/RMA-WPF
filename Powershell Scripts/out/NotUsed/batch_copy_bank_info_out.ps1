# batch_copy_bank_info_out
# copies doctor banking info, passed from online pgm to /temp/transferarea
# from which is can be imported in from another system

#datestampe incorporates userid passed in parm#1 and current date
# parm 1 = user logon id
# parm 2 = type of info being passed (eg. "payroll")
# parm 3.. dependent upon type of info being passed

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4,
  [string] $5,
  [string] $6,
  [string] $7,
  [string] $8,
  [string] $9,
  [string] $10,
  [string] $11,
  [string] $12,
  [string] $13,
  [string] $14,
  [string] $15,
  [string] $16,
  [string] $17,
  [string] $18,
  [string] $19,
  [string] $20,
  [string] $21,
  [string] $22,
  [string] $23,
  [string] $24
)

$user=$1
$infotype=$2 

#$datestamp=`date +%y%m%d_%H%M%S`_$user_$infotype
# write audit record

$transfer_area = $env:transfer_area
If(!(Test-Path $transfer_area))
{
    New-Item -ItemType Directory -Force -Path $transfer_area
}

Remove-Item $transfer_area\brad.dat*
Remove-Item $transfer_area\transfer.dat*

#echo $3 > /temp/transfer_area/rmabill/$infotype.$datestamp

#echo $* >> /temp/transfer_area/rmabill/transfer.dat
# write out the first 3 parms which are required and then loop shifting
# parameters past 3 into the 3rd position until all parms have been processed
# 
echo $* >>  $transfer_area\brad.dat
echo $1 >>  $transfer_area\transfer.dat
echo $2 >> $transfer_area\transfer.dat
echo $3 >> $transfer_area\transfer.dat
echo $4 >> $transfer_area\transfer.dat
echo $5 >> $transfer_area\transfer.dat
echo $6 >> $transfer_area\transfer.dat
echo $7 >> $transfer_area\transfer.dat
echo $8 >> $transfer_area\transfer.dat
echo $9 >> $transfer_area\transfer.dat
echo $10 >>  $transfer_area\transfer.dat
echo $11 >>  $transfer_area\transfer.dat
echo $12 >>  $transfer_area\transfer.dat
echo $13 >>  $transfer_area\transfer.dat
echo $14 >>  $transfer_area\transfer.dat
echo $15 >>  $transfer_area\transfer.dat
echo $16 >>  $transfer_area\transfer.dat
echo $17 >>  $transfer_area\transfer.dat
echo $18 >>  $transfer_area\transfer.dat
echo $19 >>  $transfer_area\transfer.dat
echo $20 >>  $transfer_area\transfer.dat
echo $21 >>  $transfer_area\transfer.dat
echo $22 >>  $transfer_area\transfer.dat
echo $23 >>  $transfer_area\transfer.dat
echo $24 >>  $transfer_area\transfer.dat

# convert the transfer file from variable length to fixed 80 byte records
#mv /temp/transfer_area/rmabill/transfer.dat \
#   /temp/transfer_area/rmabill/transfer.tmp
#awk -f $cmd/pad_to_80_bytes.awk < /temp/transfer_area/rmabill/transfer.tmp \
#                                > /temp/transfer_area/rmabill/transfer.dat 
#rm /temp/transfer_area/rmabill/transfer.tmp

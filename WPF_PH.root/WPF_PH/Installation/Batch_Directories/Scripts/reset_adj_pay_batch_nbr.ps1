#-------------------------------------------------------------------------------
# File 'reset_adj_pay_batch_nbr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reset_adj_pay_batch_nbr'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

##  $cmd/reset_adj_pay_batch_nbr           
##  this macro should be run at yearend to reset batch nbr for adjustment and payment  

$rcmd = $env:QTP + "u090 ${1}" 
Invoke-Expression $rcmd > u090.log

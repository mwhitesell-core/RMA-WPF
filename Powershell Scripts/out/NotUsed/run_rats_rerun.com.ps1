#-------------------------------------------------------------------------------
# File 'run_rats_rerun.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_rats_rerun.com'
#-------------------------------------------------------------------------------

###
###  clinic 22 to 33 requires rerun due to errors        
###  clinic 34 to 96 have been run successfully after recompile of u030b_part2.qts
###  Require to run the remaining macros after clinic 33  

Get-Date

&$env:cmd\application_of_rat_22_part1

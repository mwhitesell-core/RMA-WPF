#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_old.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_mstr_verify_old'
#-------------------------------------------------------------------------------

echo "CLAIMS_MSTR_VERIFY_OLD"
echo ""

echo "A\R FILE PURGE STAGE" # 3
echo ""
#echo  HIT "NEWLINE" TO VERIFY 'OLD' CLAIMS MSTR
# read garbage
echo ""
echo "PROGRAMR071 NOW LOADING ..."

### comment out the r071 if it is run after batch control purge
###    since it is run after batch control purge and cp r071_after
###    from batch adj purge to be r071_before_claims_purge 

Set-Location \\$Env:root\charly\purge

##  2012/01/23 - if claim purge at yearend time, the following section can be commented out
##------------------------

$rcmd = $env:COBOL + "r001"
Invoke-Expression $rcmd

##  create records in f002 shadow for the current cycle claims with agent 4 or 6
##  so that it should balance between rv071 & r071

$rcmd = $env:QTP  + "u020_shdw" > u020_shdw.log
Invoke-Expression $rcmd

##-----------------------

####cp r071_after r071_before_claims_purge 

$rcmd= $env:COBOL + "r071 20150630 Y"
Invoke-Expression $rcmd

# CONVERSION ERROR (expected, #37): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv071_before

echo ""
Get-ChildItem -Force r071
echo ""
Get-Date

Move-Item -Force r071 r071_before_claims_purge
Get-Content r071_before_claims_purge | Out-Printer
Get-Content rv071_before | Out-Printer

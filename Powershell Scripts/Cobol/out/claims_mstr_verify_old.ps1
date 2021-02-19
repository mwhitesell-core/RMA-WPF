#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_old.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $root\charly\purge

##  2012/01/23 - if claim purge at yearend time, the following section can be commented out
##------------------------

cobrun++ $obj\r001

##  create records in f002 shadow for the current cycle claims with agent 4 or 6
##  so that it should balance between rv071 & r071

qtp++ $obj\u020_shdw  > u020_shdw.log

##-----------------------

####cp r071_after r071_before_claims_purge 

$pipedInput = @"
20150630
Y
"@

$pipedInput | cobrun++ $obj\r071


bcheck++ $pb_data\f002_claim_shadow  > rv071_before

echo ""
Get-ChildItem -Force r071
echo ""
Get-Date

Move-Item r071 r071_before_claims_purge
Get-Contents r071_before_claims_purge| Out-Printer
Get-Contents rv071_before| Out-Printer

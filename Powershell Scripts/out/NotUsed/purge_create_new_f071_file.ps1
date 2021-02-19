#-------------------------------------------------------------------------------
# File 'purge_create_new_f071_file.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_create_new_f071_file'
#-------------------------------------------------------------------------------

echo "CREATE_NEW_f071_FILE"
#  modification history
#  2002/nov/14 M.C. - original         
#  2005/jul/06 M.C. - changed to move f071 orig file  and processing of subifle
#                     on /charly/purge disk
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge

echo ""
echo ""
Get-Date
echo ""
echo "NOTE !!"
echo "NO ONE MUST BE ACCESSING THE  F071  FILE !!!"
echo ""
echo "HIT  `"NEWLINE``"  TO COMMENCE PROCEDURE ..."
 $garbage = Read-Host
echo ""
echo "RECREATING THE F071  FILE `"F071_CLIENT_RMA_CLAIM_NBR``" ..."
echo ""

##cd $pb_prod
Set-Location $Env:root\charly\purge

echo ""
echo "PROGRAM `"u071``" NOW LOADING ..."
echo ""

&$env:QTP u071

Set-Location $pb_data

Move-Item -Force f071_client_rma_claim_nbr $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig
Move-Item -Force f071_client_rma_claim_nbr.idx $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig.idx

Remove-Item f071_client_rma_claim_nbr.dat

. .\createfiles.com


##cd $pb_prod
Set-Location $Env:root\charly\purge



echo ""
echo "PROGRAM `"u071a``" NOW LOADING ..."
echo ""

&$env:QTP u071a

echo ""
Get-Date
echo ""

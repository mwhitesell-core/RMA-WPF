#-------------------------------------------------------------------------------
# File 'cleandir.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleandir'
#-------------------------------------------------------------------------------

Get-Date
echo "********************************************************************"
echo "TO CLEAN OFF U020_TAPEOUT_FILE AND U02+SF+ FILES AND REPORTS"
echo "THIS WILL DELETE ALL THE REPORTS INCLUDING RU020MR AND RU022MR"
echo "AND OHIP TAPE MAKE SURE ALL THE EXTRA COPPIES ARE PRINTED AND"
echo "COPY_MAG_TAPE IS CREATED"
echo "********************************************************************"

echo "HIT `"NEWLINE`"  OHIP REPORTS AND TAPE"
 $garbage = Read-Host

Set-Location $env:application_production
Remove-Item u020_tapeout_file* *> $null
Remove-Item u02*sf* *> $null
Remove-Item r001b *> $null
Remove-Item r002aa *> $null
Remove-Item r002ab *> $null
Remove-Item r004_c *> $null
Remove-Item r014 *> $null
Remove-Item ru022 *> $null
Remove-Item ru022a* *> $null
Remove-Item ru022b* *> $null
Remove-Item ru022_sd *> $null
Remove-Item ru022a_sd *> $null
Remove-Item ru022b_sd *> $null
Remove-Item ru020a* *> $null
Remove-Item ru020b* *> $null
Remove-Item ru020c* *> $null
Remove-Item ru022c* *> $null
Remove-Item ru022c_sd *> $null
Remove-Item r010 *> $null
Remove-Item ru020mr* *> $null
Remove-Item ru022mr* *> $null
Remove-Item u020*.sf* *> $null
Remove-Item u022*.sf* *> $null
Remove-Item sd_u022*.sf* *> $null
Remove-Item u035* *> $null
Remove-Item r085c.txt *> $null

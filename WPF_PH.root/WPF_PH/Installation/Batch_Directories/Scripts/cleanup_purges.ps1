#-------------------------------------------------------------------------------
# File 'cleanup_purges.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_purges'
#-------------------------------------------------------------------------------

echo "********************************************************************"
echo ""
echo "THIS PROGRAM WILL DELETE ALL THE PURGE REPORTS"
echo "MAKE SURE ALL THE REPORS ARE PRINTED AND BALANCED"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
 $garbage = Read-Host

Remove-Item r001b_before_r093 *> $null
Remove-Item r001b_after_r093 *> $null
Remove-Item r001b_before_r095 *> $null
Remove-Item r001b_after_r095 *> $null
Remove-Item r093_22 *> $null
Remove-Item r093_60 *> $null
Remove-Item r093_80 *> $null
Remove-Item r093_81 *> $null
Remove-Item r093_82 *> $null
Remove-Item r093_83 *> $null
Remove-Item r095_22 *> $null
Remove-Item r095_60 *> $null
Remove-Item r095_80 *> $null
Remove-Item r095_81 *> $null
Remove-Item r095_82 *> $null
Remove-Item r095_83 *> $null
Remove-Item r071_before *> $null
Remove-Item r071_after *> $null
Remove-Item iverify_f010.ls *> $null
Remove-Item iverify_f010_before.ls *> $null
Remove-Item iverify_f010_after.ls *> $null
Remove-Item ru099 *> $null
Remove-Item ru080 *> $null
Remove-Item r071 *> $null
Remove-Item ru072 *> $null
Remove-Item r073 *> $null
Remove-Item rv071 *> $null
Remove-Item rv073 *> $null
Remove-Item u920.ls *> $null

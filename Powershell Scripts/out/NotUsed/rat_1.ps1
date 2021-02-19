#-------------------------------------------------------------------------------
# File 'rat_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_1'
#-------------------------------------------------------------------------------

echo "APPLICATION_OF_RAT_22"
echo ""
echo "**   application of OHIP remittance advice tape   ** without backup"
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "If this is the 1st processing of this rat tape"
echo "then convert_rat_to_ascii must be run to convert"
echo "the disk file fromEBCDIC toASCII"
echo ""
echo "If file has been converted once then  hit   `"NEWLINE`"   to continue ..."
$garbage = Read-Host
Set-Location $application_upl
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "Doctor revenue file and claims master will be updated by this run"
echo ""
echo "A doctor revenue backup should have already been run --before-- this update ..."


echo "HitNEWLINE   to initiate update program ..."
$garbage = Read-Host
echo ""
echo "programU030 now loading ..."

Remove-Item u030.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "rat_1" -InitializationScript $init -ScriptBlock {
  & $env:cmd\u030 *> u030.ls
}

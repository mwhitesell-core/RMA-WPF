#-------------------------------------------------------------------------------
# File 'copy_u030_rec_8.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_u030_rec_8'
#-------------------------------------------------------------------------------

# macro: copy_u030_rec_8  
# 09/Apr/07 M.C. copy all u030-tape-8-file from each clinic directory into 101/production/clinic  


Set-Location $env:application_production
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\u030_tape_8_file.dat

Set-Location $env:application_production\31
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\31\u030_tape_8_file.dat

Set-Location $env:application_production\32
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\32\u030_tape_8_file.dat

Set-Location $env:application_production\33
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\33\u030_tape_8_file.dat

Set-Location $env:application_production\34
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\34\u030_tape_8_file.dat

Set-Location $env:application_production\35
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\35\u030_tape_8_file.dat

Set-Location $env:application_production\36
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\36\u030_tape_8_file.dat

Set-Location $env:application_production\37
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\37\u030_tape_8_file.dat

Set-Location $env:application_production\41
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\41\u030_tape_8_file.dat

Set-Location $env:application_production\42
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\42\u030_tape_8_file.dat

Set-Location $env:application_production\43
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\43\u030_tape_8_file.dat

Set-Location $env:application_production\44
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\44\u030_tape_8_file.dat

Set-Location $env:application_production\45
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\45\u030_tape_8_file.dat

Set-Location $env:application_production\46
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\46\u030_tape_8_file.dat

Set-Location $env:application_production\61
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\61\u030_tape_8_file.dat

Set-Location $env:application_production\62
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\62\u030_tape_8_file.dat

Set-Location $env:application_production\63
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\63\u030_tape_8_file.dat

Set-Location $env:application_production\64
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\64\u030_tape_8_file.dat

Set-Location $env:application_production\65
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\65\u030_tape_8_file.dat

Set-Location $env:application_production\71
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\71\u030_tape_8_file.dat

Set-Location $env:application_production\72
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\72\u030_tape_8_file.dat

Set-Location $env:application_production\73
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\73\u030_tape_8_file.dat

Set-Location $env:application_production\74
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\74\u030_tape_8_file.dat

Set-Location $env:application_production\75
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\75\u030_tape_8_file.dat

Set-Location $env:application_production\84
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\84\u030_tape_8_file.dat

Set-Location $env:application_production\96
Copy-Item u030_tape_8_file.dat $Env:root\alpha\rmabill\rmabill101\production\96\u030_tape_8_file.dat

echo ""
echo "end of the run"
echo ""
Get-Date

#-------------------------------------------------------------------------------
# File 'rerun_r153.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r153'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# MC3
echo "--- cobol program r153 ---"
&$env:COBOL r153
Remove-Item r153*_${1}.txt *> $null
Move-Item -Force r153a r153a_${1}.txt
Move-Item -Force r153b r153b_${1}.txt
Move-Item -Force r153c r153c_${1}.txt
# MC3 - end

}

# MC1 - end

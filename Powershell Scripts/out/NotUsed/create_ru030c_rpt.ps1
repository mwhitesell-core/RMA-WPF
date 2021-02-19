#-------------------------------------------------------------------------------
# File 'create_ru030c_rpt.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_ru030c_rpt'
#-------------------------------------------------------------------------------


# 2016/Feb/01 - $cmd/create_ru030c_rpt                   

echo ""
echo "start of the run for create_ru030c_rpt"
echo ""
Get-Date


Remove-Item ru030c.txt *> $null
&$env:QUIZ r030f


echo ""
echo "end of the run for create_ru030c_rpt"
echo ""
Get-Date

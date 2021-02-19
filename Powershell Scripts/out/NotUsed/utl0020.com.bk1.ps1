#-------------------------------------------------------------------------------
# File 'utl0020.com.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0020.com.bk1'
#-------------------------------------------------------------------------------

# program: utl0020.com
# 2003/sep/28 B.E.  original

clear
echo "utl0020 - Creating PC download file of doctor information"
echo ""
#printf "Hit ENTER to continue ..."
#read  garbage

echo "program starting at:  $time"
echo ""
echo "Re-creating empty tmp download file ... $time"
$pipedInput = @"
create file tmp-pc-download-file
"@

$pipedInput | qutil++
echo ""
echo ""

echo "Delete any old files if found .."
Remove-Item utl0020_??.ps
Remove-Item utl0020_??.psd
Remove-Item utl0020_??.txt
echo ""


echo ""
echo "running utl0020a_1  $Env:root\  _2.qtc  $Env:root\ _3.qtc  ...  $time"
&$env:QTP utl0020a_1
&$env:QTP utl0020a_2
&$env:QTP utl0020a_3

echo ""
echo "running utl0020b.qtc ...  $time"
&$env:QTP utl0020b

echo "running utl0020c.qzs ...  $time"
#quiz auto=$obj/utl0020c.qzu
&$env:QUIZ utl0020c
Move-Item -Force utl0020c_1.qts.txt utl0020c_1.qts
Move-Item -Force utl0020c_2.qts.txt utl0020c_2.qts
&$env:QTP utl0020c_1
&$env:QTP utl0020c_2
&$env:QTP utl0020c_1
&$env:QTP utl0020c_2

echo ""
echo "running utl0020d.qzc ...  $time"
&$env:QUIZ utl0020d
Move-Item -Force utl0020_00.txt utl0020_00.ps

&$env:cmd\delete_empty_file.com utl0020_01.ps
&$env:cmd\delete_empty_file.com utl0020_02.ps
&$env:cmd\delete_empty_file.com utl0020_03.ps
&$env:cmd\delete_empty_file.com utl0020_04.ps
&$env:cmd\delete_empty_file.com utl0020_05.ps
&$env:cmd\delete_empty_file.com utl0020_06.ps
&$env:cmd\delete_empty_file.com utl0020_07.ps
&$env:cmd\delete_empty_file.com utl0020_08.ps
&$env:cmd\delete_empty_file.com utl0020_09.ps
&$env:cmd\delete_empty_file.com utl0020_10.ps
&$env:cmd\delete_empty_file.com utl0020_11.ps
&$env:cmd\delete_empty_file.com utl0020_12.ps
&$env:cmd\delete_empty_file.com utl0020_13.ps
&$env:cmd\delete_empty_file.com utl0020_14.ps
&$env:cmd\delete_empty_file.com utl0020_15.ps
&$env:cmd\delete_empty_file.com utl0020_16.ps
&$env:cmd\delete_empty_file.com utl0020_17.ps
&$env:cmd\delete_empty_file.com utl0020_18.ps
&$env:cmd\delete_empty_file.com utl0020_19.ps
&$env:cmd\delete_empty_file.com utl0020_20.ps
&$env:cmd\delete_empty_file.com utl0020_21.ps
&$env:cmd\delete_empty_file.com utl0020_22.ps
&$env:cmd\delete_empty_file.com utl0020_23.ps
&$env:cmd\delete_empty_file.com utl0020_24.ps
&$env:cmd\delete_empty_file.com utl0020_25.ps
&$env:cmd\delete_empty_file.com utl0020_26.ps
&$env:cmd\delete_empty_file.com utl0020_27.ps
&$env:cmd\delete_empty_file.com utl0020_28.ps
&$env:cmd\delete_empty_file.com utl0020_29.ps
&$env:cmd\delete_empty_file.com utl0020_30.ps

&$env:cmd\delete_empty_file.com utl0020_33.ps

&$env:cmd\delete_empty_file.com utl0020_34.ps
&$env:cmd\delete_empty_file.com utl0020_35.ps
&$env:cmd\delete_empty_file.com utl0020_36.ps
&$env:cmd\delete_empty_file.com utl0020_37.ps
&$env:cmd\delete_empty_file.com utl0020_38.ps

&$env:cmd\delete_empty_file.com utl0020_70.ps
&$env:cmd\delete_empty_file.com utl0020_71.ps
&$env:cmd\delete_empty_file.com utl0020_72.ps
&$env:cmd\delete_empty_file.com utl0020_73.ps
&$env:cmd\delete_empty_file.com utl0020_74.ps
&$env:cmd\delete_empty_file.com utl0020_75.ps

echo ""
echo "Done!  $time"

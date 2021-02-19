#-------------------------------------------------------------------------------
# File 'utl0020.com.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0020.com.bk2'
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

echo "Removing last month's download files ... $time"
Remove-Item utl0020*.txt

echo ""
echo "running utl0020a.qtc ...  $time"
&$env:QTP utl0020a

echo ""
echo "running utl0020b.qtc ...  $time"
&$env:QTP utl0020b

echo "running utl0020c.qzu ...  $time"
&$env:QUIZ utl0020c

echo ""
echo "running utl0020d.qzc ...  $time"
&$env:QUIZ utl0020d

echo ""
echo "Done!  $time"

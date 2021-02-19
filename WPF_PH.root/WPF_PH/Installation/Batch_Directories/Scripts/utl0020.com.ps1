# program: utl0020.com
# 2003/sep/28 B.E.  original
# 2011/apr/26 added pgm utl0020c_3.qts.txt 
# 2014/sep/20 added delete of dept 53 subfile
# 2015/apr/21 added delete of dept 80 subfile

#clear
#echo "utl0020 - Creating download file of doctor information used to create Revenue Workbooks of ME"

#printf "Hit ENTER to continue ..."
#read  garbage

#echo "program starting at: " (Get-Time) 

#echo "Re-creating empty tmp download file ..." (Get-Date)
#qutil << qutil_EXIT
#create file tmp-pc-download-file
#qutil_EXIT



#echo Delete any old files if found ..


Remove-Item utl0020_*  -EA SilentlyContinue




#echo "running utl0020a_1  /  _2.qtc  / _3.qtc  ... " (Get-Date)

#$rcmd = $env:QTP + "utl0020a_1"
#invoke-expression $rcmd
#$rcmd = $env:QTP + "utl0020a_2"
#invoke-expression $rcmd
#$rcmd = $env:QTP + "utl0020a_3"
#invoke-expression $rcmd


#echo "running utl0020b.qtc ... " (Get-Date)

#$rcmd = $env:QTP + "utl0020b"
#invoke-expression $rcmd

#echo "running utl0020c.qzs ... " (Get-Date)

#$rcmd = $env:QUIZ + "utl0020c"
#invoke-expression $rcmd

#$rcmd = $env:QTP + "utl0020c_1"
#invoke-expression $rcmd
#$rcmd = $env:QTP + "utl0020c_2"
#invoke-expression $rcmd
#$rcmd = $env:QTP + "utl0020c_3"
#invoke-expression $rcmd


#$rcmd = $env:QTP + "utl0020c_2"
#invoke-expression $rcmd
#$rcmd = $env:QTP + "utl0020c_3"
#invoke-expression $rcmd


 
#echo "running utl0020d.qzc ... " (Get-Date)

#$rcmd = $env:QUIZ + "utl0020d"
#invoke-expression $rcmd

#mv utl0020_00.txt utl0020_00.ps

Remove-Item utl0020_01.ps  -EA SilentlyContinue
Remove-Item utl0020_02.ps  -EA SilentlyContinue
Remove-Item utl0020_03.ps  -EA SilentlyContinue
Remove-Item utl0020_04.ps  -EA SilentlyContinue
Remove-Item utl0020_05.ps  -EA SilentlyContinue
Remove-Item utl0020_06.ps  -EA SilentlyContinue
Remove-Item utl0020_07.ps  -EA SilentlyContinue
Remove-Item utl0020_08.ps  -EA SilentlyContinue
Remove-Item utl0020_09.ps  -EA SilentlyContinue
Remove-Item utl0020_10.ps  -EA SilentlyContinue
Remove-Item utl0020_11.ps  -EA SilentlyContinue
Remove-Item utl0020_12.ps  -EA SilentlyContinue
Remove-Item utl0020_13.ps  -EA SilentlyContinue
Remove-Item utl0020_14.ps  -EA SilentlyContinue
Remove-Item utl0020_15.ps  -EA SilentlyContinue
Remove-Item utl0020_16.ps  -EA SilentlyContinue
Remove-Item utl0020_17.ps  -EA SilentlyContinue
Remove-Item utl0020_18.ps  -EA SilentlyContinue
Remove-Item utl0020_19.ps  -EA SilentlyContinue
Remove-Item utl0020_20.ps  -EA SilentlyContinue
Remove-Item utl0020_21.ps  -EA SilentlyContinue
Remove-Item utl0020_22.ps  -EA SilentlyContinue
Remove-Item utl0020_23.ps  -EA SilentlyContinue
Remove-Item utl0020_24.ps  -EA SilentlyContinue
Remove-Item utl0020_25.ps  -EA SilentlyContinue
Remove-Item utl0020_26.ps  -EA SilentlyContinue
Remove-Item utl0020_27.ps  -EA SilentlyContinue
Remove-Item utl0020_28.ps  -EA SilentlyContinue
Remove-Item utl0020_29.ps  -EA SilentlyContinue
Remove-Item utl0020_30.ps  -EA SilentlyContinue

Remove-Item utl0020_33.ps  -EA SilentlyContinue

Remove-Item utl0020_34.ps  -EA SilentlyContinue
Remove-Item utl0020_35.ps  -EA SilentlyContinue
Remove-Item utl0020_36.ps  -EA SilentlyContinue
Remove-Item utl0020_37.ps  -EA SilentlyContinue
Remove-Item utl0020_38.ps  -EA SilentlyContinue

Remove-Item utl0020_51.ps  -EA SilentlyContinue
Remove-Item utl0020_53.ps  -EA SilentlyContinue

Remove-Item utl0020_70.ps  -EA SilentlyContinue
Remove-Item utl0020_71.ps  -EA SilentlyContinue
Remove-Item utl0020_72.ps  -EA SilentlyContinue
Remove-Item utl0020_73.ps  -EA SilentlyContinue
Remove-Item utl0020_74.ps  -EA SilentlyContinue
Remove-Item utl0020_75.ps  -EA SilentlyContinue
Remove-Item utl0020_76.ps  -EA SilentlyContinue
Remove-Item utl0020_79.ps  -EA SilentlyContinue

Remove-Item utl0020_80.ps  -EA SilentlyContinue

 
echo "Done! " (Get-Date)

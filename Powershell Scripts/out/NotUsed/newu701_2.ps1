#-------------------------------------------------------------------------------
# File 'newu701_2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'newu701_2'
#-------------------------------------------------------------------------------

Remove-Item submit?.sf*
Remove-Item submit??.sf*

&$env:QTP split_file
echo "Continue ?"
&$Garbage = Read-Host

Move-Item -Force submit1.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit1.sf

Move-Item -Force submit2.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit2.sf

Move-Item -Force submit3.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit3.sf

Move-Item -Force submit4.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit4.sf

Move-Item -Force submit5.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit5.sf

Move-Item -Force submit6.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit6.sf

Move-Item -Force submit7.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit7.sf

Move-Item -Force submit8.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit8.sf

Move-Item -Force submit9.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit9.sf

Move-Item -Force submit10.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit10.sf

Move-Item -Force submit11.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit11.sf

Move-Item -Force submit12.sf submit_disk_pat_in.sf
&$env:cmd\newu701_3
Move-Item -Force submit_disk_pat_in.sf submit12.sf

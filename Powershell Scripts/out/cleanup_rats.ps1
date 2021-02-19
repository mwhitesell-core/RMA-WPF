#-------------------------------------------------------------------------------
# File 'cleanup_rats.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'cleanup_rats'
#-------------------------------------------------------------------------------

Get-Date
&$env:cmd\cleanup_rat_files
&$env:cmd\cleanup_rat_files_23
&$env:cmd\cleanup_rat_files_24
&$env:cmd\cleanup_rat_files_25
&$env:cmd\cleanup_rat_files_26
&$env:cmd\cleanup_rat_files_30
&$env:cmd\cleanup_rat_files_31
&$env:cmd\cleanup_rat_files_32
&$env:cmd\cleanup_rat_files_33
&$env:cmd\cleanup_rat_files_34
&$env:cmd\cleanup_rat_files_35
&$env:cmd\cleanup_rat_files_36
&$env:cmd\cleanup_rat_files_37
&$env:cmd\cleanup_rat_files_41
&$env:cmd\cleanup_rat_files_42
&$env:cmd\cleanup_rat_files_43
&$env:cmd\cleanup_rat_files_44
&$env:cmd\cleanup_rat_files_45
&$env:cmd\cleanup_rat_files_46
&$env:cmd\cleanup_rat_files_60
&$env:cmd\cleanup_rat_files_68
&$env:cmd\cleanup_rat_files_69
&$env:cmd\cleanup_rat_files_70
&$env:cmd\cleanup_rat_files_78
&$env:cmd\cleanup_rat_files_79
&$env:cmd\cleanup_rat_files_80
&$env:cmd\cleanup_rat_files_81
&$env:cmd\cleanup_rat_files_82
&$env:cmd\cleanup_rat_files_84
&$env:cmd\cleanup_rat_files_86
&$env:cmd\cleanup_rat_files_87
&$env:cmd\cleanup_rat_files_88
&$env:cmd\cleanup_rat_files_89
&$env:cmd\cleanup_rat_files_90
&$env:cmd\cleanup_rat_files_91
&$env:cmd\cleanup_rat_files_92
&$env:cmd\cleanup_rat_files_93
&$env:cmd\cleanup_rat_files_94
&$env:cmd\cleanup_rat_files_95
&$env:cmd\cleanup_rat_files_96

Set-Location \\$Env:srvname\rma\alpha\rmabill\rmabill${env:RMABILL_VERS}\data

Remove-Item ohip_rat_ascii_*

Set-Location \\$Env:srvname\rma\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

Get-Date

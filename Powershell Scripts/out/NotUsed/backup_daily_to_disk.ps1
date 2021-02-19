#-------------------------------------------------------------------------------
# File 'backup_daily_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily_to_disk'
#-------------------------------------------------------------------------------

clear
echo "BACKUP_DAILY_to_DISK"
echo ""
echo ""

if (("$1" -ne "") -and ("$1" -ne "nv"))
{
        echo ""
        echo "**ERROR**"
        echo "You must run the backup with either no parameter or theNo Verify parameter"
        echo ""
        echo ""
        echo "Valid format:   backup_daily_to_disk [nv]"
        exit
}

echo "An audit of this backup will be found in backupdaily.ls"
echo ""

echo ""
echo "BACKUP NOW COMMENCING - audit log in backupdaily.ls ..."
echo ""

Get-Date
echo ""
&$env:cmd\backup_daily_to_disk.com $1 > backupdaily.ls
echo ""
Get-Date
echo "An audit of this backup will be found in backupdaily.ls"
echo ""
Get-ChildItem backupdaily.ls
echo ""
echo "DONE!"

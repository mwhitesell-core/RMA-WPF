#-------------------------------------------------------------------------------
# File 'testif.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'testif'
#-------------------------------------------------------------------------------

echo "ENTERY to run macro - otherwise job will TERMINATE!"

&$response = Read-Host
echo "$response"

if  ("$response" -eq "Y" -or "$response" -eq "y")
{
        echo "job will now start ..."
        echo "..."
} else {
        echo `
          "`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`a`aWARNING - job was TERMINATED AT YOUR REQUEST!"
        echo "Terminated!"
}

#-------------------------------------------------------------------------------
# File 'transfer_f020_f027_f028.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'transfer_f020_f027_f028'
#-------------------------------------------------------------------------------

#    TRANSFER THE DOCTOR INFORMATION OF F020, F020 EXTRA, F027 AND F028 
#    INTO REPLACED BY DOC NEW RECORDS. THIS SCRIP IS CALLED FROM M020
#    WHEN A DOCTOR IS TERMINATED AND REPLACED BY A NEW DOCTOR NBR

Set-Location $HOME
echo "Starting to transfer -$(udate)"  >> u902.log
$pipedInput = @"
exec $obj/u902
${1}
${2}
"@

$pipedInput | qtp++  >> u902.log

echo "Completed transfer -$(udate)"  >> u902.log

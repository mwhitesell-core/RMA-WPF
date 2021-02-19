#-------------------------------------------------------------------------------
# File 'upload_meditech_patients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'upload_meditech_patients'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# upload_meditech_patients
Set-Location $env:application_production
echo ""
echo ""
echo ""
echo "Running 'upload_meditech_patients' ..."
echo ""

if ("$1" -eq "")
{
    echo ""
    echo ""
    echo "**ERROR**"
    echo "You must supply the name of the Meditech file to process (yyyy_mm_dd)"
    echo "`a`a`a`a`a"
    echo ""
    echo "Valid Format:   upload_meditech_patients    yyyy_mm_dd"
    exit
} else {
    if (-not(Test-Path ..\upload\${1} ))
    {
        echo ""
        echo "**ERROR** file ' ${1}' was not found!"
        echo "`a`a`a`a`a"
        echo ""
        exit
    } else {

echo ""
echo "Backing up previously uploaded files ..."

#rm meditech_patient_file_bk10                           1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk09 meditech_patient_file_bk10 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk08 meditech_patient_file_bk09 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk07 meditech_patient_file_bk08 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk06 meditech_patient_file_bk07 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk05 meditech_patient_file_bk06 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk04 meditech_patient_file_bk05 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk03 meditech_patient_file_bk04 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk02 meditech_patient_file_bk03 1>/dev/null 2>/dev/null
#mv meditech_patient_file_bk01 meditech_patient_file_bk02 1>/dev/null 2>/dev/null

#echo "Obtain file from hospital system ..."
#ftp -v ihis << E_O_F
#get rma.out
#quit
#E_O_F           

echo ""
echo "Copying upload file into production directory ..."
echo ""

Copy-Item ..\upload\${1} meditech_patient_file

echo ""
echo "Reformating meditech file into u011 format ..."
echo ""
#awk -f $cmd/reformat_meditech_patient_file_1.awk  <                          \
#                          meditech_patient_file  > meditech_patient_file.key
# CONVERSION ERROR (expected, #61): awk.
# awk -f $cmd/reformat_meditech_patient_file_2.awk  <                           \                           meditech_patient_file  > meditech_patient_file.u011
&$env:cmd\reformat_meditech_patient_file_2 meditech_patient_file

echo ""
echo "Starting upload process:"
echo ""
#  echo "Running u993 (verifies I-keys are consistent) ..."
#  cobrun $obj/u993 - not needed to run - 2009/oct/26

echo ""
echo "Running u011 (uploads patients into f010)..."
$rcmd = $env:COBOL + "u011"
Invoke-Expression $rcmd

# build date time stamp for identifying files
$now = "$(Get-Date -uformat `"%Y_%m_%d`")_$(Get-Date -uformat `"%T`")".Replace(":", "")

echo ""
echo "Reports ru011a\b\c renamed for backup purposes ..."
Move-Item -Force ru011a ru011a.$now
Move-Item -Force ru011b ru011b.$now
Move-Item -Force ru011c ru011c.$now

echo ""
echo "Run is successful - renaming input and output iles to indicate processed ..."
echo ""
Move-Item -Force meditech_patient_file.u011 meditech_patient_file.u011.${1}
Move-Item -Force meditech_patient_file.out meditech_patient_file.out.${1}

Set-Location ..\upload

echo ""
Move-Item -Force "${1}" "${1}.${now}"
echo ""
Set-Location ..\production

#quiz auto=$obj/utl0011.qzc
#quiz auto=$obj/utl0011a.qzc
#lp utl0011.txt
#lp utl0011a.txt

echo ""
echo "Done!"
echo ""
Get-Date

}
}

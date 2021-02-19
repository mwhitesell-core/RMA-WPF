#-------------------------------------------------------------------------------
# File 'u700.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u700'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#   NAME: u700
# 
#   PURPOSE: OHIP DISKETTE INPUT INTO RMA SYSTEM
#            THIS MACRO WILL TAKEN THE UPLOADED DISKETTES
#                 FROM THE PC AND APPEND INTO 1 DISKETTE WITH
#                 A NAME THAT IDENTIFIES THE DOCTOR/GROUP SUBMITTING THE
#                 CLAIMS

#   MODIFICATION HISTORY
#      DATE   PERSON        DESCRIPTION (PDR/SMS #)
#   90/JUL/01 B. ELLIOTT    ORIGINAL
#   90/AUG/01 B. ELLIOTT    CHANGED DISKETTE FILES TO SUBMIT.1/2/3/...
#   90/AUG/15 B. ELLIOTT    NAME OF DISKETTE CHANGED TO DOCTOR/GROUP
#   95/DEC/13 M. CHAN    ADD 2 MORE DISKETTE FILES
#   98/JAN/21 KEVIN MILES       CHANGED INTO UNIX (KORN SHELL)
#   00/sep/20 B.E. - removed request to hit newline at end of script
#   00/sep/21 B.E.- added processing of 'manual review' or 'description'
#                       record file
#   01/jan/02 B.E. - allowed up to 25 incoming files to be processed

if ("$1" -eq "")
{
        echo "`a"
        echo ""
        echo "**ERROR**"
        echo "You must supply the 8 character filename of the diskettes to be processed!"
        echo "No extention required !!!"
        echo ""
        echo ""
        echo "Valid format:   u700  bx999999"
        exit
} else {
        if (-not(Test-Path  ${1}.001))
        {
                echo "`a"
                echo ""
                echo "**ERROR** Can't find $1 files !"
                echo ""
                exit
        } else {
# CONVERSION ERROR
#                 if ( [ -f f002_submit_disk_${1}.in ] !! [ -f f002_submit_desc_${1}.in ] )
# Can't convert; Unknown command.
                {
                  echo "`a"
                  echo ""
                  echo ""
                  echo "**ERROR** Unprocessed batch for this doctor\group found."
                  echo "You must first run u701 for this doctor\group before you"
                  echo "continue this upload program"
                  echo ""
                } else {
                  echo ""
                  Get-Content ${1}.001, ${1}.002, ${1}.003, ${1}.004, ${1}.005, ${1}.006, ${1}.007, ${1}.008, ${1}.009, ${1}.010, ${1}.011, ${1}.012, ${1}.013, ${1}.014, ${1}.015, ${1}.016, ${1}.017, ${1}.018, ${1}.019, ${1}.020, ${1}.021, ${1}.022, ${1}.023, ${1}.024, ${1}.025  > f002_submit_disk_${1}.in
                  if (Test-Path ${1}.026)
                  {
                     echo "`a`a`a`a`a`a`a`a`a"
                     echo "WARNING - 26 or more files exist - Files PAST 25 NOT PROCESSED!!!"
                     echo "`a`a`a`a`a`a`a`a`a"
                  }
                  if (Test-Path ${1}.des)
                  {
                    Get-Content ${1}.des  > f002_submit_desc_${1}.in
                  }
                }
        }
}
echo ""
echo ""
#printf "Hit NEWLINE to continue"
#read garbage
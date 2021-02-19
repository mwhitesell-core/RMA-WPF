#-------------------------------------------------------------------------------
# File 'r123_22.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r123_22'
#-------------------------------------------------------------------------------

#cobrun $obj/r123 1>r123.log 2>&1 << R123_EXIT
&$env:COBOL r123a "LIVE RUN" 001 015 356 015 365 Y N 22 2015 12 31 Y *> r123a.log
&$env:COBOL r123b 22 *> r123b.log
#R123_EXIT
echo ""
echo ""
echo "Ensure the below logs are zero length files!"
echo ""
Get-ChildItem r123?.log

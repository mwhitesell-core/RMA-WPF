#-------------------------------------------------------------------------------
# File 'fix_dump_tech.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'fix_dump_tech'
#-------------------------------------------------------------------------------

# 2010/02/23  yas    - This program will zero out the tech amount in f002-hdr and f002-dtl
#                    - dump_tech.qzs will create dump_tech.sf and dump_tech.txt and 
#                    - $obj/fix_dump_tech.qtc will use the subfile to zero tech amounts 


$pipedInput = @"
exe $obj/fix_dump_tech.qtc
"@

$pipedInput | qtp++
#-------------------------------------------------------------------------------
# File 'diskette_rat_create.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'diskette_rat_create'
#-------------------------------------------------------------------------------

#cp $pb_data
echo " "
echo "diskette_rat_create running ..."
echo " "

# CONVERSION ERROR (expected, #6): EBCDIC.
# echo "temporarily converting ascii file to ebcdic ..."
echo " "
# CONVERSION ERROR (expected, #8): EBCDIC.
# dd conv=ebcdic < out_ohip_rat_ascii > out_ohip_rat_ebcdic.tmp

# convert back to ascii automatically adding 'lf' at end of every record
echo " "
echo "converting back to fixed length 79 byte ascii file adding 'lf'"
# CONVERSION ERROR (expected, #13): EBCDIC.
# dd ibs=79 obs=80 cbs=79 conv=sync,ascii < out_ohip_rat_ebcdic.tmp \                                        > out_ohip_rat_ascii.tmp
echo " "

echo "replacing 'lf' with 'cr+lf' and adding ^Z for EOF"
#cat out_ohip_rat_ascii.tmp | sed 's/\012/\015\012/' > ohip.rat
# CONVERSION ERROR (expected, #19): awk.
# awk -f $cmd/massage_rat_diskette_recs.awk < out_ohip_rat_ascii.tmp      \                                          > ohip.rat
echo " "

# rm out_ohip_rat_ebcdic.tmp    \
#    out_ohip_rat_ascii.tmp

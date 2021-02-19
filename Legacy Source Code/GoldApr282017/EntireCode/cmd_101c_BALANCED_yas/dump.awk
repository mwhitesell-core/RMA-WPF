BEGIN {
ctrAllRecords=0
docOhip = "000000"
docSpec = "00"
blanks="                                                                                "
}
{
ctrAllRecords = ctrAllRecords + 1
recType = substr($0,1,3)
if (recType == "HEB") ctrBatch   = ctrBatch   + 1
if (recType == "HEE") ctrTrailer = ctrTrailer + 1
if (recType == "HEH") ctrHdr     = ctrHdr     + 1
if (recType == "HET") ctrItem    = ctrItem    + 1
if (recType == "HEA") ctrAddr    = ctrAddr    + 1
if (recType == "HER") ctrPats    = ctrPats    + 1


if (recType == "HEB" ) docOhip = substr($0,30,6)
if (recType == "HEB" ) docSpec = substr($0,36G,2)

#if (length($0) != 269) printf "%s=%s:%s\n", ctrAllRecords, length($0),$0
#if (length($0) != 79) printf "%s=%s:%s\n", ctrAllRecords, length($0),$0
#if (recType == "HEH" && substr($0,58,1) == "Y" && substr($0,32,3) != "HCP") printf "%5d=%s  :  %s\n", ctrAllRecords, substr($0,24,8),$0
#if (recType == "HEH" && ctrAllRecords> 4748 && ctrAllRecords < 5345) printf "%5d=%s  :  %s\n", ctrAllRecords, substr($0,24,8),$0

####if (recType == "HEH") printf "%s%s%s%5d\n", substr($0,24,8),docOhip,docSpec,ctrAllRecords
}
END{
printf "AUDIT Totals:\n"
printf "   Tota # Recs    %5d\n", ctrAllRecords 
printf "   Batch      :   %5d\n", ctrBatch 
printf "   Trailer    :   %5d\n", ctrTrailer
printf "   Claims     :   %5d\n", ctrHdr
printf "   Items      :   %5d\n", ctrItem
printf "   Address    :   %5d\n", ctrAddr
}

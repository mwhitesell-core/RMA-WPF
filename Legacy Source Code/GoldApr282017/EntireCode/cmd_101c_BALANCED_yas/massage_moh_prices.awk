#! /bin/ksh -f
BEGIN {
blanks="                                                                               "
}

{
  desc=""
  len=length($0)
#  printf "0$=%s\n",$0
  fldTotUnits      = NF - 3
  fldCurrBundled   = NF - 2
  fldCurrUnbundled = NF - 1
  fldProposed      = NF     

# (build description text)
  for (i=2; i<=fldTotUnits - 1; ++i) desc = desc " "$i
# (remove blank if first character)
  if (substr(desc,1,1) == " ") desc = substr(desc,2,length(desc))

# (everything before the first "-" is 'general area' description
  posHyphen = index(desc,"\-")
  rmaDesc = substr(desc,posHyphen + 2,length(desc))

# (truncate desciptions if too long)
  if (length(desc   ) > 120)  desc     = substr(desc   ,1,120)
  if (length(rmaDesc) >  48)  rmaDesc  = substr(rmaDesc,1, 48)

# (pad description if too small)
  desc    = desc    substr(blanks,1,120 - length(desc   ) )
  rmaDesc = rmaDesc substr(blanks,1, 48 - length(rmaDesc) )

#  printf "%s%+10s%+10s%+10s%+10s%s\n",$1,$fldTotUnits,$fldCurrBundled,$fldCurrUnbundled,$fldProposed,desc
  printf "%s|%+10s|%+10s|%+10s|%+10s|%s|%s\n",$1,$fldTotUnits,$fldCurrBundled,$fldCurrUnbundled,$fldProposed,rmaDesc,desc
}
END{
}

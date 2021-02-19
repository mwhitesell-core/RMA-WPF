#! /bin/ksh -f
BEGIN {
blank1="                                                                                                               "
blank2="                                                                                                               "
blanks=blank1 blank2
}

{
  len=length($0)
  $0 = $0 substr(blanks,1,158-len)
# printf "%s\010\n",$0			# add 'cr' in front of 'lf'
  printf "%s\n",$0
}
END{
}

#! /bin/ksh -f
BEGIN {
blanks="                                                                                                                                                               "
}

{
  len=length($0)
  $0 = $0 substr(blanks,1,80-len)
# printf "%s\010\n",$0			# add 'cr' in front of 'lf'
  printf "%s\n",$0
}
END{
}

#! /bin/ksh -f
BEGIN {
blanks="                                                                                                                                                               "
}

{
  len=length($0)
  $0 = $0 substr(blanks,1,132-len)
  len2 = length($0)
# printf "%s%s%s%s%s\n",len,"=",len2,"=",$0
  printf "%s\n",$0
}
END{
}

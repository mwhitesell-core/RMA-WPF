#! /bin/ksh -f
BEGIN {

blanks1="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          "
blanks2="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          "
blanks=blanks1 blanks2

}

{
  len=length($0)
  $0 = $0 substr(blanks,1,1464-length($0))
#  printf "%s\010\n",$0				# add 'cr'
  printf "%s\n",$0
}
END{
}

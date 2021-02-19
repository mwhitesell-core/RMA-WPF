#! /bin/ksh -f
# 98/Sep/21 - calcuation of new length of $0 reduce by 1 additional character
BEGIN {

blanks1="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          "
blanks2="                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          "
blanks=blanks1 blanks2

}

{
  len=length($0)
  $0 = $0 substr(blanks,1,240-length($0)-1)
  printf "%s\n",$0
}
END{
}

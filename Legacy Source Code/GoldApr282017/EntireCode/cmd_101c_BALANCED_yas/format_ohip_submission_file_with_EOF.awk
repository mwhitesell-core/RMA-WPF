BEGIN {
blanks="                                                                                "
}

{ len=length($0)
  $0 = $0 substr(blanks,1,79-len)
  printf"%s\r\n", $0
}
;END {
;  printf""
;}


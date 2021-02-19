#! /bin/ksh -f
BEGIN {
RS="\012"
#FS="!"
}
{
  printf "%s\n",$0
#  printf "%s:%s:%s\n",$1,$2,$3
}
END {
}

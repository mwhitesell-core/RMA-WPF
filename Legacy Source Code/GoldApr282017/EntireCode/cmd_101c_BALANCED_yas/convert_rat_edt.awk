#! /bin/ksh -f
BEGIN {
RS="\012"
#FS="!"
}
{
  printf "%s",$0
}
END {
}

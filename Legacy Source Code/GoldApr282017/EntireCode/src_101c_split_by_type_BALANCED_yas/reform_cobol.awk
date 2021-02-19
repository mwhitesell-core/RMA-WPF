BEGIN {
}

{
#printf "BEFORE:%s\n",$0

 if ($1 == "*")
  {
    printf "      %s \n",$0
  }
  else
  {
    printf "       %s \n",$0
  }
}

BEGIN {
}

{ 
  found=index($0,"00000057")
#  if (found)  printf "DROP=%s\n", $0
  if (!found) printf "%s\n", $0
}
END {
}

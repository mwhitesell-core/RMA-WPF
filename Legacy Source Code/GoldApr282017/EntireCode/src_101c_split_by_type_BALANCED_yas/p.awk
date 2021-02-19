BEGIN {
}
{
gsub(/\014/,"\014\012",$0)      # append a 'carriage return' after a form feed
printf "%s\n",$0
}
END {
}


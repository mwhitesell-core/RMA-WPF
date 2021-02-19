BEGIN {
blanks="                                                                                "
}
{
$0 = $0 substr(blanks,1,79-length($0))
printf "%s",$0
}
END{}


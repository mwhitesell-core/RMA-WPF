BEGIN {
recCtr=0
blanks="                                                                                "
}
{
recCtr = recCtr + 1
#if (length($0) != 269) printf "%s=%s:%s\n", recCtr, length($0),$0
if (length($0) != 79) printf "%s=%s:%s\n", recCtr, length($0),$0
}
END{printf "%s records in total\n", recCtr
}

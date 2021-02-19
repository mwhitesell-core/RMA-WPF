BEGIN {
headingLine="Regional Medical Associates"
}
{
if (index($0, headingLine) == 0 ) printf "%s\n", $0
}
END{}

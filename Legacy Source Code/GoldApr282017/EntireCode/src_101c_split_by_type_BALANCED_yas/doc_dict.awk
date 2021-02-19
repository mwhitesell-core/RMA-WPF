BEGIN{
}
{
record=index($1,
a=index($0,".bak")
b=a+4
s1=substr($0,55,(b-55))

2=substr($0,55,(a-55))
printf "cp %s %s\n", s1, s2
}
end {
}

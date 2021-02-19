BEGIN {
}

{
rec1 =  substr($0, 1,79)
rec2 =  substr($0,80,79)
printf "%s\n",rec1
printf "%s\n",rec2

}
END{}


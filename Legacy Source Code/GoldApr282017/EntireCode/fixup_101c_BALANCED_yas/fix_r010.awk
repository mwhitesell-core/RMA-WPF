BEGIN{
}
{
found=index($0,"\/")
if (found==9) 
  {
   batchNbr1 = substr($0,1,2)
   batchNbr2 = substr($0,3,6)
   batchNbr  = batchNbr1 0 batchNbr2
#printf "%s=%s",found,$0
   printf "    and adj-batch-nbr <> %s		&\n ",batchNbr
  }
}
END{
}


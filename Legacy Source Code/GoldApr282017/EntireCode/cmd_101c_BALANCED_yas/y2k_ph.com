for fname in $1
do
  /macros/dy_time "Searching for date fields in .. $fname"
  mv                $fname $fname.y2k
  awk -f $cmd/y2k_p2.awk < $fname.y2k > $fname
done

for fname in `cat     y2k_cob.files`
do
  /macros/dy_time "Searching for date fields in .. $fname"
#  mv                $fname $fname.y2k
  awk -f $cmd/y2k_c2.awk < $fname.y2k > $fname
done

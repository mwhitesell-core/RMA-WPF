rm y2k_files
for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
  awk -f y2k_1.awk < $fname  > y2k_files
done
sort -u < y2k_files > y2k_files_sorted

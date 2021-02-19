awk -f $cmd/drop_35.awk < $1 > $2

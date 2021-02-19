awk -f $cmd/drop_57.awk < $1 > $2

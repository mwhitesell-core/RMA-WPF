#/bin/ksh
# mail merge pgm

quiz << EOF
exe $obj/mm_a
exe $obj/mm_b
exe $obj/mm_c
EOF
cat mm_a.sf mm_b.sf mm_c.sf > mm.rtf
echo
echo "Download 'mm.rtf' for mail merge secondary (data) file ..."

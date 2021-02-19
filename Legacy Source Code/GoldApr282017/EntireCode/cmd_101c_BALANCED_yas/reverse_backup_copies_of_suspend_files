# reverse_backup_copies_of_suspend_files
# renames 5 backup copies of suspend hdr-dtl/desc/addr files
# 2009/oct/28 - MC - Yas requested to maintain 2 backup copies only

echo
echo "Running reverse_backup_copies_of_suspend_files ..."
rm                          f002_suspend_hdr
mv f002_suspend_hdr_bk1     f002_suspend_hdr
mv f002_suspend_hdr_bk2     f002_suspend_hdr_bk1

rm                          f002_suspend_hdr.idx
mv f002_suspend_hdr_bk1.idx f002_suspend_hdr.idx
mv f002_suspend_hdr_bk2.idx f002_suspend_hdr_bk1.idx

rm                          f002_suspend_dtl
mv f002_suspend_dtl_bk1     f002_suspend_dtl
mv f002_suspend_dtl_bk2     f002_suspend_dtl_bk1

rm                          f002_suspend_dtl.idx
mv f002_suspend_dtl_bk1.idx f002_suspend_dtl.idx
mv f002_suspend_dtl_bk2.idx f002_suspend_dtl_bk1.idx

rm                           f002_suspend_desc
mv f002_suspend_desc_bk1     f002_suspend_desc
mv f002_suspend_desc_bk2     f002_suspend_desc_bk1

rm                           f002_suspend_desc.idx
mv f002_suspend_desc_bk1.idx f002_suspend_desc.idx
mv f002_suspend_desc_bk2.idx f002_suspend_desc_bk1.idx

rm                              f002_suspend_address
mv f002_suspend_address_bk1     f002_suspend_address
mv f002_suspend_address_bk2     f002_suspend_address_bk1

rm                              f002_suspend_address.idx
mv f002_suspend_address_bk1.idx f002_suspend_address.idx
mv f002_suspend_address_bk2.idx f002_suspend_address_bk1.idx
echo
echo "Done reverse of backups"

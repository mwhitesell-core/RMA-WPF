# maintain_backup_copies_of_suspend_files
# maintains 5 backup copies of suspend hdr-dtl/desc/addr files
# 2009/oct/28 - MC - Yas requested to keep for 2 backup copies only

echo
echo "Running maintain_backup_copies_of_suspend_files ..."
rm                          f002_suspend_hdr_bk2
mv f002_suspend_hdr_bk1     f002_suspend_hdr_bk2
cp f002_suspend_hdr         f002_suspend_hdr_bk1

rm                          f002_suspend_hdr_bk2.idx
mv f002_suspend_hdr_bk1.idx f002_suspend_hdr_bk2.idx
cp f002_suspend_hdr.idx     f002_suspend_hdr_bk1.idx

rm                          f002_suspend_dtl_bk2
mv f002_suspend_dtl_bk1     f002_suspend_dtl_bk2
cp f002_suspend_dtl         f002_suspend_dtl_bk1

rm                          f002_suspend_dtl_bk2.idx
mv f002_suspend_dtl_bk1.idx f002_suspend_dtl_bk2.idx
cp f002_suspend_dtl.idx     f002_suspend_dtl_bk1.idx

rm                           f002_suspend_desc_bk2
mv f002_suspend_desc_bk1     f002_suspend_desc_bk2
cp f002_suspend_desc         f002_suspend_desc_bk1

rm                           f002_suspend_desc_bk2.idx
mv f002_suspend_desc_bk1.idx f002_suspend_desc_bk2.idx
cp f002_suspend_desc.idx     f002_suspend_desc_bk1.idx

rm                              f002_suspend_address_bk2
mv f002_suspend_address_bk1     f002_suspend_address_bk2
cp f002_suspend_address         f002_suspend_address_bk1

rm                              f002_suspend_address_bk2.idx
mv f002_suspend_address_bk1.idx f002_suspend_address_bk2.idx
cp f002_suspend_address.idx     f002_suspend_address_bk1.idx
echo
echo "Done backups"

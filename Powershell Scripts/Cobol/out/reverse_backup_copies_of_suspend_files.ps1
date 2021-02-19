#-------------------------------------------------------------------------------
# File 'reverse_backup_copies_of_suspend_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reverse_backup_copies_of_suspend_files'
#-------------------------------------------------------------------------------

# reverse_backup_copies_of_suspend_files
# renames 5 backup copies of suspend hdr-dtl/desc/addr files
# 2009/oct/28 - MC - Yas requested to maintain 2 backup copies only

echo ""
echo "Running reverse_backup_copies_of_suspend_files ..."
Remove-Item f002_suspend_hdr
Move-Item f002_suspend_hdr_bk1 f002_suspend_hdr
Move-Item f002_suspend_hdr_bk2 f002_suspend_hdr_bk1

Remove-Item f002_suspend_hdr.idx
Move-Item f002_suspend_hdr_bk1.idx f002_suspend_hdr.idx
Move-Item f002_suspend_hdr_bk2.idx f002_suspend_hdr_bk1.idx

Remove-Item f002_suspend_dtl
Move-Item f002_suspend_dtl_bk1 f002_suspend_dtl
Move-Item f002_suspend_dtl_bk2 f002_suspend_dtl_bk1

Remove-Item f002_suspend_dtl.idx
Move-Item f002_suspend_dtl_bk1.idx f002_suspend_dtl.idx
Move-Item f002_suspend_dtl_bk2.idx f002_suspend_dtl_bk1.idx

Remove-Item f002_suspend_desc
Move-Item f002_suspend_desc_bk1 f002_suspend_desc
Move-Item f002_suspend_desc_bk2 f002_suspend_desc_bk1

Remove-Item f002_suspend_desc.idx
Move-Item f002_suspend_desc_bk1.idx f002_suspend_desc.idx
Move-Item f002_suspend_desc_bk2.idx f002_suspend_desc_bk1.idx

Remove-Item f002_suspend_address
Move-Item f002_suspend_address_bk1 f002_suspend_address
Move-Item f002_suspend_address_bk2 f002_suspend_address_bk1

Remove-Item f002_suspend_address.idx
Move-Item f002_suspend_address_bk1.idx f002_suspend_address.idx
Move-Item f002_suspend_address_bk2.idx f002_suspend_address_bk1.idx
echo ""
echo "Done reverse of backups"

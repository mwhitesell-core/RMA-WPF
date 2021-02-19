#-------------------------------------------------------------------------------
# File 'maintain_backup_copies_of_suspend_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'maintain_backup_copies_of_suspend_files'
#-------------------------------------------------------------------------------

# maintain_backup_copies_of_suspend_files
# maintains 5 backup copies of suspend hdr-dtl/desc/addr files
# 2009/oct/28 - MC - Yas requested to keep for 2 backup copies only

echo ""
echo "Running maintain_backup_copies_of_suspend_files ..."
Remove-Item f002_suspend_hdr_bk2.dat
Move-Item -Force f002_suspend_hdr_bk1.dat f002_suspend_hdr_bk2.dat
Copy-Item f002_suspend_hdr.dat f002_suspend_hdr_bk1.dat

<#Remove-Item f002_suspend_hdr_bk2.idx
Move-Item -Force f002_suspend_hdr_bk1.idx f002_suspend_hdr_bk2.idx
Copy-Item f002_suspend_hdr.idx f002_suspend_hdr_bk1.idx#>

Remove-Item f002_suspend_dtl_bk2.dat
Move-Item -Force f002_suspend_dtl_bk1.dat f002_suspend_dtl_bk2.dat
Copy-Item f002_suspend_dtl.dat f002_suspend_dtl_bk1.dat

<#Remove-Item f002_suspend_dtl_bk2.idx
Move-Item -Force f002_suspend_dtl_bk1.idx f002_suspend_dtl_bk2.idx
Copy-Item f002_suspend_dtl.idx f002_suspend_dtl_bk1.idx#>

Remove-Item f002_suspend_desc_bk2.dat
Move-Item -Force f002_suspend_desc_bk1.dat f002_suspend_desc_bk2.dat
Copy-Item f002_suspend_desc.dat f002_suspend_desc_bk1.dat

<#Remove-Item f002_suspend_desc_bk2.idx
Move-Item -Force f002_suspend_desc_bk1.idx f002_suspend_desc_bk2.idx
Copy-Item f002_suspend_desc.idx f002_suspend_desc_bk1.idx#>

Remove-Item f002_suspend_address_bk2.dat
Move-Item -Force f002_suspend_address_bk1.dat f002_suspend_address_bk2.dat
Copy-Item f002_suspend_address.dat f002_suspend_address_bk1.dat

<#Remove-Item f002_suspend_address_bk2.idx
Move-Item -Force f002_suspend_address_bk1.idx f002_suspend_address_bk2.idx
Copy-Item f002_suspend_address.idx f002_suspend_address_bk1.idx#>
echo ""
echo "Done backups"

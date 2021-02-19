#-------------------------------------------------------------------------------
# File 'copy_f020_extra_f027_f028_to_foxtrot.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f020_extra_f027_f028_to_foxtrot'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\data

Copy-Item f020_doctor_mstr $Env:root\foxtrot\purge
Copy-Item f020_doctor_mstr.idx $Env:root\foxtrot\purge
Copy-Item f020_doctor_extra.dat $Env:root\foxtrot\purge
Copy-Item f020_doctor_extra.idx $Env:root\foxtrot\purge
Copy-Item f021_avail_doctor_mstr.dat $Env:root\foxtrot\purge
Copy-Item f021_avail_doctor_mstr.idx $Env:root\foxtrot\purge
Copy-Item f027_contacts_mstr $Env:root\foxtrot\purge
Copy-Item f027_contacts_mstr.idx $Env:root\foxtrot\purge
Copy-Item f028_audit_file.dat $Env:root\foxtrot\purge
Copy-Item f028_audit_file.idx $Env:root\foxtrot\purge
Copy-Item f028_contacts_info_mstr $Env:root\foxtrot\purge
Copy-Item f028_contacts_info_mstr.idx $Env:root\foxtrot\purge

Set-Location $Env:root\alpha\rmabill\rmabillmp\data
Copy-Item f020_doctor_mstr $Env:root\foxtrot\purge\mp
Copy-Item f020_doctor_mstr.idx $Env:root\foxtrot\purge\mp
Copy-Item f020_doctor_extra.dat $Env:root\foxtrot\purge\mp
Copy-Item f020_doctor_extra.idx $Env:root\foxtrot\purge\mp
Copy-Item f021_avail_doctor_mstr.dat $Env:root\foxtrot\purge\mp
Copy-Item f021_avail_doctor_mstr.idx $Env:root\foxtrot\purge\mp
Copy-Item f027_contacts_mstr $Env:root\foxtrot\purge\mp
Copy-Item f027_contacts_mstr.idx $Env:root\foxtrot\purge\mp
Copy-Item f028_audit_file.dat $Env:root\foxtrot\purge\mp
Copy-Item f028_audit_file.idx $Env:root\foxtrot\purge\mp
Copy-Item f028_contacts_info_mstr $Env:root\foxtrot\purge\mp
Copy-Item f028_contacts_info_mstr.idx $Env:root\foxtrot\purge\mp

Set-Location $Env:root\alpha\rmabill\rmabillsolo\data
Copy-Item f020_doctor_mstr $Env:root\foxtrot\purge\solo
Copy-Item f020_doctor_mstr.idx $Env:root\foxtrot\purge\solo
Copy-Item f020_doctor_extra.dat $Env:root\foxtrot\purge\solo
Copy-Item f020_doctor_extra.idx $Env:root\foxtrot\purge\solo
Copy-Item f021_avail_doctor_mstr.dat $Env:root\foxtrot\purge\solo
Copy-Item f021_avail_doctor_mstr.idx $Env:root\foxtrot\purge\solo
Copy-Item f027_contacts_mstr $Env:root\foxtrot\purge\solo
Copy-Item f027_contacts_mstr.idx $Env:root\foxtrot\purge\solo
Copy-Item f028_audit_file.dat $Env:root\foxtrot\purge\solo
Copy-Item f028_audit_file.idx $Env:root\foxtrot\purge\solo
Copy-Item f028_contacts_info_mstr $Env:root\foxtrot\purge\solo
Copy-Item f028_contacts_info_mstr.idx $Env:root\foxtrot\purge\solo

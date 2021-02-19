#-------------------------------------------------------------------------------
# File 'hist_and_i_o_audit_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hist_and_i_o_audit_update'
#-------------------------------------------------------------------------------

echo "HIST_AND_I_O_AUDIT_UPDATE"
echo ""
echo "**   Audit file update and Claims History tape creation   **"
echo ""
echo ""
echo "- WARNING !! - The batch control file (f001) and the appointment"
echo "reconciliation files (f201i\rf201o) will be updated by this run"
echo ""
echo "Load a scratch tape on drive write ring in and when ready"
echo "Hit `"NEWLINE`" to backup f001\f201i\f201o...."
$garbage = Read-Host
echo ""
echo ""
&$env:cmd\backup_f001_f201i_f201o
# CONVERSION ERROR (unexpected, #15): Unknown command.
# mt/rewind
echo ""
echo ""
echo ""
echo "Hit `"NEWLINE`" to commence update procedure ..."
$garbage = Read-Host
echo ""
echo "program `"U210`" now being loaded"
echo ""

&$env:COBOL u210

echo ""
echo ""
Get-ChildItem -Force r210
echo ""
echo "Hit `"NEWLINE`" to queue the report"
echo "for printing"
$garbage = Read-Host

echo "lp last page of r210"

echo ""
echo ""
echo "HitNEWLINE to backup history tape file ..."
$garbage = Read-Host

&$env:cmd\backup_f002_history_tape
# CONVERSION ERROR (unexpected, #43): Unknown command.
# mt/rewind
echo ""
echo ""
echo "WARNING !!! - if and only if the backup was successful hit newline --"
echo "otherwise hit ^C to terminate run !!!"
echo ""
echo "Hit `"NEWLINE`" or `"^C`""
echo ""
$garbage = Read-Host

echo "Hit `"NEWLINE`" to delete the history disk file"
echo ""
$garbage = Read-Host

# CONVERSION ERROR (unexpected, #57): -/i/f002_claims_history_tape_file  not identifiers or numbers.
# rm -i f002_claims_history_tape_file

echo ""
echo "Re-load the history tape  without write ring"
echo "on tape drive and hit   newline  when ready..."
echo ""
$garbage = Read-Host

echo ""
&$env:cmd\reload_f002_history_tape
echo ""
# CONVERSION ERROR (unexpected, #68): Unknown command.
# mt/rewind
echo ""
echo "Hit `"NEWLINE`" to commence verification of re-loaded history file ..."
echo ""
$garbage = Read-Host

echo ""
echo "programR211 now being loaded"
echo ""

&$env:COBOL r211

echo ""
echo ""

Get-ChildItem -Force r211

echo ""
echo ""
echo "Hit `"NEWLINE`" to queue the report for printing"
$garbage = Read-Host

Get-Content r211 | Out-Printer

echo ""
echo "Now verify thatR210 andR211 balance before running any further  stages !!!!"


echo ""
echo "You will now change the constants master for next p.e.d."
echo "Hit `"NEWLINE`" to continue...."
$garbage = Read-Host

echo ""
echo "Program `"M090`" now being loaded...."
echo ""

&$env:COBOL m090

echo ""
echo "Finished...."
echo ""

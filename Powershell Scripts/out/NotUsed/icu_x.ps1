#-------------------------------------------------------------------------------
# File 'icu_x.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'icu_x'
#-------------------------------------------------------------------------------

Copy-Item generate_icu_payroll generate_81y2k_payroll

Copy-Item icu_reports, 81 y2k_reports

Copy-Item icu_special_run, 81 y2k_special_run

Copy-Item moh1_icu moh1_81y2k

echo "do these series - run_icu_payroll_1"

Copy-Item run_icu_reports run_81yk2_reports

Copy-Item run_monthend_moh_icu run_monthend_moh_81y2k

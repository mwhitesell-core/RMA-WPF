#-------------------------------------------------------------------------------
# File 'fix_doc_Y35.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_doc_Y35'
#-------------------------------------------------------------------------------

# 2013/Jan/07 MC - fix_doc_Y35
#  fix doctor Y35 records in f110, f119, f119-history, f020 & f020-history  files
#

Set-Location $env:application_production

Remove-Item fix_doc_Y35.log *> $null

echo "Fix doctor Y35 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > fix_doc_Y35.log

# Assuming to fix current f119 & f119 history files (12 passing parameters)
echo "Execute fixf110f119hist.qts ---   " >> fix_doc_Y35.log

# fix_doc_1 comp-code ep-nbr doc-nbr fix-f110-flag amt-gross amt-net fix-f119-flag amt-mtd amt-ytd fix-f119hist-flag amt-mtd amt-ytd

# if you want to fix 93   screen, you must pass 93 under fix-f110-flag    ; otherwise pass 0
# if you want to fix 94   screen, you must pass 94 under fix-f119-flag    ; otherwise pass 0
# if you want to fix HI94 screen, you must pass 94 under fix-f119hist-flag; otherwise pass 0
#
#                             fix-f110                  fix-f119          fix-f119-hist
#                                 flag                      flag                   flag
#           comp-code  ep-nbr  doc     amt-gross     amt-net      amt-mtd   amt-ytd      amt-mtd   amt-ytd
&$env:cmd\fix_doc_1  PAYPOT 201306  Y35  93         0     1209675  94  1209675   7459675  94  1209675   7459675 `
  >> fix_doc_Y35.log 2> fix_doc_Y35.log
&$env:cmd\fix_doc_1  PAYEFT 201306  Y35  93         0     1209675  94  1209675   7459675  94  1209675   7459675 `
  >> fix_doc_Y35.log 2> fix_doc_Y35.log
&$env:cmd\fix_doc_1  YTDCEA 201306  Y35  93         0     7459675   0        0         0   0        0         0 `
  >> fix_doc_Y35.log 2> fix_doc_Y35.log

#echo "Execute fixf020hist.qts ---       " >> fix_doc_Y35.log

# Assuming to fix current f020 & f020 history files (9 passing parameters)
# fix_doc_2 doc-nbr ep-nbr  doc-ytdear doc-ytdinc doc-ytdinc-g doc-ytdcea doc-totinc doc-totinc-g fix-f020-flag

# from TOT screen, the following items can be changed in the order for passing parameters
# doc-ytdear    = 93(YTDEAR) Net   Amt + 93(PAYPOT) Net Amt should equal to 94(PAYPOT) YTD Amt
# doc-ytdinc    = 93(YTDINC) Net   Amt
# doc-ytdinc-g  = 93(YTDINC) Gross AMt
# doc-ytdcea    = 93(YTDCEA) Net   Amt
# doc-totinc    = 93(TOTINC) Net   Amt
# doc-totinc-g  = 93(TOTINC) Gross AMt

#01 YTD Earnings ........:   doc-ytdear   
#02 YTD Income (Net).....:   doc-ytdinc    YTD Income (Gross)...:      doc-ytdinc-g
#03 YTD Ceiling -EARNINGS:   doc-ytdcea    EP  Ceiling -EARNINGS:                    
#05 Computed Ceil-EARNINGS:                TOTINC ..............:      doc-totinc 
#06    "        "-EXPENSES:                TOTINC-Gross ........:      doc-totinc-g 

# if you want to fix TOT screen, you must pass 20 under fix-f020-flag; otherwise pass 0
# you should always pass 20 to fix-f020-flag to fix tot-history along with TOT screen

# fix_doc_2  doc-nbr ep-nbr  doc-ytdear doc-ytdinc doc-ytdinc-g doc-ytdcea doc-totinc doc-totinc-g fix-f020-flag
&$env:cmd\fix_doc_2  Y35  201306   7459675     9269065    10299220      7459675   3679224    3679224        20 `
  >> fix_doc_Y35.log 2> fix_doc_Y35.log

echo "Fix doctor Y35 -  ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> fix_doc_Y35.log
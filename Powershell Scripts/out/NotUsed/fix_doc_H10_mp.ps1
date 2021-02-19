#-------------------------------------------------------------------------------
# File 'fix_doc_H10_mp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_doc_H10_mp'
#-------------------------------------------------------------------------------

# 2013/Jan/08 MC - fix_doc_H10_mp
#  fix doctor H10 records in f110, f119, f119-history, f020 & f020-history  files
#
#--------------------------------------------------------------------------------------------
#
# NOTE:  must delete SURPLU manually OR use 1st fix line to zero this comp code
#        & modify other comp-code  accordingly in 93 screen for 201305 & in hi94 screen for 201305 as well ????????????
#
#--------------------------------------------------------------------------------------------

Set-Location $env:application_production

Remove-Item fix_doc_H10.log *> $null

echo "Fix doctor H10 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > fix_doc_H10.log

# Assuming to fix current f119 & f119 history files (12 passing parameters)
echo "Execute fixf110f119hist.qts ---   " >> fix_doc_H10.log

# fix_doc_1 comp-code ep-nbr doc-nbr fix-f110-flag amt-gross amt-net fix-f119-flag amt-mtd amt-ytd fix-f119hist-flag amt-mtd amt-ytd

# if you want to fix 93   screen, you must pass 93 under fix-f110-flag    ; otherwise pass 0
# if you want to fix 94   screen, you must pass 94 under fix-f119-flag    ; otherwise pass 0
# if you want to fix HI94 screen, you must pass 94 under fix-f119hist-flag; otherwise pass 0
#
#                             fix-f110                  fix-f119          fix-f119-hist
#                                 flag                      flag                   flag
#           comp-code  ep-nbr  doc     amt-gross     amt-net      amt-mtd   amt-ytd      amt-mtd   amt-ytd
# 
# !!!! below calcs not modified for 05 PEd - still 06 values !!!!!!!!!!!!!!!!!!
#
#$cmd/fix_doc_1  SURPLU 201305  H10   0         0           0   0        0         0  94        0         0  1>>fix_doc_H10.log 2>&1
#$cmd/fix_doc_1  TOTINC 201305  H10  93    989907      989907   0        0         0  94   989907   1769719  1>>fix_doc_H10.log 2>&1
#$cmd/fix_doc_1  INCEXP 201305  H10  93    989907      989907   0        0         0  94   989907   1769719  1>>fix_doc_H10.log 2>&1
#$cmd/fix_doc_1  YTDEAR 201305  H10  93    989907      989907   0        0         0  94   989907   1769719  1>>fix_doc_H10.log 2>&1
#$cmd/fix_doc_1  PAYPOT 201305  H10  93    989907      989907   0        0         0  94   989907   1769719  1>>fix_doc_H10.log 2>&1
#$cmd/fix_doc_1  PAYEFT 201305  H10  93    989907      989907   0        0         0  94   989907   1769719  1>>fix_doc_H10.log 2>&1

&$env:cmd\fix_doc_1  SURPLU 201306  H10   0         0           0   0        0         0  94        0         0 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
&$env:cmd\fix_doc_1  TOTINC 201306  H10  93    989907      989907   0        0         0  94   989907   1769719 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
&$env:cmd\fix_doc_1  INCEXP 201306  H10  93    989907      989907   0        0         0  94   989907   1769719 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
&$env:cmd\fix_doc_1  YTDEAR 201306  H10  93    989907      989907   0        0         0  94   989907   1769719 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
&$env:cmd\fix_doc_1  PAYPOT 201306  H10  93    989907      989907   0        0         0  94   989907   1769719 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
&$env:cmd\fix_doc_1  PAYEFT 201306  H10  93    989907      989907   0        0         0  94   989907   1769719 `
  >> fix_doc_H10.log 2> fix_doc_H10.log

# CONVERSION ERROR (unexpected, #46): Unknown command.
# !!!!!!!!!!!!!!!!!! move below to end of macro !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
#                               YTDEAR     TOTINC-ytd   <-same     YTDCEA     TOTINC-mtd   <-same
# fix_doc_2  doc-nbr ep-nbr doc-ytdear doc-ytdinc doc-ytdinc-g doc-ytdcea doc-totinc doc-totinc-g fix-f020-flag
#                               ,  .        ,  .        ,  .        ,  .       ,  .       ,  .     
&$env:cmd\fix_doc_2  H10  201306   1769719     1769719     1769719           0     989907       989907       20 `
  >> fix_doc_H10.log 2> fix_doc_H10.log
#echo "Execute fixf020hist.qts ---       " >> fix_doc_H10.log

# Assuming to fix current f020 & f020 history files (9 passing parameters)
# fix_doc_2 doc-nbr ep-nbr  doc-ytdear doc-ytdinc doc-ytdinc-g doc-ytdcea doc-totinc doc-totinc-g fix-f020-flag

# from TOT screen, the following items can be changed in the order for passing parameters
# doc-ytdear    = 94(YTDEAR) YTD   Amt
# doc-ytdinc    = 93(YTDINC) Net   Amt
# doc-ytdinc-g  = 93(YTDINC) Gross AMt
# doc-ytdcea    = 94(YTDEAR) YTD   Amt
# doc-totinc    = 93(TOTINC) Net   Amt
# doc-totinc-g  = 93(TOTINC) Gross AMt

#01 YTD Earnings ........:   doc-ytdear   
#02 YTD Income (Net).....:   doc-ytdinc    YTD Income (Gross)...:      doc-ytdinc-g
#03 YTD Ceiling -EARNINGS:   doc-ytdcea    EP  Ceiling -EARNINGS:                    
#05 Computed Ceil-EARNINGS:                TOTINC ..............:      doc-totinc 
#06    "        "-EXPENSES:                TOTINC-Gross ........:      doc-totinc-g 

# if you want to fix TOT screen, you must pass 20 under fix-f020-flag; otherwise pass 0
# you should always pass 20 to fix-f020-flag to fix tot-history along with TOT screen


echo "Fix doctor H10 -  ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> fix_doc_H10.log

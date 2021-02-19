#-------------------------------------------------------------------------------
# File 'u132_awk.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u132_awk.com'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4,
  [string] $5,
  [string] $6
)

#file: u132_awk.com
# CONVERSION ERROR
# awk -f $cmd/u132.awk < $7 > u132.dat -v colDocNbr=$1                                      -v colDocSurname=$2                                      -v colDocInits=$3                                      -v colDocGivenNames=$4                                      -v colAmt=$5                                      -v colCompCode=$6
# Can't convert; Not all keywords are ready for output.
k:converted/w:0/v:awk++ $cmd\u132.awk, k:other/w:1/v:-, k:id/w:0/v:v, k:id/w:1/v:colDocNbr, k:other/w:0/v:=, k:id/w:0/v:$1, k:other/w:38/v:-, k:id/w:0/v:v, k:id/w:1/v:colDocSurname, k:other/w:0/v:=, k:id/w:0/v:$2, k:other/w:38/v:-, k:id/w:0/v:v, k:id/w:1/v:colDocInits, k:other/w:0/v:=, k:id/w:0/v:$3, k:other/w:38/v:-, k:id/w:0/v:v, k:id/w:1/v:colDocGivenNames, k:other/w:0/v:=, k:id/w:0/v:$4, k:other/w:38/v:-, k:id/w:0/v:v, k:id/w:1/v:colAmt, k:other/w:0/v:=, k:id/w:0/v:$5, k:other/w:38/v:-, k:id/w:0/v:v, k:id/w:1/v:colCompCode, k:other/w:0/v:=, k:id/w:0/v:$6

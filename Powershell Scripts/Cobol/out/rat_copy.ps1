#-------------------------------------------------------------------------------
# File 'rat_copy.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'rat_copy'
#-------------------------------------------------------------------------------

echo ""
echo "Hit new line to run clinic 22 group 2215  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*2215* ohip_rat_ascii
Set-Location $application_production
#cobrun $obj/u030a 1>u030a.log 2>&1 << RAT_EXIT
# use above line if you don't want the amount displayed but put on log file
#log file does not keep the screen values
$pipedInput = @"
2215
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_22
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 23 group 0706  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*0706* ohip_rat_ascii
Set-Location $application_production\23
$pipedInput = @"
0706
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_23
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 24 group AB99  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AB99* ohip_rat_ascii
Set-Location $application_production\24
$pipedInput = @"
AB99
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_24
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 25 group 0930  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*0930* ohip_rat_ascii
Set-Location $application_production\25
$pipedInput = @"
0930
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_25
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 26 group 1837 ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*1837* ohip_rat_ascii
Set-Location $application_production\26
$pipedInput = @"
1837
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_26
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 30 group H290  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H290* ohip_rat_ascii
Set-Location $application_production\30
$pipedInput = @"
H290
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_30
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 31 group H104  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H104* ohip_rat_ascii
Set-Location $application_production\31
$pipedInput = @"
H104
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_31
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 32 group H061  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H061* ohip_rat_ascii
Set-Location $application_production\32
$pipedInput = @"
H061
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_32
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 33 group H107  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H107* ohip_rat_ascii
Set-Location $application_production\33
$pipedInput = @"
H107
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_33
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 34 group H105    ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H105* ohip_rat_ascii
Set-Location $application_production\34
$pipedInput = @"
H105
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_34
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 35 group H106  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H106* ohip_rat_ascii
Set-Location $application_production\35
$pipedInput = @"
H106
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_35
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 36 group H103  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H103* ohip_rat_ascii
Set-Location $application_production\36
$pipedInput = @"
H103
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_36
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 37 group 6411  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*6411* ohip_rat_ascii
Set-Location $application_production\37
$pipedInput = @"
6411
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_37
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################

echo ""
echo "Hit new line to run clinic 41 group H108  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H108* ohip_rat_ascii
Set-Location $application_production\41
$pipedInput = @"
H108
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_41
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 42 group H110  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H110* ohip_rat_ascii
Set-Location $application_production\42
$pipedInput = @"
H110
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_42
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 43 group H055  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H055* ohip_rat_ascii
Set-Location $application_production\43
$pipedInput = @"
H055
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_43
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 44 group H111  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H111* ohip_rat_ascii
Set-Location $application_production\44
$pipedInput = @"
H111
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_44
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 45 group H112..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H112* ohip_rat_ascii
Set-Location $application_production\45
$pipedInput = @"
H112
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_45
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 46 group H147  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H147* ohip_rat_ascii
Set-Location $application_production\46
$pipedInput = @"
H147
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_46
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 61 group 9595  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9595* ohip_rat_ascii
Set-Location $application_production\61
$pipedInput = @"
9595
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_61
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 62 group 9598  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9598* ohip_rat_ascii
Set-Location $application_production\62
$pipedInput = @"
9598
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_62
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 63 group 9607  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9607* ohip_rat_ascii
Set-Location $application_production\63
$pipedInput = @"
9607
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_63
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 64 group 9619  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9619* ohip_rat_ascii
Set-Location $application_production\64
$pipedInput = @"
9619
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_64
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 65 group 9632  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9632* ohip_rat_ascii
Set-Location $application_production\65
$pipedInput = @"
9632
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_65
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 66 group 9098  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*9098* ohip_rat_ascii
Set-Location $application_production\66
$pipedInput = @"
9098
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_66
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 68 group 6064  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*6064* ohip_rat_ascii
Set-Location $application_production\68
$pipedInput = @"
6064
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_68
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################

echo ""
echo "Hit new line to run clinic 69 group AA5B  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA5B* ohip_rat_ascii
Set-Location $application_production\69
$pipedInput = @"
AA5B
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_69
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo ""
echo "Hit new line to run clinic 71 group H520  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H520* ohip_rat_ascii
Set-Location $application_production\71
$pipedInput = @"
H520 
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_71
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 72 group H521  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H521* ohip_rat_ascii
Set-Location $application_production\72
$pipedInput = @"
H521
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_72
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 73 group H522  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H522* ohip_rat_ascii
Set-Location $application_production\73
$pipedInput = @"
H522
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_73
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 74 group H523  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H523* ohip_rat_ascii
Set-Location $application_production\74
$pipedInput = @"
H523
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_74
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 75 group H524  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*H524* ohip_rat_ascii
Set-Location $application_production\75
$pipedInput = @"
H524
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_75
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 78 group AA8U  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA8U* ohip_rat_ascii
Set-Location $application_production\78
$pipedInput = @"
AA8U
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_78
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
#################
echo ""
echo "Hit new line to run clinic 80 group AA32  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA32* ohip_rat_ascii
Set-Location $application_production\80
$pipedInput = @"
AA32
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_80
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 82 group AA21  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA21* ohip_rat_ascii
Set-Location $application_production\82
$pipedInput = @"
AA21
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_82
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 84 group 6072  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*6072* ohip_rat_ascii
Set-Location $application_production\84
$pipedInput = @"
6072
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_84
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 86 group AA18  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA18* ohip_rat_ascii
Set-Location $application_production\86
$pipedInput = @"
AA18
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_86
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 87 group C001  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*C001* ohip_rat_ascii
Set-Location $application_production\87
$pipedInput = @"
C001
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_87
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 88 group AA3F  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA3F* ohip_rat_ascii
Set-Location $application_production\88
$pipedInput = @"
AA3F
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_88
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 89 group C022  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*C022* ohip_rat_ascii
Set-Location $application_production\89
$pipedInput = @"
C022
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_89
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 91 group AA5V  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA5V* ohip_rat_ascii
Set-Location $application_production\91
$pipedInput = @"
AA5V
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_91
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 92 group AA5W  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA5W* ohip_rat_ascii
Set-Location $application_production\92
$pipedInput = @"
AA5W
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_92
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 93 group AA5X  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA5X* ohip_rat_ascii
Set-Location $application_production\93
$pipedInput = @"
AA5X
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_93
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 94 group AA5Y  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA5Y* ohip_rat_ascii
Set-Location $application_production\94
$pipedInput = @"
AA5Y
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_94
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 95 group AA2K  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*AA2K* ohip_rat_ascii
Set-Location $application_production\95
$pipedInput = @"
AA2K
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_95
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

#################
echo ""
echo "Hit new line to run clinic 96 group 6317  ..."
$garbage = Read-Host
echo ""
Set-Location $pb_data
Move-Item P*6317* ohip_rat_ascii
Set-Location $application_production\96
$pipedInput = @"
6317
${1}
Y
"@

$pipedInput | cobrun++ $obj\u030a
Set-Location $pb_data
Move-Item ohip_rat_ascii ohip_rat_ascii_96
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host

# modification history
# 2007/may./07 b.e. - removed double quotes from health card nbr and version cd
#
# reformat incoming Meditech patient file into format expected by RMA's
# upload program u011 - because we don't know the before/after data
# we have to make each record an 'A'dd transaction.
# the incoming file looks like:
# 0$="DEVENPORT,OLIVE""14/02/18""F""1062314""501-200 JACKSON ST.W.""""HAMILTON"
# "L8P 4R9""3873487478-KC" 
#
# the 'words' we want are:
# DESC					WORD #	  	EXAMPLE DATA
# ---------------------------------	--------	-------------
# health care number - version code	$word(12)	3873487478-KC
# phone number 				$word(11)	564-2345
# province      			$word(10)	ON      
# postal code				$word(09)	L8P 4R9
# city                 			$word(08)	HAMILTON
# address line 2			$word(07)	AP # 203                  
# address line 1			$word(06)	501-200 JACKSON ST.W.
# siteFlag     				$word(05)       ".","H"
# chart number				$word(04)       1062314
# sex					$word(03)	F
# patient birth date			$word(02)       04/02/18 (dd/mm/yy) -- dd/mm/yyyy new format
# lastname, firstname			$word(01) 	DEVENPORT,OLIVE
#
# format for output is:
# outFunctionCode  	x(2) hard coded to  "AA"
# outLastName		x(24)
# outFirstName		x(24)
# outBirthDate		x(10) (yyyy/mm/dd)
# outsex 		x(1)
# outChartNbr		x(9)	TODO in the future will be longer (10 or 15 chars)
#            15  first-char              pic x 'M,K,H,1,5'.
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#            15  tp-pat-id-no-9-digit    pic x.
#            15  filler                  pic x(5).
# outStreetAddr-1	x(28)
# outStreetAddr-2	x(28)		New item , must be added 
# outCity		x(18)
# outProv 		x(2)
# outPostalCode		x(6)
# outPhoneNbr		x(20)		?????
# outPatOhipNbr         x(8)      TODO for now I put (_) value but will be changed in the future
# outHealthNbr		x(10)
# outVersionCode	x(2)		?????
# outHealth65Flag	x(1)		?????
# outHealthExpiryDate   x(4)	  mmyy  '0000'

param(
  [string] $1
)

$qmark = "?????????????????????????????????????????????????????????????????????????"
$crLf = "`r`n"
$debug = 0

$inputLine = ""
$outputLine = ""
$newLine = ""

$inputLineCount = 0
$outputLineCount = 0
$newLineCount = 0
$maxLines = 10000

if (Test-Path "./INPUT.txt" -PathType Leaf)
{
    Remove-Item "INPUT.txt"
}

if (Test-Path "./OUTPUT.txt" -PathType Leaf)
{
    Remove-Item "OUTPUT.txt"
}

if(Test-Path "./meditech_patient_file.u011" -PathType Leaf)
{
    Remove-Item "meditech_patient_file.u011"
}

foreach($line in Get-Content .\$1)
{
	$arr = $line.split("~")

	$patOhipNbr = "        "
    $versionCode = " "
    $healthNbr = " "
    $phoneNbr = " "
    $prov = " "
    $postalCode = " "
    $city = " "
    $addr2 = " "
    $addr1 = " "
    $siteFlag = " "
    $chartNbr = " "
    $sex = " "
    $birthDateYYYY = "    "
	$birthDateMM = "  "
  	$birthDateDD = "  "
    $outBirthDate = "        "
    $lastName = " "
    $firstName = " "
	$health65Flag = " "
	$healthExpiryDate = "0000"

    if ($arr.Count -ge 12)
    {
        if ($arr[11].IndexOf("-") -gt 0)
        {
            $versionCode = $arr[11].Replace("`"", "").Split("-")[1]
	        $healthNbr = $arr[11].Replace("`"", "").Split("-")[0]
        }
        elseif ($arr[11].Replace("`"", "").Trim().Length -gt 0)
        {
            if ($arr[11].Replace("`"", "").Trim().Length -gt 10)
            {
                $healthNbr = $arr[11].Replace("`"", "").Substring(0, 10)
                $versionCode = $arr[11].Replace("`"", "").Substring(11)
            }
            else
            {
                $healthNbr = $arr[11].Replace("`"", "")
            }
        }
    }

    if ($arr.Count -ge 11)
    {
    	$phoneNbr = $arr[10].Replace("`"", "")
    }

    if ($arr.Count -ge 10)
    {
    	$prov = $arr[9].Replace("`"", "")
    }

    if ($arr.Count -ge 9)
    {
    	$postalCode = $arr[8].Replace("`"", "")
    }

    if ($arr.Count -ge 8)
    {
    	$city = $arr[7].Replace("`"", "")
    }

    if ($arr.Count -ge 7)
    {
        if ($arr[6].length -gt 0)
        {
	        $addr2 = $arr[6].Replace("`"", "")
        }
    }

    if ($arr.Count -ge 6)
    {
    	$addr1 = $arr[5].Replace("`"", "")
    }

    if ($arr.Count -ge 5)
    {
    	$siteFlag = $arr[4].Replace("`"", "")
    }

    if ($arr.Count -ge 4)
    {
    	$chartNbr = $arr[3].Replace("`"", "")
    }

    if ($arr.Count -ge 3)
    {
    	$sex = $arr[2].Replace("`"", "")
    }

    if ($arr.Count -ge 2)
    {
    	if ($arr[1].Replace("`"", "").Replace("/", "").length -gt 0)
	    {
		    $birthDateYYYY = $arr[1].Replace("`"", "").Split("/")[2]
    		$birthDateMM = $arr[1].Replace("`"", "").Split("/")[1]
	    	$birthDateDD = $arr[1].Replace("`"", "").Split("/")[0]
		
    		$outBirthDate = $birthDateYYYY + "/" + $birthDateMM + "/" + $birthDateDD
	    }
    }

    if ($arr.Count -ge 1)
    {    
	    if ($arr[0].Replace("`"", "").IndexOf(",") -gt 0)
	    {
		    $lastName = $arr[0].Replace("`"", "").Split(",")[0]
		    $firstName = $arr[0].Replace("`"", "").Split(",")[1]
	    }
	    else
	    {
		    $lastName = $arr[0].Replace("`"", "")
	    }
    }

	if ($debug -eq 1)
	{

        $inputLine += "firstname=" + $firstName + $crLf
        $inputLine += "lastname=" + $lastName + $crLf
        $inputLine += "birthYY=" + $birthDateYYYY + $crLf
        $inputLine += "birthMM=" + $birthDateMM + $crLf
        $inputLine += "birthDD=" + $birthDateDD + $crLf
        $inputLine += "sex=" + $sex + $crLf
        $inputLine += "siteflag=" + $siteFlag + $crLf
        $inputLine += "chartNbr=" + $chartNbr + $crLf
        $inputLine += "addr1=" + $addr1 + $crLf
        $inputLine += "addr2=" + $addr2 + $crLf
        $inputLine += "city=" + $city + $crLf
        $inputLine += "prov=" + $prov + $crLf
        $inputLine += "postalCode=" + $postalCode + $crLf
        $inputLine += "patOhipNbr=" + $patOhipNbr + $crLf
        $inputLine += "phoneNbr=" + $phoneNbr + $crLf
        $inputLine += "healthNbr=" + $healthNbr + $crLf
        $inputLine += "versionCode=" + $versionCode + $crLf
        $inputLine += "65 Flag=" + $health65Flag + $crLf
        $inputLine += "expiryDate=" + $healthExpiryDate + $crLf + $crLf
        
        $inputLineCount += 1

        if ($inputLineCount -eq $maxLines)
        {
    		if (Test-Path "./INPUT.txt" -PathType Leaf)
	    	{
		    	Add-Content INPUT.txt $inputLine
    		}
	    	else
		    {
			    Set-Content -Path "./INPUT.txt" -Value $inputLine
    		}
            $inputLineCount = 0
            $inputLine = ""
        }
	}

	$outFunctionCode = "AA"

	if ($lastName.length -gt 24)
	{
		$outLastName = $lastName.Substring($lastName, 0, 24)
	}
	else
	{
		$outLastName = $lastName.PadRight(24, ' ')
	}

	if ($firstName.length -gt 24)
	{
		$outFirstName = $firstName.Substring($firstName, 0, 24)
	}
	else
	{
		$outFirstName = $firstName.PadRight(24, ' ')
	}

	$outSex = $sex

	if ($siteFlag.length -gt 1)
	{
		$outSiteFlag = "?"
	}
	else
	{
		$outSiteFlag = $siteFlag + $qmark.Substring(1, 1 - $siteFlag.length)
	}
	
	if ($chartNbr.length -gt 10)
	{
		$outChartNbr = $chartNbr.Substring($chartNbr.length - 9, 10)
	}
	elseif ($chartNbr.length -eq 10)
	{
		if (".G".Contains($chartNbr.Substring(0, 1)))
		{
			$outchartNbr = "0001" + $arr[3].Replace("`"", "").Substring(4, 6)
		}
		else
		{
			$outchartNbr = $arr[3].Replace("`"", "")
		}
	}
	elseif ($chartNbr.length -eq 7 -and "15".Contains($chartNbr.Substring(0, 1)))
    {
        $outChartNbr = $chartNbr.PadLeft(10, '0')
	    $chartNbr = "12345678901"
	}
	elseif ($chartNbr.length -lt 10)
	{
		$outChartNbr = $outSiteFlag + $chartNbr.PadLeft(9, '0')
	}
	
	$outChartNbr = $outChartNbr + "     "
	
	if ($addr1.length -gt 28)
	{
		$outAddr1 = $addr1.Substring(0, 28)
	}
	else
	{
		$outAddr1 = $addr1.PadRight(28, ' ')
	}
	
	if ($addr2.length -gt 28)
	{
		$outAddr2 = $addr2.Substring(0, 28)
	}
	else
	{
		$outAddr2 = $addr2.PadRight(28, ' ')
	}
	
	if ($city.length -gt 18)
	{
		$outCity = $city.Substring(0, 18)
	}
	else
	{
		$outCity = $city.PadRight(18, ' ')
	}
	
	if ($prov.length -gt 2)
	{
		$outProv = $prov.Substring(0, 2)
	}
	else
	{
		$outProv = $prov.PadRight(2, ' ')
	}
	
	if ($postalCode.length -le 6)
	{
		$outPostalCode = $postalCode.PadRight(6, ' ')
	}
	elseif ($postalCode.length -eq 7)
	{
		$outPostalCode = $postalCode.Substring(0, 3) + $postalCode.Substring(4, 3)
	}
	elseif ($postalCode -gt 7)
	{
		$outPostalCode = $postalCode.Substring(0, 6)
	}

	if ($phoneNbr.length -gt 20)
	{
		$outPhoneNbr = $phoneNbr.Substring(0, 20)
	}
	else
	{
		$outPhoneNbr = $phoneNbr.PadRight(20, ' ')
	}
	
	if ($phoneNbr.length -gt 20)
	{
		$outPhoneNbr = $phoneNbr.Substring(0, 20)
	}
	else
	{
		$outPhoneNbr = $phoneNbr.PadRight(20, ' ')
	}

	if ($patOhipNbr.length -gt 8)
	{
		$outPatOhipNbr = $patOhipNbr.Substring(0, 8)
	}
	else
	{
		$outPatOhipNbr = $patOhipNbr.PadRight(8, ' ')
	}

	if ($healthNbr.length -gt 10)
	{
		$outHealthNbr = $healthNbr.Substring(0, 10)
	}
	else
	{
		$outHealthNbr = $healthNbr.PadRight(10, ' ')
	}

	if ($versionCode.length -gt 2)
	{
		$outVersionCode = $versionCode.Substring(0, 2)
	}
	else
	{
		$outVersionCode = $versionCode.PadRight(2, ' ')
	}

	if ($health65Flag.length -gt 0)
	{
		$outHealth65Flag = $health65Flag.Substring(0, 1)
	}
	else
	{
		$outHealth65Flag = " "
	}

	if ($healthExpiryDate.length -gt 4)
	{
		$outHealthExpiryDate = $healthExpiryDate.Substring(0, 4)
	}
	else
	{
		$outHealthExpiryDate = $healthExpiryDate.PadRight(4, ' ')
	}

	if ($debug -eq 1)
	{
        $outputLine += "outFirstName=" + $outFirstName + $crLf
        $outputLine += "outLastName=" + $outLastName + $crLf
        $outputLine += "outBirthDate=" + $outBirthDate + $crLf
        $outputLine += "outSex=" + $outSex + $crLf
        $outputLine += "outSiteFlag=" + $outSiteFlag + $crLf
        $outputLine += "outChartNbr=" + $outChartNbr + $crLf
        $outputLine += "outAddr1=" + $outAddr1 + $crLf
        $outputLine += "outAddr2=" + $outAddr2 + $crLf
        $outputLine += "outCity=" + $outCity + $crLf
        $outputLine += "outProv=" + $outProv + $crLf
        $outputLine += "outPostalCode=" + $outPostalCode + $crLf
        $outputLine += "outPatOhipNbr=" + $outPatOhipNbr + $crLf
        $outputLine += "outPhoneNbr=" + $outPhoneNbr + $crLf
        $outputLine += "outHealthNbr=" + $outHealthNbr + $crLf
        $outputLine += "outVersionCode=" + $outVersionCode + $crLf
        $outputLine += "outHealth65Flag=" + $outHealth65Flag + $crLf
        $outputLine += "outExpiryDate=" + $outHealthExpiryDate + $crLf + $crLf

        $outputLineCount += 1

        if ($outputLineCount -eq $maxLines)
        {
    		if (Test-Path "./OUTPUT.txt" -PathType Leaf)
	    	{
		    	Add-Content OUTPUT.txt $outputLine
    		}
	    	else
		    {
			    Set-Content -Path "./OUTPUT.txt" -Value $outputLine
    		}
            $outputLineCount = 0
            $outputLine = ""
        }
	}

    if ($newLineCount -eq $maxLines)
    {
    	if (Test-Path "./meditech_patient_file.u011" -PathType Leaf)
	    {
		    Add-Content meditech_patient_file.u011 $newLine
	    }
	    else
	    {
    		Set-Content -Path "./meditech_patient_file.u011" -Value $newLine
	    }


        $newLineCount = 0
        $newLine = ""
    }

    $newLine += "C1" + $outLastName + $outFirstName + $outBirthDate + $outSex + $outChartNbr + $outAddr1 + $outAddr2 + $outCity + $outProv + $outPostalCode + $outPhoneNbr + $outPatOhipNbr + $outHealthNbr + $outVersionCode + $outHealth65Flag + $outHealthExpiryDate + $crLf
    $newLine += "C2" + $outLastName + $outFirstName + $outBirthDate + $outSex + $outChartNbr + $outAddr1 + $outAddr2 + $outCity + $outProv + $outPostalCode + $outPhoneNbr + $outPatOhipNbr + $outHealthNbr + $outVersionCode + $outHealth65Flag + $outHealthExpiryDate + $crLf
    $newLineCount += 1
 }

if ($debug -eq 1)
{
   	Add-Content INPUT.txt $inputLine
   	Add-Content OUTPUT.txt $outputLine
}

Add-Content meditech_patient_file.u011 $newLine

#Remove the blank lines.
Get-Content "./meditech_patient_file.u011" | ?{$_.trim() -ne ""} | Set-Content -Path "./meditech_patient_file2.u011"
Remove-Item "./meditech_patient_file.u011"
Move-Item "./meditech_patient_file2.u011" "./meditech_patient_file.u011"

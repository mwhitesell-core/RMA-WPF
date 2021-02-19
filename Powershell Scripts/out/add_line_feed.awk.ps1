Param(
    [string]$filename,
    [string]$fileout
    )
$read = [System.IO.File]::OpenText($filename)
if($read) {
    $i=0;
    $string = $read.ReadLine()
    while($i*1464 -lt $string.length) {
        $buffer = $buffer + $string.substring($i*1464, 1464)+"`n"
        $i++
    }
    [System.IO.File]::WriteAllLines($fileout,$buffer)
}

    
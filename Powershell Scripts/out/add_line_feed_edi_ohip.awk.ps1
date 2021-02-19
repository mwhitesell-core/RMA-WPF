Param(
    [string]$filename,
    [string]$fileout
    )
$read = [System.IO.File]::OpenText($filename)
if($read) {
    $i=0;
    $string = $read.ReadLine()
    while($i*158 -lt $string.length) {
        $buffer = $buffer + $string.substring($i*158, 158)+"`n"
        $i++
    }
    [System.IO.File]::WriteAllLines($fileout,$buffer)
}
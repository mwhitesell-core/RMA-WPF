Param(
    [string]$filename,
    [string]$fileout
)
$read = [System.IO.File]::OpenText($filename)
if($read) {
    while($line = $read.ReadLine()) {
        $buffer = $buffer + $line +"`n"
    }
    [System.IO.File]::WriteAllLines($fileout,$buffer)
}
else {
    echo "Error:Could not open file"
}
Param(
    [string]$filename,
    [string]$fileout
)
$read = [System.IO.File]::ReadAllLines($filename)
if($read) {
    for($i=0; $i -lt $read.length; $i++) {
        $buffer = $buffer + $read[$i].PadRight(158," ")+"`n"
    }
    $Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
    [System.IO.File]::WriteAllLines($fileout,$buffer,$Utf8NoBomEncoding)
    $stream = [IO.File]::OpenWrite($fileout)
    $stream.SetLength($stream.Length - 2)
    $stream.Close()
    $stream.Dispose()
}
else {
    echo "Error:Could not open file"
}


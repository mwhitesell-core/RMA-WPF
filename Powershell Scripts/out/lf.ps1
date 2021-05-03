param(
[string]$filein,
[string]$fileout,
[string]$length
)

$currpath = Get-Location
$currpath = Convert-Path -Path $currpath

$file1 = Join-Path $currpath $filein
$file2 = Join-Path $currpath $fileout

$read = New-Object -TypeName System.IO.StreamReader -ArgumentList $file1
$text = $read.ReadLine()

if ($text.Length -gt $length) {
  $write = New-Object -TypeName System.IO.StreamWriter -ArgumentList $file2
  $i=0

  while($i*$length -lt $text.Length) {
    $write.WriteLine($text.Substring($i*$length, $length))
    $i++   
  }

  $write.Close()
  $read.Close()

  #Replace the $filein with $fileout
  Remove-Item $file1
  Get-Content $file2 | Out-File -FilePath $file1 -Encoding ASCII
  Remove-Item $file2 
}
else
{
  $read.Close()
}	



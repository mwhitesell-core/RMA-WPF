

$application_production = "\\rmaweb\RMA\" + $env:username
$cmd = "E:\RMA\Scripts\"

$env:pb_data = "MP"
$env:QTP = "E:\RMA\RMA_Batch\RMA_Batch.exe " + $env:pb_data + " " + "QTP" + " "
$env:QUIZ = "E:\RMA\RMA_Batch\RMA_Batch.exe " + $env:pb_data + " " + "QUIZ" + " "
$env:COBOL = "E:\RMA\RMA_Batch\RMA_Batch.exe " + $env:pb_data + " " + "COBOL" + " "

Write-Output $env:application_production
Write-Output $env:QTP
Write-Output $env:QUIZ
Write-Output $env:COBOL
Write-Output $env:pb_data


$env:clinic_nbr = "22"
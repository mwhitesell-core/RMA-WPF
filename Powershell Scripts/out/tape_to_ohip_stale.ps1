#-------------------------------------------------------------------------------
# File 'tape_to_ohip_stale.ps1'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Remove-Item u020a1*.sf, u020a1*.sfd, u020b*.sf, u020b*.sfd, u020_tp.sf, u020_tapeout_file*, stale.log, ohiptape*, R020_stale* *> $null

$rcmd = $env:QTP+ "u020a Y $1"
Invoke-Expression $rcmd


if (Test-Path stale.log)
{
	echo "Error occurred. Check stale.log for details."
}
else
{
	echo "Processing u020a1_a ..."
	if ((Test-Path u020a1_a.sf) -and ((Get-Item u020a1_a.sf).Length -gt 0))
	{
	 Move-Item -Force u020a1_a.sf u020a1.sf
	 Move-Item -Force u020a1_a.sfd u020a1.sfd

	  $rcmd = $env:QTP+ "u020b Y"
	 Invoke-Expression $rcmd

	  Move-Item -Force u020_tp.sf u020_tapeout_file_a
	 Remove-Item u020_tp.sfd

	  Move-Item -Force u020a1.sf u020a1_a.sf
	  Move-Item -Force u020a1.sfd u020a1_a.sfd
	}

	echo "Processing u020a1_b ..."
	if ((Test-Path u020a1_b.sf) -and ((Get-Item u020a1_b.sf).Length -gt 0))
	{
		Move-Item -Force u020a1_b.sf u020a1.sf
		Move-Item -Force u020a1_b.sfd u020a1.sfd

		$rcmd = $env:QTP+ "u020b Y"
		Invoke-Expression $rcmd

		Move-Item -Force u020_tp.sf u020_tapeout_file_b
		Remove-Item u020_tp.sfd

		Move-Item -Force u020a1.sf u020a1_b.sf
		Move-Item -Force u020a1.sfd u020a1_b.sfd
	}

	echo "Processing u020a1_c ..."
	if ((Test-Path u020a1_c.sf) -and ((Get-Item u020a1_c.sf).Length -gt 0))
	{
		Move-Item -Force u020a1_c.sf u020a1.sf
		Move-Item -Force u020a1_c.sfd u020a1.sfd

		$rcmd = $env:QTP+ "u020b Y"
		Invoke-Expression $rcmd

		Move-Item -Force u020_tp.sf u020_tapeout_file_c
		Remove-Item u020_tp.sfd

		Move-Item -Force u020a1.sf u020a1_c.sf
		Move-Item -Force u020a1.sfd u020a1_c.sfd
	}

	echo "Processing u020a1_d ..."
	if ((Test-Path u020a1_d.sf) -and ((Get-Item u020a1_d.sf).Length -gt 0))
	{
		Move-Item -Force u020a1_d.sf u020a1.sf
		Move-Item -Force u020a1_d.sfd u020a1.sfd

		$rcmd = $env:QTP+ "u020b Y"
		Invoke-Expression $rcmd

		Move-Item -Force u020_tp.sf u020_tapeout_file_d
		Remove-Item u020_tp.sfd

		Move-Item -Force u020a1.sf u020a1_d.sf
		Move-Item -Force u020a1.sfd u020a1_d.sfd
	}

	echo "Processing u020a1_e ..."
	if ((Test-Path u020a1_e.sf) -and ((Get-Item u020a1_e.sf).Length -gt 0))
	{
		Move-Item -Force u020a1_e.sf u020a1.sf
		Move-Item -Force u020a1_e.sfd u020a1.sfd

		$rcmd = $env:QTP+ "u020b Y"
		Invoke-Expression $rcmd

		Move-Item -Force u020_tp.sf u020_tapeout_file_e
		Remove-Item u020_tp.sfd

		Move-Item -Force u020a1.sf u020a1_e.sf
		Move-Item -Force u020a1.sfd u020a1_e.sfd
	}

	if (Test-Path u020_tapeout_file_a -PathType Leaf)
	{
		Get-Content u020_tapeout_file_a | Set-Content u020_tapeout_file
	}

	if (Test-Path u020_tapeout_file_b -PathType Leaf)
	{
		Get-Content u020_tapeout_file_b | Add-Content u020_tapeout_file 2>$null
	}

	if (Test-Path u020_tapeout_file_c -PathType Leaf)
	{
		Get-Content u020_tapeout_file_c | Add-Content u020_tapeout_file 2>$null
	}

	if (Test-Path u020_tapeout_file_d -PathType Leaf)
	{
		Get-Content u020_tapeout_file_d | Add-Content u020_tapeout_file 2>$null
	}

	if (Test-Path u020_tapeout_file_e -PathType Leaf)
	{
		Get-Content u020_tapeout_file_e | Add-Content u020_tapeout_file 2>$null
	}

	if (Test-Path u020b.sf -PathType Leaf)
	{
		$rcmd = $env:QUIZ+ "r020_stale"
		Invoke-Expression $rcmd
	}

	if (Test-Path u020_tapeout_file -PathType Leaf)
	{
		&$env:cmd\ohip_convert_copy_to_tape
	}
}
param(
  [Parameter(Mandatory=$true)]
	[string]$assemblyPath
)

$binariesPath = $env:XOMNI_SDK_BINARIES_DIR
if($binariesPath -eq $null)
{
		Write-Host $binariesPath
		$binariesPath = "c:\xomni-binaries"
}

if(Test-Path $binariesPath)
{
		$fileNameToCopy = (Split-Path $assemblyPath -Leaf)
		$fullDestinationPath = (Join-Path $binariesPath $fileNameToCopy)
		if(Test-Path $fullDestinationPath)
		{
				Remove-Item $fullDestinationPath
		}
		
		Copy-Item $assemblyPath -Destination $binariesPath
}
param(
    [Parameter(Mandatory=$true)]
    [string]$assemblyPath
)

$copyPaths = @()
$semiColonSeperatedBinariesDir = $env:XOMNI_SDK_BINARIES_DIR
if($semiColonSeperatedBinariesDir -eq $null)
{
    $copyPaths += "c:\xomni-binaries"
}
else
{
    $copyPaths = $semiColonSeperatedBinariesDir.split(';')
}

$copyPaths | foreach {
    
    $binariesPath = $_
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
}
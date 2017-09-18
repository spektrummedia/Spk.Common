$path = '..\**\*.nuspec'
$nuget = '.\NuGet.exe'
$year = [System.DateTime]::Now.Year
$specFiles = Get-ChildItem $path -Recurse

foreach($file in $specFiles)
{
	$dll = $file.fullname.Replace($file.Name, "")
	$dll = $dll + "bin\release\" + $file.Name.Replace(".nuspec", ".dll")
	$version = [System.Reflection.Assembly]::LoadFile($dll).GetName().Version
	$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)
	Write-Host "Found " $versionStr " from " $dll
	& $nuget pack $file -properties "version=$versionStr;year=$year" -symbols
}
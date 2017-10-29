$initialLocation = Get-Location

Get-ChildItem test -Directory | ForEach-Object {
    cd $_.FullName
    OpenCover.Console.exe -register:user -target:"C:\Program Files\dotnet\dotnet.exe" -targetargs:"xunit -noshadow" -filter:"+[Spk.*]*" -output:".\coverage_result.xml"
}

cd $initialLocation

Get-ChildItem -File -Recurse coverage_result.xml | ForEach-Object {
    codecov -f $_.FullName -t $env:CODECOV_TOKEN
}
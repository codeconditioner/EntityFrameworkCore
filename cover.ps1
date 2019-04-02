$root = $PSScriptRoot

$testFiles = Get-ChildItem "$root\artifacts\bin\*Tests\Debug\net4*\*.Tests.dll" -recurse -include "*.Tests.dll" `
                | Sort-Object -Property Name -Unique

if (Test-Path results.xml) {
    Remove-Item results.xml
}

foreach ($file in $testFiles) {
    $target = (Get-Command xunit.console).Source
    $args = """$($file.FullName)"" -noshadow -xml ""$($file.Name).xml"""
    Write-Host "ARGS: $args"
    C:\tools\OpenCover.4.7.922\tools\OpenCover.Console.exe `
        -register:user `
        -filter:"+[Microsoft*]* -[*Tests]*" `
        -target:$target `
        -targetargs:$args `
        -mergeoutput `
        -output:results.xml
}

C:\tools\reportgenerator.4.0.15\tools\net47\ReportGenerator.exe `
    -reports:results.xml `
    -targetdir:c:\coveragereport `
    -reporttypes:HTMLSummary
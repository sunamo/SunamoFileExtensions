# Script to add XML documentation to public const fields in AllExtensions files
# This fixes CS1591 warnings

$projectPath = "E:\vs\Projects\PlatformIndependentNuGetPackages\SunamoFileExtensions\SunamoFileExtensions"
$files = @(
    "$projectPath\AllExtensions.cs",
    "$projectPath\AllExtensions1.cs",
    "$projectPath\AllExtensions2.cs",
    "$projectPath\AllExtensions3.cs",
    "$projectPath\AllExtensions4.cs",
    "$projectPath\AllExtensions5.cs"
)

foreach ($file in $files) {
    if (-not (Test-Path $file)) {
        Write-Host "File not found: $file" -ForegroundColor Yellow
        continue
    }

    Write-Host "Processing: $file" -ForegroundColor Green

    $content = Get-Content $file -Raw
    $lines = Get-Content $file
    $newLines = New-Object System.Collections.ArrayList

    $i = 0
    while ($i -lt $lines.Count) {
        $line = $lines[$i]

        # Check if this is an attribute line [TypeOfExtension(...)]
        if ($line -match '^\s*\[TypeOfExtension\(') {
            # Check if next line is a public const string without XML doc
            if ($i + 1 -lt $lines.Count) {
                $nextLine = $lines[$i + 1]
                if ($nextLine -match '^\s*public const string (\w+) = "\.(\w+)";') {
                    $fieldName = $Matches[1]
                    $extension = $Matches[2]

                    # Check if there's already XML doc before the attribute
                    $hasXmlDoc = $false
                    if ($i -gt 0) {
                        $prevLine = $lines[$i - 1]
                        if ($prevLine -match '^\s*///') {
                            $hasXmlDoc = $true
                        }
                    }

                    # Add XML doc if not present
                    if (-not $hasXmlDoc) {
                        $indent = if ($line -match '^(\s*)') { $Matches[1] } else { "    " }
                        [void]$newLines.Add("$indent/// <summary>")
                        [void]$newLines.Add("$indent/// File extension for .$extension files")
                        [void]$newLines.Add("$indent/// </summary>")
                    }
                }
            }
        }

        [void]$newLines.Add($line)
        $i++
    }

    # Write back to file
    $newLines | Set-Content $file -Encoding UTF8
    Write-Host "Updated: $file" -ForegroundColor Cyan
}

Write-Host "`nDone! XML documentation added to all public const fields." -ForegroundColor Green

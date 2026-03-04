# If you don't have access to powershell on your machine, please do not hesitate to fetch the docker image to do this exercice.
# The code below is an example on how to fetch the json from the endpoint.
# Please provide the proper code to have a display that matches the question.
$albumsDetail = Invoke-WebRequest -URI http://jsonplaceholder.typicode.com/albums | ConvertFrom-Json
$photoDetail = Invoke-WebRequest -URI http://jsonplaceholder.typicode.com/photos | ConvertFrom-Json


$joinData = $albumsDetail | Select-Object `
 @{Name = "AlbumId"; Expression = {$_.id}},
 @{Name = "AlbumTitle"; Expression = {$_.title}},
 @{Name = "PhotoCount"
    Expression = {
        $currentAlbumId = $_.id
        $match = $photoDetail | Where-Object {$_.albumId -eq $currentAlbumId}
        return @($match).Count
    }
}

$joinData | Sort-Object 'PhotoCount' -Descending | Select-Object -First 5 | Format-Table
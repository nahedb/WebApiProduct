param(
    [bool]
    $b = 0
)

if ($b){
    docker build --rm -t productive-dev/bnahed-api:latest .
}

docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 productive-dev/bnahed-api
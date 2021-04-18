command to build then run
`dotnet publish -c Release && docker build -t card-game:0.1 . && docker run card-game:0.1`
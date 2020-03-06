# Projekt do nauki architektury aplikacji net core


## Docker images
https://hub.docker.com/r/datalust/seq

https://hub.docker.com/_/rabbitmq

Format .yaml wymaga uwagi i odpowiednich "spacji" i poziomów - uwaga na taby itp. 
## Biblioteki

Serilog

Ważne jest, żeby wystawić contextAccessor do DI bo bez tego nie rejestuje się CorrelationId
https://github.com/ekmsystems/serilog-enrichers-correlation-id

## git - polecenia

    git init
    git add .
    git rm .
    git reset --hard
    git status

## dotnet polecenia
    dotnet new xunit -o Learncafe.TestUtilities --dry-run
    dotnet new -u

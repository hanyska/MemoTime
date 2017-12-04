FROM microsoft/dotnet
WORKDIR /dotnetapp
COPY ./bin/Docker .
ENV ASPNETCORE_ENVIRONMENT docker 
ENTRYPOINT dotnet MemoTime.Api.dll --urls "http://*:5050"


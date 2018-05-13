FROM microsoft/dotnet:2.1.300-rc1-sdk-alpine3.7 as web-builder
ADD . /code
WORKDIR /code/Names.Web
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:2.1.300-rc1-sdk-alpine3.7 AS api-builder
ADD . /code
WORKDIR /code/Names.API
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:2.1.0-rc1-aspnetcore-runtime-alpine3.7
WORKDIR /app
ADD ./nombres.db ..
COPY --from=api-builder /code/Names.API/out .
COPY --from=web-builder /code/Names.Web/out/Names.Web/dist ./wwwroot
COPY --from=web-builder /code/Names.Web/out/wwwroot/css ./wwwroot/css
COPY --from=web-builder /code/Names.Web/out/wwwroot/sample-data ./wwwroot/sample-data
ENTRYPOINT ["dotnet", "Names.API.dll"]
EXPOSE 5000/tcp

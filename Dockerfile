FROM microsoft/dotnet:2.1.300-rc1-sdk-alpine3.7 as web-builder
ADD . /code
WORKDIR /code/src/Names.Web
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:2.1.300-rc1-sdk-alpine3.7 AS api-builder
ADD . /code
WORKDIR /code/src/Names.API
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore

FROM microsoft/dotnet:2.1.0-rc1-aspnetcore-runtime-alpine3.7
WORKDIR /app
RUN mkdir /app/release
RUN mkdir /db
ADD ./db/nombres.db ../db
WORKDIR /app/release
COPY --from=api-builder /code/src/Names.API/out .
COPY --from=web-builder /code/src/Names.Web/out/Names.Web/dist ./wwwroot
COPY --from=web-builder /code/src/Names.Web/out/wwwroot/css ./wwwroot/css
COPY --from=web-builder /code/src/Names.Web/out/wwwroot/js ./wwwroot/js
COPY --from=web-builder /code/src/Names.Web/out/wwwroot/data ./wwwroot/data
COPY --from=web-builder /code/src/Names.Web/out/wwwroot/images ./wwwroot/images
COPY --from=web-builder /code/src/Names.Web/out/wwwroot/vendor ./wwwroot/vendor
ENTRYPOINT ["dotnet", "Names.API.dll"]
EXPOSE 5000/tcp

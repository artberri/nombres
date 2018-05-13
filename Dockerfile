FROM microsoft/dotnet:2.1.300-rc1-sdk-alpine3.7 as builder
ADD . /code

WORKDIR /code/Names.Web
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore
# RUN dotnet run

FROM nginx
COPY --from=builder /code/Names.Web/bin/Release/netstandard2.0/dist /usr/share/nginx/html

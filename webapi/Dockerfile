# Sample contents of Dockerfile
 # Stage 1
 FROM microsoft/aspnetcore-build AS builder
 WORKDIR /UpcomingMovies.Api
    RUN ls
 # caches restore result by copying csproj file separately
 COPY . .   
 RUN ls
 RUN dotnet restore

 # copies the rest of your code
 COPY . .
 RUN dotnet publish --output /app/ --configuration Release

FROM microsoft/aspnetcore
WORKDIR /app+
COPY --from=builder /app .
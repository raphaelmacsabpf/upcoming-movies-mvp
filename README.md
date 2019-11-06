# upcoming-movies-mvp
Repository for Upcoming Movies Web Application

#  Run

## Front End

```shell
cd frontend
npm install
ng serve
```

## Back End

First copy Server Side Rendered files in frontend/dist to backend/UpcomingMovies.Api/wwwroot folder
```shell
cd webapi/UpcomingMovies.Api
dotnet run
```

## In Docker Compose (optional)

```shell
docker-compose up --build -d
```
Open your browser and go to http://localhost:4200

# Main tools and libraries

## Front End
• Angular 7 - Main frontend library\
• RxJS - Observable collections\
• Angular Material - Material Design components for Angular

## Back End
• ASP .NET Core 2.0 - Back End Host\
• AutoMapper - Auto mapping class library\
• Newtonsoft.Json - Serialize & deserialize JSON
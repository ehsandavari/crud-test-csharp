FROM mcr.microsoft.com/dotnet/sdk:6.0 as buildEnv

WORKDIR /src

COPY ./Application/Application.csproj ./Application/Application.csproj

COPY ./Domain/Domain.csproj ./Domain/Domain.csproj

COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/Infrastructure.csproj

COPY ./Persistence/Persistence.csproj ./Persistence/Persistence.csproj

COPY ./Presentation/Presentation.csproj ./Presentation/Presentation.csproj

RUN dotnet restore ./Presentation/Presentation.csproj

COPY . .

WORKDIR /src/Presentation

RUN dotnet publish -c Release -o ./output

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=buildEnv /src/Presentation/output ./

ENTRYPOINT dotnet Presentation.dll
 

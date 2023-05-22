# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos de projeto para o diretório de trabalho
COPY TesteProgramacaoMF.Core/TesteProgramacaoMF.Core.csproj TesteProgramacaoMF.Core/
COPY TesteProgramacaoMF.Profissionais.Application/TesteProgramacaoMF.Profissionais.Application.csproj TesteProgramacaoMF.Profissionais.Application/
COPY TesteProgramacaoMF.Profissionais.Data/TesteProgramacaoMF.Profissionais.Data.csproj TesteProgramacaoMF.Profissionais.Data/
COPY TesteProgramacaoMF.Profissionais.Domain/TesteProgramacaoMF.Profissionais.Domain.csproj TesteProgramacaoMF.Profissionais.Domain/
COPY TesteProgramacaoMF.WebApp.MVC/TesteProgramacaoMF.WebApp.MVC.csproj TesteProgramacaoMF.WebApp.MVC/

# Restaura as dependências dos projetos
RUN dotnet restore TesteProgramacaoMF.WebApp.MVC/TesteProgramacaoMF.WebApp.MVC.csproj

# Copia todo o código-fonte para o diretório de trabalho
COPY . ./

# Publica o projeto principal
RUN dotnet publish TesteProgramacaoMF.WebApp.MVC/TesteProgramacaoMF.WebApp.MVC.csproj -c Release -o out

# Define a imagem base para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos publicados para o diretório de trabalho
COPY --from=build /app/out ./

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "TesteProgramacaoMF.WebApp.MVC.dll"]

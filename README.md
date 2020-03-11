# Mentoria DB1
## Objetivo

1. Entender os conceitos de docker aplicados em produção;
2. Como funciona o docker compose em ambientes de desenvolvimento e produção;
3. Criar um dockerfile para encapsular as aplicações dotnet e realizara correção de problemas
4. Criar um docker compose capaz de subir uma aplicação dotnet que realize acesso a dados
5. Entender os conceitos mais avançados de CQRS e Arquitetura de aplicações;
6. Criar uma aplicação exemplo com os conceitos aprendidos;

## Docker 
Durante a mentoria foi realizado um treinamento prático de docker no qual foi mostrados os principais comandos executados no docker para execução e monitoramento de containers. Através da mentoria hoje sou capaz de entender e criar as imagens próprias para cada aplicação através de um Dockerfile e entender como o mesmo é aplicado em um ambiente de produção.
Comandos

### Containers
- docker ps -a
	- -a: lista os containers em execução e os parados
- docker run <nome ou código da imagem>:<opcional colocar a tag> -p <PortaContainer:PortaHost> --rm
- docker rm <nome ou codigo do container>
- docker start <nome ou codigo do container>
- docker stop <nome ou codigo do container>
- docker logs <nome ou codigo do container>
- docker build -t <o nome da imagem a ser gerada> .

### Imagens
- docker images
- docker rmi <nome ou código da imagem>
- docker pull <nome ou código da imagem>

### Dockerfile
- FROM <imagem> AS <nome escolhido para a nova imagem a ser gerada>
- WORKDIR <pasta de trabalho no container>
- ENV <Variaveis de ambiente>
- EXPOSE <porta do container a ser aberta para o host>
- COPY <arquivos do hopst a ser copiado> <pasta do container que receberá os arquivos>
- RUN <comando a ser executado no container>
- ENTRYPOINT <permite a configuracao de um container no momento que é executado>
O que foi executado com os conceitos aprendidos?

Com os conceitos aprendidos foi criado um docker file para criar uma imagem com uma aplicação dotnet e a identificação de problemas assim como a sua resolução.

### Dockerfile desenvolvido através da mentoria

```
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN ls .
RUN dotnet restore "Restaurante.Api/Restaurante.Api.csproj"
WORKDIR "/src/Restaurante.Api"
RUN dotnet build "Restaurante.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurante.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurante.Api.dll"]
```

---
## Docker Compose

Foi demonstrado que o docker compose é uma ferramenta indispensável para criar uma aplicação resiliente, através da conexão de vários containers para criar uma aplicação modular e assim separar a responsabilidade de cada parte da aplicação(frontend, backend, infraestrutura e acesso a dados).

### Comandos

docker-compose up -d
docker-compose down
docker stack ls

docker-compose.yml
version: <versao do docker-compose a ser utilizada>

services: -> indica os serviços a serem executados
   <nome do serviço, o usuário escolhe>: 
     image: <imagem a ser utilizada>
     container_name: <nome do container a ser criado>
     depends_on: <serviços que o container utilizará, esses serviços são criados no próprio docker file>
       - <nome do serviço>
     ports:
       - <porta do container a ser aberta>:<porta do host que será mapeada para o container>

### O que foi executado com os conceitos aprendidos?

Com os conceitos aprendidos foi criado um docker file para criar uma imagem com uma aplicação dotnet e a identificação de problemas assim como a sua resolução.
docker-compose.yml desenvolvido através da mentoria

```
version: '3.4' 

services:
   restauranteapi:
     image: image_restaurante:latest
     container_name: estudos_mentoria_compose
     depends_on:
       - sqlserver
     ports:
       - "5000:5000"

   sqlserver:
     image: microsoft/mssql-server-linux:latest
     container_name: sqlserver
     ports:
       - "1433"
     volumes:
       - 'C:\DockerData\mssql:/var/opt/mssql/data'
     environment:
       - ACCEPT_EULA=Y
       - SA_PASSWORD=docker123!
```

---
## CQRS e Arquitetura

Aqui foi demonstrado e discutido diferente tipos de arquitetura e padrões de projetos aplicados em arquitetura de aplicações escaláveis e a aplicação dos containers e do docker-compose na estrutura de uma aplicação

### Conceitos abordados:

- DDD - Domain - Driven Design;
- CQRS - Command Query Responsibility Segregation;
- TDD - Test-driven development;
- Métodos de sincronização de dados entre os bancos de leituras e escrita do CQRS;

### Conceitos ensinados

Durante a monitoria foi passado um conjunto de palestras com diferentes implementações do CQRS. Depois de assistir as duas palestras foir realizado um levantamento das diferenças entre as abordagens utilizadas nas palestras e discutidos as diferentes abordagens com duas vantagens e desvantagens.

Depois de apontar as diferenças foi orientado a criação de uma aplicação utilizando os conceitos aprendidos e não deveria ser utilizado um projeto pronto e sim criar um do zero baseado nos conceitos ensinados. 

A aplicação escolhida foi um cardápio ou livro de receitas online. Os endpoints necessários são:
- [x] Categoria de ingredientes;
- [ ] Ingrediente;
- [ ] Receitas;
- [ ] Passos;
- [ ] Porções;

A aplicação desenvolvida foi dividida da seguinte maneira:
- uma camada para a o usuário;
- uma camada para aplicação;
- uma camada para o domínio;
- uma camada para a persistência de dados;
- um teste de integração;
- um teste de unidade;

A aplicação pode ser encontrada no github:

## Próximas etapas definidas pelo Mentor:

- [ ] Aplicar um banco de leitura(NoSQL) para o projeto;
- [ ] Testar os métodos de sincronização entre os bancos de escrita e leitura:
	- [ ] Síncrono;
	- [ ] Assíncrono;
	- [ ] Agendado
	- [ ] Sobe Demanda;
- [ ] Aplicar uma solução de mensageiria para eventos;
- [ ] Separar o acesso a dados em um docker próprio;

## Próximas etapas definidas pelo Mentorado:

- [ ] Configurar um CI/CD para a aplicação;
- [ ] Configurar um ambiente Cloud (Azure) para o projeto;
- [ ] Configurar um ambiente Cloud (AWS) para o projeto;
	

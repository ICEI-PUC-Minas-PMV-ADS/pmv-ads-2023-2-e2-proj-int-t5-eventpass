# Configuração do ambiente SQL no Ubuntu

## Criar o container SQL Server
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Jul14Chave$" -e "MSSQL_PID=Developer" -p 1433:1433  --name sqlserver --hostname sqlserver -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
```

## Listar containers
```
docker ps
docker ps -a
```

## Parar e iniciar container
```
docker stop <container-name> (sqlserver)
docker start <container-name> (sqlserver)
```

## Remover container
```
docker rm <container-name> (sqlserver)
```

## Criar database
```
create database Eventpass;
```

## Rodar migrações de banco
```
dotnet ef database update
```

## Iniciar aplicação em modo Development
```
dotnet run --environment Development
```
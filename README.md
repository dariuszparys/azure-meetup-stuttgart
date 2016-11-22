# Deployment steps

This demo should be deployed to Azure AppService for Linux inside a custom container.

## Docker Hub Account

The easiest is to get an docker hub repository. To create an image follow the repository instructions on the Docker website. The following steps are used to create this repository into an docker container.

```
dotnet build

dotnet publish -c release -o output

copy Dockerfile output

cd output

docker build -t writeline/some-repository:1.0 .

docker push writeline/some-repository:1.0
```

## Azure AppService for Linux

With the published docker container on docker hub you can simply create the AppService and specify the container resource. After that it should just work.


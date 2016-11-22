FROM microsoft/aspnetcore
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "SimpleApp.dll"]

# docker build -t myapp .

# docker run -d -p 8000:80 myapp

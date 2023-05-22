set "diretorio_atual=%CD%"

docker compose up -d

start "TesteProgramacaoMF" http://localhost:8080/

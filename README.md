API Posição Consolidada
==============

API tem como finalidade consolidar as posições em diversos tipo de investimentos

Tecnologia
------------------------------

- .Net Core 2.1 (Habilitado para rodar em docker Linux)
- [Serilog](https://serilog.net/)
- [Restsharp](https://restsharp.dev/) 
- Implementação de memory cache para as chamadas das apis
- Autenticação via token Bearer

Arquitetura
------------

Foi definida da seguinte forma:

- Business - Onde será implementada todas as classes com as regras de negócio.
- ExternalService - Onde será feita todas as chamadas de serviços externos
- Domain - Onde será armazenado todos os mapeamentos de domínio
- Test - Testes de Unidade
- API - Controlador principal e endpoints

[![Build Status](https://ci-next.docker.com/public/buildStatus/icon?job=compose/master)](https://ci-next.docker.com/public/job/compose/job/master/)

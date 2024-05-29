# MediatR Lib - Implementation sample

O padrão Mediator é um padrão de projeto comportamental (GoF) que já abordei em um artigo anterior: "O padrão de projeto Mediator". A aplicação deste padrão nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação, permitindo que um objeto se comunique com outros sem conhecer sua estrutura. Além disso, centraliza o fluxo de comunicação entre os objetos, facilitando sua manutenção.

Neste repositório você encontrará uma implementação deste padrão em uma aplicação ASP .NET Core utilizando a biblioteca MediatR que foi criada por Jimmy Bogard e que pode ser obtida via Nuget.

Para baixar os pacotes, basta adicionar os pacotes no NuGet:

`
Install-Package MediatR
Install-Package MediatR.Extensions.Microsoft.DependencyInjection
`

O primeiro pacote é o MediatR, enquanto o segundo é usado para gerenciar suas dependências. Se a sua aplicação tiver um grande fluxo de requisições entre os objetos, o objeto mediator pode se tornar um gargalo. Para contornar isso, é comum implementar o CQRS (Command Query Responsibility Segregation), que em português significa Segregação de Responsabilidade de Comando e Consulta.

## CQRS

O CQRS é mais um padrão de projeto separa as operações de leitura e de escrita da base de dados em dois modelos:

1. Queries - São responsáveis pelas leituras ou consultas e retornam objetos DTOs ou ViewModels e não alteram o estado dos dados;
 
2. Commands - São responsáveis pelas ações que realizam alguma alteração na base de dados e não retornam nada.(operações para incluir, alterar e deletar). Para gerenciar a comunicação entre os objetos nos Commands usamos o Mediator.

IMPORTANTE: não precisamos do padrão Mediator para implementar o padrão CQRS.

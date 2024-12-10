# Tech Challenger - Serviço de Processamento em Lote

# Introdução

Temos a necessidade de realizar mais de um cadastro ao mesmo tempo, pensando nisso, gostariamos de manter nossa aplicação escalável,
sem diminuir a performace da nossa aplicação principal, assim sendo, é interessante o envio em lote para o rabbitMQ de novos contatos para cadastramento.

# Processamento em Lote

- **Função**: Este serviço consome os contatos recebidos e realiza um pré-processamento dos dados, agrupando-os em lotes para melhor performance e organização.
- **Processo**:
  - Recebe mensagens da fila `fila-processamento`.
  - Processa as mensagens em lotes para não sobrecarregar o sistema principal.

# Tecnologias Utilizadas:

- **.NET 8**: Framework para construção da Minimal API.
- **C#**: Linguagem de programação usada no desenvolvimento do projeto.
- **RabbitMQ**: Broker para o gerenciamento das mensagens.
- **WorkerService**: Broker para o gerenciamento das mensagens.

# Documentação

- [Documentação da API](https://horse-neon-79c.notion.site/Documenta-o-da-API-04183b890d7c47cb89af4445d01d6678?pvs=4)
- [Documentação de Estilo para C#](https://horse-neon-79c.notion.site/Documenta-o-de-Estilo-para-C-de62b229fd01436a96f7a090b4d11e27?pvs=4)
- [Documentação dos Testes](https://horse-neon-79c.notion.site/Documenta-o-dos-Testes-a402a32a16a24b1b925dab83201e7d19?pvs=4)
- [Documentação de Banco de Dados](https://horse-neon-79c.notion.site/Documenta-o-de-Banco-de-Dados-6ba60c4c8533491a9d28da71f6b57c93?pvs=4)
- [Guia de Estrutura do Projeto](https://horse-neon-79c.notion.site/Guia-de-Estrutura-do-Projeto-fbfbc24c616d456bb56306cfda2c0bc9?pvs=4)

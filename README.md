# CleanWave API

## Descrição do Projeto
Para a solução desta Global Solution, nós do grupo pensamos em como reduzir a poluição marinha usando tecnologia, para isso criaremos um aplicativo/site onde abrirá portas para muitas pessoas começarem a se preocupar com os oceanos de todo o planeta, que ocupam 70% da superfície terrestre.
Nosso aplicativo terá o intuito de conscientizar mais pessoas para cuidar do meio ambiente, para isso criaremos lixeiras inteligentes que ficarão em vários pontos de coleta nas praias. Para as pessoas que reciclarem os lixos (ex. saquinhos de sorvete, plásticos, descartáveis...), a lixeira inteligente detecte o material/item jogado por meio de uma câmera ou QRCODE e isso será computado e armazenado no nosso sistema, para fazer com que as pessoas comecem a reciclar mais, nesse aplicativo teremos uma funcionalidade para o usuário ganhar créditos conforme fosse reciclando e jogando o lixo na nossa lixeira inteligente, assim trocando por consumos na praia como, sorvetes, cervejas e aperitivos.
Acreditamos ser uma ideia inovadora e que chamará muitas pessoas de diversas idades para começarem a dar valor para nossos oceanos e ajudar o próximo.


## Principais Funcionalidades

- **Cadastro de Usuários:** Permite o registro e a gestão de usuários que utilizam o sistema.
  
- **Gerenciamento de Lixeiras:** Controla a localização e os itens depositados nas lixeiras inteligentes.
  
- **Registro de Pontos:** Acompanha e registra os pontos acumulados pelos usuários ao depositarem itens recicláveis nas lixeiras.
  
- **Integração com Banco de Dados Oracle:** Utiliza o Entity Framework para gerenciar as operações de banco de dados.
  
- **Documentação da API com Swagger:** Fornece uma interface interativa para testar os endpoints da API.


## Como Executar o Projeto ?

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Banco de Dados Oracle](https://www.oracle.com/database/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

### Mostraremos o Passo a Passo!!!

1. **Clone o repositório:**
   
   abra o Bash
   
   git clone https://github.com/erictamada/CSGlobalSolution.git
   
   cd CSGlobalSolution



2. **Configuração do Banco de Dados:**

    Certifique-se de que o banco de dados Oracle está instalado e em execução, no nosso caso, usamos o SQLDEVELOPER para a integração ao database.

    Crie um usuário e um esquema para o projeto.
   


3. **Configuração da String de Conexão ao Banco de Dados da Oracle**

   Vamos editar o arquivo appsettings.json com as credenciais do banco de dados Oracle:
   
      {
        "ConnectionStrings": {
          "OracleDbConnection": "Data Source=SeuOracleDB/orcl;User Id=SeuUserID; Password=SuaSenha;"
        },
        "Logging": {
          "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
          }
        },
        "AllowedHosts": "*"
      }



4. **Agora vamos aplicar as Migrations!**
   
      No Package Manager Console do Visual Studio, vamos executar os seguintes comandos:
   
      Add-Migration InitialCreate
   
      Update-Database



5. **Por fim executaremos a aplicação :)**

     No Visual Studio, selecionaremos a opção de execução 'CleanWaveAPI'.

     Assim, a nossa aplicação será iniciada abrindo o Swagger no 'https://localhost:5001/swagger'.

     Ficará assim:

![image](https://github.com/erictamada/CSGlobalSolution/assets/136273097/99046da3-925c-42a3-8e63-34196f6dbde0)


## Estrutura do Projeto CleanWave

    - Controllers: Onde estará os controladores da API.

    - Models: Onde estará os modelos de dados.

    - Data: Onde estará o contexto do Banco de Dados e as configurações de Migrações.


### Endpoints da API

    Usuários:
    
    - GET /api/Usuarios - Retorna todos os usuários.
    
    - GET /api/Usuarios/{id} - Retorna um usuário específico pelo ID.
    
    - POST /api/Usuarios - Cria um novo usuário.
    
    - PUT /api/Usuarios/{id} - Atualiza um usuário existente.
    
    - DELETE /api/Usuarios/{id} - Exclui um usuário específico pelo ID.

    ![image](https://github.com/erictamada/CSGlobalSolution/assets/136273097/c7258999-dc64-4168-bc57-b524735b185b)


    Lixeiras:

    - GET /api/Lixeiras - Retorna todas as lixeiras.
    
    - GET /api/Lixeiras/{id} - Retorna uma lixeira específica pelo ID.
    
    - POST /api/Lixeiras - Cria uma nova lixeira.
    
    - PUT /api/Lixeiras/{id} - Atualiza uma lixeira existente.
    
    - DELETE /api/Lixeiras/{id} - Exclui uma lixeira específica pelo ID.

    ![image](https://github.com/erictamada/CSGlobalSolution/assets/136273097/7ffd3c7d-d2ef-4f57-8e87-43be72e8b6c4)


    Pontos:

    - GET /api/Lixeiras - Retorna todas as lixeiras.
    
    - GET /api/Lixeiras/{id} - Retorna uma lixeira específica pelo ID.
    
    - POST /api/Lixeiras - Cria uma nova lixeira.
    
    - PUT /api/Lixeiras/{id} - Atualiza uma lixeira existente.
    
    - DELETE /api/Lixeiras/{id} - Exclui uma lixeira específica pelo ID.

    ![image](https://github.com/erictamada/CSGlobalSolution/assets/136273097/45ebefd5-49a5-4961-93d2-67f285cb13ec)


    Itens da Lixeira:

    - GET /api/ItensLixeira - Retorna todos os itens das lixeiras.
    
    - GET /api/ItensLixeira/{id} - Retorna um item específico pelo ID.
    
    - POST /api/ItensLixeira - Cria um novo item.
    
    - PUT /api/ItensLixeira/{id} - Atualiza um item existente.
    
    - DELETE /api/ItensLixeira/{id} - Exclui um item específico pelo ID.

    ![image](https://github.com/erictamada/CSGlobalSolution/assets/136273097/d7eebc4c-1c00-4ffc-a3a8-22839e5ed727)



### Conclusão

    O projeto CleanWave API proporciona uma solução completa para a gestão de 
    lixeiras inteligentes, incentivando a reciclagem e a conscientização ambiental. 
    Com uma arquitetura bem definida, integração com banco de dados Oracle e documentação abrangente via Swagger, 
    a aplicação está pronta para ser utilizada e expandida conforme necessário.

    
## Integrantes do Grupo

    RM97160 - Thomaz Bernardes
    
    RM97316 - Eric Tamada
    
    RM96696 - Kauã Menezes
    
    RM97027 - Igor Carvalho




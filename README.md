Instruções para Configuração e Execução Local do Projeto

Este guia oferece instruções detalhadas para configurar e executar localmente tanto o back-end quanto o front-end do projeto. Siga cada passo cuidadosamente para garantir um ambiente de desenvolvimento funcional.

Configuração e Execução Local do Back-End:

Configurar o Banco de Dados SQL Server:

Certifique-se de que o SQL Server esteja em execução localmente ou no Docker. Utilize o comando docker-compose up -d para iniciar um contêiner Docker com o SQL Server. O usuário é sa, e a senha é example_123. Configurar a Conexão com o Banco de Dados:

Abra o arquivo appsettings.json no projeto do back-end. Verifique e ajuste, se necessário, a string de conexão com o banco de dados. Executar o Back-End:

Abra o projeto do back-end em um ambiente de desenvolvimento integrado (IDE) e execute o aplicativo.

Configuração e Execução Local do Front-End: Instalar o Angular CLI:

Instale o Angular CLI globalmente com o comando npm install -g @angular/cli@12.2.13. Clonar o Repositório do Front-End:

Clone o repositório do front-end para o seu ambiente local. Instalar Dependências do Front-End:

Navegue até o diretório do projeto do front-end no terminal e execute npm install. Configurar o Back-End no Front-End:

Abra o arquivo de configuração do ambiente (environment.ts) e ajuste a URL do back-end para https://localhost:7171/api. Executar o Front-End:

No terminal, dentro do diretório do projeto do front-end, execute ng serve. Acessar o Aplicativo Localmente:

Abra um navegador e acesse http://localhost:4200/.

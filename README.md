<h1>API Infectados covid-19</h1>
<p>
    Este projeto consiste em uma API para cadastro e gerenciamento de dados de infectados pela covid-19. O projeto foi desenvolvido em .NET  com integração ao banco de dados MongoDB.
</p>
<h2>Funcionalidades</h2>
<p>A API desenvolvida possui as seguintes funcionalidades:</p>
<ul>
    <li>Cadastro de infectados;</li>
    <li>Listagem dos infectados;</li>
    <li>Atualização de dados do infectado;</li>
    <li>Deletar um infectado;</li>
    <li>Marcar infectado como curado.</li>
</ul>
<p>
    O projeto foi documentado utilizando <a href="https://swagger.io/">Swagger</a> e  suas rotas podem ser acessadas ao rodar a aplicação em modo debug:
</p>
<img src="https://github.com/AnaPaulaMenezes/ApiMongo/blob/master/images/Swagger.JPG"/>

<h2>Instalação</h2>
<ul>
    <li><a href="https://www.mongodb.com/cloud/atlas">Crie uma conta no mongoDB atlas</a> e siga o passo a passo para <a href="https://docs.atlas.mongodb.com/tutorial/create-new-cluster/">criar um cluster</a>;</li>
    <li>Clone este repositorio;</li>
	<li>Acesse o arquivo "appsettings.example.json", localizado na raiz do projeto, e preencha o campo  "ConnectionString" com a string de conexão do MongoDB;</li>
	<li>Altere o nome do arquivo para "appsettings.json;"</li>
    <li>Rode o projeto em modo debug utilizando a tecla "F5", para visualizar a documentação da API.</li>
</ul>


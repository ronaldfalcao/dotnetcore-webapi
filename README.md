# Exemplo de WEBApi com .NET Core (versão 2 preview)
Passo longe de ser um conhecedor de .NET, mas achei interessante a ideia de ter o dotnet Core para Linux. Por isso fiz um pequeno exemplo mostrando como criar uma estrutura simples de API e seu consumo.

## Porque usei o VSCode para o exemplo?
Pensei sobre isso e tive certa dificuldade em configurar o Sublime para fazer esse teste. Instalar os plugins e tudo mais não foi tão fácil como pensei. Outro ponto, parti do pressuposto que uma ferramenta mantida com apoio da Microsoft seria mais adequada para desenvolver com C# no .NET Core. Realmente foi, abri a pasta e já foram carregados os plugins necessários para C#, assim como o ambiente de debug e build. Facilitaram meu trabalho, e precisei debugar muito :-)

## Ambiente de Desenvolvimento Linux/Microsoft
A instalação do dotnet Core no Linux (no meu caso Ubuntu) foi bem fácil. Você pode ver isso em https://www.microsoft.com/net/core#linuxubuntu

O VSCode também não traz dificuldades na sua instalação, basta seguir os passos indicados em https://code.visualstudio.com/docs/setup/linux. Não tem respositório e precisa baixar o arquivo, mas o próprio VSCode se encarrega das atualizações.

## Agora à Prática

Crie a pasta do seu projeto
<pre><code>mkdir ApiRestQuadrado</code></pre>

Vamos iniciar o VSCode abrindo a pasta atual
<pre><code>code .</code></pre>

Entre na pasta criada (cd) e crie a solução principal do projeto
<pre><code>dotnet new sln -n ApiRestQuadrado</code></pre>

Como saída vocẽ deve ter um arquivo chamado *ApiRestQuadrado.sln*. Não tenho conhecimento técnico para discutir esse arquivo, por isso, só aceitei sua criação.Agora vamos criar a biblioteca de classes (classlib) Quadrado
<pre><code>dotnet new classlib -n Quadrado</code></pre>

Vamos agora adicionar a classlib Quadrado à solução principal
<pre><code>dotnet sln Quadrado/Quadrado.csproj</code></pre>

Entre na pasta, precisamos agora atualizar as dependências da classlib
<pre><code>dotnet restore</code></pre>

O dotnet cria o arquivo padrão dentro dessa pasta, *Class1.cs*. Alterei para *QuadradoClasse.cs*. O conteúdo dessa classe se encontra no arquivo de mesmo nome versionado. Hora do build!!!!
<pre><code>dotnetbuild</code></pre>

Caso tenha cometido algum erro você pode debugá-lo utilizando a aba Debug Console do VS Code, ou pela saída do terminal. Como não tenho intimidade com a ferramenta recorri ao terminal mesmo. Vamos criar agora nossa webAPI
<pre><code>dotnet new webapi -n ApiQuadrado</code></pre>

Precisamos vincular nossa webAPI ao projeto principal
<pre><code>dotnet sln add ApiQuadrado/ApiQuadrado.csproj</code></pre>

Entrando na pasta criada (ApiQuadrado) vamos inserir a referência para a nossa classlib Quadrado
<pre><code>dotnt add reference ../Quadrado/Quadrado.csproj</code></pre>

Atualizando as dependências da nossa webAPI
<pre><code>dotnet restore</code></pre>

Aqui também foi criado o arquivo default *ValuesController.cs* na pasta *Controllers*, vamos mudei seu nome para *AreaQuadrado.cs*. O conteúdo desse arquivo também se encontra aqui no código versionado. Finalmente podemos rodar nosso projeto.
<pre><code>dotnet run</code></pre>

Por default o dotnet Core usa a porta 5000 em localhost, para acessar nossa webAPI basta inserir a seguinte URL no navegador
<pre><code>http://localhost:5000/api/AreaQuadradoExemplo/Lado/{valor do lado}</code></pre>

![Saída da API](https://github.com/ronaldfalcao/dotnetcore-webapi/blob/master/quadrado-sa%C3%ADda-navegador.png)


O seu retorno deve ser o valor do lado do quadrado e sua área. Muito útil :-)

## Conclusões
Desenvolver em .NET Core em ambiente Linux não é algo que os desenvolvedores tradicionais dessa linguagem devam amar. Principalmente pelo fato do Linux ainda não ter uma IDE a altura do Visual Studio. Mas vejo algum futuro para o framework no mundo opensource, principalmente na questão de serviços. Apesar do exemplo tosco que fiz ele dá uma ideia de como fornecer serviços em ambientes Linux, o que é uma ótima alternativa para quem quer um ambiente leve, elástico e de baixo custo. 

### Fontes
* http://www.c-sharpcorner.com/article/create-your-first-asp-net-core-application-on-ubuntulinux/
* https://docs.microsoft.com/en-us/aspnet/core/tutorials/your-first-mac-aspnet
* https://medium.com/@felipedutratine/how-to-code-and-host-a-dotnet-core-webapi-on-a-linux-container-b8a459b00fa7
* https://jonhilton.net/2016/10/19/creating-a-new-net-core-web-application-what-are-your-options/
* https://youtu.be/rxazv8KcyRU


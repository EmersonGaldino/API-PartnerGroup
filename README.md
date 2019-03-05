# API-PartnerGroup
Projeto teste Partner Group

-- Desenvolvimento do projeto -- 

Dentro da solução do projeto WEB API criei uma pasta com o nome de AcessoDados, dentro da pasta criei uma classe chamada
AcessoDadosADONet. Essa classe contem a string de conexao com o banco de dados e os metodos que retornam um conexao, um comando e DataReader.

Na pasta Models crier os modelos marca e patrimonio.

Criei uma outra pasta chamada Repositorios que contem uma interface chamada IRepositorio, essa inteface com um parametro generico contem os metodos
de Inserção, Alteração, Exclusão e seleção de dados. A pasta também contem duas classes repositorioMarca e repositorioPatrimonio, essas classes
implementam os metodos da Interface.

Na classe WebApiConfig que fica na pasta App_Start, declarei uma variavel do tipo GlobalConfiguration e chamei o metodo Remove, para remover o formato XML
e exibir sem o formato Json.

Na pasta Controllers criei dois controllers, o controller Marca e o controller Patrimonio.

Obs: Infelizmente não consegui implementar o GET com os patrimonios da Marca, porem de qualquer forma achei melhor entregar o projeto.


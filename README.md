# Cálculo de juros composto

Esta solução contém duas APIs para o cálculo de juros compostos. 
<h2>APITaxaJuros</h2>
  Retorna o valor da taxa de juros.
<h2>APICalculoJuros</h2>
  Realiza o cálculo dos juros compostos baseado no valor inicial e no meses. Este endpoint se comunica com a APITaxaJuros para obter o valor da taxa de juros para o cálculo.

# Detalhes da implementação

Essa aplicação foi desenvolvida em [.Net 5.0](https://dotnet.microsoft.com/download/dotnet/5.0). Para rodar é necessário uma máquina contendo o [Docker](https://www.docker.com). 
Para os testes de unidade foi utilizado o [XUnit](https://github.com/xunit/xunit). Para testes da API foi utilizado a ferramenta [SOAPui](https://www.soapui.org/). 

# Como instalar

Após a instalação do [Docker](https://www.docker.com/products/docker-desktop) é necessário realizar o download do projeto:

```
1. git clone https://github.com/mguollo/APITaxaJurosComposto.git
2. cd APIJurosComposto
3. docker-compose build
4. docker-compose up
```

A APITaxaJuros estará acessivel na porta 7000. 

A APICalculoJuros estará acessivel na porta 7001.

# Como utilizar

O Swagger foi utilizado para a documentação da API. Dessa forma pode ser verificado a partir dos endereços http://localhost:7000/swagger/index.html e http://localhost:7001/swagger/index.html todos os métodos disponíveis para uso.

**APITaxaJuros**
Endpoints
  - /TaxaJuros
Requisição GET no endereço http://localhost:7000/TaxaJuros.
Retornará um JSON com a chaave TaxaJuro contendo o valor da taxa de juros.

**APITaxaJuros**
Endpoints
  - /CalculaJuros
  - /ShowMeTheCode

**/CalculaJuros**
Requisição GET no endereço http://localhost:7001/CalculoJuros com os parametros ValorInicial(double) e Meses(inteiro)
Exemplo:
```
http:localhost:7000/calculajuros?valorinicial=100&meses=5
```
Retornará o valor da taxa de juros.

**/ShowMeTheCode**
Requisição GET no endereço http://localhost:7001/ShowMeTheCode.
Retornará o endereço do repositório no GIT.

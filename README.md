# Jogo da Forca

<p align="center">
	<img width="650" src="docs/img/Tempo-Resposta.gif">
</p>

## Projeto

Desafio desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Detalhes

O computador receber� uma sequ�ncia de comandos referentes � mensagens trocadas entre Sara e seus amigos. Cada amigo recebe uma numera��o e a sequ�ncia de eventos recebida informa se a mensagem foi recebida ou enviada.

O intuito deste programa � informar o tempo que Sara demora para responder cada um dos seus amigos.

---
## Entrada

Sara deve informar a sequ�ncia de mensagens trocadas e o tempo demorado, se este for superior a 1 segundo.

---
## Funcionalidades

- __N�mero de eventos__: A primeira linha fornecida deve informar o n�mero de mensagens trocadas entre Sara e seus amigos;
- __Natureza dos eventos__: Cada informa��o fornecida ao programa deve iniciar com as letras "R", "E" ou "T", indicando que a mensagem foi recebida, enviada ou qual o tempo de demora entre um evento e outro, respectivamente;
- __Identifica��o dos amigos__: Seguindo a letra que descreve a natureza do evento, dever� ser informado o amigo em quest�o. Para isso, cada amigo recebe uma numera��o de identifica��o;
- __Contagem do tempo de resposta__: Sara deve responder (e apenas responder) a todas as mensagens que receber. Assim, o tempo de resposta � contado do momento que a mensagem � recebida at� o momento em que Sara a responde. Considerando que Sara, por padr�o, demora 1 segundo para realizar uma intera��o, o tempo � contado linearmente, a n�o ser que Sara demore mais que o normal (neste caso, ela deve informar quanto tempo demorou);
- __Mensagens sem resposta__: A vida � corrida e nem sempre Sara consegue responder � todos os seus amigos. Por�m, para n�o ser injusta, ela atribui um tempo total negativo, para cada amigo que ficou sem resposta;
- __Ranking de tempos de resposta__: Ao receber todos os eventos informados, o computador organiza os amigos de Sara em ordem crescente, de acordo com as suas identifica��es, e soma os tempos de resposta respectivos a cada amigo. Ao final, o computador informa todos os amigos em contato com Sara e o tempo que Sara demora para responder cada um deles;

---
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.
---
## Como Usar

#### Clone o Reposit�rio
```
git clone https://github.com/chayannerech/TempoResposta
```

#### Navegue at� a pasta raiz da solu��o
```
cd TempoResposta
```

#### Restaure as depend�ncias
```
dotnet restore
```

#### Navegue at� a pasta do projeto
```
cd TempoResposta.ConsoleApp
```

#### Execute o projeto
```
dotnet run
```
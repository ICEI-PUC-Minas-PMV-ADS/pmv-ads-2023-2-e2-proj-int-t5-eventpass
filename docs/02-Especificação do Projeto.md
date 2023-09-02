# Especificações do Projeto

Os membros da equipe realizaram um trabalho de imersão para consolidar a definição do problema e os pontos mais relevantes a serem abordados neste projeto, contando com a participação dos usuários por meio de observações em seu ambiente habitual, estudos e pesquisas. Os detalhes coletados foram organizados em personas e histórias de usuários para guiar o design e desenvolvimento do produto ou serviço.

## Personas

Durante o processo de estudo foram coletadas informações como idade, ocupação, motivação e frustrações. das personas identificadas durante o processo de entendimento do problema. As personas são apresentadas nas figuras a seguir:

|                                                                                        | Ricardo lima - 43 anos                                                    |                                                         |
| -------------------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------- |
| ![Gráfico de Im pacto](img/prefeito.png)                                               | **Ocupação:** Prefeito de Quartel São João Mg.                            | **Dispositivos:** Notebook, Smartphone e Tablet.        |
| **Motivações:** Buscas constantementes para aprimorar a gestão pública de sua cidade.. | **Frustrações:** Recursos financeiros limitados, infraestrutura precaria. | **Hobbies:** Leitura, caminhadas e sair com a familia . |

|                                                                | Luciana Texeira - 21 anos                                            |                                                          |
| -------------------------------------------------------------- | -------------------------------------------------------------------- | -------------------------------------------------------- |
| ![Gráfico de Impacto](img/Luciana.png)                         | **Ocupação:** Estudante de farmacia.                                 | **Dispositivos:** Smartphone e Notebook.                 |
| **Motivações:** Formar e conseguir a independencia financeira. | **Frustrações:** Cidade pequena com poucas oportunidades de emprego. | **Hobbies:** Sair com amigos para se divertir e natação. |

|                                                                         | Ricardo Martins - 38 anos                                                                             |                                                         |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ------------------------------------------------------- |
| ![Gráfico de Impacto](img/ricardo.jpeg)                                 | **Ocupação:** Produtor de eventos.                                                                    | **Dispositivos:** Smartphone,Notebook e tablet.         |
| **Motivações:** Proporcionar momentos memoráveis e unicos para publico. | **Frustrações:** Orçamentos restritos das prefeituras, concorrência acirrada e alterações climaticas. | **Hobbies:** Teatro, cozinhas para os amigos e viagens. |

|
| | Maria Julia Souza - 15 anos | |
| -------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ----------------------------------------------- |
| ![Gráfico de Impacto](img/maria.png) | **Ocupação:** Colegial. | **Dispositivos:** Smartphone. |
| **Motivações:** Sonha em ser uma ifluencer digital. | **Frustrações:** Falta de diversidade cultural, monotonia e acesso limitado de tecnologia. | **Hobbies:** Assitir series, passeios com amigos da escola e tiktok. |
                                                   

## Histórias de Usuários

Com base na análise das personas identificadas na etapa anterior, foram identificadas as seguintes histórias de usuários:

| EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE`                                              | PARA ... `MOTIVO/VALOR`                                                                                                                    |
| -------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| Espectador           | Visualizar os eventos disponíveis na minha cidade                               | Escolher qual evento melhor se adapta aos meus interesses e agenda.                                                                        |
| Espectador           | Realizar a compra de ingressos de eventos do meu interesse de forma online      | Garantir o meu ingresso para o evento em qualquer horário e de forma mais rápida, sem ter que me deslocar a uma bilheteria física.         |
| Espectador           | Receber meus ingressos de acesso ao evento em formato virtual                   | Evitar o deslocamento para retirada ou impressão do ingresso físico.                                                                       |
| Gestor do evento     | Realizar o controle de retirada de ingressos de um evento de forma automatizada | Ter maior controle e acesso mais rápido a informações relevantes, como número de participantes, para melhor adequar a estrutura do evento. |
| Gestor do evento     | Entregar para o espectador do evento um ingresso virtual                        | Reduzir os custos da fase de distribuição de ingressos, eliminando a impressão e equipes envolvidas na logística de entrega dos ingressos. |
| Gestor do evento     | Fornecer ingressos confiáveis que permitam validação rápida no acesso ao evento | Evitar ação de cambistas e falsificação de ingressos.                                                                                      |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.
Os requisitos funcionais são a funcionalidades essenciais para o funcionamento da aplicação.
Os requisitos não funcionais não impedem o funcionamento da aplicação e está relacionadao diretamente em como as funcionalidades serão entregues ao usuário do software.

### Requisitos Funcionais

| ID     | Descrição do Requisito                                                              | Prioridade |
| ------ | ----------------------------------------------------------------------------------- | ---------- |
| RF-001 | A aplicação deve permitir gerenciamento de cadastros.                               | ALTA       |
| RF-002 | A aplicação deve conter perfis de gestor de eventos e espectador.                   | ALTA       |
| RF-003 | A aplicação deve permitir o cadastro do evento pelo gestor.                         | ALTA       |
| RF-004 | A aplicação deve permitir o espectador pesquisar eventos.                           | ALTA       |
| RF-005 | A aplicação deve informar os próximos 3 eventos na tela principal.                  | MÉDIA      |
| RF-006 | A aplicação deve controlar a quantidade de ingressos disponíveis.                   | MÉDIA      |
| RF-007 | A aplicação deve gerar número de ticket para cada ingresso adquirido                | MÉDIA      |
| RF-008 | A aplicação deve gerar um qr code por ticket e enviar por e-mail para o espectador. | MÉDIA      |
| RF-009 | A aplicação deve possibilitar ao gestor do evento gerar relatório.                  | BAIXA      |

### Requisitos não Funcionais

| ID      | Descrição do Requisito                                                        | Prioridade |
| ------- | ----------------------------------------------------------------------------- | ---------- |
| RNF-001 | A aplicação deve ser responsiva para rodar em todos os dispositivos.          | MÉDIA      |
| RNF-002 | A aplicação processar requisições do usuário em no máximo 10s.                | BAIXA      |
| RNF-003 | Apenas espectadores previamente cadastrados e logados poderão gerar ingressos | MÉDIA      |
| RNF-004 | A aplicação deve permitir o espectador solicitar até 3 ingressos.             | MÉDIA      |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| A geração de ingressos deverá ser limitada a 3 unidades por CPF       |
|03| O desenvolvimento da solução não poderá ser subcontratado  |


## Diagrama de Casos de Uso

Com base nas histórias de usuários coletadas na fase de elicitação de requisitos, foi desenvolvido o diagrama de casos de uso que tem como objetivo ilustrar os atores e suas relações com o sistema Eventpass

Diagrama de casos de uso - Eventpass
![Casos de uso](img/Diagrama%20de%20caso%20de%20uso%20-%20Eventpass.jpg)

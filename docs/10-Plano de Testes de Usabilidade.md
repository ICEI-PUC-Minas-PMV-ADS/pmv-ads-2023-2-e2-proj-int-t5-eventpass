# Plano de Testes de Usabilidade

Um plano de teste de usabilidade foi elaborado para detectar possíveis problemas e aprimorar a experiência do usuário na aplicação EventPass. A seguir, apresentamos um exemplo prático desse plano específico para o cenário em questão:

### Objetivo do Teste de Usabilidade:

O objetivo principal deste teste de usabilidade é avaliar a facilidade de uso e a eficácia do processo de execução das tarefas associadas aos casos de uso propostos na aplicação.

#### Participantes:

Selecionamos uma amostra de participantes que representem o público-alvo do EventPass. Isso pode incluir diferentes faixas etárias, níveis de experiência em solicitação online e preferências de dispositivos.

#### Método

Para conduzir essa avaliação adotaremos o "plano de testes" como roteiro e utilizaremos o método de observação direta para medição das variáveis previamente estabelecidas.

#### Variáveis de Teste:

- Facilidade de navegação do usuário entre as funções na plataforma
- Capacidade de interpretação da interface pelo usuário
- Tempo na execução da tarefa proposta
- Sucesso na conclusão das tarefas

#### Métricas de Avaliação:

- Taxa de sucesso na conclusão da solicitação.
- Tempo médio gasto para concluir a solicitação.
- Número de erros cometidos pelos participantes.
- Satisfação do usuário (avaliada por meio da observação durante a execução da tarefa e da opinião expressa pelo usuário)

#### Materiais Necessários:

- Computadores ou dispositivos móveis para os participantes.
- Acesso à plataforma EventPass.

#### Procedimento:

1. Apresentar o cenário da tarefa descrito no "caso de teste" para o participante e orientá-ló a seguir o passo a passo proposto.
2. Registrar o tempo de interação em cada tarefa e eventuais dificuldades dos participantes.
3. Registrar o número de interações e o numero de eventuais erros durante a execução da tarefa.
4. Após a conclusão da tarefa designada, solicitar aos participantes que forneçam avaliações, destacando áreas em que encontraram a interface intuitiva ou confusa durante a execução de cada tarefa.
5. Analisar os dados coletados e identificar áreas de melhoria na usabilidade da plataforma.

### Plano de testes de usabilidade

Abaixo segue os planos desenvolvidos para avaliar as métricas estabelecidas:

|   **Caso de Teste**   |                                                                                                              **CTU-01 – Realizar cadastro**                                                                                                              |
| :-------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                     Usuário (todos)                                                                                                                      |
| **Objetivo do Teste** |                                                                                                  Avaliar a interação do usuário com a tela de cadastro                                                                                                   |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Clicar na opção “Cadastrar”<br> 4. Selecionar o tipo de usuário<br> 5. Preencher o formulário com as informações orientadas nos campos<br>6. Clicar em “Cadastrar-se". |

|   **Caso de Teste**   |                                                                                                      **CTU-02 – Login de usuário**                                                                                                      |
| :-------------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                             Usuário (todos)                                                                                                             |
| **Objetivo do Teste** |                                                                                             Avaliar a interação do usuário na tela de Login                                                                                             |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Visualizar a página de login;<br>4. Preencher e-mail cadastrado no campo indicado<br>5. Preencher a senha no campo indicado<br>6. Clicar em "Entrar". |

|   **Caso de Teste**   |                                                                                                                                                                                          **CTU-03 – Cadastrar evento**                                                                                                                                                                                          |
| :-------------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                                                                 Usuário Gestor                                                                                                                                                                                                  |
| **Objetivo do Teste** |                                                                                                                                                                         Avaliar a interação do usuário na função de cadastro de eventos                                                                                                                                                                         |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Preencher os campos de email e senha <br> 4. Acessar a aplicação logado como gestor <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Criar evento" na barra de navegação lateral <br>7. Preencher todos os campos do formulário de cadastro do evento <br>8. Clicar em cadastrar <br> |

|   **Caso de Teste**   |                                                                                                                                                                                            **CTU-04 – Gerenciar os eventos**                                                                                                                                                                                            |
| :-------------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                                                                     Usuário Gestor                                                                                                                                                                                                      |
| **Objetivo do Teste** |                                                                                                                                                                           Avaliar a interação do usuário na tela de gerenciamento de eventos                                                                                                                                                                            |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Preencher os campos de email e senha <br> 4. Acessar a aplicação logado como gestor <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meus eventos" na barra de navegação lateral <br>7. Visualizar os eventos e identificar as opções de editar, detalhes, excluir e verificar relatório <br> |

|   **Caso de Teste**   |                                                                                                                                          **CTU-05 – Solicitar ingressos**                                                                                                                                           |
| :-------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                 Usuário Espectador                                                                                                                                                  |
| **Objetivo do Teste** |                                                                                                                           Avaliar a interação do usuário na função de solicitar ingressos                                                                                                                           |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Preencher os campos de email e senha <br> 4. Acessar a aplicação logado como espectador <br>5. Pesquisar pelo evento desejado na barra de pesquisa superior<br>6. Clicar na opção "retirar"<br>7. Clicar na opção "Confirmar"<br> |

|   **Caso de Teste**   |                                                                                                                                                                                                   **CTU-06 – Gerenciar os ingressos retirados**                                                                                                                                                                                                    |
| :-------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                                                                                 Usuário Espectador                                                                                                                                                                                                                 |
| **Objetivo do Teste** |                                                                                                                                                                                           Avaliar a interação do usuário na tela de ingressos retirados                                                                                                                                                                                            |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Preencher os campos de email e senha <br> 4. Acessar a aplicação logado como espectador <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meus ingressos" na barra de navegação lateral <br>7. Visualizar os ingressos retirados e identificar os detalhes como data e local, identificar a opção de excluir o evento<br> |

|   **Caso de Teste**   |                                                                                                                                                                                                                      **CTU-07 – Gerenciar cadastro**                                                                                                                                                                                                                      |
| :-------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                                                                                              Usuário (todos)                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                   Avaliar a interação do usuário na tela de gerenciar perfil de usuário                                                                                                                                                                                                   |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Preencher os campos de email e senha e clicar em "Entrar" <br> 5. Após logado, acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meu perfil" na barra de navegação lateral <br>7. Visualizar os ingressos as informações de cadastro<br> 8. Clicar em "Editar Perfil"<br> 9. Realizar alteração dos campos que deseja alterar<br>10. Clicar em "Salvar" |
|                       |

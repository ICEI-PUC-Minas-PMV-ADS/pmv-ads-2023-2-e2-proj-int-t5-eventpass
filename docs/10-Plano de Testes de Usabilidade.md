# Plano de Testes de Usabilidade

Um plano de teste de usabilidade para solicitar ingressos na plataforma EventPass pode ajudar a identificar problemas e melhorar a experiência do usuário. Abaixo, você encontrará um exemplo de plano de teste de usabilidade para esse cenário:

### Objetivo do Teste de Usabilidade:

O objetivo deste teste de usabilidade é avaliar a facilidade de uso e a eficácia do processo de solicitação de ingressos no EventPass, identificando problemas e oportunidades de melhoria na experiência do usuario.

#### Participantes:

Selecionamos uma amostra de participantes que representem o público-alvo do EventPass. Isso pode incluir diferentes faixas etárias, níveis de experiência em solicitação online e preferências de dispositivos.

#### Cenário de Tarefa:

1. Você deseja gerenciar um evento específico que está acontecendo em uma data futura.
1. Você já escolheu o evento e a data que deseja solicitar ingressos para você.
1. Você deve navegar pelo EventPass, selecionar os eventos e os ingressos desejados.

#### Variáveis de Teste:

- Facilidade de cadastro na plataforma.
- Facilidade de navegação na plataforma.
- Facilidade de encontrar o evento desejado.
- Facilidade de selecionar o tipo e a quantidade de ingressos.
- Facilidade de adicionar ingressos ao carrinho.
- Facilidade de revisar o carrinho e fazer alterações, se necessário.
- Clareza das informações sobre o evento, ingressos.

#### Métricas de Avaliação:

- Taxa de sucesso na conclusão da solicitação.
- Tempo médio gasto para concluir a solicitação.
- Número de erros cometidos pelos participantes.
- Satisfação geral do usuário (por meio de questionários pós-teste).

#### Materiais Necessários:

- Computadores ou dispositivos móveis para os participantes.
- Acesso a plataforma EventPass.
- Gravador de tela e câmera para registrar a interação dos participantes.
- Questionários pós-teste para coletar feedback.

#### Procedimento:

1. Apresentar o cenário de tarefa aos participantes e observar suas interações enquanto eles navegam pela plataforma.

1. Incentivar os participantes a interagir com a plataforma e fornecer feedback à medida que realizam as tarefas.

1. Registrar o tempo de interação em cada etapa da tarefa e eventuais dificuldades dos participantes.

1. Após a conclusão das tarefas, peça aos participantes que preencham um questionário pós-teste para avaliar sua satisfação e coletar comentários adicionais.

1. Analisar os dados coletados e identificar áreas de melhoria na usabilidade da plataforma.

### Plano de testes de usuabilidade

Abaixo segue os planos desenvolvidos para avaliar as métricas estabelecidas

|   **Caso de Teste**   |                                                                                                                                                                                                                      **CTU-01 – Realizar cadastro**                                                                                                                                                                                                                      |
| :-------------------: | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
|      **Perfil**       |                                                                                                                                                                                                                             Usuário (todos)                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                          Avaliar a interação do usuário com a tela de cadastro                                                                                                                                                                                                           |
| **Ações necessárias** |                                                                                                       1. Acessar a tela home do site pelo browser<br> 2. Clicar na opção “Login”<br>3. Clicar na opção “Cadastrar”<br> 4. Selecionar o tipo de usuário<br> 5. Preencher o formulário com as informaçoes orientadas nos nos campos<br>6. Clicar em “Cadastrar-se".                                                                                                        |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                                      **CTU-02 – Login de usuário**                                                                                                                                                                                                                       |
|      **Perfil**       |                                                                                                                                                                                                                             Usuário (todos)                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                             Avaliar a interação do usuário na tela de Login                                                                                                                                                                                                              |
| **Ações necessárias** |                                                                                                                 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Visualizar a página de login;<br>4. Preencher e-mail cadastrado no campo indicado<br>5. Preencher a senha no campo indicado<br>6. Clicar em "Entrar".                                                                                                                  |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                                      **CTU-03 – Cadastrar evento**                                                                                                                                                                                                                       |
|      **Perfil**       |                                                                                                                                                                                                                              Usuário Gestor                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                     Avaliar a interação do usuário na função de cadastro de eventos                                                                                                                                                                                                      |
| **Ações necessárias** |                              1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Prencher os campos de email e senha <br> 4. Acessar a aplicaçao logado como gestor <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Criar evento" na barra de navegação lateral <br>7. Preencher todos os campos do formulário de cadastro do evento <br>8. Clicar em cadastrar <br>                              |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                                    **CTU-04 – Gerênciar os eventos**                                                                                                                                                                                                                     |
|      **Perfil**       |                                                                                                                                                                                                                              Usuário Gestor                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                    Avaliar a interação do usuário na tela de gerênciamento de eventos                                                                                                                                                                                                    |
| **Ações necessárias** |                          1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Prencher os campos de email e senha <br> 4. Acessar a aplicaçao logado como gestor <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meus eventos" na barra de navegação lateral <br>7. Visualizar os eventos e identificar as opções de editar, detalhes, excluir e verificar relatório <br>                          |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                                     **CTU-05 – Solicitar ingressos**                                                                                                                                                                                                                     |
|      **Perfil**       |                                                                                                                                                                                                                            Usuário Espectador                                                                                                                                                                                                                            |
| **Objetivo do Teste** |                                                                                                                                                                                                     Avaliar a interação do usuário na função de solicitar ingressos                                                                                                                                                                                                      |
| **Ações necessárias** |                                                                            1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Prencher os campos de email e senha <br> 4. Acessar a aplicaçao logado como espectador <br>5. Pesquisar pelo evento desejado na barra de pesquisa superior<br>6. Clicar na opção "retirar"<br>7. Cliar na opção "Confirmar"<br>                                                                             |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                               **CTU-06 – Gerênciar os ingresso retirados**                                                                                                                                                                                                               |
|      **Perfil**       |                                                                                                                                                                                                                            Usuário Espectador                                                                                                                                                                                                                            |
| **Objetivo do Teste** |                                                                                                                                                                                                      Avaliar a interação do usuário na tela de ingressos retirados                                                                                                                                                                                                       |
| **Ações necessárias** |            1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Prencher os campos de email e senha <br> 4. Acessar a aplicaçao logado como espectador <br>5. Acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meus ingressos" na barra de navegação lateral <br>7. Visualizar os ingressos retirados e identificar os detalhes como data e local, identificar a opção de excluir o evento<br>             |
|                       |                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
|   **Caso de Teste**   |                                                                                                                                                                                                                     **CTU-07 – Gerênciar cadastro**                                                                                                                                                                                                                      |
|      **Perfil**       |                                                                                                                                                                                                                             Usuário (todos)                                                                                                                                                                                                                              |
| **Objetivo do Teste** |                                                                                                                                                                                                  Avaliar a interação do usuário na tela de gerenciar perfil de usuário                                                                                                                                                                                                   |
| **Ações necessárias** | 1. Acessar a tela home do site pelo browser;<br> 2. Clicar na opção “Login”<br>3. Prencher os campos de email e senha e clicar em "Entrar" <br> 5. Após logado, acessar o menu "Meu perfil" na barra superior "header" <br>6. Selecionar a opção "Meu perfil" na barra de navegação lateral <br>7. Visualizar os ingressos as informações de cadastro<br> 8. Clicar em "Editar Perfil"<br> 9. Realizar alteração dos campos que deseja alterar<br>10. Clicar em "Salvar" |
|                       |

#### Ações de Acompanhamento:

Com base nos resultados do teste de usabilidade, realize as correções com as melhorias necessárias na plataforma.

Realize testes adicionais para verificar se as melhorias tiveram um impacto positivo na experiência do usuário.

Repita o processo de teste de usabilidade conforme necessário para garantir uma experiência contínua de alta qualidade.

# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto".

Por exemplo:

|  **Caso de Teste**  |                                    CT-01 – Gerenciar cadastro                                     |
| :-----------------: | :-----------------------------------------------------------------------------------------------: |
| Requisito Associado |                  RF-001 - A aplicação deve permitir gerenciamento de cadastros.                   |
|  Objetivo do Teste  |               Verificar se o usuário consegue gerenciar seu cadastro na aplicação.                |
|       Passos        | - Acessar a aplicação <br> - Na página inicial clicar em “acesse sua conta” <br> - Realizar login |
|  Critério de Êxito  |                            - O usuário consegue gerenciar seu acesso.                             |

|  **Caso de Teste**  |                                                                                        CT-02 – Tipos de perfil                                                                                        |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                              RF-002 - A aplicação deve conter perfis de gestor de eventos e espectador.                                                               |
|  Objetivo do Teste  |                                                       Verificar se o usuário consegue selecionar entre gestor e espectador na hora do cadastro.                                                       |
|       Passos        | - Acessar a aplicação <br> - Na página inicial clicar em “seja um gestor” ou em “cadastre-se” <br> - Preencher os campos de cadastro com as informações solicitadas <br> - Clicar em “cadastrar” <br> |
|  Critério de Êxito  |                                                               - O usuário consegue selecionar o tipo de perfil e realizar seu cadastro.                                                               |

|  **Caso de Teste**  |                                                                              CT-03 – Gerenciar evento                                                                              |
| :-----------------: | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                     RF-003 - A aplicação deve permitir o gerenciamento do evento pelo gestor.                                                      |
|  Objetivo do Teste  |                                                          Verificar se o gestor consegue criar, alterar e excluir eventos.                                                          |
|       Passos        | - Acessar a aplicação logado como gestor <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> - Selecionar a opção "Meus eventos" na barra de navegação lateral <br> |
|  Critério de Êxito  |                                                               - O gestor consegue criar, alterar e excluir eventos.                                                                |

|  **Caso de Teste**  |                                                                     CT-04 – Pesquisar evento                                                                      |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                    RF-004 A aplicação deve permitir o espectador pesquisar o evento por nome do evento ou data                                    |
|  Objetivo do Teste  |                                        Permitir ao usuário encontrar o evento disponível atravéz da data ou nome do evento                                        |
|       Passos        | - Acessar a aplicação <br> - Na barra superior de navegação "header" localizar o campo pesquisar <br> - Digitar o nome do evento e clicar em no botão buscar <br> |
|  Critério de Êxito  |                                                - Será possivel visualizar os eventos pesquisados por data ou nome                                                 |

|  **Caso de Teste**  |                               CT-05 – Exibir eventos                               |
| :-----------------: | :--------------------------------------------------------------------------------: |
| Requisito Associado |     RF-005 - A aplicação deve exibir os próximos 3 eventos na tela principal.      |
|  Objetivo do Teste  |         Verificar se os 3 próximos eventos são exibidos na tela principal.         |
|       Passos        |        - Acessar a aplicação <br> - Verificar a seção “eventos em destaque”        |
|  Critério de Êxito  | - Os 3 próximos eventos são exibidos corretamente em uma seção da página principal |

|  **Caso de Teste**  |                                                                                                                          CT-06 – Cadastro de evento                                                                                                                           |
| :-----------------: | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                              RF-006 - A aplicação deve garantir que ao cadastrar o evento, o gestor informe a atração, o local, a data e a quantidade de ingressos disponíveis.                                                               |
|  Objetivo do Teste  |                                                                     Garantir que o gestor informe a atração, local, data e quantidade de ingressos disponíveis ao realizar o cadastro de um novo evento.                                                                      |
|       Passos        | - Acessar a aplicação como gestor <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> Selecionar a opção "Criar evento" na barra de navegação lateral <br> - Não preencher todos os campos do formulário de cadastro do evento <br> - Clicar em cadastrar <br> |
|  Critério de Êxito  |                                                                                              - O gestor só consegue cadastrar o evento caso preencha todos os campos necessários                                                                                              |

|  **Caso de Teste**  |                                                                   CT-07 – Gerênciar ingressos pelo espectador                                                                   |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                           RF007 - A aplicação deve permitir o gerenciamento dos ingressos retirados pelo espectador.                                            |
|  Objetivo do Teste  |                                           Verificar se o espectador consegue solicitar, visualizar e excluir os ingressos retirados.                                            |
|       Passos        | - Acessar a aplicação como espectador <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> Selecionar a opção "Meus ingressos" na barra de navegação lateral <br> |
|  Critério de Êxito  |                                                  - O espectador consegue visualizar os ingressos e excluir ingressos retirados                                                  |

|  **Caso de Teste**  |                                                                            CT-08 – Enviar e-mail de confirmação                                                                             |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                         RF-008 - A aplicação deve enviar um e-mail de confirmação para o espectador                                                         |
|  Objetivo do Teste  |                                    Garantir que para toda retirada de ingresso seja enviado um e-mail para espectador confirmando a reserva do ingresso.                                    |
|       Passos        | - Acessar a aplicação como espectador <br> - Buscar pelo evento desejado <br> - Clicar em “retirar” no evento desejado <br> - Conferir se o o ingresso foi enviado para o e-mail cadastrado |
|  Critério de Êxito  |                                                                  - O ingresso é enviado ao e-mail cadastrado do espectador                                                                  |

|  **Caso de Teste**  |                                                                                                                                                                                CT-09 – Gerar relatório                                                                                                                                                                                 |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                                                          RF-009 - A aplicação deve possibilitar ao gestor do evento gerar relatório geral do evento com dados do eventos, ingressos disponíveis e ingressos já distribuídos.                                                                                                           |
|  Objetivo do Teste  |                                                                                                                                                        Garantir que o gestor consegue gerar relatório de um evento cadastrado.                                                                                                                                                         |
|       Passos        |                                                                            - Acessar a aplicação logado como gestor <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> - Selecionar a opção "Meus eventos" na barra de navegação lateral <br> - Clicar em relatório do evento no icone <br>                                                                            |
|  Critério de Êxito  |                                                                                                                                                    - Visualizar a tela com informações de ingressos retirados e restantes do evento                                                                                                                                                    |
|  **Caso de Teste**  |                                                                                                                                                                    CT-10 – Limitar retirada de ingresso por usuário                                                                                                                                                                    |
| Requisito Associado |                                                                                                                     RST-002 - A geração de ingressos estará sujeita a uma restrição, sendo permitida a emissão de no máximo 3 unidades por usuário em cada evento.                                                                                                                     |
|  Objetivo do Teste  |                                                                                                                                                           Garantir que o espectador não consiga retirar mais de 3 ingressos                                                                                                                                                            |
|       Passos        | - Acessar a aplicação logado como espectador <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> - Selecionar a opção "Meus ingressos" na barra de navegação lateral <br> - Observar se já existem 3 ingressos reservados para o evento <br> -Digitar o nome do evento e clicar em no botão buscar <br> - Clicar no botão retirar <br> - Clicar no botão confirmar <br> |
|  Critério de Êxito  |                                                                                                                                          - Será exibido uma mensagem indicando que o usuário já possui 3 ingressos reservados para o evento.                                                                                                                                           |

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

|  **Caso de Teste**  |                                                                       CT-03 – Gerenciar evento                                                                        |
| :-----------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                               RF-003 - A aplicação deve permitir o gerenciamento do evento pelo gestor.                                               |
|  Objetivo do Teste  |                                                   Verificar se o gestor consegue criar, alterar e excluir eventos.                                                    |
|       Passos        | - Acessar a aplicação <br> - Na página inicial clicar em “acesse sua conta” <br> - Realizar o login (gestor) <br> - Logado como gestor, clicar em “gerenciar eventos” |
|  Critério de Êxito  |                                                         - O gestor consegue criar, alterar e excluir eventos.                                                         |

|  **Caso de Teste**  |                                                                         CT-04 – Pesquisar evento                                                                          |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                        RF-004 A aplicação deve permitir o espectador pesquisar o evento por nome do evento ou data                                        |
|  Objetivo do Teste  |                                            Permitir ao usuário encontrar o evento disponível atravéz da data ou nome do evento                                            |
|       Passos        | - Acessar a aplicação <br> - Na barra superior de navegação "header" localizar o campo pesquisar <br> - Digitar o nome ou data do evento e clicar em no botão buscar <br> |
|  Critério de Êxito  |                                                    - Será possivel visualizar os eventos pesquisados por data ou nome                                                     |

|  **Caso de Teste**  |                               CT-05 – Exibir eventos                               |
| :-----------------: | :--------------------------------------------------------------------------------: |
| Requisito Associado |     RF-005 - A aplicação deve exibir os próximos 3 eventos na tela principal.      |
|  Objetivo do Teste  |         Verificar se os 3 próximos eventos são exibidos na tela principal.         |
|       Passos        |        - Acessar a aplicação <br> - Verificar a seção “eventos em destaque”        |
|  Critério de Êxito  | - Os 3 próximos eventos são exibidos corretamente em uma seção da página principal |

|  **Caso de Teste**  |                                                                                     CT-06 – Cadastro de evento                                                                                      |
| :-----------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                         RF-006 - A aplicação deve garantir que ao cadastrar o evento, o gestor informe a atração, o local, a data e a quantidade de ingressos disponíveis.                          |
|  Objetivo do Teste  |                                Garantir que o gestor informe a atração, local, data e quantidade de ingressos disponíveis ao realizar o cadastro de um novo evento.                                 |
|       Passos        | - Acessar a aplicação como gestor <br> - Clicar em “gerenciar eventos” <br> - Iniciar o cadastro de novo evento <br> - Preencher o formulário de cadastro do evento <br> - Clicar em cadastrar <br> |
|  Critério de Êxito  |                                                         - O gestor só consegue cadastrar o evento caso preencha todos os campos necessários                                                         |

|  **Caso de Teste**  |                                                                      CT-07 – Número de ticket                                                                       |
| :-----------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |        RF-007 - A aplicação deve gerar número de ticket para cada ingresso adquirido pelo espectador e deve diminuir a quantidade de ingressos disponíveis.         |
|  Objetivo do Teste  |              Garantir que a cada ingresso adquirido pelo espectador um número único será gerado e a quantidade de ingressos disponíveis seja reduzida.              |
|       Passos        | - Acessar a aplicação como espectador <br> - Selecionar o evento desejado <br> - Selecionar a quantidade de ingressos desejada <br> - Clicar em “retirar ingressos” |
|  Critério de Êxito  |      - Um número único e exclusivo é gerado ao se “retirar” um ingresso <br> - A quantidade de ingressos disponíveis é reduzida na quantidade que foi retirada      |

|  **Caso de Teste**  |                                                                                                     CT-08 – Gerar QR Code e e-mail                                                                                                     |
| :-----------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                                                                 RF-008 - A aplicação deve gerar um qr code por número de ticket e enviar por e-mail para o espectador.                                                                 |
|  Objetivo do Teste  |                                                               Garantir que para toda retirada de ingresso seja gerado um qr code e enviado um e-mail para o espectador.                                                                |
|       Passos        | Acessar a aplicação como espectador <br> - Selecionar o evento desejado <br> - Selecionar a quantidade de ingressos desejada <br> - Clicar em “retirar ingressos” <br> - Conferir se o o ingresso foi enviado para o e-mail cadastrado |
|  Critério de Êxito  |                                                             - É gerado um qr code para o ingresso retirado <br> - O ingresso é enviado ao e-mail cadastrado do espectador                                                              |

|  **Caso de Teste**  |                                                                                                   CT-09 – Gerar relatório                                                                                                   |
| :-----------------: | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| Requisito Associado |                             RF-009 - A aplicação deve possibilitar ao gestor do evento gerar relatório geral do evento com dados do eventos, ingressos disponíveis e ingressos já distribuídos.                             |
|  Objetivo do Teste  |                                                                           Garantir que o gestor consegue gerar relatório de um evento cadastrado.                                                                           |
|       Passos        | Acessar a aplicação logado como gestor <br> - Acessar o menu "Meu perfil" na barra superior "header" <br> - Selecionar a opção "Meus eventos" na barra de navegação lateral <br> - Clicar relatório do evento no icone <br> |
|  Critério de Êxito  |                                                                      - Visualizar a tela com informações de ingressos retirados e restantes do evento                                                                       |

# Programação de Funcionalidades

Durante a etapa de desenvolvimento, os artefatos de software foram elaborados com base nos requisitos funcionais.

A tabela a seguir estabelece a correlação entre o artefato produzido e o respectivo requisito funcional.

| ID     | Descrição do Requisito                                                                                                                                     | Artefato produzido                                                                                        |
| ------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| RF-001 | A aplicação deve permitir gerenciamento de cadastros.                                                                                                      | \Models\Usuario.cs, \Views\Usuarios1\Create-Delete-Details-Edit.cshtml                                    |
| RF-002 | A aplicação deve conter perfis de gestor de eventos e espectador.                                                                                          | \Models\Usuario.cs, \Controllers\Usuarios1Controller.cs                                                   |
| RF-003 | A aplicação deve permitir o gerenciamento do evento pelo gestor.                                                                                           | \Controllers\EventosController.cs, \Views\Eventos\Create-Delete-Details-Edit.cshtml                       |
| RF-004 | A aplicação deve permitir o espectador pesquisar o evento pelo nome                                                                                        | \Controllers\EventosController.cs, \Views\Eventos\Buscar.cshtml                                           |
| RF-005 | A aplicação deve exibir os próximos 3 eventos na tela principal.                                                                                           | \Views\Home\Index.cshtml                                                                                  |
| RF-006 | A aplicação deve garantir que ao cadastrar o evento, o gestor informe a atração, o local, a data e a quantidade de ingressos disponíveis.                  | \Controllers\EventosController.cs, \Models\Evento.cs                                                      |
| RF-007 | A aplicação deve permitir o gerenciamento dos ingressos retirados pelo espectador.                                                                         | \EventPass1\Controllers\IngressosController.cs, \Views\Ingressos\Edit-Delete-retirar-MeusIngressos.cshtml |
| RF-008 | A aplicação deve enviar um e-mail de confirmação de reserva para o espectador.                                                                             | \Services\EmailService.cs                                                                                 |
| RF-009 | A aplicação deve possibilitar ao gestor do evento gerar relatório geral do evento com dados do eventos, ingressos disponíveis e ingressos já distribuídos. | \Controllers\EventosController.cs, \Views\Eventos\Relatorio.cshtml                                        |

# Instruções de acesso

Para acesso a aplicação EventPass dese acessar o link <a href="https://eventpass.azurewebsites.net/"> EventPass </a>.A aplicação possui um usuário padrão cadastrado, para acessar as funcionalidades deve-se seguir os segintes passos:

Acessar a aplicação como gestor

- Acessar o menu **Login** na barra de navegação superior
- Preencher o campo **Usuário** com o Email gestor@email.com
- Preencher o campo **senha** com a senha 123456

Acessar a aplicação como espectador

- Acessar o menu **Login** na barra de navegação superior
- Preencher o campo **Usuário** com o Email espectador@email.com
- Preencher o campo **senha** com a senha 123456

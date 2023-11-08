using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

public class EmailService
{
    private readonly string _remetente;
    private readonly string _emailRemetente;
    private readonly string _senhaEmail;
    private readonly string _servidorSmtp;
    private readonly int _portaSmtp;

    
    //Configura as credenciais de email
    public EmailService()
    {
        _remetente = "Suporte Event Pass";
        _emailRemetente = "suporte.eventpass@hotmail.com";
        _senhaEmail = "eventpass@puc2023";
        _servidorSmtp = "smtp-mail.outlook.com"; 
        _portaSmtp = 587;
    }

    public void EnviarEmailConfirmacaoReserva(string destinatario, int idIngresso, string nomeEvento, string nomeUsuario)
    {
        var mensagem = new MimeMessage();
        mensagem.From.Add(new MailboxAddress(_remetente, _emailRemetente));
        mensagem.To.Add(new MailboxAddress(nomeUsuario, destinatario));
        mensagem.Subject = "Ingresso reservado com sucesso!";

        var corpoMensagem = new BodyBuilder();
        corpoMensagem.HtmlBody = $@"
            <h1>Olá {nomeUsuario},</h1>
            <p>Seu ingresso de número {idIngresso} para o evento {nomeEvento} foi resgatado com sucesso. Nos vemos em breve e obrigado por escolher o Event Pass!</p>";

        mensagem.Body = corpoMensagem.ToMessageBody();

        using (var clienteSmtp = new SmtpClient())
        {
            clienteSmtp.Connect(_servidorSmtp, _portaSmtp, SecureSocketOptions.StartTls);
            clienteSmtp.Authenticate(_emailRemetente, _senhaEmail);
            clienteSmtp.Send(mensagem);
            clienteSmtp.Disconnect(true);
        }
    }

    public void EnviarEmailRecuperarLogin(string destinatario, string nomeUsuario)
    {
        var mensagem = new MimeMessage();
        mensagem.From.Add(new MailboxAddress(_remetente, _emailRemetente));
        mensagem.To.Add(new MailboxAddress(nomeUsuario, destinatario));
        mensagem.Subject = "Recuperação de login";

        var corpoMensagem = new BodyBuilder();
        corpoMensagem.HtmlBody = $@"
            <h1>Olá {nomeUsuario},</h1>
            <p>Parece que perdeu seu login?</p>";

        mensagem.Body = corpoMensagem.ToMessageBody();

        using (var clienteSmtp = new SmtpClient())
        {
            clienteSmtp.Connect(_servidorSmtp, _portaSmtp, SecureSocketOptions.StartTls);
            clienteSmtp.Authenticate(_emailRemetente, _senhaEmail);
            clienteSmtp.Send(mensagem);
            clienteSmtp.Disconnect(true);
        }
    }
}

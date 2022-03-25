﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatatio, string assunto, 
            int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatatio,
                assunto, usuarioId, code);

            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"), 
                        _configuration.GetValue<int>("EmailSettings:Port"),
                        true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var msg = new MimeMessage();

            msg.From.Add(new MailboxAddress(
                _configuration.GetValue<string>("EmailSettings:From")));
            msg.To.AddRange(mensagem.Destinatario);
            msg.Subject = mensagem.Assunto;
            msg.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return msg;
        }
    }
}

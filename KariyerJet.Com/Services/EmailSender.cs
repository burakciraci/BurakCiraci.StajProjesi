﻿using KariyerJet.Com.Models.Settings;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace KariyerJet.Com.Services
{
    /// <summary>
    /// Interface for the EmailSender service using <paramref name="emailSettings" /> and
    /// <paramref name="httpContextAccessor" /> to send emails.
    /// </summary>
    /// <param name="httpContextAccessor">Injected IHttpContextAccessor.</param>
    /// <param name="emailSettings">Injected EmailSettings.</param>
    /// <remarks>
    /// Uses <see cref="HttpContextAccessor" /> to extract current context properties to include
    ///  when an email is sent to the <see cref="EmailSettings.AdminEmail" /> address.
    /// </remarks>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email to the <paramref name="email" /> address with <paramref name="subject" />,
        /// <paramref name="textMessage" /> and <paramref name="htmlMessage" />.
        /// </summary>
        /// <param name="email">The send to email address.</param>
        /// <param name="subject">The email's subject.</param>
        /// <param name="textMessage">The email's MimeKit.BodyBuilder.TextBody.</param>
        /// <param name="htmlMessage">The email's MimeKit.BodyBuilder.HtmlBody.</param>
        Task SendEmailAsync(string email, string subject, string textMessage, string htmlMessage);

        /// <summary>
        /// Sends an email to the address set with the readonly <see cref="EmailSettings.AdminEmail" /> property
        /// with <paramref name="subject" /> and <paramref name="textMessage" /> including HttpContext properties.
        /// </summary>
        /// <param name="subject">The email's subject.</param>
        /// <param name="textMessage">The email's MimeMessage.Body.TextPart.</param>
        /// <remarks>
        /// Uses <see cref="HttpContextAccessor" /> to extract current context properties to include when an email sent
        /// to the <see cref="EmailSettings.AdminEmail" /> address.
        /// </remarks>    
        Task SendAdminEmailAsync(string subject, string textMessage);
    }

    public class EmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailSender(IOptions<EmailSettings> emailSettings, IHttpContextAccessor httpContextAccessor)
        {
            _emailSettings = emailSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendEmailAsync(string email, string subject, string textMessage, string htmlMessage)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            mimeMessage.To.Add(MailboxAddress.Parse(email));

            mimeMessage.Subject = subject;
            var builder = new BodyBuilder { TextBody = textMessage, HtmlBody = htmlMessage };
            mimeMessage.Body = builder.ToMessageBody();

            try
            {
                using var client = new SmtpClient();
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                if (_emailSettings.IsDevelopment)
                    await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, _emailSettings.UseSsl)
                        .ConfigureAwait(false);
                else
                    await client.ConnectAsync(_emailSettings.MailServer).ConfigureAwait(false);

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password).ConfigureAwait(false);
                await client.SendAsync(mimeMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task SendAdminEmailAsync(string subject, string textMessage)
        {
            var _context = _httpContextAccessor.HttpContext;
            var _host = _context.Request.Host.ToString();
            var _uaString = _context.Request.Headers["User-Agent"].ToString();
            var _ipAnonymizedString = _context.Connection.RemoteIpAddress.AnonymizeIP();
            var _uid = _context.User.Identity.IsAuthenticated
                ? _context.User.FindFirst(ClaimTypes.NameIdentifier).Value
                : "Unknown";
            var _path = _context.Request.Path;
            var _queryString = _context.Request.QueryString;

            StringBuilder sb = new StringBuilder($"Host = {_host} \r\n");
            sb.Append($"User Agent = {_uaString} \r\n");
            sb.Append($"Anonymized IP = {_ipAnonymizedString} \r\n");
            sb.Append($"UserId = {_uid} \r\n");
            sb.Append($"Path = {_path} \r\n");
            sb.Append($"QueryString = {_queryString} \r\n \r\n");
            sb.Append(textMessage);

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            mimeMessage.To.Add(MailboxAddress.Parse(_emailSettings.AdminEmail));

            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain") { Text = sb.ToString() };

            try
            {
                using var client = new SmtpClient();
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                if (_emailSettings.IsDevelopment)
                    await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, _emailSettings.UseSsl)
                        .ConfigureAwait(false);
                else
                    await client.ConnectAsync(_emailSettings.MailServer).ConfigureAwait(false);

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password).ConfigureAwait(false);
                await client.SendAsync(mimeMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return this.SendEmailAsync(email, subject, "", htmlMessage);
        }
    }
}

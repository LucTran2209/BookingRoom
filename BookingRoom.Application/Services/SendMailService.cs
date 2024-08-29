using AutoMapper;
using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.DependencyInjection.Options;
using BookingRoom.Application.Dtos.SendMailServiceDto;
using BookingRoom.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Application.Services
{
    public class SendMailService : BaseService, ISendMailService
    {
        private readonly SendMailSettings _sendMailSettings;

        public SendMailService(IUnitOfWork unitOfWork, IMapper mapper,
                               IConfiguration configuration) : base(unitOfWork, mapper)
        {
            _sendMailSettings = configuration.GetSection(nameof(SendMailSettings)).Get<SendMailSettings>() ?? new SendMailSettings();
        }

        /// <summary>
        /// SendMailWelcomAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task<bool> SendMailWelcomAsync(SendMailWelcomAsyncInputDto inputDto)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = new MailboxAddress(_sendMailSettings.DisplayName, _sendMailSettings.Mail);
                email.From.Add(new MailboxAddress(_sendMailSettings.DisplayName, _sendMailSettings.Mail));
                email.To.Add(new MailboxAddress(inputDto.To, inputDto.To));
                email.Subject = inputDto.Subject;

                // Create body
                var builder = new BodyBuilder();
                builder.HtmlBody = inputDto.Body;
                
                email.Body = builder.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();

                try
                {
                    await smtp.ConnectAsync(_sendMailSettings.Host, _sendMailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_sendMailSettings.Mail, _sendMailSettings.Password);
                    await smtp.SendAsync(email);
                }
                catch (Exception)
                {     
                    return false;
                    throw;
                }

                smtp.Disconnect(true);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using System.Net.Mail;
using System.Threading.Tasks;
using Quartz;

namespace CronJobAspNetMVC.Engine
{
    [DisallowConcurrentExecution]
    public class EngineSendEmail : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            EnviarMailNotificacion(context);
            return Task.CompletedTask;
        }
        public bool EnviarMailNotificacion(IJobExecutionContext context)
        {
            bool result = false;
            try
            {
                MailMessage mensaje = new MailMessage();
                System.Net.Mail.SmtpClient servidor = new System.Net.Mail.SmtpClient();
                mensaje.From = new System.Net.Mail.MailAddress("EMC Ingenieria de Software <efrainmejiasc@gmail.com>");
                mensaje.Subject = "Prueba CronJob Asp.Net MVC";
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                mensaje.Body = "Probando CronJob en Asp.Net MVC";
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.To.Add(new System.Net.Mail.MailAddress("efrainmejiasc@gmail.com"));
                servidor.Credentials = new System.Net.NetworkCredential("efrainmejiasc@gmail.com", "1234fabrizio");
                servidor.Port = 587;
                servidor.Host = "smtp.gmail.com";
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                mensaje.Dispose();
                result = true;
            }
            catch { }
          
            return result;
        }

     
    }
}
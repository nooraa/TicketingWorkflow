
using System.Threading.Tasks;

namespace Ticketing.Workflow.Base
{
    public interface IMailService
    {
          Task SendEmailAsync(MailRequest mailRequest);
    }
}

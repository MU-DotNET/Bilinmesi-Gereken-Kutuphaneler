using Hangfire;
using HangFire.Web.Services;

namespace HangFire.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void EmailSendToUserJob(string userId, string message)
        {
            BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
        }
    }
}

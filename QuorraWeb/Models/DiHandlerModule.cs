using Autofac;
using QuorraWeb.Interfaces;
using QuorraWeb.Services;

namespace QuorraWeb.Models
{
    public class DiHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

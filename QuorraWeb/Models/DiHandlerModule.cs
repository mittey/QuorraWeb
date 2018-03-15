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
            builder.RegisterType<UpdateService>().As<IUpdateService>().InstancePerLifetimeScope();
            builder.RegisterType<HubService>().As<IHubService>().InstancePerLifetimeScope();
            builder.RegisterType<BotService>().As<IBotService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<NoneService>().As<INoneService>().InstancePerLifetimeScope();
            builder.RegisterType<LuisService>().As<ILuisService>().InstancePerLifetimeScope();
            builder.RegisterType<JokeService>().As<IJokeService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

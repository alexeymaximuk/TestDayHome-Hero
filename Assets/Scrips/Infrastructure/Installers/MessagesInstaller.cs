using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Scrips.Infrastructure.Installers
{
    public class MessagesInstaller : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
        }
    }
}
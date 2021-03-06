using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Shoutbox.NET.Services;
using Shoutbox.NET.Data;
using Shoutbox.NET.Data.AD;
using Shoutbox.NET.Controllers;
using Shoutbox.NET.Hubs;

namespace Shoutbox.NET
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IActiveDirectoryService, ActiveDirectory>();
            container.RegisterType<IMessageControllerService, MessageController>();
            container.RegisterType<IUserControllerService, UserController>("User");
            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}
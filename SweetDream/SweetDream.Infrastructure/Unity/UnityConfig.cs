using Microsoft.Practices.Unity;
using System.Reflection;


namespace SweetDream.Infrastructure.Unity
{
    public static class UnityConfig
    {
        public static UnityContainer Container;
        public static IUnityContainer Initialise()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            Container = container;

            return container;
        }

        private static void RegisterTypes(UnityContainer container)
        {
            string[] assemblyNameParts = Assembly.GetExecutingAssembly().GetName().Name.Split('.');
            string assemblyPrefix = string.Join(".", assemblyNameParts, 0, 1);
        }
    }
}

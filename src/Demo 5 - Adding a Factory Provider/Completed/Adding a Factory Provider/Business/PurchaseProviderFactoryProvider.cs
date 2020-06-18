using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adding_a_Factory_Provider.Business
{
    public class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> factories;

        public PurchaseProviderFactoryProvider()
        {
            factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderFactory)
                .IsAssignableFrom(t));
        }
        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = factories
                .Single(x => x.Name.ToLowerInvariant()
                .Contains(name.ToLowerInvariant()));

            var instance = 
                (IPurchaseProviderFactory)Activator
                .CreateInstance(factory);

            return instance;
        }
    }
}

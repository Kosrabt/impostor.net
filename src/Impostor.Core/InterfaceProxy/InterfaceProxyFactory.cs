using Castle.DynamicProxy;
using System;

namespace Impostor.Core.InterfaceProxy
{
    public class InterfaceProxyFactory : IInterfaceProxyFactory
    {
        private readonly IInterceptor interceptor;

        public InterfaceProxyFactory(IInterceptor interceptor)
        {
            this.interceptor = interceptor;
        }

        public object CreateProxy(Type interfaceToProxy) => new ProxyGenerator().CreateInterfaceProxyWithoutTarget(interfaceToProxy, interceptor);
    }
}
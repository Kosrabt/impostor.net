using System;

namespace Impostor.Core.InterfaceProxy
{
    internal interface IInterfaceProxyFactory
    {
        object CreateProxy(Type interfaceToProxy);
    }
}
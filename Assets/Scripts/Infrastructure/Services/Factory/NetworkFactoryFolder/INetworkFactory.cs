using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory.NetworkFactoryFolder
{
    public interface INetworkFactory: IService
    {
        GameObject CreateNetworkManager();
    }
}
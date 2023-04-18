
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Factory.PlayerFactory
{
    public interface IPlayerFactory:IService
    {
        public GameObject CreatePlayer(Vector3 spawnPoint);
    }
}
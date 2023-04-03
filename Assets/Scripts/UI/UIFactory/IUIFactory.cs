using UnityEngine;
using Assets.Scripts.Data.NewTypes;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.UI.UIFactory
{
    public interface IUIFactory : IService
    {
        GameObject CreateRootUI();
        GameObject CreateHUD(GameObject player);
        GameObject CreateMainMenu();

    }
}
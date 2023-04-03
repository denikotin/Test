using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputServiceFolder
{
    public interface IInputService: IService
    {
        public Vector2 Axis { get; }

    }
}
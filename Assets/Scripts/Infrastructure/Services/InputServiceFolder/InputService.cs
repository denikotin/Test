using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputServiceFolder
{
    public class InputService : IInputService
    {
        protected const string HORIZONTAL = "Horizontal";
        protected const string VERTICAL = "Vertical";
        public Vector2 Axis => GetSimpleInputAxis();

        public Vector2 GetSimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(HORIZONTAL), SimpleInput.GetAxis(VERTICAL));
        }

    }
}

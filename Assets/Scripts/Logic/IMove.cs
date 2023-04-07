using UnityEngine;

namespace Assets.Scripts.Logic
{
    public interface IMove
    {
        public bool IsMoving { get; set; }
        public void Move();
    }
}

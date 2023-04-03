﻿namespace Assets.Scripts.Logic
{
    public interface IMovable
    {
        public bool IsMoving { get; set; }
        public void Move();
    }
}

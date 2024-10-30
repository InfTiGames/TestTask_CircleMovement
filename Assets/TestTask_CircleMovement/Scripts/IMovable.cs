using UnityEngine;

namespace Assets.TestTask_CircleMovement.Scripts
{
    public interface IMovable
    {
        void SetTarget(Vector3 position);
        void Move();
    }
}
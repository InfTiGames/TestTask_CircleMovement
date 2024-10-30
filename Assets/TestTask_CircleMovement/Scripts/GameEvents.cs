using UnityEngine;
using System;

namespace Assets.TestTask_CircleMovement.Scripts
{
    public class GameEvents : MonoBehaviour
    {
        public static Action<Vector3> OnMoveCommand;

        public static void MoveTo(Vector3 position)
        {
            OnMoveCommand?.Invoke(position);
        }
    }
}
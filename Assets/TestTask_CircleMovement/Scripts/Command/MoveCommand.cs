using UnityEngine;

namespace Assets.TestTask_CircleMovement.Scripts.Command
{
    public class MoveCommand : ICommand
    {
        private IMovable _movable;
        private Vector3 _targetPosition;

        public MoveCommand(IMovable movable, Vector3 targetPosition)
        {
            _movable = movable;
            _targetPosition = targetPosition;
        }

        public void Execute()
        {
            _movable.SetTarget(_targetPosition);
        }
    }
}
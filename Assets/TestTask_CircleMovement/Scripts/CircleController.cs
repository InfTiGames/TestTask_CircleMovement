using Assets.TestTask_CircleMovement.Scripts.Command;
using Assets.TestTask_CircleMovement.Scripts.State;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.TestTask_CircleMovement.Scripts
{
    public class CircleController : MonoBehaviour, IMovable
    {
        private float _moveSpeed;
        private Vector3 _currentTarget;
        private CircleState _currentState;
        private Queue<ICommand> _commandQueue = new Queue<ICommand>();

        private SliderController _sliderController;
        private CircleSettings _circleSettings;
        private InputHandler _inputHandler;

        [Inject]
        private void Construct(SliderController sliderController, InputHandler inputHandler, CircleSettings circleSettings)
        {
            _sliderController = sliderController;
            _inputHandler = inputHandler;
            _circleSettings = circleSettings;
        }

        private void Start()
        {
            SetState(new IdleState());
            _moveSpeed = _circleSettings.DefaultMoveSpeed;
        }

        private void OnEnable()
        {
            _sliderController.OnSpeedChanged += UpdateSpeed;
            GameEvents.OnMoveCommand += EnqueueMoveCommand;
        }

        private void OnDisable()
        {
            _sliderController.OnSpeedChanged -= UpdateSpeed;
            GameEvents.OnMoveCommand -= EnqueueMoveCommand;
        }

        private void Update()
        {
            _currentState?.Handle(this);
        }

        private void SetState(CircleState newState)
        {
            _currentState = newState;
            Debug.Log($"Состояние изменено на: {_currentState.GetType().Name}");
        }

        private void UpdateSpeed(float speed)
        {
            _moveSpeed = speed;
        }

        public void Move()
        {
            if (Vector3.Distance(transform.position, _currentTarget) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _moveSpeed * Time.deltaTime);
            }
            else
            {
                if (_commandQueue.Count > 0)
                    DequeueCommandAndExecuteNext();
                else
                    SetState(new IdleState());
            }
        }

        private void EnqueueMoveCommand(Vector3 position)
        {
            Debug.Log($"Добавлена новая цель в очередь на позиции: {position}");

            ICommand moveCommand = new MoveCommand(this, position);
            _commandQueue.Enqueue(moveCommand);

            if (_currentState is IdleState)
                DequeueCommandAndExecuteNext();
        }

        public void SetTarget(Vector3 position)
        {
            Debug.Log($"Двигаюсь к цели на позиции: {position}");

            _currentTarget = position;
            SetState(new MovingState());
        }

        private void DequeueCommandAndExecuteNext()
        {
            ICommand nextCommand = _commandQueue.Dequeue();
            nextCommand.Execute();
        }
    }
}
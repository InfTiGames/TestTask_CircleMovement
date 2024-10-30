using UnityEngine.EventSystems;
using UnityEngine;
using UniRx;

namespace Assets.TestTask_CircleMovement.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        private void Start()
        {
            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Subscribe(_ =>
                {
                    if (!IsClickOnUI())
                    {
                        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        clickPosition.z = 0;
                        GameEvents.OnMoveCommand?.Invoke(clickPosition);
                    }
                });
        }

        private bool IsClickOnUI()
        {
            if (Application.isEditor || Input.mousePresent)
                return EventSystem.current.IsPointerOverGameObject();

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            }

            return false;
        }
    }
}
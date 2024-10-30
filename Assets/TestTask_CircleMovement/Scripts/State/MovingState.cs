namespace Assets.TestTask_CircleMovement.Scripts.State
{
    public class MovingState : CircleState
    {
        public override void Handle(CircleController controller)
        {
            controller.Move();
        }
    }
}
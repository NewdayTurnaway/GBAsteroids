using UnityEngine;

namespace GBAsteroids
{
    internal class StartState : State
    {
        public override void Handle(Situation situation)
        {
            MoveRigitbodyFollow follow = new(situation.Rigidbody2D, situation.Rigidbody2D.transform.localPosition, 7f, 0f);
            follow.Move(0, 0);

            if(Vector3.Distance(situation.Rigidbody2D.transform.localPosition, Vector3.zero) < 0.2f)
            {
                situation.Rigidbody2D.velocity = Vector2.zero;
                situation.Rigidbody2D.angularVelocity = 0f;
                situation.State = new EndState();
            }
        }
    }
}

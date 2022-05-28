using UnityEngine;

namespace GBAsteroids
{
    internal class EndState : State
    {
        public override void Handle(Situation situation)
        {
            if (Vector3.Distance(situation.Rigidbody2D.transform.localPosition, Vector3.zero) > 10f)
            {
                situation.State = new StartState();
            }
        }
    }
}
using UnityEngine;

namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/ReachedWaypointDecision")]
    public class ReachedWaypointDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            return (stateMachine.GetComponent<PatrolPoints>().HasReachedPoint()) ? true : false;
        }
    }
}
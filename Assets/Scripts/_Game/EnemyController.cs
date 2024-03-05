using SimpleJSON;
using TT;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EntityInfo Info;
    NavMeshAgent agent;

    protected void Start()
    {
        JSONArray array = ServiceLocator.Current.Get<DataService>().GetByEntityInfo(Info).AsArray;

        var nodeTypes = NodeUtils.GetNodeTypes(array);

        for (int i = 0; i < nodeTypes.Length; i++)
        {
            ComponentUtils.HandleNodeType(gameObject, nodeTypes[i]);
        }
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = agent.angularSpeed * 2;

        var stateMachine = GetComponent<StateMachine>();
        stateMachine.Events.RegisterEvent(StateMachine.StateMachineEventType.OnChangeState, (StateController state) =>
        {
            Debug.Log(state.Info.StateName);
        });
    }
}

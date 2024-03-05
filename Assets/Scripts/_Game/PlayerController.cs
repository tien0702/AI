using UnityEngine;
using UnityEngine.AI;
using TT;
using SimpleJSON;

public class PlayerController : SingletonBehaviour<PlayerController>
{
    public EntityInfo Info;
    LineRenderer lineRenderer;
    NavMeshAgent agent;

    protected override void Awake()
    {
        base.Awake();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected void Start()
    {
        gameObject.name = Info.Name;
        JSONArray array = ServiceLocator.Current.Get<DataService>().GetByEntityInfo(Info).AsArray;

        var nodeTypes = NodeUtils.GetNodeTypes(array);

        for (int i = 0; i < nodeTypes.Length; i++)
        {
            Debug.Log(i);
            ComponentUtils.HandleNodeType(gameObject, nodeTypes[i]);
        }
        agent.angularSpeed = 360;

    }

    private void Update()
    {
        if (agent.hasPath)
        {
            DrawPath();
        }
    }

    void DrawPath()
    {
        lineRenderer.positionCount = agent.path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);
        if (agent.path.corners.Length < 2) return;

        lineRenderer.SetPositions(agent.path.corners);
    }
}

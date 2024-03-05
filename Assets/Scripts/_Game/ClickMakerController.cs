using UnityEngine;
using UnityEngine.AI;
using TT;

public class ClickMakerController : SingletonBehaviour<ClickMakerController>
{
    #region Events
    public enum ClickEvent { OnEnable, OnDisable }
    public ObserverEvents<ClickEvent, Vector3> Events { private set; get; }
        = new ObserverEvents<ClickEvent, Vector3>();

    #endregion
    NavMeshAgent agent;
    LineRenderer lineRenderer;

    protected override void Awake()
    {
        base.Awake();
        agent = PlayerController.Instance.GetComponent<NavMeshAgent>();
        lineRenderer = PlayerController.Instance.GetComponentInChildren<LineRenderer>();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(PlayerController.Instance.transform.position, agent.destination) <= agent.stoppingDistance)
            this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (lineRenderer != null)
        {
            lineRenderer.gameObject.SetActive(true);
        }
        Events.Notify(ClickEvent.OnEnable, transform.position);
    }

    private void OnDisable()
    {
        if (lineRenderer != null)
        {
            lineRenderer.gameObject.SetActive(false);
        }
        Events.Notify(ClickEvent.OnDisable, transform.position);
    }
}

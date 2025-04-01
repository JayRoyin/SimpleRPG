using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    private bool haveInteracted;
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        //playAgent.stoppingDistance = 2f;//stoptime
        playerAgent.SetDestination(transform.position);
        haveInteracted = false;
    }

    private void Update()
    {
        if (playerAgent != null && playerAgent.pathPending == false && haveInteracted == false)
        {
            if (playerAgent.remainingDistance <= 2)
            {
                Interact();
                haveInteracted = true;
            }
        }
    }
    protected virtual void Interact()
    {

        Debug.Log("Interacting with " + transform.name);
    }
}

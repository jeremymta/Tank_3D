using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        	RaycastHit hit;
        	if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        	{
        		this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
        	}
        }
    }
}

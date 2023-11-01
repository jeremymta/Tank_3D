using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float knockRadius = 20.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(hit.point);
            }
        }
        if (Input.GetKey("space"))
        {
            StartCoroutine(PlayKnock()); // Play audio file

            // Create the sphere collider
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, knockRadius);
            for (int i = 0; i < hitColliders.Length; i++) // check the collisions
            {
                // If it's a guard, trigger the Investigation!
                if (hitColliders[i].tag == "guard")
                {
                    hitColliders[i].GetComponent<GuardController>().InvestigatePoint(this.transform.position);
                }
            }
        }
    }

    IEnumerator PlayKnock()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
}
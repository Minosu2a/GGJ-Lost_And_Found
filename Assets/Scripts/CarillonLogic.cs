using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarillonLogic : MonoBehaviour
{
    [SerializeField] private Transform _target = null;
    private float maxDistance = 100;
    private int layerMask = 0 << 8;
    QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore;
    private void Start()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    private void Update()
    {
        Vector3 _dir = (_target.position - transform.position).normalized;
        RaycastHit hit;
        Physics.Raycast(transform.position, _dir, out hit, Mathf.Infinity, layerMask, queryTriggerInteraction);
        Debug.DrawRay(transform.position, _dir * hit.distance, Color.red);
        Debug.Log(hit.transform);
    }

}

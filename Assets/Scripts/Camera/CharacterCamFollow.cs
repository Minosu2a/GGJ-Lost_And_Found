using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamFollow : MonoBehaviour
{
    #region Serialized
    [SerializeField] private Transform target;
    [SerializeField] private float smooth;
    [Range(0.01f, 1.0f)]
    #endregion Serialized

    #region Property
    private Vector3 offsetCamera;
    #endregion Property

    #region Methods
    void Start()
    {
        offsetCamera = transform.position - target.position;
    }

    void Update()
    {
        Vector3 cameraPosition = target.position + offsetCamera;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }
    #endregion Methods
}

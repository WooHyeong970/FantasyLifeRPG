using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _target = null;

    public void OnUpdate()
    {
        transform.position = _target.transform.position;
    }
}

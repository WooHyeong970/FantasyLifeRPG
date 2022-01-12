using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    Vector3 delta;

    private void Awake()
    {
        if(target == null)
        {
            TargetToPlayer();
        }
        delta = new Vector3(0,0,-10.0f);
    }

    public void LateUpdate()
    {
        transform.position = target.transform.position + delta;
    }

    public void TargetToPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}

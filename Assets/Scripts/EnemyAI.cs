using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    bool isMoving = false;
    float speed = 2.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!isMoving)
        {
            isMoving = true;
            startingPosition = transform.position;
            roamPosition = GetRoamingPosition();
        }
        else
        {
            if (Vector3.Distance(startingPosition, roamPosition) < 0.1f)
            {
                Vector3 dir = (roamPosition - startingPosition).normalized;
                transform.Translate(dir * speed * Time.deltaTime);
                startingPosition = transform.position;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(2.0f, 2.0f);
    }

    public Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)).normalized;
    }

    private void MoveToRoamingPos()
    {

    }
}

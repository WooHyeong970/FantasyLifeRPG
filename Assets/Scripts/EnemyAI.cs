using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private Vector3 longWayPos;
    private Vector3 shortWayPos;
    private Vector3 longWayDir;
    private Vector3 shortWayDir;
    bool isLongAxisMoving = true;
    bool isIdel = false;
    float speed = 1.0f;
    float delayTime = 5.0f;
    IEnumerator move;

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();

        move = MoveToRoamingPos();
        StartCoroutine(move);
    }

    private void FixedUpdate()
    {
        if(isIdel)
        {
            return;
        }

        if(isLongAxisMoving)
        {
            if(Vector3.Distance(startingPosition, longWayPos) < 0.1f)
            {
                isLongAxisMoving = false;
            }
            transform.Translate(longWayDir * speed * Time.deltaTime);
            startingPosition = transform.position;
        }
        else
        {
            if(Vector3.Distance(startingPosition, roamPosition) < 0.1f)
            {
                isIdel = true;
            }
            transform.Translate(shortWayDir * speed * Time.deltaTime);
            startingPosition = transform.position;
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

    IEnumerator MoveToRoamingPos()
    {
        int rand = UnityEngine.Random.Range(0,2);
        if(rand == 1)
        {
            Debug.Log("Move");
            if(Mathf.Abs(roamPosition.x) > Mathf.Abs(roamPosition.y))
            {
                longWayPos = new Vector3(roamPosition.x, startingPosition.y, 0);
            }
            else
            {
                longWayPos = new Vector3(startingPosition.x, roamPosition.y, 0);
            }
            shortWayPos = new Vector3(roamPosition.x, roamPosition.y, 0);
            longWayDir = (longWayPos - startingPosition).normalized;
            shortWayDir = (roamPosition - longWayPos).normalized;
            isIdel = false;
            isLongAxisMoving = true;
        }
        else
        {
            Debug.Log("Idle");
        }

        yield return new WaitForSeconds(delayTime);

        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();

        move = MoveToRoamingPos();
        StartCoroutine(move);
    }
}

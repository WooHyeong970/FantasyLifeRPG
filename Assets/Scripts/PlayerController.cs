using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed;

    private Vector3 _moveVector;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _moveVector = Vector3.zero;
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();

        Vector3 moveDir = Vector3.zero;

        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();

        if(Mathf.Abs(h) > Mathf.Abs(v))
        {
            moveDir = new Vector3(h, 0.0f, 0.0f);
            if(h > 0)
                spriteRenderer.sprite = GameManager.Resource.Instantiate("playerRight");
            else
                spriteRenderer.sprite = GameManager.Resource.Instantiate("playerLeft");
        }
        else
        {
            moveDir = new Vector3(0.0f, v, 0.0f);
            if(v > 0)
                spriteRenderer.sprite = GameManager.Resource.Instantiate("playerBack");
            else
                spriteRenderer.sprite = GameManager.Resource.Instantiate("playerFront");    
        }
        return moveDir.normalized;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }
}

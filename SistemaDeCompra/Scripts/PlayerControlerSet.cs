using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerSet : MonoBehaviour
{
    private Animator anim;
    public float rotation = 360f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Move()
    {
     
        anim.SetFloat("move", Input.GetAxis("Vertical"));

        transform.Rotate(0, rotation * Input.GetAxis("Horizontal") * Time.deltaTime, 0); ;
    }

    private void Update()
    {
        Move();
    }
}

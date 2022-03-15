using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingChestScript : MonoBehaviour
{
    private Animator _anim;


    private enum States
    {
        Idle = 0,
        Finish =1,
    }


    private States State
    {
        get => (States) _anim.GetInteger("state");
        set => _anim.SetInteger("state", (int) value);
    }



    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            State = States.Finish;
            _anim.Play("");
        }
     
    }
}
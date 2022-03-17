using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class FinishingChestScript : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            animator.SetBool("finish", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPC : MonoBehaviour
{


    public AudioSource npcTalk;
    public GameObject bubble;
    public GameObject bubble2;

    private Collider2D getCollider;


    private void Awake()
    {
        npcTalk.Stop();
        bubble.SetActive(false);
        bubble2.SetActive(false);

    }

    private void Start()
    {
        getCollider = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            npcTalk.Play();
            bubble.SetActive(true);
            bubble2.SetActive(true);
        }
        else
        {
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npcTalk.Stop();
        bubble.SetActive(false);
        bubble2.SetActive(false);
    }
}

using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private LevelMngr lm;

    private void Awake()
    {
        lm = FindObjectOfType<LevelMngr>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            lm.lastCheckPointPos = gameObject.transform.position;
        }
    }
}

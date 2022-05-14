using UnityEngine;

public class LevelMngr : MonoBehaviour
{
    public Vector2 lastCheckPointPos;
    private GameObject player;

    void Start()  
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            player.transform.position = lastCheckPointPos;
        }
    }
}

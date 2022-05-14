using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class ManageInput : MonoBehaviour
{
    public static ManageInput Instance { get; private set; }
    
    public delegate void PlayerJump();
    public event PlayerJump OnPlayerJump;
    public delegate void PlayerAction();
    public event PlayerAction OnPlayerAction;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void JumpPerformed()
    {
        Debug.Log("Jump");
    
        if (OnPlayerJump != null)
        {
            OnPlayerJump();
        }
    }
    
    private void ActionPerformed()
    {
        if (OnPlayerAction != null)
        {
            OnPlayerAction();
        }
    }
}

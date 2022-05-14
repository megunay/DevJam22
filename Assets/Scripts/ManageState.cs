using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class ManageState : MonoBehaviour
{
    public static ManageState Instance { get; private set; }

    public enum currentState
    {
        Menu,
        Game,
        Dead,
    }

    private ManageGame manageGame;
    private Activator[] activatorList;

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

        manageGame = FindObjectOfType<ManageGame>();
        activatorList = FindObjectsOfType<Activator>();
    }

    private void Start()
    {
        ChangeStateToMenu();
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChange;

        if (manageGame != null)
        {
            manageGame.OnGameEvent += ChangeStateToGame;
            manageGame.OnMenuEvent += ChangeStateToMenu;
            manageGame.OnPauseEvent += ChangeStateToPause;
            manageGame.OnDeadEvent += ChangeStateToDead;
        }
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;

        if (manageGame != null)
        {
            manageGame.OnGameEvent -= ChangeStateToGame;
            manageGame.OnMenuEvent -= ChangeStateToMenu;
            manageGame.OnPauseEvent -= ChangeStateToPause;
            manageGame.OnDeadEvent -= ChangeStateToDead;
        }
    }

    private void OnSceneChange(Scene current, Scene next)
    {
        manageGame = FindObjectOfType<ManageGame>();
        activatorList = FindObjectsOfType<Activator>();

        ChangeStateToMenu();
    }

    private void ChangeStateToMenu()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.menuActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }

    private void ChangeStateToGame()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.gameActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }
    private void ChangeStateToPause()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.pauseActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }

    private void ChangeStateToDead()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.deadActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }
}


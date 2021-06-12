using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    private bool gameEnded = false;
    private float currentTime;
    [SerializeField] private float startingTime;
    [SerializeField] private Text timerCountText;
    [SerializeField] private float reloadSceneDelay = 1f;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource winSound;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerCountText.text = "Timer: " + currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            timerCountText.text = "Time's Up!";
            Invoke("EndGame", reloadSceneDelay);
        }
    }

    private void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            ReloadGame();
        }
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlaySound(string soundName)
    {
        if (soundName == "playerDeath")
        {
            playerDeath.Play();
        }
        else if (soundName == "winSound")
        {
            winSound.Play();
        }
    }
}

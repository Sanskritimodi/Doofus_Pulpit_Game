/*using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Score: " + score);

        if (score >= 50)
        {
            Debug.Log("You win!");
            // Add additional win logic here
        }
    }
}*/


using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    public UnityEngine.UI.Text scoreText; // Reference to a UI Text component for displaying the score
    public GameObject gameOverScreen; // Reference to a Game Over screen UI

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Hide the Game Over screen at the start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void IncreaseScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (score >= 50)
        {
            Debug.Log("You win!");
            // Optionally handle win condition here
        }
    }

    public void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // Optionally restart the game or go back to the main menu
        // RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
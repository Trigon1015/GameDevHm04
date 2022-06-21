using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public BallController ball { get; private set; }
    public PaddleController paddle { get; private set; }


    public int level = 1;
    public int score = 0;
    public int lives = 3;
   private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        //Debug.Log(this.lives);
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        LoadLevel(1);
    }

    private void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scne, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<BallController>();
        this.paddle = FindObjectOfType<PaddleController>();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        NewGame();
    }
    public void Miss()
    {
        this.lives--;

        if(this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;
    }
}

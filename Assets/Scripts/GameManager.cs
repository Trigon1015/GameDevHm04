using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public BallController ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    public TMP_Text text;


    public static int level = 1;
    public  static int score = 0;
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
        Debug.Log(level);
        text.text = score.ToString();
    }

    private void NewGame()
    {
        if(score > 0)
        {
            score -= 1000;
        }
        else
        {
            score = 0;
        }
        
        this.lives = 3;
        //LoadLevel(level);
    }

    private void LoadLevel(int levels)
    {
        level = levels;
        
        if(level > 3)
        {
            SceneManager.LoadScene("Endgame");

        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    private void OnLevelLoaded(Scene scne, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<BallController>();
        this.paddle = FindObjectOfType<PaddleController>();
        this.bricks = FindObjectsOfType<Brick>();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
        if (score > 0)
        {
            score -= 100;
        }
        else
        {
            score = 0;
        }
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
        score += brick.points;
        if(Cleared())
        {
            LoadLevel(level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i<this.bricks.Length; i++)
        {
            if(bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                
                return false;
            }
        }
        
        return true;
    }
}

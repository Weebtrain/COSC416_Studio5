using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private GameObject AudioMenu;
    [SerializeField] private int score = 0;
    [SerializeField] private ScoreCounterUI scoreCounter;

    private int currentBrickCount;
    private int totalBrickCount;


    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        InputHandler.Instance.OnEscape.AddListener(ToggleAudioMenu);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here
        AudioManager.Instance.PlaySoundEffect(0);
        // implement particle effect here
        // add camera shake here
        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        IncreaseScore();
        if (currentBrickCount == 0)
        {
            AudioManager.Instance.PlaySoundEffect(1);
            AudioManager.Instance.EndMusic();
            SceneHandler.Instance.LoadNextScene();
        }
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        ball.ResetBall();
    }

    public void ToggleAudioMenu ()
    {
        AudioMenu.SetActive(!AudioMenu.activeSelf);
        if (AudioMenu.activeSelf)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreCounter.UpdateScore(score);
    }
}

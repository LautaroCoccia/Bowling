using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UIScore;
    [SerializeField] private TextMeshProUGUI UIPins;
    [SerializeField] private TextMeshProUGUI UITries;
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private Slider ForceSlider;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject QuitMenu;
    [SerializeField] private GameObject GameOverMenu;
    private static bool pause = false;
    int score = 0;
    int lives = 0;
    int pinsLeft = 0;
    private static LevelManager _instanceLevelManager;
    bool fullSlide = false;
    private const float minForce = 100;
    private const float maxForce = 750;
    private const int maxLives = 3;
    private const int minLives = 1;
    private Vector3 finalSpeed;
    private bool activeForce = false;
    public static LevelManager Get()
    {
        return _instanceLevelManager;
    }
    private void Awake()
    {
        if (_instanceLevelManager == null)
        {
            _instanceLevelManager = this;
        }
        else if (_instanceLevelManager != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        pause = false;
        lives = maxLives;
        SetTimeScale(1);
    }
    private void Update()
    {
        UpdateSlider();
        UpdateTries();
    }
    private void UpdateSlider()
    {
        if(!GetForceActive())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetPause();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (!fullSlide)
                {
                    ForceSlider.value += 5 * Time.deltaTime;
                    if (ForceSlider.value >= 1)
                    {
                        fullSlide = !fullSlide;
                    }
                }
                else if (fullSlide)
                {
                    ForceSlider.value -= 5 * Time.deltaTime;
                    if (ForceSlider.value <= 0.05)
                    {
                        fullSlide = !fullSlide;
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                fullSlide = false;
                SetForceActive();
                finalSpeed = Vector3.Lerp(new Vector3(0, 0, minForce), new Vector3(0, 0, maxForce), ForceSlider.value);
                ForceSlider.value = 0;
            }
        }
    }
    private void UpdateScore()
    {
        UIScore.text = ("SCORE: " + score);
    }
    private void UpdateTries()
    {
        UITries.text = ("TRIES: " + lives);
        if(lives<minLives)
        {
            GameOver();
        }
    }
    private void UpdatePinsLeft()
    {
        UIPins.text = "KEGEL LEFT: " + pinsLeft;
        if(pinsLeft == 0)
        {
            pinsLeft = 0;
            GameOver();
        }

    }
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        GameOverMenu.SetActive(true);
        UIExtras.text = ("TRIES LEFT: " + lives + "\n"
                + "KEGEL LEFT: " + pinsLeft + "\n"
                + ("SCORE: " + score));
    }
    public void SetPause()
    {
        pause = !pause;

        if (pause)
        {
            SetTimeScale(0);
            PauseMenu.SetActive(pause);
        }
        else
        {
            SetTimeScale(1);
            PauseMenu.SetActive(pause);
            QuitMenu.SetActive(pause);
        }
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    public void AddPins(int pins)
    {
        pinsLeft += pins;
        UpdatePinsLeft();
    }
    public Vector3 GetSpeed()
    {
        return finalSpeed;
    }
    public void SetSpeed()
    {
        finalSpeed = Vector3.zero;
    }
    public void SetForceActive()
    {
        activeForce = !activeForce;
    }
    public void UpdateLives()
    {
        lives--;
    }
    public bool GetForceActive()
    {
        return activeForce;
    }
}

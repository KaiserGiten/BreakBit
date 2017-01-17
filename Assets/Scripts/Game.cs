using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Game : MonoBehaviour
{
    [SerializeField][Range(1,650)] private int MaxScore = 0;
    private int score = 0;
    private int lives = 3;
    public GUIText ScoreText;
    public GUIText LifeText;
    public GameObject balls;
    public AudioClip impact;
    new AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Restart();
        Winstate();
        Losestate();
        UpdateLife();
        if (Input.GetButtonDown("Fire1"))
        {
            Slowmotion();
        }
    }

    // Update is called once per frame
    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }
    void UpdateLife()
    {
        LifeText.text = "Life: " + lives;
    }
    public void AddScore()
    {
        score += 10;
        UpdateScore();
    }
    public void Restart()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Winstate()
    {
        
        if (score >= MaxScore)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void PlayAudio()
    {
        audio.PlayOneShot(impact, 0.1F);
    }
    void Slowmotion()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = 0.21F;
        else
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    void Losestate()
    {
        if (GameObject.FindWithTag("ball") == null)
        {
            lives -= 1;
            if (lives == 0)
            {
                //if (Input.GetButtonDown("Reset"))
                //{
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //}
            }
            else
            {
                Instantiate(balls, new Vector3(0, -80, 0), transform.rotation);
            }
        }
    }
 }

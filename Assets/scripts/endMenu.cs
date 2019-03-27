using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endMenu : MonoBehaviour
{
    public Text score;
    public Text highScore;


    // Start is called before the first frame update
    void Start()
    {
        score.text = PlayerPrefs.GetInt("score", 0).ToString();
        if(PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
        }
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }
}

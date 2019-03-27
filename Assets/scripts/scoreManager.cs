using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    public void scoreAdder(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("score", score);
    }

}

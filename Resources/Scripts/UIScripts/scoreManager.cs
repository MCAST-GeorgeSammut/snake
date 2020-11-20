using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    Text scoreText;

    public static int scoreValue =0;

    public bool scoreStarted;



    IEnumerator scoreTracker()
    {
        while (true)
        {
            if (scoreStarted)
            {
                scoreText.text = "Score: " + scoreValue;

                yield return null;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        StartCoroutine(scoreTracker());
    }

}

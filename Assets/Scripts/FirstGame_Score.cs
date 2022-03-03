using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstGame_Score : MonoBehaviour
{
    public int counter_score;
    public Text textScore;

    private void Start()
    {
        counter_score = 0;
    }
    void Update()
    {
        textScore.text = $"Score: {counter_score}";
    }
}

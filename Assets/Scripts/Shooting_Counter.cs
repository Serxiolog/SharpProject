using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting_Counter : MonoBehaviour
{
    public int counter_bullets;
    public Text textBullets;
    public int counter_score;
    public Text textScore;
    public int HP;
    public Text textHP;
    public bool boolHP;
    public bool boolBullets;

    private void Start()
    {
        counter_bullets = 10;
        counter_score = 0;
        HP = 20;
    }
    void Update()
    {
        if (boolHP)
            textHP.text = $"HP: {HP}/20";
        if (boolBullets)
            textBullets.text = $"Bullets Left: {counter_bullets}/10";
        textScore.text = $"Score: {counter_score}";
    }

    

}

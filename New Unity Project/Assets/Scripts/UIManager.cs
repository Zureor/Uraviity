using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    PlayerGravity playerGravity;
    public TextMeshProUGUI timer;

    private float countdown;
    private int countdownRounding;
    void Start()
    {
        playerGravity = FindObjectOfType<PlayerGravity>();
        countdown = playerGravity.GravityTimer + .5f;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        countdownRounding = Mathf.RoundToInt(countdown);
        timer.text = "Changing Gravity in: " + countdownRounding;
        if (countdown <= 0)
        {
            countdown = playerGravity.GravityTimer;
        }
    }
}

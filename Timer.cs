using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    private int timerCountdown = 5;
    public Text timerText;
    [HideInInspector] public bool isGameStart;

    void Start()
    {
        isGameStart = false;
        StartCoroutine(TimeCount());
    }

    void Update()
    {
        if (timerCountdown == 0)
            isGameStart = true;
    }
    IEnumerator TimeCount()
    {
        while (timerCountdown > 0)
        {
            timerText.text = timerCountdown.ToString();
            yield return new WaitForSeconds(1);
            timerCountdown--;
        }

        timerText.text = "Go!";
    }
}

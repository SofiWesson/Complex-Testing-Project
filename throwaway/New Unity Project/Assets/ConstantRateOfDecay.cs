using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.EditorTools;

public class ConstantRateOfDecay : MonoBehaviour
{
    [Header("Time")]
    public float time = 0;
    public float timeMax = 0;

    [Space(10)] [Header("Amount")]
    public float amount = 0;
    public float amountMin = 0;
    public float amountMax = 0;

    [Space(10)] [Header("Add")]
    public float addAmount = 0;
    public bool TestAddAmount = false;

    [Space(10)] [Header("Other")]
    public float t = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeMax = time;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    time = time + Time.deltaTime;
        //}
        //else if (Keyboard.current.downArrowKey.isPressed)
        //{
            time = time - Time.deltaTime;
        //}
        time = Mathf.Clamp(time, 0f, timeMax);

        t = time / timeMax;

        amount = Lerp(amountMin, amountMax, t);

        if (TestAddAmount)
        {
            AddAmount(addAmount);
            TestAddAmount = false;
        }
    }

    float Lerp(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    void AddAmount(float amountToAdd)
    {
        time = (amount + amountToAdd) / amountMax * timeMax;
    }
}

using System;
using System.Runtime.CompilerServices;
using NUnit.Framework.Internal;
using UnityEngine;

public class Operator : MonoBehaviour
{


    private void Start()
    {
        ex1();
        ex2();
        ex3();
    }
    private static void ex1()
    {
        int health = 100;

        if (health >= 70)
        {
            Debug.Log("건강함니다");
        }
        else if (health > 30)
        {
            Debug.Log("약간 지쳤슴니다");
        }
        else if (health > 0)
        {
            Debug.Log("위험함니다");
        }
        else
        {
            Debug.Log("사망임니다");
        }
    }
    private void ex2()
    {
        int mathScore = 95;
        int englishScore = 85;

        int average = (mathScore + englishScore) / 2;

        if (average >= 90)
        {
            Debug.Log("합격");
        }
        else
        {
            Debug.Log("불합격");
        }
    }
    private void ex3()
    {
        int level = 5;
        bool hasSpscialItem = true;
        bool isInbattle = true;

        if (level >= 5 && hasSpscialItem && isInbattle)
        {
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("NO");
        }
    }
    void Update()
    {

    }
}

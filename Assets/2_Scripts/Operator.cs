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
            Debug.Log("�ǰ��Դϴ�");
        }
        else if (health > 30)
        {
            Debug.Log("�ణ ���ƽ��ϴ�");
        }
        else if (health > 0)
        {
            Debug.Log("�����Դϴ�");
        }
        else
        {
            Debug.Log("����Ӵϴ�");
        }
    }
    private void ex2()
    {
        int mathScore = 95;
        int englishScore = 85;

        int average = (mathScore + englishScore) / 2;

        if (average >= 90)
        {
            Debug.Log("�հ�");
        }
        else
        {
            Debug.Log("���հ�");
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

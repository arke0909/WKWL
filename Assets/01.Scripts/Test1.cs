using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject test;

    Test2 Test2;

    private void Awake()
    {
        Test2 = GetComponent<Test2>();

        Test2.OnLeftClickEvent += ClickEffect;
    }
    private void ClickEffect()
    {
        GameObject test2 = Instantiate(test);
        test2.transform.SetPositionAndRotation(Test2.MousePos ,transform.rotation);
        Debug.Log(Input.mousePosition);
        Debug.Log(test2.transform.position);
    }
}

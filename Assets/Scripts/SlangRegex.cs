using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlangRegex : MonoBehaviour
{
    static string patternSlang = "(��|����|����|�Ͼ�)";
    public List<string> slangs;

    void Start()
    {
        for(int i = 0; i < slangs.Count; i++)
        {
            string result = Regex.Replace(slangs[i], patternSlang, "*");
            Debug.Log($"�ٸ��� �� : {result}");
        }
    }
    

    // ���콺������ �Լ� ���� ǥ��...
    /// <summary>
    /// ���޹��� ���� ���
    /// </summary>
    /// <param name="a">���޹޴� ���� a</param>
    public void Foo(int a)
    {

    }
}

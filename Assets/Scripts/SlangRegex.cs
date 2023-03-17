using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlangRegex : MonoBehaviour
{
    static string patternSlang = "(개|개새|씨발|니애)";
    public List<string> slangs;

    void Start()
    {
        for(int i = 0; i < slangs.Count; i++)
        {
            string result = Regex.Replace(slangs[i], patternSlang, "*");
            Debug.Log($"바른말 고운말 : {result}");
        }
    }
    

    // 마우스오버로 함수 설명 표시...
    /// <summary>
    /// 전달받은 정수 출력
    /// </summary>
    /// <param name="a">전달받는 정수 a</param>
    public void Foo(int a)
    {

    }
}

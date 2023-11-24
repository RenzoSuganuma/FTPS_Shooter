using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
public class InputTestClass : MonoBehaviour
{
    InputPooler _iPooler;
    private void Start()
    {
        _iPooler = GetComponent<InputPooler>();
    }

    private void Update()
    {
        Debug.Log(_iPooler.GetActionValueAsButton("Player", "Fire"));
    }
}
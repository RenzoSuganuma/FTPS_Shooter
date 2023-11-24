using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
public class InputTestClass : MonoBehaviour
{
    InputValueWindow _inputVWindow;
    private void Start()
    {
        _inputVWindow = GetComponent<InputValueWindow>();
    }

    private void Update()
    {
        Debug.Log(_inputVWindow.GetActionValueAsButton("Player", "Fire"));
    }
}
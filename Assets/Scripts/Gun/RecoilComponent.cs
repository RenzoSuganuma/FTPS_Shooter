using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
using UnityEngine.InputSystem;
/// <summary> �e�̔������Č�����R���|�[�l���g </summary>
public class RecoilComponent : MonoBehaviour
{
    InputWindowLL _input;

    private void Start()
    {
        _input = GameObject.FindFirstObjectByType<InputWindowLL>();
    }

    private void FixedUpdate()
    {
        
    }

    public void OnMove(InputAction.CallbackContext callback)
    {

    }

    public void OnLook(InputAction.CallbackContext callback)
    {

    }

    public void OnFire(InputAction.CallbackContext callback)
    {

    }
}
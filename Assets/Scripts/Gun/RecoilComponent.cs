using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
using UnityEngine.InputSystem;
/// <summary> 銃の反動を再現するコンポーネント </summary>
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
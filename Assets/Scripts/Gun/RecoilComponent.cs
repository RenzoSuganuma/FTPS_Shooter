using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
using UnityEngine.InputSystem;
/// <summary> 銃の反動を再現するコンポーネント </summary>
public class RecoilComponent : MonoBehaviour
{
    InputWindowLL _input;
    Vector2 _recoilDir;

    private void Start()
    {
        _input = GameObject.FindFirstObjectByType<InputWindowLL>();
        _input.BindAction("Player", "Fire",
            (InputAction.CallbackContext context) =>
            {
                _recoilDir = (context.ReadValueAsButton()) ? Vector2.up : Vector2.zero;
            }
        );
    }

    private void FixedUpdate()
    {
        Debug.Log(_recoilDir.ToString());
        Camera main = Camera.main;
        Quaternion rotation = main.transform.rotation;

        if (_recoilDir != Vector2.zero)
            rotation.x += _recoilDir.y * -Time.deltaTime;
        else if(rotation.x != 0)
            rotation.x += Time.deltaTime;

        main.transform.rotation = rotation;
    }
}
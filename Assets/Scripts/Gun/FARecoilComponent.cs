using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSEngine;
using UnityEngine.InputSystem;
/// <summary> 銃の反動を再現するコンポーネント (Full Auto) </summary>
public class FARecoilComponent : MonoBehaviour
{
    [SerializeField] Camera _cam;
    InputWindowLL _input;
    Vector2 _recoilDir;
    float _elapsedTime;

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
        Quaternion rotation = _cam.transform.rotation;

        if (_recoilDir != Vector2.zero)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > 1.0f / 30.0f)
            {
                Debug.Log("Bang!");
                _elapsedTime = 0;

                if (_recoilDir != Vector2.zero)
                    rotation.x += _recoilDir.y * -Time.deltaTime;
            }
        }
        else if (rotation.x < 0)
        {
            rotation.x += Time.deltaTime;
        }

        _cam.transform.rotation = rotation;
    }
}
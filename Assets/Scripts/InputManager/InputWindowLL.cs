using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace RSEngine
{
    [RequireComponent(typeof(PlayerInput))]
    /// <summary> InputSystem の InputActionAsset に登録されているアクションにデリゲートをバインドする機能を提供する </summary>
    public class InputWindowLL : MonoBehaviour
    {
        [SerializeField] InputActionAsset _inputAction;
        [SerializeField] bool _dontDestroyThis;
        PlayerInput _playerInputComponent;

        private void Awake()
        {
            if (_dontDestroyThis) GameObject.DontDestroyOnLoad(this.gameObject);
            _playerInputComponent = GetComponent<PlayerInput>();
        }

        // アクション名を指定してそれに登録
        public void BindAction(string actionMapName, string actionName
            , Action<InputAction.CallbackContext> callbackAction)
        {
            var actionMap = _inputAction.FindActionMap(actionMapName);
            var action = actionMap.FindAction(actionName);
            action.started += callbackAction;
            action.performed += callbackAction;
            action.canceled += callbackAction;
        }

        public void BindAction(string actionMapName, string actionName
            , Action<InputAction.CallbackContext> callbackAction, ActionInvokeStep actionInvokingFaze)
        {
            var actionMap = _inputAction.FindActionMap(actionMapName);
            var action = actionMap.FindAction(actionName);
            switch (actionInvokingFaze)
            {
                case ActionInvokeStep.Started:
                    action.started += callbackAction;
                    break;
                case ActionInvokeStep.Performed:
                    action.performed += callbackAction;
                    break;
                case ActionInvokeStep.Canceled:
                    action.canceled += callbackAction;
                    break;
            }
        }

        public T GetActionValueAs<T>(string actionMapName, string actionName)
        {
            var actionMap = _inputAction.FindActionMap(actionMapName);
            var action = actionMap.FindAction(actionName);
            T result = default;
            if (action != null)
            {
                var input = action.ReadValueAsObject();
                if (input != null)
                    result = (T)input;
            }
            return result;
        }

        public bool GetActionValueAsButton(string actionMapName, string actionName)
        {
            var actionMap = _inputAction.FindActionMap(actionMapName);
            var action = actionMap.FindAction(actionName);
            return action.IsPressed();
        }
    }

    public enum ActionInvokeStep
    {
        Started,
        Performed,
        Canceled
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace RSEngine
{
    /// <summary> InputSystem �� InputActionAsset �ɓo�^����Ă���A�N�V�����Ƀf���Q�[�g���o�C���h����@�\��񋟂��� </summary>
    public class InputWindowLL : MonoBehaviour
    {
        [SerializeField] InputActionAsset _inputAction;
        [SerializeField] bool _dontDestroyThis;

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
            if (_dontDestroyThis) GameObject.DontDestroyOnLoad(this.gameObject);
        }

        // �A�N�V���������w�肵�Ă���ɓo�^
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
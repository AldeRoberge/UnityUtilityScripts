using System;
using System.Collections.Generic;
using InputActions;
using UnityEngine;

namespace PlayerInput
{
    
    /**
    * Allows to dynamically bind an InputType to an action.
    * TODO is fatally broken. OnDisable breaks it.
    */
    public class UIInputBinder : MonoBehaviour
    {
        private UIInputActions inputAction;

        public void Start()
        {
            inputAction = new UIInputActions();
        }

        public void OnEnable()
        {
            if (inputAction == null)
            {
                inputAction = new UIInputActions();
            }

            inputAction.Enable();

            foreach (KeyValuePair<InputType, Action> keyValuePair in toRebind)
            {
                Bind(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public void OnDisable()
        {
            inputAction.Disable();
        }

        Dictionary<InputType, Action> toRebind = new Dictionary<InputType, Action>();

        public void Bind(InputType inputType, Action onDo)
        {
            toRebind.Add(inputType, onDo);
            
            Debug.Log(name + " ToRebind amount : " + toRebind.Count);

            switch (inputType)
            {
                case InputType.A:
                    inputAction.Control.A.performed += ctx => { onDo.Invoke(); };
                    break;
                case InputType.B:
                    inputAction.Control.B.performed += ctx => { onDo.Invoke(); };
                    break;
                case InputType.X:
                    inputAction.Control.X.performed += ctx => { onDo.Invoke(); };
                    break;
                case InputType.Y:
                    inputAction.Control.Y.performed += ctx => { onDo.Invoke(); };
                    break;
                case InputType.DPadLeft:
                    inputAction.Control.DPadLeft.performed += ctx => { onDo.Invoke(); };
                    break;
                case InputType.DPadRight:
                    inputAction.Control.DPadRight.performed += ctx => { onDo.Invoke(); };
                    break;
                default:
                    Debug.LogError("Unhandled InputType : " + inputType + ".");
                    break;
            }
        }
    }
}

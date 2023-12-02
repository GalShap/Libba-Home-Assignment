using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace InputHandling
{
    public abstract class InputReceiver<T> : MonoBehaviour
    {   
        // a generic input type from user.
        protected UserInput<T> UserInput;

        protected virtual void Start()
        {
            SetUpInput();
        }

        /// <summary>
        /// sets up class in order to receive input from user.
        /// </summary>
        public abstract void SetUpInput();
        
        /// <summary>
        /// Once input receiver is set up, gets input from user and sets is as the generic T. 
        /// </summary>
        public abstract void GetInputFromUser();

        public T GetCurInput() => UserInput.Input;
    }
}

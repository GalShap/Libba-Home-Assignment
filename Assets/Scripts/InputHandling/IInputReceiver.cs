using UnityEngine;

namespace InputHandling
{
    public abstract class InputReceiver<T> : MonoBehaviour
    {   
        // a generic input type from user.
        public T UserInput { get; protected set; }
        
        /// <summary>
        /// sets up class in order to receive input from user.
        /// </summary>
        public abstract void SetUpInput();
        
        /// <summary>
        /// Once input receiver is set up, gets input from user and sets is as the generic T. 
        /// </summary>
        public abstract void GetInputFromUser();
    }
}

using UnityEngine;

namespace InputHandling
{   
    // class is a parent class for every input given by user. 
    public abstract class UserInput<T>
    {
        public T Input { get; set; }
    }
} 
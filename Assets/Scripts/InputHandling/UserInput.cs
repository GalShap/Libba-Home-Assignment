using UnityEngine;

namespace InputHandling
{
    public abstract class UserInput<T>
    {
        public T Input { get; set; }
    }
} 
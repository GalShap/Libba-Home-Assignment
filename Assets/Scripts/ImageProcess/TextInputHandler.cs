using System;
using InputHandling;
using TMPro;
using UnityEngine;

namespace ImageProcess
{   
    
    /// <summary>
    /// class is made to get a textual input from user, process it and make it available to
    /// be passed forward. 
    /// </summary>
    public class TextInputHandler : InputReceiver<string>
    {
        #region Serialized Fields

        [SerializeField] private TMP_InputField textInputField;

        [SerializeField] private TextMeshProUGUI latestTextDisplay;

        [SerializeField] private string preInputDisplayText = "Your latest text appears here!";

        [SerializeField] private string postInputDisplayText = "Current text input: ";
        
        #endregion

        #region Mono Behaviour
        protected override void Start()
        {
            base.Start();
            UserInput = new TextInput();
        }
        #endregion

        #region Public Methods

        protected override void SetUpInput()
        {   
            latestTextDisplay.text = preInputDisplayText;
        }

        public override void GetInputFromUser()
        {   
            
            UserInput.Input = textInputField.text;
            latestTextDisplay.text = postInputDisplayText + UserInput.Input;
        }
        
        #endregion
    }
}

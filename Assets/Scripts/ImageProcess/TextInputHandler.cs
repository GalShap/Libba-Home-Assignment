using System;
using InputHandling;
using TMPro;
using UnityEngine;

namespace ImageProcess
{
    public class TextInputHandler : InputReceiver<string>
    {
        #region Serialized Fields

        [SerializeField] private TMP_InputField textInputField;

        [SerializeField] private TextMeshProUGUI latestTextDisplay;

        [SerializeField] private string preInputDisplayText = "Your latest text appears here!";

        [SerializeField] private string postInputDisplayText = "Current text input: ";
        
        #endregion

        private void Start()
        {
            SetUpInput();
        }

        public override void SetUpInput()
        {
            latestTextDisplay.text = preInputDisplayText;
        }

        public override void GetInputFromUser()
        {
            UserInput = textInputField.text;
            latestTextDisplay.text = postInputDisplayText + UserInput;
        }
    }
}

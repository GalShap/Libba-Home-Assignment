using System.Collections.Generic;
using ImageProcess;
using OpenAI.Chat;
using UnityEngine;
using UnityEngine.Events;
using Utilities;

namespace InputToApi
{
    public class OpenAiVisionConnector : MonoBehaviour, IInputApiConnector
    {

        #region Serialized Field
        
        [SerializeField] private WebCamCapturer webCamCapturer;

        [SerializeField] private TextInputHandler textInputHandler;

        [SerializeField] private UnityEvent<ChatResponse> onGetResult;
        
        #endregion

        #region Private fields

        private bool _hasText = false;

        private bool _hasImage = false;
        
        #endregion

        #region Public Methods

        /// <summary>
        /// used in order to update class that a text input was given, in order not to send empty input
        /// to API.
        /// </summary>
        public void OnEnteredText()
        {
            if (_hasText) return;
            _hasText = true;
        }
        
        /// <summary>
        /// used in order to update class that an image input was given, in order not to send empty input
        /// to API.
        /// </summary>
        public void OnCapturedImage()
        {
            if (_hasImage) return;
            _hasImage = true;
        }
        
        public async void SendInputToApi()
        {
            if (!_hasImage || !_hasText) return;

            string text = textInputHandler.GetCurInput();
            Texture2D photo = webCamCapturer.GetCurInput();

            var contentList = new List<Content>()
            {
                text,
                photo
            };
            
            ChatResponse result = await OpenAiClientProvider.Instance.SendContent(contentList, Constants.Vision);
            onGetResult.Invoke(result);
        }
        
        #endregion
    }
}
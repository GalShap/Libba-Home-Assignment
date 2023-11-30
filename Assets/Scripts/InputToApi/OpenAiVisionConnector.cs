using System.Threading.Tasks;
using ImageProcess;
using InputHandling;
using OpenAI;
using OpenAI.Chat;
using UnityEngine;

namespace InputToApi
{
    public class OpenAiVisionConnector : MonoBehaviour, IInputApiConnector
    {
        
        [SerializeField] private WebCamCapturer webCamCapturer;

        [SerializeField] private TextInputHandler textInputHandler;

        private bool _hasText = false;

        private bool _hasImage = false;

        public void OnEnteredText()
        {
            if (_hasText) return;
            _hasText = true;
        }

        public void OnCapturedImage()
        {
            if (_hasImage) return;
            _hasImage = true;
        }
        
        public async void SendInputToApi()
        {
            if (!_hasImage || !_hasText) return;

            string text = textInputHandler.UserInput;
            Texture2D photo = webCamCapturer.UserInput;

            ChatResponse result = await OpenAiClientWrapper.Instance.SendTextAndImage(text, photo);

            Debug.Log(result.ToString());
        }
    }
}
using InputHandling;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace ImageProcess
{   
    /// <summary>
    /// class is made to capture an image input from webcam, process it and make it available to
    /// be passed forward. 
    /// </summary>
    public class WebCamCapturer : InputReceiver<Texture2D>
    {   
        #region SerializeField
        
        [SerializeField] private Image webCamRenderer;

        [SerializeField] private Image webCamShotDisplay;

        [SerializeField] private string imageSavePath;
        
        #endregion
        
        #region Private fields

        private WebCamTexture _webCamTexture;

        private bool _isFirstPic = true;

        #endregion

        #region Mono Behaviour

        private void Start()
        {
                    SetUpInput();
        }

        #endregion
        
        #region Public Methods

        public  override void SetUpInput()
        {   
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == Constants.Empty)
                Debug.LogWarning("No camera devices found, please connect a camera and restart scene");

            _webCamTexture = new WebCamTexture(1920,1080,30);
            webCamRenderer.material.mainTexture = _webCamTexture;
            _webCamTexture.Play();
        }

        public override void GetInputFromUser()
        {   
            _webCamTexture.Pause();

            Texture2D photo = new Texture2D(_webCamTexture.width, _webCamTexture.height);
            photo.SetPixels(_webCamTexture.GetPixels());
            photo.Apply();

            if (_isFirstPic)
            {
                _isFirstPic = false;
                webCamShotDisplay.color = Color.white;
            }

            webCamShotDisplay.sprite = Sprite.Create(photo, 
                new Rect(0, 0, photo.width, photo.height), Vector2.zero);
            
            byte[] bytes = photo.EncodeToPNG();
            UserInput = photo;
            System.IO.File.WriteAllBytes(imageSavePath + "/LatestPhoto.png", bytes);
        
            // Resume the camera
            _webCamTexture.Play();
        }

        #endregion
    }
}
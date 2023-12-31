﻿using InputHandling;
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

        #endregion
        
        #region Private fields

        private WebCamTexture _webCamTexture;

        private bool _isFirstPic = true;

        #endregion

        #region Mono Behaviour

        protected override void Start()
        {
            base.Start();
            UserInput = new ImageInput();
        }

        #endregion
        
        #region Public Methods

        protected override void SetUpInput()
        {   
            // check if a camera device is connected.
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == Constants.Empty)
                Debug.LogWarning("No camera devices found, please connect a camera and restart scene");
            
            // set a new camera texture on screen.
            _webCamTexture = new WebCamTexture(1920,1080,30);
            webCamRenderer.material.mainTexture = _webCamTexture;
            _webCamTexture.Play();
        }

        public override void GetInputFromUser()
        {   
            _webCamTexture.Pause();
            
            // create a new texture based on the latest pixels from camera.
            Texture2D photo = new Texture2D(_webCamTexture.width, _webCamTexture.height);
            photo.SetPixels(_webCamTexture.GetPixels());
            photo.Apply();

            if (_isFirstPic)
            {
                // make the image appear in screen if it's first snapshot. 
                _isFirstPic = false;
                webCamShotDisplay.color = Color.white;
            }
            
            // set the snapshot onto the image, to see latest image taken. 
            webCamShotDisplay.sprite = Sprite.Create(photo, 
                new Rect(0, 0, photo.width, photo.height), Vector2.zero);
            
            UserInput.Input = photo;
           
            // Resume the camera
            _webCamTexture.Play();
        }

        #endregion
    }
}
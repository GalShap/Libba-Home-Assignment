using OpenAI.Chat;
using TMPro;
using UnityEngine;

namespace APIOutput
{
    /// <summary>
    /// class gets a response from an openAI model and analyze it for further use. 
    /// </summary>
    public class TextualResponseHandler : MonoBehaviour,IApiOutputHandler
    {
        #region serialized fields

        [SerializeField] private TextMeshProUGUI responseDisplay;
        
        [SerializeField] private string responsePrefix;
        
        #endregion
        
        /// <summary>
        /// will be invoked when a result has returned from the open ai model. 
        /// </summary>
        /// <param name="response"> A response given from the open ai model </param>
        public void OnGetResponseFromAPI(ChatResponse response)
        {
            string responseText = response.ToString();
            responseDisplay.text = responsePrefix + responseText;
        }
    }
}
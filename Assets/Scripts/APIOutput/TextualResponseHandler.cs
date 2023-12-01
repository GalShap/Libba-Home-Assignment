using OpenAI.Chat;
using TMPro;
using UnityEngine;

namespace APIOutput
{
    public class TextualResponseHandler : MonoBehaviour,IApiOutputHandler
    {
        #region serialized fields

        [SerializeField] private TextMeshProUGUI responseDisplay;
        
        [SerializeField] private string responsePrefix;
        
        #endregion
        
        public void OnGetResponseFromAPI(ChatResponse response)
        {
            string responseText = response.ToString();
            responseDisplay.text = responsePrefix + responseText;
        }
    }
}
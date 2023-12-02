using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using UnityEngine;
using Utilities;

namespace InputToApi
{   
    /// <summary>
    /// Class acts a Facade on the OpenAIClient class from the OpenAI package. 
    /// </summary>
    public class OpenAiClientProvider : SingletonPersistent<OpenAiClientProvider>
    {
        [SerializeField] private string pathToDirectory;
        
        private OpenAIClient _openAIClient;

        private void Start()
        {
            _openAIClient = new OpenAIClient(new OpenAIAuthentication().
                LoadFromDirectory(pathToDirectory));
        }

        /// <summary>
        /// get's a textual and texture input and sends it to openAI through client.
        /// </summary>
        /// <param name="contents">
        /// 
        /// </param>
        /// <param name="model">
        ///
        /// </param>
        /// <returns> A chat response from the chatgpt4 vision model. </returns>
        public async Task<ChatResponse> SendTextAndImage(List<Content> contents, string model)
        {
            var messages = new List<Message>
            {
                new Message(Role.System, "You are a helpful assistant."),
                new Message(Role.User, contents)
            };
            var chatRequest = new ChatRequest(messages, model);
            var result = await _openAIClient.ChatEndpoint.GetCompletionAsync(chatRequest);
            return result;
        }
        
        

    }
}
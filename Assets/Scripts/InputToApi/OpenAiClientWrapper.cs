using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using UnityEngine;
using Utilities;

namespace InputToApi
{
    public class OpenAiClientWrapper : SingletonPersistent<OpenAiClientWrapper>
    {
        [SerializeField] private string pathToDirectory;
        
        private OpenAIClient _openAIClient;

        private void Start()
        {
            _openAIClient = new OpenAIClient(new OpenAIAuthentication().
                LoadFromDirectory(pathToDirectory));
        }

        public async Task<ChatResponse> SendTextAndImage(string text, Texture2D image)
        {
            var messages = new List<Message>
            {
                new Message(Role.System, "You are a helpful assistant."),
                new Message(Role.User, new List<Content>
                {
                    text,
                    image
                })
            };
            
            var chatRequest = new ChatRequest(messages, "gpt-4-vision-preview");
            var result = await _openAIClient.ChatEndpoint.GetCompletionAsync(chatRequest);
            return result;
        }
        
        public async Task<ChatResponse> SendText(string text)
        {
            var messages = new List<Message>
            {
                new Message(Role.System, "You are a helpful assistant."),
                new Message(Role.User, new List<Content>
                {
                    text
                })
            };

            var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
            var result = await _openAIClient.ChatEndpoint.GetCompletionAsync(chatRequest);
            return result;
        }

    }
}
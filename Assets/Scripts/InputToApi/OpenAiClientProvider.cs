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
    public class OpenAiClientProvider : SingletonPersistent<OpenAiClientProvider>
    {
        [SerializeField] private string pathToDirectory;
        
        private OpenAIClient _openAIClient;

        private void Start()
        {
            _openAIClient = new OpenAIClient(new OpenAIAuthentication().
                LoadFromDirectory(pathToDirectory));
        }

        public async Task<ChatResponse> SendContent(List<Content> contents, string model)
        {
            var messages = new List<Message>
            {
                new(Role.System, "You are a helpful assistant."),
                new(Role.User, contents)
            };
            
            var chatRequest = new ChatRequest(messages, model);
            var result = await _openAIClient.ChatEndpoint.GetCompletionAsync(chatRequest);
            return result;
            
        }
    }
}
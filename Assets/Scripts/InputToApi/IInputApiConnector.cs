namespace InputToApi
{
    public interface IInputApiConnector
    {   
        /// <summary>
        /// Sends the input type to chat gpt 4 using openAiAPI. 
        /// </summary>
        public void SendInputToApi();
    }
}
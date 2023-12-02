namespace InputToApi
{
    public interface IInputApiConnector
    {   
        /// <summary> Sends the input type to an openAI model using API. </summary>
        public void SendInputToApi();
    }
}
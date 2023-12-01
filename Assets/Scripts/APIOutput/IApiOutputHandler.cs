using OpenAI.Chat;

namespace APIOutput
{
    public interface IApiOutputHandler
    {
        public void OnGetResponseFromAPI(ChatResponse response);
    }
}

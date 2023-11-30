
using Network.SDK.Models;

namespace Network.SDK.Services
{
    public interface IGetSend
    {
        Task<ServiceResponse<byte[]>> FormingMessageForSend(Message message);

        Task<Message> FormingMessageForGet(byte[] sendMessage);
    }
}
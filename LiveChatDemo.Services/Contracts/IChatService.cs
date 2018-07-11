using System.Threading.Tasks;

namespace LiveChatDemo.Services.Contracts
{
    public interface IChatService
    {
        Task SaveMessage(string userName, string message);

        Task CreateNewChatRoom();
    }
}

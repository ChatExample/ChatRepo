namespace LiveChatDemo.Services
{
    using System;
    using System.Threading.Tasks;
    using Contracts;
    using LiveChatDemo.Database;
    using LiveChatDemo.Models;
    using System.Linq;

    public class ChatService : IChatService
    {
        private readonly LiveChatDbContext dbContext;

        public ChatService(LiveChatDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task CreateNewChatRoom()
        {
            throw new NotImplementedException();
        }

        public async Task SaveMessage(string userName, string message)
        {
            var user = dbContext.Users.Where(u => u.UserName == userName).SingleOrDefault();

            User newUser;
            
            if (user == null)
            {
                newUser = new User()
                {
                    UserName = userName,
                };
            }
            else
            {
                newUser = user;
            }
            
            var msg = new Message() {  Description = message, SendOn = DateTime.Now, User = newUser };

            await dbContext.Users.AddAsync(newUser);
            await dbContext.Messages.AddAsync(msg);
            await dbContext.SaveChangesAsync();
        }
    }
}

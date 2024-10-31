using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Data;
using SignalRChat.Models;



namespace SignalRChat
{
    public class ChatHub : Hub
    {

        private readonly MyDbContext conn;

        public ChatHub(MyDbContext context)
        {
            conn = context;
        }


        public async Task UpdateConnectionId(string userId, string connectionId)
        {
            try
            {
                var user = await conn.Users.Where(a=>a.userId == int.Parse(userId)).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.ConnectionId = connectionId;
                    user.Timestamp = DateTime.UtcNow;
                    conn.Users.Update(user);
                    await conn.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessageToSpecificClient(string userId, string message)
        {

            try
            {
                var data = await conn.Users.Where(x => x.userId == int.Parse(userId)).FirstOrDefaultAsync();
                if (data != null)
                {

                    usermsghistory his = new usermsghistory();
                    his.userId = int.Parse(userId);
                    his.msghistory = message;
                    //his.Timestamp = DateTime.Now;

                    conn.UserMessage.Add(his);
                    await conn.SaveChangesAsync();

                    await Clients.Client(data.ConnectionId).SendAsync("ReceiveMessage",message);

                }
                else
                {

                    throw new HubException("User Id Is Not FOund");

                }

            }
            catch (Exception ex)
            {

                throw;
            }
                
            

            
        }
    }
};

using Microsoft.AspNetCore.Mvc;
using SignalRChat.Data;

namespace SignalRChat.Controllers
{

    public class ClientController : Controller


    {

        private readonly MyDbContext conn;
        public ClientController()
        {
            conn = new MyDbContext();
        }
        //    private readonly IHubContext<ChatHub> _hubContext;
        //    private readonly MyDbContext _context;

        //    public ClientController(IHubContext<ChatHub> hubContext, MyDbContext context)
        //    {
        //        _hubContext = hubContext;
        //        _context = context; // Store the context for later use
        //    }

        //    public IActionResult Index()
        //    {

        //        var hub = new ChatHub(_context);
        //        var connectedClients = hub.GetConnectedClients(); 
        //        var model = new List<ConnectedClient>();

        //        foreach (var client in connectedClients)
        //        {
        //            model.Add(new ConnectedClient
        //            {
        //                // ConnectionId = client.Key, 
        //                UserId = client.Value.UserId,
        //                UserName = client.Value.UserName
        //            });
        //        }

        //        return View(model);
        //    }
        //}

        //public class ConnectedClient
        //{
        //    // public string ConnectionId { get; set; } // 
        //    public string UserId { get; set; }
        //    public string UserName { get; set; }

        public IActionResult Index()
        {

            if(HttpContext.Session.GetString("Admin")!= null){
                var data = conn.Users.ToList();

                return View(data);
            };
            return RedirectToAction("Login", "Home");
           

        }
    }
};

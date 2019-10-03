using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SignalRChat


{
    //public static class UserHandler
    //{
    //public static HashSet<string> ConnectedIds = new HashSet<string>();

    //}
    //public class clients
    //{
    //    public string ConnectionId { get; set; }
    //
    //}

    public class ChatHub : Hub
    {

        //clients : found in 
        clients A_client = new clients();

        private static readonly List<clients> ClientList = new List<clients>();

        //static HashSet<string> CurrentConnections = new HashSet<string>();
        public void SendMessage(string sendFromId, string userId, string sendFromName, string userName, string message)
        {

        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(message);



        }



        public override Task OnConnected()
        {
            // var id = Context.ConnectionId;
            //CurrentConnections.Add(id);

            return base.OnConnected();
        }

        //return list of all active connections
        //public List<string> GetAllActiveConnections()
        //{
        //    
        //}
        public void register(string name)
        {
             Debug.Write("play");
            A_client.ConnectionId = Context.ConnectionId;
            A_client.Name = name;
            ClientList.Add(A_client);

        }
        //passes in message is which click button 
        //1 or zero
        public void play(string name, string message)
        {
            Debug.Write("play");
           // for (int i = 0; i <= 1; i++)
            //{
                //if (name == ClientList[i].Name)
                //{
                    //if (ClientList[i].ConnectionId == Context.ConnectionId)
                    //{
                        if (message == "1")
                        {

                            //Clients.AllExcept().pressbutton("1");
                            Clients.Client(ClientList[0].ConnectionId).pressbutton(message);
                            Clients.Client(ClientList[1].ConnectionId).pressbutton(message);
                        }
                        if (message == "2")
                        {

                            Clients.Client(ClientList[0].ConnectionId).pressbutton(message);
                            Clients.Client(ClientList[1].ConnectionId).pressbutton(message);
            }
                    //}
                //}
            //}
        }
    }

}
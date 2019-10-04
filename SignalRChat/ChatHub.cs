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
        //not best way
        //https://www.codeproject.com/Questions/233650/How-to-define-Global-veriable-in-Csharp-net
        static int whoseturn = 0;
        
       
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
        
        public void printturn()
        {
            string name = "";
            if (whoseturn == 0)
            {

                //Clients.Client(ClientList[1].ConnectionId).printturn(name);
                name = ClientList[1].Name;
            }
            //second player
            if (whoseturn == 1)
            {
                //Clients.Client(ClientList[0].ConnectionId).printturn(name);
                name = ClientList[0].Name;
            }

            if (whoseturn == 0)
            {
                whoseturn = 1;
            }
            else if (whoseturn == 1  )
            {
                whoseturn = 0;
            }

            //get rid of whoseturn
            Clients.Client(ClientList[0].ConnectionId).printname(name);
            Clients.Client(ClientList[1].ConnectionId).printname(name);
            //return (name);

        }





        



        public string register(string name)
        {
             Debug.Write("play");
            A_client.ConnectionId = Context.ConnectionId;
            A_client.Name = name;
            ClientList.Add(A_client);

            

            return ("A");
        }
        //passes in message is which click button 
        //1 or zero
        public void play(string name, string message)
        {
            //Debug.Write("play");
            //for (int i = 0; i <= 1; i++)
            //{
               //if the correct user is presing the click number button
               if (name == ClientList[whoseturn].Name)
                {
                //controls whos turn is it and sends name for printing
                

                    //if (ClientList[i].ConnectionId == Context.ConnectionId)
                    //{
                if (message == "1")
                        {

                            //disabled buttons!
                            //Clients.AllExcept().pressbutton("1");
                            Clients.Client(ClientList[0].ConnectionId).pressbutton(message);
                            Clients.Client(ClientList[1].ConnectionId).pressbutton(message);
                        }
                        if (message == "2")
                        {

                            Clients.Client(ClientList[0].ConnectionId).pressbutton(message);
                            Clients.Client(ClientList[1].ConnectionId).pressbutton(message);
                        }
                printturn();
            }
               

        }
        
        //public void initial(string name)
        //{
        //    var a = 1;
            //if (name == ClientList[0].Name)
            //{



            //    //get rid of whoseturn
            //    Clients.Client(ClientList[0].ConnectionId).printname(name);
            //    Clients.Client(ClientList[1].ConnectionId).printname(name);
            //    //return (name);
            //}

        //}
    }

}
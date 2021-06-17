namespace NoobServer.GameServer
{
  using NoobNetwork;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Server
  {
    private Listener listener;

    public Server()
    {
      this.listener = new Listener();
    }

    public bool Start()
    {
      return this.listener.Start();
    }
  }
}

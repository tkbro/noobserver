namespace NoobServer.GameServer
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Launcher
  {
    public bool Run()
    {
      var env = new GameEnvironment();

      var server = new Server();
      if (server.Start() == false)
      {
        Console.WriteLine("Failed to listen start.");
        return false;
      }

      var runner = new Runner(env);
      return runner.Run();
    }
  }
}

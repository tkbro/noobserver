namespace NoobServer
{
  using NoobServer.GameServer;
  using System;

  public class Program
  {
    public static int Main(string[] args)
    {
      var launcher = new Launcher();
      if (!launcher.Run())
      {
        return -1;
      }

      return 0;
    }
  }
}

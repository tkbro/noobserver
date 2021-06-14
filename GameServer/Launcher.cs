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
      // log?
      // todo : network module run

      var env = new GameEnvironment();
      var runner = new Runner(env);

      return runner.Run();
    }
  }
}

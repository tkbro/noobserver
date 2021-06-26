namespace NoobServer.GameServer
{
  using NoobServer.GameServer.Core;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class GameEnvironment
  {
    public GameEnvironment()
    {
      this.Initialize();
    }

    public UpdateJobQueue JobQueue { get; } = new UpdateJobQueue();

    private void Initialize()
    {
      // map manger -> map spawn npc.
      // usermanager
    }
  }
}

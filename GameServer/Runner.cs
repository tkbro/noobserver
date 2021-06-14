namespace NoobServer.GameServer
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;

  public class Runner
  {
    private readonly int frameMs = 16;
    private readonly GameEnvironment env;
    private bool active;

    public Runner(GameEnvironment env)
    {
      this.env = env;
    }

    // run 함수를 single 버전과 multi 버전을 만들어야 할까?
    public bool Run()
    {
      var prevTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
      while (this.active)
      {
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        long diff = prevTime - currentTime;
        this.PhysicsLoop(diff);
        this.LogicLoop(diff);
        prevTime = currentTime;

        var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var frameExecutionTime = prevTime - now;

        if (frameExecutionTime < this.frameMs)
        {
          Thread.Sleep(this.frameMs - (int)frameExecutionTime);
        }
      }

      return false;
    }

    public void PhysicsLoop(long elapsed)
    {
      // foreach (reserved_physics_object_queue)

      // IPhysicsObject.Collider
      // aoi 에서 인접한 애들을 리스트로 관리?, 들어온느 순서대로 대충 큐잉?
      // Collider 를 기준으로 충돌 여부를 판단해주면 되지않나?
    }

    public void LogicLoop(long elapsed)
    {
      // IGamePlayObject.UpdateLogic?
    }
  }
}

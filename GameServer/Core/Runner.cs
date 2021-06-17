namespace NoobServer.GameServer.Core
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

    public bool Run()
    {
      this.active = true; // tmp

      var prevTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
      while (this.active)
      {
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        long diff = prevTime - currentTime;
        this.Update(diff);
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

    public void Update(long elapsed)
    {
      var jobs = this.env.JobQueue.UpdateJobs;
      foreach (var job in jobs)
      {
        job.Update();
      }

      this.env.JobQueue.ChangeFlag();

      // ...
    }
  }
}

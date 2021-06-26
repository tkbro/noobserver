namespace NoobServer.GameServer.Core
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class UpdateJobQueue
  {
    private Queue<UpdateJob>[] doubleUpdateJobQueue;
    private int flag;

    public UpdateJobQueue()
    {
      this.doubleUpdateJobQueue = new Queue<UpdateJob>[2];
      for (int i = 0; i < 2; i++)
      {
        this.doubleUpdateJobQueue[i] = new Queue<UpdateJob>();
      }
    }

    public Queue<UpdateJob> UpdateJobs => this.doubleUpdateJobQueue[this.flag];

    public void EnqueuJob(UpdateJob job)
    {
      this.doubleUpdateJobQueue[this.flag].Enqueue(job);
    }

    public void ChangeFlag()
    {
      var cur = this.flag;
      this.doubleUpdateJobQueue[cur].Clear();

      this.flag = cur == 0 ? 1 : 0;
    }
  }
}

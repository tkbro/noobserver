namespace NoobNetwork
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class CircularBuffer
  {
    private readonly int size;
    private readonly byte[] data;

    private int head;
    private int tail;

    public CircularBuffer(int size)
    {
      this.size = size;
      this.data = new byte[size];
    }

    public int MaxSize => this.size;
    public int WritableSize => this.tail - this.head;

    public void Produce()
    {
    }

    public void Consume()
    {
    }
  }
}

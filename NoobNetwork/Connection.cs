namespace NoobNetwork
{
  using System;
  using System.Net.Sockets;

  public class Connection : IDisposable
  {
    private readonly int maxSize = 24 * 1024;

    private Socket socket;
    private SocketAsyncEventArgs args;
    private CircularBuffer buffer;

    public Connection(Socket socket, SocketAsyncEventArgs args)
    {
      this.socket = socket;
      this.args = args;
      this.buffer = new CircularBuffer(this.maxSize);
    }

    public void Dispose()
    {
      this.Release();
    }

    public void Start()
    {
      this.BeginReceive();
    }

    private void BeginReceive()
    {
      this.args.SetBuffer(this.buffer.MaxSize, this.buffer.WritableSize);

      var pending = this.socket.ReceiveAsync(this.args);
      if (!pending)
      {
        this.ReceiveCallback(this.socket, this.args);
      }
    }

    public void ReceiveCallback(object sender, SocketAsyncEventArgs args)
    {
      if (args.SocketError != SocketError.Success)
      { 
        this.Close();
        return;
      }

      var bytesTransferred = this.args.BytesTransferred;
      if (bytesTransferred <= 0)
      {
        this.Close();
        return;
      }

      // todo: https://developers.google.com/protocol-buffers/docs/reference/csharp-generated#structure
      // 1. deserialize
      // 2. pass to MessageParser
      ////MessageParser
      // 3. pass parsed message to session owner

      this.BeginReceive();
    }

    private void Close()
    {
      try
      {
        this.socket.Shutdown(SocketShutdown.Both);
      }
      catch (SocketException e)
      {
        Console.WriteLine(e);
      }

      this.Release();
    }

    private void Release()
    {
      try
      {
        this.args.Dispose();

        this.socket.Close();
        this.socket.Dispose();
      }
      catch (SocketException e)
      {
        Console.WriteLine(e);
      }
    }
  }
}

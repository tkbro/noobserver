namespace NoobNetwork
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Net.Sockets;
  using System.Text;
  using System.Threading.Tasks;

  public class Listener
  {
    private readonly int prot = 10000;
    private Socket socket;
    
    public bool Start()
    {
      var endPoint = new IPEndPoint(IPAddress.Any, this.prot);
      var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      try
      {
        socket.Bind(endPoint);
        this.socket = socket;
      }
      catch (SocketException e)
      {
        socket.Dispose();
        Task.Delay(1000).Wait();
      }

      if (this.socket == null)
      {
        return false;
      }

      this.socket.Listen();

      // 일단은 네트워크 리슨은 스레드하나로
      var args = new SocketAsyncEventArgs();
      args.Completed += this.OnAccept;
      this.StartAccept(args);

      return true;
    }

    private void StartAccept(SocketAsyncEventArgs args)
    {
      args.AcceptSocket = null;
      if (this.socket == null)
      {
        return;
      }

      bool pending = this.socket.AcceptAsync(args);
      if (!pending)
      {
        this.OnAccept(this.socket, args);
      }
    }

    private void OnAccept(object sender, SocketAsyncEventArgs args)
    {
      if (args.SocketError == SocketError.Success)
      {
        // todo : 실제 GameObject 가 핸들할 session 을 생성해서 전달.
        // 1. connection 도 따로 관리?
        // 2. packet handler ?
        // 3. gameObject 와 connection/session 관계 어떻게?
      }
      
      if (args.SocketError == SocketError.OperationAborted)
      {
        args.Dispose();
        return;
      }

      this.StartAccept(args);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Servidor
{
    class Program
    {
        public static Hashtable clientList = new Hashtable();

        public class Player
        {
            public string name;
            public int posX;
            public int posY;
            public int map;
            public int dir;
            public int s;
            public Player(string name, int posX, int posY, int map, int dir, int s)
            {
                this.name = name;
                this.posX = posX;
                this.posY = posY;
                this.map = map;
                this.dir = dir;
                this.s = s;
            }
        }
        public static bool startedGame = false;
        public static bool pause = false;
        private static List<Boolean> listosFalso = new List<Boolean>();
        private static List<Boolean> listosVerdadero = new List<Boolean>(); 
        public static List<Player> players = new List<Player>();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Servidor iniciado! :)");

            while (true)
            {
                if (!startedGame)
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();

                    byte[] bytesFrom = new byte[10025];
                    string dataFromClient = null;

                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Player p = null;
                    string name;
                    int posx, posy, map, dir, s;
                    name = dataFromClient.Substring(0, dataFromClient.IndexOf(" "));
                    posx = Convert.ToInt32(dataFromClient.Substring(dataFromClient.IndexOf(" ") + 1, dataFromClient.IndexOf(" ")));
                    posy = Convert.ToInt32(dataFromClient.Substring(dataFromClient.IndexOf(" ") + 1, dataFromClient.IndexOf(" ")));
                    map = Convert.ToInt32(dataFromClient.Substring(dataFromClient.IndexOf(" ") + 1, dataFromClient.IndexOf(" ")));
                    dir = Convert.ToInt32(dataFromClient.Substring(dataFromClient.IndexOf(" ") + 1, dataFromClient.IndexOf(" ")));
                    s = Convert.ToInt32(dataFromClient.Substring(dataFromClient.IndexOf(" ") + 1, dataFromClient.IndexOf(" ")));
                    p = new Player(name, posx, posy, map, dir, s);
                    players.Add(p);
                    clientList.Add(dataFromClient, clientSocket);
                    listosFalso.Add(false);
                    //Broadcast(dataFromClient + " se ha unido ", dataFromClient, false);
                    Console.WriteLine(name + " se ha unido a la sala de chat.");

                    //HandleClient client = new HandleClient();
                    //client.StartClient(clientSocket, dataFromClient, clientList);
                }
            }
            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("Salida");
            Console.ReadLine();
        }

        public static List<Player> getData()
        {
            return players;
        }

        public static void refreshData(Player p)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (p.name.Equals(players[i].name))
                {//actualizo data del player
                    players[i].map = p.map;
                    players[i].posX = p.posX;
                    players[i].posY = p.posY;
                    players[i].dir = p.dir;
                    players[i].s = p.s;
                    break;
                }
            }
        }

        public static void Broadcast(String msg, String userName, bool flag)
        {
            foreach (DictionaryEntry item in clientList)
            {
                TcpClient broadcastSocket = (TcpClient)item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;
                if (flag)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(userName + " dice: " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }
    }

    public class HandleClient
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientList;

        public void StartClient(TcpClient inClientSocket, string clientNo, Hashtable cList)
        {
            clientSocket = inClientSocket;
            clNo = clientNo;
            clientList = cList;
            Thread myThread = new Thread(DoChat);
            myThread.Start();
        }

        private void DoChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;

            while (true)
            {
                try
                {
                    requestCount++;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("Del cliente - " + clNo + ": " + dataFromClient);
                    Program.Broadcast(dataFromClient, clNo, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

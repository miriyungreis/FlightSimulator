﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulatorApp.Model
{
    class MySimulatorConnector : ISimulatorConnector
    {
        TcpClient my_client;
        private NetworkStream write_stream = null;
        private NetworkStream read_stream = null;
        public void connect(string ip, int port) { 
            try
            {
                Console.WriteLine("connecting to ip: {0}, port: {1}", ip, port.ToString());
                my_client = new TcpClient(ip, port);
                write_stream = my_client.GetStream();
                write_stream.Flush();
                read_stream = my_client.GetStream();
                read_stream.Flush();
                //isConnected = true;
                Console.WriteLine("Connected!");
            } catch (Exception ex)
            {
                Console.WriteLine("EROR - failed to connect please try again");
                Console.WriteLine(ex.Message);

            }
        }
        public void write(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command+"\r\n");
            this.write_stream.Write(buffer, 0, buffer.Length);
        }
        public string read()
        {
            byte[] buffer = new byte[1024];
            try
            {
                this.read_stream.Read(buffer, 0, 1024);
                string incomingInfo = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                Console.WriteLine(incomingInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("eror reading from server");
            }
            return "v";
        }
        public void disconnect()
        {
            this.write_stream.Close();
            this.read_stream.Close();
        }
    }
}
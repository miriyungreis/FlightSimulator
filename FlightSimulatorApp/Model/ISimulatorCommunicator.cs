﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    interface ISimulatorCommunicator
    {
        void connect(string ip, int port);
        void write(string command);
        string read();
        void disconnect();
    }
}

﻿
using System;
using System.Diagnostics;
using System.Threading;
using Stump.Server;
using Stump.Server.WorldServer;

namespace Stump.GUI.WorldConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            var server = new WorldServer();
            if (!Debugger.IsAttached)
            {
                try
                {
                    server.Initialize();
                    server.Start();

                    GC.Collect();

                    while (true)
                    {
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e)
                {
                    server.HandleCrashException(e);
                }
                finally
                {
                    server.Shutdown();
                }
            }
            else
            {
                server.Initialize();
                server.Start();

                GC.Collect();

                while (true)
                {
                    Thread.Sleep(5000);
                }
            }
        }
    }
}

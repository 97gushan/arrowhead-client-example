﻿using System;
using Arrowhead;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Arrowhead_client
{
    class Program
    {
        private Arrowhead.Admin admin;
        private Arrowhead.Client client;
        private Arrowhead.Test t;

        public Program(string serviceName, string systemName, string certPath)
        {
            Arrowhead.Utils.Settings settings = new Arrowhead.Utils.Settings();
            settings.SetCertPath(certPath);
            settings.SetServiceSettings(serviceName, new string[] { "HTTPS-SECURE-JSON" }, "/");
            settings.SetSystemSettings(systemName, "127.0.0.1", "8080");
            this.client = new Arrowhead.Client(settings);
        }

        public Program(string certPath)
        {
            Arrowhead.Utils.Settings settings = new Arrowhead.Utils.Settings();
            settings.SetCertPath(certPath);
            settings.SetCloudSettings("testcloud2", "aitia");
            settings.SetSystemSettings("test_producer", "127.0.0.1", "8080", "12");
            settings.SetServiceSettings("producer3", new string[] { "HTTPS-SECURE-JSON" }, "");
            this.admin = new Arrowhead.Admin(settings);
        }

        private void Run()
        {
            Console.WriteLine(this.client.Orchestrate("producer3"));
        }

        static void Main(string[] args)
        {
            // Program producer = new Program("producer3", "test_producer", "/home/user/Projects/arrowhead/core-java-spring/certificates/testcloud2/test_producer.p12");
            // producer.Run();

            // Program consumer = new Program("consumer", "test_consumer", "/home/user/Projects/arrowhead/core-java-spring/certificates/testcloud2/test_consumer.p12");
            // consumer.Run();

            Program admin = new Program("/home/user/Projects/arrowhead/core-java-spring/certificates/testcloud2/sysop.p12");
            // admin.Run();
        }
    }
}

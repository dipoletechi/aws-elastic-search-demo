using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using Nest;
using Newtonsoft.Json;

using ElasticDataProcessingUtility.Models;

namespace ElasticDataProcessingUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing data..");

            var nestClient = new ElasticClient(new ConnectionSettings(new Uri("https://search-smartdataplacement-vm6bi5koicwdgrcjim4jfbyesy.us-east-2.es.amazonaws.com"))
                       .DefaultMappingFor<PropertyData>(i => i.IndexName("properties"))
                       .DefaultMappingFor<ManagementData>(i => i.IndexName("managements")));            
            
            nestClient.Bulk(b => b
                       .IndexMany(JsonConvert.DeserializeObject<List<ManagementData>>(File.ReadAllText("mgmt.json")).Where(m=>m.mgmt!=null))
                       .IndexMany(JsonConvert.DeserializeObject<List<PropertyData>>(File.ReadAllText("properties.json")).Where(p=>p.property!=null)));            
                      
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();

        }       
    }
}

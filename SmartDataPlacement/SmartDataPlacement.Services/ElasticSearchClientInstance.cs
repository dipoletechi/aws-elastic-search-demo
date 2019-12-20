using System;

using Nest;
using SmartDataPlacement.Common.Enums;
using SmartDataPlacement.Common.Responses;

namespace SmartDataPlacement.Services
{
    public class ElasticSearchClientInstance
    {
        public readonly ElasticClient elasticClient;

        private ElasticSearchClientInstance()
        {
            var settings = new ConnectionSettings(new Uri(System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.awselasticsearchbaseurl.ToString()]))
                         .DefaultMappingFor<PropertyData>(i => i.IndexName(System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.properties.ToString()]))
                         .DefaultMappingFor<ManagementData>(i => i.IndexName(System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.managements.ToString()]));

            elasticClient = new ElasticClient(settings);
        }

        public static ElasticSearchClientInstance Instance { get; } = new ElasticSearchClientInstance();
    }
}

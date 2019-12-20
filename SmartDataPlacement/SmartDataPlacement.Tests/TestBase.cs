using NUnit.Framework;
using SmartDataPlacement.Common.Enums;

namespace SmartDataPlacement.Tests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.awselasticsearchbaseurl.ToString()] = "https://search-smartdataplacement-vm6bi5koicwdgrcjim4jfbyesy.us-east-2.es.amazonaws.com";
            System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.managements.ToString()] = "managements";
            System.Configuration.ConfigurationSettings.AppSettings[EAppSettingsVariable.properties.ToString()] = "properties";
        }

    }
}

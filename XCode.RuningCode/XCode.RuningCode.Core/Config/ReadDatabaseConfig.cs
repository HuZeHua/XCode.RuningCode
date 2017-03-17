using System;
using System.Configuration;

namespace XCode.RuningCode.Core.Config
{
    /// <summary>
    /// 只读数据库配置
    /// </summary>
    public class ReadDatabaseConfig : ConfigurationSection
    {
        private static ReadDatabaseSection _connections;

        public static ReadDatabaseSection Connections
        {
            get
            {
                if (_connections == null)
                {
                    ExeConfigurationFileMap exeMap = new ExeConfigurationFileMap()
                    {
                        ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "/Config/ReadDatabase.config"
                    };
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(exeMap,
                        ConfigurationUserLevel.None);

                    _connections = (ReadDatabaseSection)config.GetSection("readDatabases");
                }

                return _connections;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework
{
    public class Config
    {
        public string LocaldeviceName { get; set; }
        #region File paths
        public string MCPath { get; set; }
        public string MCProcName { get; set; }
        public string XLPath { get; set; }
        public string driverPath { get; set; }
        #endregion
        #region MC credentials
        public string userName { get; set; }
        public string password { get; set; }
        #endregion
        #region MC config
        public string deviceId { get; set; }
        public string hostAddress { get; set; }
        public string port { get; set; }
        public string httpPort { get; set; }
        public string responseTimeout { get; set; }
        public string commsTimeout { get; set; }
        public bool useHttps { get; set; }
        public bool communicationsActive { get; set; }
        #endregion
        public int timeout { get; set; }

    }
}

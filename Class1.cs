using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotGaea.Geometry;
using PilotGaea.TMPEngine;
using PilotGaea.Serialize;

namespace Account
{
    public class AccessControlClass : AccountBaseClass
    {
        public override void DeInit()
        {

        }

        public override bool Init()
        {
            return true;
        }

        public override bool Login(LoginInputParameter InputData, out LoginOutputParameter OutputData)
        {
            bool Ret = false;
            OutputData = new LoginOutputParameter();
            if ((InputData.Username.ToLower() == "pilotgaea" && InputData.Password == "aeagtolip") || InputData.IP == "192.168.123.1")
            {
                bool Admin = false;
                for (int i = 0; i < InputData.Groups.Count; i++)
                {
                    if (InputData.Groups[i].Name == "Administrators")
                    {
                        Admin = true;
                        break;
                    }
                }
                OutputData.CanLogin = true;
                if (Admin) OutputData.GroupName = "Administrators";
                else OutputData.GroupName = "Everyone";
                OutputData.Memo = "";
            }
            Ret = true;
            return Ret;

        }
    }
}

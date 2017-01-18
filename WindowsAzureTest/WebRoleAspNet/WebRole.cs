using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRoleAspNet
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // Дополнительные сведения по управлению изменениями конфигурации
            // см. раздел MSDN по ссылке http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace DesktopManager
{
    public class AdminCheck
    {
        //https://stackoverflow.com/questions/1089046/in-net-c-test-if-process-has-administrative-privileges/1089061
        public AdminCheck(){
            IsAdmin = IsAdministrator();
        }
        public bool IsAdmin;
        public bool IsAdministrator(){//https://stackoverflow.com/questions/1089046/in-net-c-test-if-process-has-administrative-privileges/1089061
            //bool value to hold our return value
            bool isAdmin;
            WindowsIdentity user = null;
            try{
                //get the currently logged in user
                user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex){ isAdmin = false; }
            catch (Exception ex){ isAdmin = false; }
            finally{
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.IO;
using Core.Windows.UI.Core.Windows.UI;
using System.Collections;

namespace rma.PS
{
    public class PowerShellEngine : IDisposable
    {
        private Dictionary<string, Runspace> _runspaceCache = new Dictionary<string, Runspace>();

        ~PowerShellEngine()
        {
            Clean();
        }

        public Collection<PSObject> ExecuteScriptFile(string scriptFilePath, IEnumerable<object> arguments = null, string machineAddress = null)
        {

            IEnumerable<object> parms;   

            if (ApplicationState.Current.Selected == 1)
            {
                parms = new object[] { "mp" };
                ExecuteScript(File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["JobScriptPath"] + @"rmabill.ps1"), null, machineAddress);
            }
            else if (ApplicationState.Current.Selected == 2)
            {
                parms = new object[] { "solo" };
                ExecuteScript(File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["JobScriptPath"] + @"rmabill.ps1"), null, machineAddress);
            }
            else
            {
                parms = new object[] { "101c" };
                ExecuteScript(File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["JobScriptPath"] + @"rmabill.ps1"), parms, machineAddress);
            }

            return ExecuteScript(File.ReadAllText(scriptFilePath), arguments, machineAddress);
        }

        public Collection<PSObject> ExecuteScript(string script, IEnumerable<object> arguments = null, string machineAddress = null)
        {
            Runspace runspace = GetOrCreateRunspace(machineAddress);
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript(script);
                if (arguments != null)
                {
                    foreach (var argument in arguments)
                    {
                        ps.AddArgument(argument);
                    }
                }

                return ps.Invoke();
            }
        }

        public void Dispose()
        {
            Clean();
            GC.SuppressFinalize(this);
        }

        private Runspace GetOrCreateLocalRunspace()
        {
            if (!_runspaceCache.ContainsKey("localhost"))
            {
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                _runspaceCache.Add("localhost", runspace);
            }

            return _runspaceCache["localhost"];
        }

        private Runspace GetOrCreateRunspace(string machineAddress)
        {
            if (string.IsNullOrWhiteSpace(machineAddress))
            {
                return GetOrCreateLocalRunspace();
            }

            machineAddress = machineAddress.ToLowerInvariant();
            if (!_runspaceCache.ContainsKey(machineAddress))
            {
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
                connectionInfo.ComputerName = machineAddress;
                Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
                runspace.Open();
                _runspaceCache.Add(machineAddress, runspace);
            }

            return _runspaceCache[machineAddress];
        }

        private void Clean()
        {
            foreach (var runspaceEntry in _runspaceCache)
            {
                runspaceEntry.Value.Close();
            }

            _runspaceCache.Clear();
        }
    }
}

using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace rma.Views
{
    public partial class About : Window
    {
        private readonly double _originalHeight;
        private readonly double _originalWidth;

        //Remove in production
        private readonly bool addingRoles;

        public About()
        {
           

            InitializeComponent();

            

            Loaded += AboutLoaded;
            Unloaded += AboutUnloaded;
            _originalHeight = Height;
            _originalWidth = Width;
            ContentResized();

            AboutLabel.Text = "Version: " + AssemblyFileVersion + Environment.NewLine
                              + "Build Date / Time: " + GetBuildDate + Environment.NewLine
                              + AssemblyTitle + Environment.NewLine
                              + AssemblyProduct + Environment.NewLine
                              + AssemblyDescription + Environment.NewLine
                              + CopyrightInformation + Environment.NewLine
                              + AssemblyTrademark + Environment.NewLine
                              + "OS Version: " + Environment.OSVersion + Environment.NewLine
                              + "Culture: " + Thread.CurrentThread.CurrentCulture + Environment.NewLine
                              + "UI Culture: " + Thread.CurrentThread.CurrentUICulture + Environment.NewLine;

            

           
        }

        public DateTime GetBuildDate
        {
            get
            {
                var date = new DateTime(2000, 1, 1);
                string[] parts = Assembly.GetExecutingAssembly().FullName.Split(',');
                string[] versionParts = parts[1].Split('.');
                date = date.AddDays(Int32.Parse(versionParts[2]));
                date = date.AddSeconds(Int32.Parse(versionParts[3])*2);
                if (TimeZoneInfo.Local.IsDaylightSavingTime(date))
                {
                    date = date.AddHours(1);
                }

                return date;
            }
        }

        public static string Version
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var name = new AssemblyName(assembly.FullName);
                return name.Version.ToString();
            }
        }

        public static string AssemblyFileVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                    return ad.CurrentVersion.ToString();
                }
                else
                {
                    return
                        ((AssemblyFileVersionAttribute)AssemblyAttributes(typeof(AssemblyFileVersionAttribute))[0]).
                            Version;
                }
            }
        }


        public static string CopyrightInformation
        {
            get
            {
                return
                    ((AssemblyCopyrightAttribute) AssemblyAttributes(typeof (AssemblyCopyrightAttribute))[0]).Copyright;
            }
        }

        public static string AssemblyTitle
        {
            get { return ((AssemblyTitleAttribute) AssemblyAttributes(typeof (AssemblyTitleAttribute))[0]).Title; }
        }

        public static string AssemblyDescription
        {
            get
            {
                return
                    ((AssemblyDescriptionAttribute) AssemblyAttributes(typeof (AssemblyDescriptionAttribute))[0]).
                        Description;
            }
        }

        public static string AssemblyProduct
        {
            get { return ((AssemblyProductAttribute) AssemblyAttributes(typeof (AssemblyProductAttribute))[0]).Product; }
        }

        public static string AssemblyTrademark
        {
            get
            {
                return
                    ((AssemblyTrademarkAttribute) AssemblyAttributes(typeof (AssemblyTrademarkAttribute))[0]).Trademark;
            }
        }

        public static string AssemblyVersion
        {
            get { return ((AssemblyVersionAttribute) AssemblyAttributes(typeof (AssemblyVersionAttribute))[0]).Version; }
        }

       

        private void AboutLoaded(object sender, RoutedEventArgs e)
        {
            KeyUp += AboutKeyUp;
        }

        private void AboutKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Close();
            }
        }

        private void AboutUnloaded(object sender, RoutedEventArgs e)
        {
            KeyUp -= AboutKeyUp;
            Loaded -= AboutLoaded;
            Unloaded -= AboutUnloaded;
        }

        private void ContentResized()
        {
            view.Height = ((_originalHeight - 40)*App.UniformScaleAmount);
            view.Width = ((_originalWidth - 20)*App.UniformScaleAmount);
            Height = (_originalHeight*App.UniformScaleAmount);
            Width = (_originalWidth*App.UniformScaleAmount);

            UpdateLayout();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public static object[] AssemblyAttributes(Type assemblyAttributeType)
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(assemblyAttributeType, false);
            return attributes.Length == 0 ? null : attributes;
        }

        
    }
}
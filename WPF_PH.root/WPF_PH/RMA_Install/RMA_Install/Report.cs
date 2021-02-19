using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RMA_Install
{
    class Report
    {
        string name;
        /// <summary>
        /// Name of Report.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string folder;
        /// <summary>
        /// Folder contains Report on Report Server.
        /// </summary>
        public string Folder
        {
            get { return folder; }
            set { folder = value; }
        }

        string path;
        /// <summary>
        /// Report file path; (.rdl) should be included.
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        string dataSource;
        /// <summary>
        /// 
        /// </summary>
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Initiates new object from BI_Deployment_Tool.Report
        /// </summary>
        /// <param name="name">Name of Report</param>
        /// <param name="folder">Report Containing Folder</param>
        /// <param name="path">Report .RDL path file (.RDL) should be existing</param>
        /// <param name="dataSource">Report DataSource Name</param>
        public Report(string name, string folder, string path, string dataSource)
        {
            this.name = name;
            this.folder = folder;
            this.path = path;
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Loads Reports information from XML File
        /// </summary>
        /// <param name="xmlFilePath">XML File path</param>
        /// <returns>Array of BI_Deployment_Tool.Report</returns>
        public static Report[] GetReports(string xmlFilePath)
        {
            List<Report> reports = new List<Report>();
            Report tempReport;
            XDocument xmlDoc = XDocument.Load(xmlFilePath);

            var result = from c in xmlDoc.Descendants("Report")
                         select new
                         {
                             name = (string)c.Element("Name").Value,
                             path = (string)c.Element("Path").Value,
                             folder = (string)c.Element("Folder").Value,
                             datasource = (string)c.Element("DataSource").Value
                         };

            foreach (var row in result)
            {
                tempReport = new Report(row.name, row.folder, row.path, row.datasource);
                reports.Add(tempReport);
            }
            return reports.ToArray();
        }
    }
}

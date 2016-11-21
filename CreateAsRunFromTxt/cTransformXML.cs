using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace CreateAsRunFromTxt
{
    class cTransformXML
    {
        private string strOutFile = "";
        private string strXLSFile = "";
        //
        // This function takes the input xml file and runs a
        // named .xls transform from the program directory and
        // writes an .htm file to same directory as input file
        // C:\Spog Import\ProcessBXFAsRun2HTML.xsl is the temp file
        //
        public string doTransform(string strXMLFile,  decimal dOffset)
        {

            // Open strXML.xml as an XPathDocument.
            XPathDocument doc = new XPathDocument(strXMLFile);

            // Create a writer for writing the transformed file.
            strOutFile = Path.GetDirectoryName(strXMLFile)+"\\"
                + Path.GetFileNameWithoutExtension(strXMLFile) + ".htm";
            XmlWriter writer = XmlWriter.Create(strOutFile);

            // Create and load the transform with script execution enabled.
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltSettings settings = new XsltSettings();
            settings.EnableScript = true;
            XsltArgumentList argsList = new XsltArgumentList();
            argsList.AddParam("utcOffset", "", dOffset);

            transform.Load("C:\\Spog Import\\ProcessBXFAsRun2HTML.xsl", settings, null);
            try
            {
                // Execute the transformation.
                transform.Transform(doc, argsList, writer);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "No error writing " + strOutFile;
        }
    }
}

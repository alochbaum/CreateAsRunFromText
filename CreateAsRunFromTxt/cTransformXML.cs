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
        private string doTransform(string strDirectory, string strXMLFile, 
            string strXSLFile, decimal dOffset)
        {
            strOutFile = strDirectory + Path.GetFileNameWithoutExtension(strXMLFile) +
                ".htm";
            XsltArgumentList xslArg = new XsltArgumentList();
            XslCompiledTransform xslTrans = new XslCompiledTransform();
            XmlTextWriter writer = new XmlTextWriter(strOutFile, null);
            return "Error: Didn't work";
        }
    }
}

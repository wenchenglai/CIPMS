using System;
using System.Xml;
using System.IO;
using System.Text;
using System.IO.Packaging;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using wp = DocumentFormat.OpenXml.Packaging.WordprocessingDocument;
using DocumentFormat.OpenXml;
using a = DocumentFormat.OpenXml.Packaging;
using pic = DocumentFormat.OpenXml.Packaging;



namespace CIPMSOfficeObjects
{
    public class CreateXMLToWord
    {
        long dataToRead;
        public string CreateXMLWord(String FilePath)
        {
            //Create the XML for the Word document.
            XmlDocument xDoc = null;
            
            xDoc = CreateDocumentXML(FilePath);

            //Create the Word document package.
            if (xDoc != null)
            {
                bool hResult = CreateWordDocumentPackage("HelloWorld.docx",xDoc);

                if (hResult == true)
                {
                    return "Successfully created Word document";
                }
            }

            return "success";
        }

        private XmlDocument CreateDocumentXML(string FilePath)
        {
            StringBuilder docText = new StringBuilder();
            String filename  = System.IO.Path.GetFileName(FilePath);
            FileStream iStream = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            Byte[]  buffer = new byte[10000];
            int length=0;

            // Total bytes to read:
            dataToRead = iStream.Length;

            XmlTextReader reader = new XmlTextReader(FilePath);
            while (reader.Read())
            {
                docText.Append(" ");
                switch (reader.NodeType)
                {
                    //case XmlNodeType.Element: // The node is an element.
                    //    docText.Append("<" + reader.Name);
                    //    docText.AppendLine(">");
                    //    break;
                    case XmlNodeType.Text: //Display the text in each element.
                        docText.AppendLine(reader.Value);
                        break;
                    //case XmlNodeType.EndElement: //Display the end of the element.
                    //    docText.Append("</" + reader.Name);
                    //    docText.AppendLine (">");
                    //    break;
                }
            }
            
               string nsWordML =
                  "http://schemas.openxmlformats.org/wordprocessingml" +
                  "/2006/main";

            //Create a new XML document.
            XmlDocument xDoc = new XmlDocument();
            
            //Create and add the document node.
            XmlElement docNode =
               xDoc.CreateElement("w:document", nsWordML);
            xDoc.AppendChild(docNode);

            //Create and add the body node to the 
            //document node.
            XmlElement bodyNode =
                xDoc.CreateElement("w:body", nsWordML);
            docNode.AppendChild(bodyNode);

            //Create and add the wp node to the docNode.
            XmlElement wpNode =
               xDoc.CreateElement("w:p", nsWordML);
            bodyNode.AppendChild(wpNode);

            //Create and add the wr node to the wpNode.
            XmlElement wrNode =
               xDoc.CreateElement("w:r", nsWordML);
            wpNode.AppendChild(wrNode);

            //Create and add the wt node to the wrNode.
            XmlElement wtNode =
               (XmlElement)xDoc.CreateNode(XmlNodeType.Element,
               "w", "t", nsWordML);
            wrNode.AppendChild(wtNode);

            //Add the supplied text to the wtNode.
            wtNode.InnerText = docText.ToString();

            return xDoc;
        }

        private bool CreateWordDocumentPackage(string fileName, XmlDocument xDoc)
        {
            try
            {
                string docContentType = "application/vnd.openxmlformats-" +
                        "officedocument.wordprocessingml." +
                        "document.main+xml";

                string docRelationshipType =
                "http://schemas.openxmlformats.org" +
                        "/officeDocument/2006/relationships/" +
                        "officeDocument";

                //Create a new package file on the desktop of the user by using
                //the supplied file name.
                string desktopDir = System.Environment.GetFolderPath(
                        Environment.SpecialFolder.DesktopDirectory);

                Package pkg = Package.Open(desktopDir + "\\" + fileName,
                      FileMode.Create, FileAccess.ReadWrite);


                //Create a Uri for the document part.
                Uri docPartURI = PackUriHelper.CreatePartUri(
                       new Uri("/word/document.xml",
                       UriKind.Relative));

                //Create the document part.
                PackagePart pkgPart =
                pkg.CreatePart(docPartURI, docContentType);

                //Add the data from XMLDocument to the document part.
                Stream partStream = pkgPart.GetStream(
                    FileMode.Create, FileAccess.Write);

                xDoc.Save(partStream);

                //Create a relationship between the document part
                //and the package.
                PackageRelationship pkgRelationship =
                        pkg.CreateRelationship(docPartURI,
                        TargetMode.Internal, docRelationshipType, "rId1");


                //Flush the changes, and then close the package.
                pkg.Flush();
                pkg.Close();

                return true;

            }
            catch (Exception ex)
            {
                //Display a message to the user the indicates that an error
                //occurred, and then return a result of false.
                throw ex;
                //return false;
            }
        }
    }
}

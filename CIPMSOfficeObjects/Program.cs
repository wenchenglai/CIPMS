//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;

//using DocumentFormat.OpenXml;
//using V = DocumentFormat.OpenXml.Vml;
//using OVML = DocumentFormat.OpenXml.Vml.Office;

//namespace EmbedExcelFileIntoWord
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //string input = @"input.docx";
//            //string output = @"output.docx";

//            //File.Copy(input, output, true);

//            //using (WordprocessingDocument myDoc = WordprocessingDocument.Open(output, true))
//            //{
//            //    MainDocumentPart mainPart = myDoc.MainDocumentPart;

//            //    ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);
//            //    imagePart.FeedData(File.Open("placeholder.png", FileMode.Open));

//            //    EmbeddedPackagePart embeddedObjectPart =
//            //        mainPart.AddEmbeddedPackagePart(@"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
//            //    embeddedObjectPart.FeedData(File.Open("embed.xlsx", FileMode.Open));

//            //    Paragraph p = CreateEmbeddedObjectParagraph(mainPart.GetIdOfPart(imagePart), mainPart.GetIdOfPart(embeddedObjectPart));

//            //    SdtBlock sdt = mainPart.Document.Descendants<SdtBlock>()
//            //        .Where(s => s.GetFirstChild<SdtProperties>().GetFirstChild<Alias>().Val.Value
//            //            .Equals("EmbedObject")).First();

//            //    OpenXmlElement parent = sdt.Parent;
//            //    parent.InsertAfter(p, sdt);
//            //    sdt.Remove();
//            //    mainPart.Document.Save();
//            //}
//        }

//        //static Paragraph CreateEmbeddedObjectParagraph(string imageId, string embedId)
//        //{
//        //    Paragraph p =
//        //      new Paragraph(
//        //          new Run(
//        //              new EmbeddedObject(
//        //                  new V.Shapetype(
//        //                      new V.Stroke() { JoinStyle = V.StrokeJoinStyleValues.Miter },
//        //                      new V.Formulas(
//        //                          new V.Formula() { Equation = "if lineDrawn pixelLineWidth 0" },
//        //                          new V.Formula() { Equation = "sum @0 1 0" },
//        //                          new V.Formula() { Equation = "sum 0 0 @1" },
//        //                          new V.Formula() { Equation = "prod @2 1 2" },
//        //                          new V.Formula() { Equation = "prod @3 21600 pixelWidth" },
//        //                          new V.Formula() { Equation = "prod @3 21600 pixelHeight" },
//        //                          new V.Formula() { Equation = "sum @0 0 1" },
//        //                          new V.Formula() { Equation = "prod @6 1 2" },
//        //                          new V.Formula() { Equation = "prod @7 21600 pixelWidth" },
//        //                          new V.Formula() { Equation = "sum @8 21600 0" },
//        //                          new V.Formula() { Equation = "prod @7 21600 pixelHeight" },
//        //                          new V.Formula() { Equation = "sum @10 21600 0" }),
//        //                      new V.Path() { AllowGradientShape = V.BooleanValues.T, ConnectionPointType = OVML.ConnectValues.Rectangle, AllowExtrusion = V.BooleanValues.F },
//        //                      new OVML.Lock() { Extension = V.ExtensionHandlingBehaviorValues.Edit, AspectRatio = OVML.BooleanValues.T }
//        //                  ) { Id = "_x0000_t75", CoordinateSize = "21600,21600", Filled = V.BooleanValues.F, Stroked = V.BooleanValues.F, OptionalNumber = 75, PreferRelative = V.BooleanValues.T, EdgePath = "m@4@5l@4@11@9@11@9@5xe" },
//        //                  new V.Shape(
//        //                      new V.ImageData() { Title = "", RelationshipId = imageId }
//        //                  ) { Id = "_x0000_i1025", Style = "width:500pt;height:400pt", Ole = V.BooleanEntryWithBlankValues.Empty, Type = "#_x0000_t75" },
//        //                  new OVML.OleObject() { Type = OVML.OLEValues.Embed, ProgId = "Excel.Sheet.12", ShapeId = "_x0000_i1025", DrawAspect = OVML.OLEDrawAspectValues.Content, ObjectId = "_1307530183", Id = embedId }
//        //              ) { DxaOriginal = (UInt32Value)10957U, DyaOriginal = (UInt32Value)8455U })
//        //      );

//        //    return p;
//        //}
//    }
//}

using System;
using System.Data;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Configuration;

namespace CIPMSOfficeObjects
{
    public class CustomWord
    {
        private Application _wordApp = new Application();
        private object _oMissing = System.Reflection.Missing.Value;        
        object _start = Type.Missing;
        object _end = Type.Missing;
        //object _count = Type.Missing;
        //object _unit = Type.Missing;
        readonly string _uploadFilePath = ConfigurationSettings.AppSettings["UploadFilePath"];
        const int FontSize = 10;
        const string StrFontName = "Franklin Gothic Book";
        public string CreateWord(System.Data.DataTable dt)
        {
            
            object newTemplate = false;
            //object fileName = "normal.dot";
            object docType = WdNewDocumentType.wdNewBlankDocument;
            object isVisible = false;
            Document aDoc = _wordApp.Documents.Add(ref _oMissing, ref newTemplate, ref docType, ref isVisible);

            //object fileToOpen = uploadFilePath + "Classic.dotx";
            //Object missing = Type.Missing;
            //object newTemplate = false;   //if want to open a new template, please set this to True; 
            //Document aDoc = WordApp.Documents.Add(ref fileToOpen, ref newTemplate, ref oMissing, ref oMissing);
            try
            {
                //Document aDoc = WordApp.Documents.Add(ref oMissing, ref newTemplate, ref docType, ref isVisible);
                // need to see the created document, so make it visible
                //WordApp.Visible = true;
                aDoc.Activate();

                Range rng = aDoc.Range(ref _start, ref _end);
                rng.InsertBefore("Program Profile Information Report");
                rng.Font.Name = "Verdana";
                rng.Font.Size = 16;

                rng.InsertParagraphAfter();
                rng.InsertParagraphAfter();

                for (int iCount = 0; iCount < dt.Rows.Count; iCount++)
                    FillTable(aDoc, dt, dt.Rows[iCount], GetEndOfRange(rng, aDoc));

                    DocumentSaveAs(aDoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _wordApp = null;
/*
                newTemplate = null;
*/
                //fileToOpen = null;
/*
                docType = null;
*/
/*
                isVisible = null;
*/
                _oMissing = _start = _end = null;
/*
                aDoc = null;
*/
            }

            return "success";
        }

        private Table CreateTable(_Document aDoc, int noOfRows, int noOfColumns, Range rng, int tblCount)
        {
            if (aDoc == null) throw new ArgumentNullException("aDoc");

            //object start = Type.Missing;
            //object end = Type.Missing;
            //object count = Type.Missing;
            //object unit = Type.Missing;
            
            //aDoc.Range(ref start, ref end).Delete(ref unit, ref count);

            
            //Range rng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;           

            rng.SetRange(rng.End, rng.End);

            object defaultTableBehaviour = Type.Missing;
            object autoFitBehaviour = Type.Missing;
            aDoc.Tables.Add(rng, noOfRows, noOfColumns, ref defaultTableBehaviour, ref autoFitBehaviour);
            Table tbl = aDoc.Tables[tblCount];

            return tbl;
          
        }

        private void FillTable(Document aDoc, System.Data.DataTable dt, DataRow dr, Range rng)
        {
            GetEndOfRange(rng, aDoc);
            //rng.InsertParagraphAfter();
            rng.InsertParagraphAfter();
            Table tblMain = CreateTable(aDoc, 1, 2, GetEndOfRange(rng, aDoc), aDoc.Tables.Count + 1);
            int drColNumber = 0;
            
            Range rngCell;
            int col = 1;
            int row = 1;           

            tblMain.Range.Font.Size = FontSize;
            tblMain.Range.Font.Name = StrFontName;

            string tempFileName = _uploadFilePath + "temp" + DateTime.Now.Ticks + ".html";
            
            for (int iCol = 0; iCol <= 3; iCol++)
            {
                tblMain.Rows.Add(ref _oMissing);
                rngCell = tblMain.Cell(row, col).Range;
                rngCell.Text = (iCol==0?"A\t":(iCol==1?"B\t":(iCol==2?"C\t":(iCol==3?"D\t":"")))) + dt.Columns[iCol].ColumnName;
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                rngCell.Bold = (int)WdConstants.wdToggle;
                rngCell.Underline = WdUnderline.wdUnderlineSingle;               
                
                rngCell = tblMain.Cell(row, col + 1).Range;
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                rngCell.Text = dr.ItemArray.GetValue(iCol).ToString();
                
                row++;
                drColNumber = iCol;
            }

            //rng.SetRange(rng.End, rng.End);
            
            drColNumber++;

            if (!String.IsNullOrEmpty(dr[drColNumber].ToString()))
            {
                rng.InsertParagraphAfter();

                Table tblSummary = CreateTable(aDoc, 1, 1, GetEndOfRange(rng, aDoc), aDoc.Tables.Count + 1);
                tblSummary.Range.Font.Size = FontSize;
                tblSummary.Range.Font.Name = StrFontName;

                tblSummary.Rows.Add(ref _oMissing);
                rngCell = tblSummary.Cell(1, 1).Range;
                rngCell.Text = "E\tSummary Page Program Blurb:";
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                rngCell.Bold = (int)WdConstants.wdToggle;
                rngCell.Underline = WdUnderline.wdUnderlineSingle;

                rngCell = tblSummary.Cell(2, 1).Range;

                CreateFile(tempFileName, dr[drColNumber].ToString());               
                
                //object rangeSummaryFile = tblSummary.Cell(2, 1).Range;
                rngCell.InsertFile(tempFileName, ref _oMissing, ref _oMissing, ref _oMissing, ref _oMissing);// = dr[drColNumber].ToString();                

                DeleteFile(tempFileName);
            }
            drColNumber++;//For Summary 
            drColNumber++;//First timer (F:)
            drColNumber++;//second timer(G:)
            if (!String.IsNullOrEmpty(dr[drColNumber].ToString()))
            {
                rng.InsertParagraphAfter();
                Table tblGrade = CreateTable(aDoc, 1, 2, GetEndOfRange(rng, aDoc), aDoc.Tables.Count + 1);
                tblGrade.Range.Font.Size = FontSize;
                tblGrade.Range.Font.Name = StrFontName;

                tblGrade.Rows.Add(ref _oMissing);
                rngCell = tblGrade.Cell(1, 1).Range;
                rngCell.Text = "H\tGrade eligibility";
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                rngCell.Bold = (int)WdConstants.wdToggle;
                rngCell.Underline = WdUnderline.wdUnderlineSingle;

                rngCell = tblGrade.Cell(1, 2).Range;
                rngCell.Text = "Eligible = " + dr[drColNumber];
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                
            }
            drColNumber++;//For grade
            if (!String.IsNullOrEmpty(dr[drColNumber].ToString()))
            {
                rng.InsertParagraphAfter();
                Table tblDaySchool = CreateTable(aDoc, 1, 2, GetEndOfRange(rng, aDoc), aDoc.Tables.Count + 1);
                tblDaySchool.Range.Font.Size = FontSize;
                tblDaySchool.Range.Font.Name = StrFontName;

                tblDaySchool.Rows.Add(ref _oMissing);
                rngCell = tblDaySchool.Cell(1, 1).Range;
                rngCell.Text = "M\tDay school eligibility";
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                rngCell.Bold = (int)WdConstants.wdToggle;
                rngCell.Underline = WdUnderline.wdUnderlineSingle;

                rngCell = tblDaySchool.Cell(1, 2).Range;
                rngCell.Text = dr[drColNumber].ToString()=="true"?"yes":"no";
                rngCell.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

            }
            //drColNumber++;//For dayschool
        }

        private void DocumentSaveAs(_Document aDoc)
        {
            aDoc.Save();
            aDoc.Close(ref _oMissing, ref _oMissing, ref _oMissing);
            _wordApp.Quit(ref _oMissing, ref _oMissing, ref _oMissing);
        }

        protected Range GetEndOfRange(Range dataRange, Document aDoc)
        {
            Object startofDoc = dataRange.End - 1; 
            Object endofDoc = dataRange.End - 1;
            Range rng = aDoc.Range(ref startofDoc, ref endofDoc);
            return rng;
        }

        public void CreateFile(string tempFileName,string fileString)
        {
            StreamWriter stream = File.CreateText(tempFileName);
            stream.Write(fileString);
            stream.Flush();
            stream.Close();
        }

        public void DeleteFile(string tempFileName)
        {
            FileInfo fileInfo = new FileInfo(tempFileName);
            if (fileInfo.Exists) fileInfo.Delete();
        }
    }
}

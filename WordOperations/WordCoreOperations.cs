using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace WordOperations
{
    public static class WordCoreOperations
    {
        public static Word._Application oWord;
        public static Word._Document oDoc;
        internal static object WordCreate()
        {
            object oMissing = System.Reflection.Missing.Value;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            return oDoc;
        }
        internal static object WordOpen(object FilePath)
        {
            object oMissing = System.Reflection.Missing.Value;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Open(ref FilePath, ref oMissing, ref oMissing, ref oMissing);
            return oDoc;
        }
        internal static void WordWriteText(string Message, int FontSize, string FontName, int FontType, Word.WdColor Color, int SpaceAfter)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";
            Word.Paragraph oPara;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara = oDoc.Content.Paragraphs.Add(ref oRng);
            if (FontType == 1)
            {
                oPara.Range.Font.Bold = 1;
            }
            else if (FontType == 2)
            {
                oPara.Range.Font.Italic = 1;
            }
            else if (FontType == 3)
            {
                oPara.Range.Font.Bold = 1;
                oPara.Range.Font.Italic = 1;
            }
            else
            {
                oPara.Range.Font.Bold = 0;
            }
            oPara.Range.Font.Name = FontName;
            oPara.Range.Font.Color = Color;
            oPara.Range.Font.Size = FontSize;
            oPara.Range.Text = Message;
            oPara.Format.SpaceAfter = SpaceAfter;
            oPara.Range.InsertParagraphAfter();
        }
        internal static void WordSave(object FilePath)
        {
            try
            {
                oDoc.Save();
            }
            catch
            {
                WordSaveAs(FilePath);
            }
        }
        internal static void WordSaveAs(object FilePath)
        {
            oDoc.SaveAs2(ref FilePath);
        }
        internal static void WordClose(bool CloseSaveChanges, bool QuitSaveChanges)
        {
            oDoc.Close(CloseSaveChanges);
            oWord.Quit(QuitSaveChanges);
        }
        internal static void WordAddTable(int Rows, int Columns, int SpaceAfter)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, Rows, Columns, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = SpaceAfter;
            oTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        }
        internal static void WordAddImage(string ImagePath)
        {
            object oEndOfDoc = "\\endofdoc";
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            Word.InlineShape autoScaledInlineShape = wrdRng.InlineShapes.AddPicture(ImagePath);
        }
        internal static void WordAddShape(int Type, float Left, float Top, float Width, float Height)
        {
            object oEndOfDoc = "\\endofdoc";
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            Word.Shape newShape = oDoc.Shapes.AddShape(Type, Left, Top, Width, Height);
            newShape.Fill.BackColor.RGB = 2;
        }
        internal static void WordExportToPDF(string FilePath)
        {
            //oDoc.SaveAs2(FilePath, Word.WdSaveFormat.wdFormatPDF);
            oDoc.ExportAsFixedFormat(FilePath, Word.WdExportFormat.wdExportFormatPDF);
        }
        internal static void WordFindandReplace(string Find, string Replace, int Type)
        {
            oDoc.Activate();
            Word.Find find = oWord.ActiveWindow.Selection.Find;
            find.ClearFormatting();
            find.Replacement.ClearFormatting();
            find.Forward = true;
            find.Wrap = Word.WdFindWrap.wdFindContinue;
            find.Text = Find;
            find.Replacement.Text = Replace;
            if (Type == 0)
            {
                find.Execute(Replace: Word.WdReplace.wdReplaceNone);
            }
            else if (Type == 1)
            {
                find.Execute(Replace: Word.WdReplace.wdReplaceOne);
            }
            else
            {
                find.Execute(Replace: Word.WdReplace.wdReplaceAll);
            }
        }
        internal static void WordCreateBookmark(string BookMarkName)
        {
            Word.Document doc = null;
            Word.Bookmarks bookmarks = null;
            Word.Bookmark myBookmark = null;
            Word.Range bookmarkRange = null;
            Word.Selection selection = null;
            try
            {
                doc = oWord.ActiveDocument;
                selection = oWord.Selection;
                bookmarkRange = selection.Range;
                bookmarks = doc.Bookmarks;
                myBookmark = bookmarks.Add(BookMarkName, bookmarkRange);
            }
            finally
            {
                if (selection != null) Marshal.ReleaseComObject(selection);
                if (bookmarkRange != null) Marshal.ReleaseComObject(bookmarkRange);
                if (myBookmark != null) Marshal.ReleaseComObject(myBookmark);
                if (bookmarks != null) Marshal.ReleaseComObject(bookmarks);
                if (doc != null) Marshal.ReleaseComObject(doc);
            }
        }
        internal static void WordSetBookMarkContent(string BookMarkName, string Text)
        {
            Word.Document doc = null;
            Word.Bookmarks bookmarks = null;
            Word.Bookmark myBookmark = null;
            Word.Range bookmarkRange = null;

            try
            {
                doc = oWord.ActiveDocument;
                bookmarks = doc.Bookmarks;
                myBookmark = bookmarks[BookMarkName];
                bookmarkRange = myBookmark.Range;
                bookmarkRange.Text = Text;
            }
            finally
            {
                if (bookmarkRange != null) Marshal.ReleaseComObject(bookmarkRange);
                if (myBookmark != null) Marshal.ReleaseComObject(myBookmark);
                if (bookmarks != null) Marshal.ReleaseComObject(bookmarks);
                if (doc != null) Marshal.ReleaseComObject(doc);
            }
        }
        internal static string WordBookMarksList()
        {
            Word.Document doc = null;
            Word.Bookmarks bookmarks = null;
            string bookmarkNames = string.Empty;

            try
            {
                doc = oWord.ActiveDocument;
                bookmarks = doc.Bookmarks;

                for (int i = 1; i <= bookmarks.Count; i++)
                {
                    bookmarkNames += bookmarks[i].Name + Environment.NewLine;
                }
                return bookmarkNames;
            }
            finally
            {
                if (bookmarks != null) Marshal.ReleaseComObject(bookmarks);
                if (doc != null) Marshal.ReleaseComObject(doc);
            }
        }
    }
}

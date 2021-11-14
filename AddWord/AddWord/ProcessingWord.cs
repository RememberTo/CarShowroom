using System;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWord
{
    public class ProcessingWord
    {
        private FileInfo _fileInfo;
        private bool _isSuccsesfull = false;

        public bool IsSuccsesfull { get { return _isSuccsesfull; }}
        public ProcessingWord(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new IOException();
            }
        }

        public void Process(Dictionary<string, string> items, string folder, int index)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();

                Object file = _fileInfo.FullName;

                Object mising = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: mising,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: mising,
                        Replace: replace
                        );
                }

                // @"C:\Users\fdkir\OneDrive\Рабочий стол\Курсовая работа\CarShowroom\CarShowroom\WordFile\Заявки", "Заявка от:" + DateTime.Now.ToString("dd_MM_yyyy-HH:mm:ss")

                Object newFileName = Path.Combine(@"C:\Users\fdkir\OneDrive\Рабочий стол\Курсовая работа\CarShowroom\CarShowroom\WordFile\" + folder, Convert.ToString(index)+"Заявка от " + DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss") + ".docx");
                app.ActiveDocument.SaveAs2(newFileName);
                _isSuccsesfull = true;
            }
            catch (Exception)
            {
                _isSuccsesfull = false;
            }
            finally
            {
                app.ActiveDocument.Close();
                app.Quit();
                //app.Documents.Close();
            }
        }
    }
}

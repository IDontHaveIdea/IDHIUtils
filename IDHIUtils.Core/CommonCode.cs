using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace IDHIUtils
{
    internal class CC
    {
        /*static private int _language = -1;

        /// <summary>
        /// Safely get the language as configured in setup.xml if it exists.
        /// </summary>
        static public int Language
        {
            get
            {
                if (_language == -1)
                {
                    try
                    {
                        var doc = new XmlDocument();
                        doc.Load("UserData/setup.xml");
                        var dataXml = doc.DocumentElement;

                        foreach (var elementObj in dataXml.GetElementsByTagName("Language"))
                        {
                            if (elementObj != null)
                            {
                                var element = (XmlElement)elementObj;
                                _language = int.Parse(element.InnerText);
                                break;
                            }
                        }
                    }
                    catch
                    {
                        _language = 0;
                    }
                    finally
                    {
                        if (_language == -1)
                        {
                            _language = 0;
                        }
                    }
                }

                return _language;
            }
        }

        /// <summary>
        /// Open explorer focused on the specified file or directory
        /// </summary>
        static internal void OpenFileInExplorer(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException(nameof(filename));
            }

            try { NativeMethods.OpenFolderAndSelectFile(filename); }
            catch (Exception) { Process.Start("explorer.exe", $"/select, \"{filename}\""); }
        }

        static internal class NativeMethods
        {
            /// <summary>
            /// Open explorer focused on item. Reuses already opened explorer 
            /// windows unlike Process.Start
            /// </summary>
            static public void OpenFolderAndSelectFile(string filename)
            {
                var pidl = ILCreateFromPathW(filename);
                _ = SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);
                ILFree(pidl);
            }

            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            static extern private IntPtr ILCreateFromPathW(string pszPath);

            [DllImport("shell32.dll")]
            static extern private int SHOpenFolderAndSelectItems(
                IntPtr pidlFolder, 
                int cild, 
                IntPtr apidl, 
                int dwFlags);

            [DllImport("shell32.dll")]
            static extern private void ILFree(IntPtr pidl);
        }

        static internal class Paths
        {
            static readonly internal string FemaleCardPath = Path.Combine(
                UserData.Path, "chara/female/");
            static readonly internal string MaleCardPath = Path.Combine(
                UserData.Path, "chara/male/");
            static readonly internal string CoordinateCardPath = Path.Combine(
                UserData.Path, "coordinate/");
        }*/
    }
}

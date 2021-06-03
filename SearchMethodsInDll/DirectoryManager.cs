using System.IO;

namespace SearchMethodsInDll
{
    class DirectoryManager
    {
        /// <summary>
        /// Search *.dll files in a directory
        /// </summary>
        /// <param name="path">Directory full name</param>
        /// <returns>Array with full *.dll file names in a directory</returns>
        public static string[] SearchDllInDirectory(string path)
        {
            string[] _dllFiles;

            if (Directory.Exists(path))
            {
               return _dllFiles = Directory.GetFiles(path, "*.dll");
            }
            else
            {
                throw new DirectoryNotFoundException("Директория не найдена");
            }
        }
    }
}

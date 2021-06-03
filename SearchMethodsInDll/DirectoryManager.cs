using System;
using System.IO;
using System.Reflection;

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

        /// <summary>
        /// Search public and protected methods in the *.dll files
        /// </summary>
        /// <param name="files">Array of *.dll file names</param>
        /// <returns> String with classes and class's private and protected methods</returns>
        public static string SearchPublicAndProtectedMethods(string[] files)
        {
            //TODO: Обработать исключения
            string str = "";

            for (int i = 0; i < files.Length; i++)
            {
                var assembly = Assembly.LoadFile(files[i]);

                foreach (Type type in assembly.GetTypes())
                {
                    str += $"{type.Name} \n";

                    foreach (MethodInfo method in type.GetMethods
                        (BindingFlags.Public | BindingFlags.Instance | 
                        BindingFlags.DeclaredOnly | BindingFlags.NonPublic))
                    {
                        if (method.IsPublic || method.IsFamily)
                        {
                            str += $"\t{method.Name} \n";
                        }
                    }
                }
            }

            return str;
        }
    }
}

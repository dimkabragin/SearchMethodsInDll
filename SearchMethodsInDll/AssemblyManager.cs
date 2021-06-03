using System;
using System.Reflection;

namespace SearchMethodsInDll
{
    class AssemblyManager
    {
        /// <summary>
        /// Search public and protected methods in the *.dll files
        /// </summary>
        /// <param name="files">Array of *.dll file names</param>
        /// <returns> String with classes and class's private and protected methods</returns>
        public static string SearchPublicAndProtectedMethods(string[] files)
        {
            string str = "";

            for (int i = 0; i < files.Length; i++)
            {
                var assembly = Assembly.LoadFile(files[i]);

                foreach (Type type in assembly.GetTypes())
                {
                    str += $" {type.Name} \n";

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

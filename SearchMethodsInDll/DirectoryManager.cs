﻿using System;
using System.IO;
using System.Reflection;

namespace SearchMethodsInDll
{
    class DirectoryManager
    {
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

        public static string SearchPublicAndProtectedMethods(string[] files)
        {
            //TODO: Обработать исключения
            string str = "";

            for (int i = 0; i < files.Length; i++)
            {
                var assembly = Assembly.LoadFile(files[i]);

                //str += $"{assembly.GetName()} \n";

                foreach (Type type in assembly.GetTypes())
                {
                    str += $"{type.Name} \n";

                    foreach (MethodInfo method in type.GetMethods())
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

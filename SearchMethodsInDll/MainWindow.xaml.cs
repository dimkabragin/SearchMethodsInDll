using System;
using System.IO;
using System.Windows;
using Forms = System.Windows.Forms;

namespace SearchMethodsInDll
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseFolderPathBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Forms.FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == Forms.DialogResult.OK)
            {
                FolderPathTextBlock.Text = dialog.SelectedPath;

                try
                {
                    OutputTextBlock.Text = AssemblyManager.SearchPublicAndProtectedMethods(
                        DirectoryManager.SearchDllInDirectory(dialog.SelectedPath));
                }
                catch (DirectoryNotFoundException ex)
                {
                    //В нашем случае крайне маловеротно, что данное ислючение произойдет
                    //Но все равно обработаем для будущих поколений
                    MessageBox.Show(ex.Message, "We can't found a this folder");
                }
                catch (Exception ex)
                {
                    //Тут ловим прочие исключения и информируем о них пользователя
                    MessageBox.Show(ex.Message, "Oups, something went wrong");
                }
            }
        }
    }
}

using System.Windows;
using System.Windows.Forms;

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
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FolderPathTextBlock.Text = dialog.SelectedPath;

                OutputTextBlock.Text = DirectoryManager.SearchPublicAndProtectedMethods(
                    DirectoryManager.SearchDllInDirectory(dialog.SelectedPath));
            }
        }
    }
}

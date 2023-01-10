using System.Windows;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using MessageBox = WYW.UI.Controls.MessageBoxWindow;
using MessageBoxImage = WYW.UI.Controls.MessageBoxImage;

namespace WYW.DownloadStandardDocument
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Response currentResponse = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyWords.Text))
            {
                MessageBox.Show("请输入标准号", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                currentResponse = WebHelper.GetResponse(txtKeyWords.Text, 1, GetCondition());
                this.DataContext = currentResponse;
            }

        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (myListView.SelectedIndex > -1)
            {
                var item = myListView.SelectedItem as Result;
                if (item != null)
                {
                    if (!string.IsNullOrEmpty(item.PdfPath))
                    {
                        var sfd = new SaveFileDialog();
                        sfd.Filter = "PDF File|*.pdf"; //设置文件类型 
                        sfd.FilterIndex = 1; //设置默认文件类型显示顺序 
                        sfd.RestoreDirectory = true; //保存对话框是否记忆上次打开的目录 
                        sfd.FileName = TrimSpecialCharacter($"{item.Code} {item.Name}");
                        if (sfd.ShowDialog() == true)
                        {
                            try
                            {
                                WebHelper.DownloadFile(item.PdfPath.Replace(":8080", ":8087"), sfd.FileName);
                                MessageBox.Show("下载成功", "提示");
                            }
                            catch
                            {
                                MessageBox.Show("下载失败，可能下载地址不可用", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("该文件不支持下载", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }
            else
            {
                MessageBox.Show("请先选择需要下载的文件", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (currentResponse != null && currentResponse.page > 1)
            {
                currentResponse = WebHelper.GetResponse(txtKeyWords.Text, currentResponse.page - 1, GetCondition());
                this.DataContext = currentResponse;
            }

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentResponse != null && currentResponse.page < currentResponse.totalPageCount)
            {
                currentResponse = WebHelper.GetResponse(txtKeyWords.Text, currentResponse.page + 1, GetCondition());
                this.DataContext = currentResponse;
            }
        }
        private string TrimSpecialCharacter(string chars)
        {
            return Regex.Replace(chars, @"[\/\\\|\<\>\*\:\?]", " ");
        }
        private string GetCondition()
        {
            string conditon = "";
            if(chbCondition1.IsChecked==true)
            {
                conditon += "&isUnCarryState=true";
            }
            if (chbCondition2.IsChecked == true)
            {
                conditon += "&isActiveState=true";
            }
            if (chbCondition3.IsChecked == true)
            {
                conditon += "&isPartAbolishState=true";
            }
            if (chbCondition4.IsChecked == true)
            {
                conditon += "&isAbolishState=true";
            }
            return conditon;
        }
    }
}

   M S B A M L   `   `   `  ????S  ODownloadStandardDocument, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WYW.DownloadStandardDocumentWYW.DownloadStandardDocument  5   	   -    'WYW.DownloadStandardDocument.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:WYW.DownloadStandardDocument     5   	   A =WYW.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"wywhttp://wangyanwei.com/ui  5   	     ? WindowStartupLocation$  CenterScreen=?5         WindowNormalStyle#??[  5	   	    ? Title$- 'ISO/IEC/YY/GB标准文档下载器 V1.0??5
   	   $	??768??6+   $
??1024??68   $??16(?6E   .??5      ? $??20,10q?6    ? RowDefinitions 5   
   ?? 5      $??80 ?6   ?? 5      $??* ?6   ?? 5      $??60 ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      $??3* ?6#   ?? 5      ?? 5      .+?5      ?  5      ?? 5      $
??AUTO ?6$   ?? 5       5      ?? 5      ?? 5      ?? 5       ?? 5!      .+?5#      ?? -   5        $??txtKeyWords??5#   M   $??0??6   $??4??6+   $
??0,10q?6?   +  %WYW.UI.Controls.Attach.TextBoxElement   	InputHint$* $请输入标准号，例如：YY0664??5$      ?? 5%      -   5        $??chbCondition1??5%   W   $??1??6   $??0??6(    d? 	IsChecked$
 TrueY?68   $??	未实施??6I   6W   ?? 5&      -   5        $??chbCondition2??5&   V   $??1??6   $??1??6(   $
 TrueY?68   $??现行??6I   6V   ?? 5'      -   5        $??chbCondition3??5'   G   $??1??6   $??2??6(   $??部分废止??68   6G   ?? 5(      -   5        $??chbCondition4??5(   E   $??1??6   $??3??6(   $??废止??68   6E   5)      ?? 5+      -   5        $??1??5+      $??搜索??6&   $??60??64   $??20,0,0,0q?6@   6R   ?? 5,      -   5        $??2??5,      $??下载??6&   $??60??64   $??20,0,0,0q?6@   6R   5-      &   System.Windows.Controls.DataGrid  5.   
   -   5        $??
myListView??5/   2   $??1??5.      $
??0,10q?6!      
IsReadOnly .    SelectionMode$ Single=?6C      SelectionUnit$ FullRow=?6Z   ??5/      ?? *result+	   Columns	 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn
   Header$
 标准编号??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ?? *Code+  52      $
 标准名称??6%   $ 7* 63    6>   ?? *Name+  53      $
 状态??6%   $ * 61    6;   ?? *Status+  54      $
 下载??6%   $ * 61    6;   ?? *IsCanDownload+56      ? 57   
   $??2??6    58      ?? 59      $??3* ?6#   ?? 5:      ?? 5;      .+?5=      ?? -	   5        $??1??5=      $??20,0,0,0q?6&   $??	上一页??68   6F   ?? 5>      -
   5        $??2??5>      $??20,0,0,0q?6&   $??	下一页??68   6F   ?? 5?      $??0??6   ??5@      `? 5A       ?? StringFormat$9 3当前页：{0}，总页数：{1}，总条数：{2}??6#   .1?5B      ??  ?? Path$
 page?6"   ?? 5C      $ totalPageCount?6"   ?? 5D      $ 
totalCount?6"   5E      5G      5H      5I      5J      
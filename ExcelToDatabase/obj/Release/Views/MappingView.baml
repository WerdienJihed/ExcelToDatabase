   M S B A M L   `   `   `  ����   ExcelToDatabase'    !ExcelToDatabase.Views.MappingView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=�   MaterialDesignPaper#���     MaterialDesignBody#���   � Title$ Columns Mapping��$	��800��$	��800�� � 	Resources   ListOfColumns �� Source��%*   &	       ��  �� *SourceColumns+.���  � ColumnDefinitions �� $
��20px ��� $��* ��� $
��auto ��� $
��20px � � RowDefinitions �� $
��20px ��� $
��auto ��� $
��auto ��� $��* ��� $
��20px �.+�&   System.Windows.Controls.DataGrid  -     Name$ MappingItems��$��1��$��1��$��2��$��300px��$��500px��   AlternatingRowBackground
 ��ح�	 �� AlternationCount$	 2��
   AutoGenerateColumns
 .     CanUserAddRows .  "   VerticalScrollBarVisibility$
 Auto=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Destination��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *DestinationColumn+4  .System.Windows.Controls.DataGridComboBoxColumn  $ Source��   ItemsSource ��  �� Source# [    SelectedItemBinding �� *SourceColumn+ �� Mode$ TwoWay=��� -    ��Name$ Execute��$��Execute��$��3��$��2��$
��30px��$��150px��$��Right=�$��Bottom=�
   M S B A M L   `   `   `  ����  ExcelToDatabase'    !ExcelToDatabase.Views.MappingView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ NoResize=�5         MaterialDesignPaper#���   5	        MaterialDesignBody#���  5
   	    � Title$ Columns Mapping��5   	   $	��800��6!   $	��800��6.    � 	Resources 5        ListOfColumns �� Source��%8   &	       �� 5       6/   �� *SourceColumns+5      .��5      �  � ColumnDefinitions 5      �� 5      $
��20px �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��20px �6    � RowDefinitions 5      �� 5      $
��20px �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��20px �6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ MappingItems��5%      $��1��5"      $��1��5#      $��2��5$      $��300px��5&      $��500px��5'         AlternatingRowBackground
 ��ح�	 �� AlternationCount$	 2��5)      
   AutoGenerateColumns
 .     CanUserAddRows .  "   VerticalScrollBarVisibility$
 Auto=�5,         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5-         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Destination��52         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 53      �� *DestinationColumn+54      4  .System.Windows.Controls.DataGridComboBoxColumn  56      $ Source��57         ItemsSource 58      ��  �� Source# [    SelectedItemBinding 59      �� *SourceColumn+ �� Mode$ TwoWay=�5?      �� 5A      -   5         ��Name$ Execute��5B      $��Execute��5C      $��3��5D      $��2��5E      $
��30px��5F      $��150px��5G      $��Right=�5H      $��Bottom=�5I      5L      5M      
   M S B A M L   `   `   `  ����   ExcelToDatabase*    $ExcelToDatabase.Views.MainWindowView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=�   MaterialDesignPaper#���     MaterialDesignBody#���   � Title$ Excel To Database��$	��800��$	��800��$��18(�.��� 
������� � RowDefinitions �� $
��20px ��� $
��auto ��� $
��20px ��� $
��auto ��� $
��20px ��� $��* ��� $��20 � � ColumnDefinitions �� $
��20px ��� $��* ��� $
��20px �.+��� $��1��$��1��$��Excel configuration��  MaterialDesignCardGroupBox#��[ .���  �� $
��20px ��� $
��auto ��� $
��20px ��� $
��auto ��� $
��20px � �� $
��20px ��� $
��auto ��� $
��20px ��� $��150px���� $
��20px ��� $��100px���� $
��20px �.+��� $��	File path��$��1��$��1�� $  MaterialDesignHeadline6TextBlock#���  �� -    ��Name$
 Path��$��1��$��3�� �� 
IsReadOnly . 
��������� -    ��Name$ Upload��$��1��$��5��$��Upload�� # MaterialDesignRaisedLightButton#��[ �� $��
Sheet name��$��3��$��1��#���  �� -    ��Name$ Sheets��$��3��$��3��	 �� 
IsReadOnly	 . $	��200��
 �� SelectedItem
 �� *SelectedSheet+ �� Mode$ TwoWay=��� $��3��$��1��$��Sql Server configuration��#��[ .���  �� $
��20px ��� $
��auto ��� $
��20px ��� $
��auto ��� $
��20px ��� $
��auto ��� $
��20px � �� $
��20px ��� $
��auto ��� $
��20px ��� $��150px���� $
��20px ��� $��100px���� $
��20px �.+��� $��Server��$��1��$��1��#���  �� -   $ 
ServerName��$��1��$��3���� $��Database��$��3��$��1��#���  �� -   $ DatabaseName��$��3��$��3���� -   $ Connect��$��Connect��$��3��$��5��#��[ �� $��Table��$��5��$��1��#���  �� -   $ Tables��$��5��$��3��	 . $	��200��
 �� *SelectedTable+$ TwoWay=�� $��5��$��1��$��Right=�$��Bottom=� �� $
��20px ��� $
��auto ��� $
��20px ��� $
��auto ��� $
��20px �.+��� -   $ OpenColumnsConfiguration��$��1��$��columns Configuration��#��[ �� -	   $ OpenMapping��$��3��$��Mapping��#��[ 
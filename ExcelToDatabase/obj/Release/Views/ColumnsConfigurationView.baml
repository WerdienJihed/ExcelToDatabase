   M S B A M L   `   `   `  ����   ExcelToDatabase4    .ExcelToDatabase.Views.ColumnsConfigurationView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f'i1http://www.caliburnproject.org  -     �Name$  Configuration�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Title$ Columns Configuration��$	��800��$	��800��   MaterialDesignPaper#���     MaterialDesignBody#���  $��18(�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. "  Caliburn.Micro.ActionMessage     
MethodName$ OnLoad��.���  � ColumnDefinitions �� $
��20px ��� $��* ��� $��100px ��� $
��20px �	 � RowDefinitions	 �� $
��20px ��� $��* ��� $
��30px ��� $
��20px �.+�� $��1��$��1��$��3�� �� $��* ��� $��* �.+��� $��0��
�������$��3q�._��� -   
 ��Name$
 ColumnsFromSql�� �� SelectionMode$ Single=����� .R��� ���� *Name+ d� 	IsChecked �� *	IsChecked+�� $��1��
�������$��3q�._��� -   $
 ColumnsFromExcel��$ Single=����� .R��� ���� *Name+ �� *	IsChecked+�� $��OK��$��2��$��2��   $ Click��.   $ OkBtn��   
Parameters.   Caliburn.Micro.Parameter     Value ��  �� ElementName$ Configuration��
   M S B A M L   `   `   `  ����  ExcelToDatabase*    $ExcelToDatabase.Views.MainWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ NoResize=�5         MaterialDesignPaper#���   5	        MaterialDesignBody#���  5
   	    � Title$ Excel To Database��5   	   $	��800��6#   $	��800��60   $��18(�5      .��5      � 
������� � RowDefinitions 5      �� 5      $
��20px �6   �� 5      $
��auto �6   �� 5      $
��20px �6   �� 5      $
��auto �6   �� 5      $
��20px �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5      �� 5      $
��20px �6   �� 5      $��* �6   �� 5      $
��20px �6   .+�5      �� $��1��5      $��1��5       $��Excel configuration��5!        MaterialDesignCardGroupBox#��[ 5"      .��5%      �  5&      �� 5'      $
��20px �6   �� 5(      $
��auto �6   �� 5)      $
��20px �6   �� 5*      $
��auto �6   �� 5+      $
��20px �6    5-      �� 5.      $
��20px �6   �� 5/      $
��auto �6   �� 50      $
��20px �6   �� 51      $��150px��6   �� 52      $
��20px �6   �� 53      $��100px��6   �� 54      $
��20px �6   .+�57      �� $��	File path��58      $��1��59      $��1��5:       $  MaterialDesignHeadline6TextBlock#���  5;      �� 5>      -   5         ��Name$
 Path��5?      $��1��5@      $��3��5A       �� 
IsReadOnly . 
�������5C      �� 5F      -   5         ��Name$ Upload��5G      $��1��5H      $��5��5I      $��Upload��5J       # MaterialDesignRaisedLightButton#��[ 5K      �� 5N      $��
Sheet name��5O      $��3��5P      $��1��5Q      #���  5R      �� 5U      -   5         ��Name$ Sheets��5V      $��3��5W      $��3��5X      	 �� 
IsReadOnly	 . $	��200��5[      
 �� SelectedItem
 5Y      �� *SelectedSheet+ �� Mode$ TwoWay=�5[      5]      5^      �� 5a      $��3��5b      $��1��5c      $��Sql Server configuration��5d      #��[ 5e      .��5g      �  5h      �� 5i      $
��20px �6   �� 5j      $
��auto �6   �� 5k      $
��20px �6   �� 5l      $
��auto �6   �� 5m      $
��20px �6   �� 5n      $
��auto �6   �� 5o      $
��20px �6    5q      �� 5r      $
��20px �6   �� 5s      $
��auto �6   �� 5t      $
��20px �6   �� 5u      $��150px��6   �� 5v      $
��20px �6   �� 5w      $��100px��6   �� 5x      $
��20px �6   .+�5{      �� $��Server��5|      $��1��5}      $��1��5~      #���  5      �� 5�      -   5        $ 
ServerName��5�      $��1��5�      $��3��5�      �� 5�      $��Database��5�      $��3��5�      $��1��5�      #���  5�      �� 5�      -   5        $ DatabaseName��5�      $��3��5�      $��3��5�      �� 5�      -   5        $ Connect��5�      $��Connect��5�      $��3��5�      $��5��5�      #��[ 5�      �� 5�      $��Table��5�      $��5��5�      $��1��5�      #���  5�      �� 5�      -   5        $ Tables��5�      $��5��5�      $��3��5�      	 . $	��200��5�      
 5�      �� *SelectedTable+$ TwoWay=�5�      5�      5�      � 5�      $��5��5�      $��1��5�      $��Right=�5�      $��Bottom=�5�       5�      �� 5�      $
��20px �6   �� 5�      $
��auto �6   �� 5�      $
��20px �6   �� 5�      $
��auto �6   �� 5�      $
��20px �6   .+�5�      �� -   5        $ OpenColumnsConfiguration��5�      $��1��5�      $��columns Configuration��5�      #��[ 5�      �� 5�      -	   5        $ OpenMapping��5�      $��3��5�      $��Mapping��5�      #��[ 5�      5�      5�      5�      
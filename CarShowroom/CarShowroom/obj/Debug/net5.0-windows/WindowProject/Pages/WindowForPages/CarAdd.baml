   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages.CarShowroom.WindowProject.Pages.WindowForPages  5   	   ;    5CarShowroom.WindowProject.Pages.WindowForPages.CarAdd   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   
   -   5         "  MaterialDesignFlatButtonRipple#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
    # MaterialDesignToolBarBackground#���  5   
    � Title$ AcessoryAddToCar��5   	   $	��978��6"   $	��678��6.    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � WindowStyle$
 None=�6w   .��5      �  J� RenderTransformOrigin$ 0.495,0.475&�6   .+�5   
   �� $��Center=�6   
���   �$	��978��6@   $ 0.5,0.5&�6L   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.013Q�6$   �� 5      T� 5       T� X$ 0.063Q�6)   5      5      �� 5    
   $��Center=�6   $	��295��61   $��0,87,0,0q�6>     PrimaryHueDarkBrush#���  6P   $	��Top=�6   $	��898��6�   $��2��6�   �� 5"   
   -   5        	 ��Name$	 ButtonClose��5"         MaterialDesignFlatDarkButton#��[ 5#      $��×��5$      $
��Left=�6   $��27(�68   $��
952,-6,0,0q�6F   $	��Top=�5%      $��26��6)   $ 
-0.06,0.72&�65   $��28��5&      
 � Cursor$

 Hand��67     MaterialDesignBody#���  6E   ���	#FFBD3F3F$��0,0,0,0q�6�   �� 5(   
   -   5        $	 
button_Add��5)      $��Добавить��5(      #��[ 5*       ) %MaterialDesignDarkSeparatorBackground#���  5+      $
��Left=�5,      $��848,627,0,0q�6,   $	��Top=�6A   $	��110��5-      $

 Hand��6   $��34��6,   $ 
0.29,0.558&�68   6[   �� 50   
   -   5         ��Name$ 	label_suc��50      $��17(�6   $��аываываыа��61   $��Center=�6E   $��	0,393,0,0q�6b   $	��Top=�6u   $	��891��6�   ���	#DD0F57D4$��Center=�6�   $��Center=�6�   $y�Visible=�6�   	� 52   
   -   5         	�Name$ Radio_Manufac��52      $��15(�6-   $1��+Добавить производителя��6;   $
��Left=�6\   $��
287,20,0,0q�6w   $	��Top=�6�   #���  6�   #���  6�   6  	� 53   
   -   5        $ Radio_Model��53      $��15(�6+   $#��Добавить модель��69   $
��Left=�6S   $��
515,20,0,0q�6n   $	��Top=�6�   #���  6�   #���  6�   6�   	� 54   
   -   5        $ Radio_Equip��54      $��15(�6+   $/��)Добавить комплектацию��69   $
��Left=�6Y   $��
678,20,0,0q�6t   $	��Top=�6�   #���  6�   #���  6�   6  	� 55   
   -   5        $ 	Radio_Car��55      $��15(�6)   $+��%Добавить автомобиль��67   $
��Left=�6U   $��	80,20,0,0q�6p   $	��Top=�6�   #���  6�   #���  6�   $	��182��6   6  &   System.Windows.Controls.DataGrid  5;   
   -	   5          Name$ DataGridManufacturer��5;        MaterialDesignDataGrid#��[ 5<      $

 Hand��5=         AutoGenerateColumns$ False��5>         SelectionMode$ Single=�5?      $��43,93,766,300q�5@      #���  6*    � ContextMenu 5B      �� 5C      .@�5D      m� -
   5        $��Добавить��5D   6   5E         Columns 5G      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$  Производитель��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ��  �� Path$ _name� �� Mode$ OneWay=�6z   5J        5K   
   -   5        $ DataGridModel��5K      #��[ 5L      $

 Hand��5M      $ False��5N      $ Single=�5O      $��257,93,566,300q�5P      #���  6+    5R      �� 5S      .@�5T      m� -   5        $��Добавить��5T   8   5U       5W        5X      $ Модель��64   $	 140 6s    6D   �� $ _name�$ OneWay=�6s   5Z        5[   
   -   5        $ DataGridEquip��5[      #��[ 5\      $

 Hand��5]      $ False��5^      $ Single=�5_      $��443,93,44,300q�5`      #���  6*    5b      �� 5c      .@�5d      m� -   5        $��Добавить��5d   8   5e       5g        5h      $ Комплектация��64   $ * 6y    6J   �� $ _name�$ OneWay=�6y     5i      $ Тип привода��64   $ * 6x    6I   �� $ _drive�$ OneWay=�6x     5j      $ Тип топлива��64   $ * 6x    6I   �� $ _fuel�$ OneWay=�6x   5l      �� 5n   
   -   5        $	 button_Update��5o      $	��↻��5n      #��[ 5p      $��25(�5q      #���  5r      $
��Left=�5s      $��
939,94,0,0q�6,   $	��Top=�6@   $��37��5t      $

 Hand��6   $��36��6+   $��0,-2,0,0q�67   #���  6J   6|   �� 5w   
   -   5         ��Name$ TextBox_manufac��5x      $
��Left=�5y      $��
43,421,0,0q�5z      $��46��6"   $	��Top=�5{      $	��219��6%   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Производитель��5|       % !MaterialDesignFloatingHintTextBox#��[ 5}      $��15(�5~       �� 
CaretBrush �	#FF39505D#���  5�        	 MaterialDesignToolForeground#��� 	 5�       �� SelectionBrush �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_model��5�      $
��Left=�5�      $��
43,574,0,0q�5�      $��46��6"   $	��Top=�5�      $	��219��6%   $ Модель��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_nameEquip��5�      $
��Left=�5�      $��307,421,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Комплектация��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_drive��5�      $
��Left=�5�      $��307,472,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Тип привода��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_fuel��5�      $
��Left=�5�      $��307,523,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Тип топлива��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_price��5�      $
��Left=�5�      $��589,621,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Цена��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   6�   �� 5�   
   -   5        $ TextBox_vin��5�       �� 	MaxLength$ 17��5�      $
��Left=�5�      $��589,421,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $	 VIN��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_color��5�      $
��Left=�5�      $��589,472,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Цвет��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   �� 5�   
   -   5        $ TextBox_mileage��5�      $
��Left=�5�      $��589,523,0,0q�5�      $��46��6#   $	��Top=�5�      $	��242��6%   $ Пробег��5�      #��[ 5�      $��15(�5�       �	#FF39505D#���  5�      #��� 	 5�       �	#FF8BB1CE$

 Hand��6e   $��5,4,0,4q�6s   6�   (  "System.Windows.Controls.DatePicker  5�   
   -   5          Name$ 
DatePicker��5�      $ Дата выпуска��5�      $��5,4,0,4q�6;   #���  5�      $��15(�5�      $
��Left=�5�      $��589,574,0,0q�6(   $	��Top=�6=   $	��242��6U   $��46��6a   5�      5�      
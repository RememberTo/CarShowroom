   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CarShowroomSystem.WindowProject.Pages%CarShowroomSystem.WindowProject.Pages  5      9    3CarShowroomSystem.WindowProject.Pages.pageAccessory   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:CarShowroomSystem.WindowProject.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5       "  MaterialDesignFlatButtonRipple#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
      MaterialDesignToolBackground N� 
Background# �  5   
     MaterialDesignFont N� 
FontFamily# �  5   
    N� Title$ Акссусуары��5   	   $
��1355��6   $	��830��6*   .��5      � $��0,0,-0.286,0.647q�6   .+�5   
   � $��Center=�6   $��62��6-   $��	0,771,0,0q�69   $	��Top=�6L   $
��1355��6d    ) %MaterialDesignDarkSeparatorBackground#���  6q   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridDatabase��5        MaterialDesignDataGrid#��[ 5      $��
4,0,254,58q�5   #   #���  5         AutoGenerateColumns$ False��5         SelectionMode$ Single=�5         RowBackground �	#FFFBF7FF���	#1F606060 , (MaterialDesignDataGridRowHoverBackground	   AlternatingRowBackground#	 �  5      
 � Cursor$

 Hand��5       $��14(�6    � ContextMenu 5"      �� 5#      .@�5$      m� -   5        $��Удалить��5$      60   5%         Columns 5'      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$	 _Id� �� Mode$ OneWay=�6n     5)      $ Тип��64   $	 150 6p    6A   �� $ _Type�$ OneWay=�6p   0  *System.Windows.Controls.DataGridTextColumn  5*      $ Наименование��6%   $	 200 6j    6;   �� $ _Name�$ OneWay=�6j     5+      $ Цена��6%   $	 160 6c    63   �� $ _Price�$ OneWay=�6c     5,      $ Описание��6%   $ * 6m    67   �� $ _Discription�$ OneWay=�6m   5.      �� 50   
   -   5         ��Name$ button_Search��51      $��
Поиск��50         MaterialDesignFlatDarkButton#��[ 52      #���  53      $
��Left=�54      $��1223,785,0,0q�6,   $	��Top=�6B   $	��110��55      $

 Hand��6   $��34��6,   68   �� 57   
   -   5        $ 
button_Add��58      $��Добавить��57      #��[ 59      #���  5:      $
��Left=�5;      $��
32,785,0,0q�6,   $	��Top=�6@   $	��160��5<      $

 Hand��6   $��34��6,   68   �� 5>   
   -   5        $ button_AddAcessoryToCar��5?      $A��;Добавить аксессуар к автомобилю��5>      #��[ 5@      #���  5A      $
��Left=�5B      $��285,785,0,0q�6,   $	��Top=�6A   $	��282��5C      $

 Hand��6   $��34��6,   68   �� 5E   
   -   5        $ button_Update��5F      $	��↻��5E      #��[ 5G      $��25(�5H      #���  5I      $
��Left=�5J      $��
1050,0,0,0q�6,   $	��Top=�6@   $��51��5K      $

 Hand��6   $��36��6+   $��0,-2,0,0q�67     MaterialDesignBody#���  6J    J� RenderTransformOrigin$ 1.845,0.632&�6�   �� 5N   
   $Z��TУкажите один или несколько параметров поиска.��6   $
��Wrap=�6I   $��16(�6]   $
��Left=�6k   $��1131,547,0,0q�6�   $	��Top=�5O      $��56��6(   $	��224��64     PrimaryHueDarkBrush#���  6@   �� 5Q   
   $��Тип:��6   $��16(�6   $
��Left=�6-   $��1136,613,0,0q�6H   $	��Top=�6^   $��30��6v   $	��209��6�   #���  6�   �� 5R   
   -   5         ��Name$ TextBoxType��5S       	 MaterialDesignTextBox#��[	 5T      #���  5U      $
��Left=�5V      $��19(�6)   $��1136,643,0,0q�5W      $�� ��6#    �� TextWrapping$
 Wrap=�6+   $	��Top=�5X      $	��209��6%   $��1,1,1,1q�62   $��36��6L   $
 IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   �� 5Z   
   $��Наименование:��6   $��16(�6(   $
��Left=�66   $��1136,684,0,0q�6Q   $	��Top=�6g   $��30��6   $	��209��6�   #���  6�   �� 5[   
   -   5        $ TextBoxName��5\      #��[	 5]      #���  5^      $
��Left=�5_      $��19(�6)   $��1136,714,0,0q�5`      $�� ��6#   $
 Wrap=�6+   $	��Top=�5a      $	��209��6%   $��1,1,1,1q�62   $��36��6L   $
 IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   5c      5d      
   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:CarShowroomSystem.Window.PagesCarShowroomSystem.Window.Pages  5      ,    &CarShowroomSystem.Window.Pages.pageCar   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:CarShowroomSystem.Window.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Mamazing9http://schemas.microsoft.com/winfx/2006/xaml/presentation     6P    "  MaterialDesignFlatButtonRipple#���   5
      $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
      MaterialDesignToolBackground N� 
Background# �  5   
     MaterialDesignFont N� 
FontFamily# �  5   
    N� Title$ Автомобили��5   	   $
��1355��6   $	��830��6*   .��5      � $��0,0,-0.286,0.647q�6    � Cursor$ IBeam��6%   .+�5   
   � $��Center=�6   $��62��6-   $��	0,771,0,0q�69   $	��Top=�6L   $
��1355��6d    ) %MaterialDesignDarkSeparatorBackground#���  6q   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridDatabase��5        MaterialDesignDataGrid#��[ 5      $��
3,0,284,58q�5   #   #���  5         AutoGenerateColumns$ False��5         SelectionMode$ Single=�5       	   RowBackground	 �	#FFFBF7FF���	#1F606060 , (MaterialDesignDataGridRowHoverBackground
   AlternatingRowBackground#
 �  5!      $
 Hand��5"      $��14(�6    � ContextMenu 5$      �� 5%      .@�5&      m� -   5        $��Удалить��5&   8   �� 5'      m� 5(      -   5        $��Информация��5(   9   5)         Columns 5+      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$	 VIN��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 165 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$
 _Vin� �� Mode$ OneWay=�6o     5-      $  Производитель��64   $	 150 6�    6K   �� $ _manufacturer�$ OneWay=�6�   0  *System.Windows.Controls.DataGridTextColumn  5.      $ Модель��6%   $	 100 6e    65   �� $ _model�$ OneWay=�6e     5/      $ Комплектация��6%   $	 130 6o    6;   �� $ 
_equipment�$ OneWay=�6o     50      $ Дата выпуска��6%   $	 135 6q    6;   �� $ _releaseDate�$ OneWay=�6q     52      $ Тип привода��6%   $	 120 6j    6:   �� $ _drive�$ OneWay=�6j     53      $ Цвет��6%   $	 100 6c    63   �� $ _color�$ OneWay=�6c     54      $ Цена��6%   $ * 6c    63   �� $ _price�$ OneWay=�6c   56      �� 58   
   -   5         ��Name$ button_Update��59      $	��↻��58         MaterialDesignFlatDarkButton#��[ 5:      $��25(�5;      #���  5<      $
��Left=�5=      $��
1020,0,0,0q�6,   $	��Top=�6@   $��51��5>      $
 Hand��6   $��36��6+   $��0,-2,0,0q�67     MaterialDesignBody#���  6J   6|   �� 5B   
   $!��Производитель:��6   $��16(�6)   $
��Left=�67   $��1086,518,0,0q�6R   $	��Top=�5C      $��30��6(   $	��242��64     PrimaryHueDarkBrush#���  6@   �� 5E   
   -   5        $ button_Search��5F      $��
Поиск��5E      #��[ 5G      #���  5H      $
��Left=�5I      $��1223,788,0,0q�6,   $	��110��5J      $
 Hand��6   $��32��6+   $	��Top=�67   6O   �� 5L   
   $Z��TУкажите один или несколько параметров поиска.��6   $
��Wrap=�6I   $��16(�6]   $
��Left=�6k   $��
1086,0,0,0q�6�   $��Center=�5M      $��56��6+   $	��254��67   #���  6C   �� 5O   
   $��VIN автомобиля:��6   $��16(�6*   $
��Left=�68   $��1086,448,0,0q�6S   $	��Top=�6i   $��30��6�   $	��242��6�   #���  6�   �� 5P   
   -   5         ��Name$ 
TextBoxVIN��5Q       	 MaterialDesignTextBox#��[	 5R      #���  5S      $
��Left=�5T      $��19(�6)   $��1086,478,0,0q�5U      $�� ��6#    �� TextWrapping$
 Wrap=�6+   $	��Top=�5V      $	��254��6%   $��1,1,1,1q�62   $��36��6L   $ IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   �� 5X   
   -   5        $ TextBoxManufac��5Y      #��[	 5Z      #���  5[      $
��Left=�5\      $��19(�6)   $��1086,548,0,0q�5]      $�� ��6#   $
 Wrap=�6+   $	��Top=�5^      $	��254��6%   $��1,1,1,1q�62   $��36��6L   $ IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   �� 5`   
   $��Модель:��6   $��16(�6"   $
��Left=�60   $��1086,595,0,0q�6K   $	��Top=�5a      $��30��6(   $	��242��64   #���  6@   �� 5b   
   -   5        $ TextBoxModel��5c      #��[	 5d      #���  5e      $
��Left=�5f      $��19(�6)   $��1086,625,0,0q�5g      $�� ��6#   $
 Wrap=�6+   $	��Top=�5h      $	��254��6%   $��1,1,1,1q�62   $��36��6L   $ IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   �� 5j   
   $��Комплектация:��6   $��16(�6(   $
��Left=�66   $��1086,672,0,0q�6Q   $	��Top=�5k      $��30��6%   $	��242��61   #���  6=   �� 5l   
   -	   5        $ TextBoxEquipment��5m      #��[	 5n      #���  5o      $
��Left=�5p      $��19(�6)   $��1086,702,0,0q�5q      $�� ��6#   $
 Wrap=�6+   $	��Top=�5r      $	��254��6%   $��1,1,1,1q�62   $��36��6L   $ IBeam��6X   $��0,-4,0,4q�6g   $��Right=�6z   $��Center=�6�   �� 5w   
   -
   5        $ 
button_Add��5x      $��Добавить��5w      #��[ 5y      #���  5z      $
��Left=�5{      $��
32,785,0,0q�6,   $	��Top=�6@   $	��176��5|      $
 Hand��6   $��34��6,   68   5}      5~      
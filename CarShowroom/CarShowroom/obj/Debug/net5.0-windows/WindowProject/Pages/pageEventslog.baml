   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:CarShowroom.WindowProject.PagesCarShowroom.WindowProject.Pages  5      3    -CarShowroom.WindowProject.Pages.pageEventslog   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:CarShowroom.WindowProject.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	       "  MaterialDesignFlatButtonRipple#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
      MaterialDesignToolBackground N� 
Background# �  5   
     MaterialDesignFont N� 
FontFamily# �  5   
    N� Title$! Журнал событий��5   	   $
��1355��6!   $	��830��6.   .��5      � .+�5   
   � $��	0,0,0,768q�6    - )MaterialDesignTextFieldBoxHoverBackground#���  6"   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridDatabase��5        MaterialDesignDataGrid#��[ 5      $��
3,67,168,0q�5   #   #���  5         AutoGenerateColumns$ False��5          SelectionMode$ Single=�5!         MaterialDesignDarkForeground   RowBackground# �  6$   ���	#1F606060 , (MaterialDesignDataGridRowHoverBackground	   AlternatingRowBackground#	 �  5"      
 � Cursor$

 Hand��5#      $��14(�6      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Тип события��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ _type� �� Mode$ OneWay=�6i   1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5'      $ Дата��64   $	 100 6q    6B   �� $ _date�$ OneWay=�6q     5(      $ 
Время��64   $	 100 6r    6C   �� $ _time�$ OneWay=�6r     5)      $ Пользователь��6%   $	 230 6n    6;   �� $ 	_employee�$ OneWay=�6n     5*      $ Сообщение��6%   $ * 6h    68   �� $ _event�$ OneWay=�6h   5-      (  "System.Windows.Controls.DatePicker  5.   
   -   5          Name$ pickC��5.      $��18(�6$   $
��Left=�63   $��1222,90,0,0q�6N   $	��Top=�6c   $	��123��6{   $��30��6�     5/   
   -   5        $ pickPo��5/      $��18(�6%   $
��Left=�63   $��1222,125,0,0q�6N   $	��Top=�6d   $	��123��6|   $��30��6�   �� 50   
   -   5         ��Name$ Search��50      $��
поиск��6!   $
��Left=�61   $��1211,187,0,0q�6L   $	��Top=�6b   $	��134��6z      MaterialDesignChipBackground#���  6�   $��0,0,0,0q�6�     MaterialDesignCheckBoxOff#���  6�    J� RenderTransformOrigin$ 0.528,-1.606&�6  6:  �� 51   
   -   5         ��Name$ comboEmployee��51      $
��Left=�6*   $��
453,77,0,0q�6E   $	��Top=�6Y   $��19��6q   $��0,0,0,0q�6|   $��16��6�   $��0,4,5,4q�6�   $ 0.548,0.497&�6�   �� 52   
   -   5        $ comboTyp��52      $
��Left=�6%   $	��Top=�6@   $��19��6X   $��0,0,0,0q�6c   $��
103,77,0,0q�6}   $��16��6�   $��0,4,5,4q�6�   6�   �� 53   
   -   5        $
 drop��53      $��сбросить��6   $
��Left=�62   $��1211,231,0,0q�6M   $	��Top=�6c   $	��134��6{   #���  6�   $��0,0,0,0q�6�   #���  6�   $ 0.528,-1.606&�6  6;  �� 54   
   $��18(�6   $
��Left=�6"   $��1202,100,0,0q�6=   $	��с:��6S   $
��Wrap=�6]   $	��Top=�6q   $��20��6�   $��21��6�   �� 55   
   $��18(�6   $
��Left=�6"   $��1192,133,0,0q�6=   $��по:��6S   $
��Wrap=�6^   $	��Top=�6r   $��30��6�   $��21��6�   �� 57   
   -   5        $ button_Update��58      $	��↻��57        	 MaterialDesignFlatDarkButton#��[	 59      $��25(�5:      #���  5;      $
��Left=�5<      $��1136,67,0,0q�6,   $	��Top=�6A   $��51��5=      $

 Hand��6   $��36��6+   $��0,-2,0,0q�67    
 MaterialDesignBody#��� 
 6J   6|   �� 5>   
   $��Center=�6   $��18(�61   $��0,10,0,0q�6?   $����Здесь представлен журнал событий за последние сутки. Нажмите 'Поиск' для загрузки событий за другой промежуток времени, а также можно отфильтровать записи по пользователям и типу события нажав на стрелочку в таблице. Таблица обновляеться динамически.��6Q   $
��Wrap=�6S  $	��Top=�6g  $
��1335��6  $��52��6�     MaterialDesignTextAreaBorder#���  6�  5B      5C      
   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages.CarShowroom.WindowProject.Pages.WindowForPages  5   	   C    =CarShowroom.WindowProject.Pages.WindowForPages.AddAccessToCar   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5         "  MaterialDesignFlatButtonRipple#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
    # MaterialDesignToolBarBackground#���  5   
    � Title$ AcessoryAddToCar��5   	   $	��561��6"   $	��973��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � WindowStyle$
 None=�6w   .��5      � .+�5   
   �� $��Center=�6   
���   �$	��973��6@    J� RenderTransformOrigin$ 0.5,0.5&�6L   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.013Q�6$   �� 5      T� 5       T� X$ 0.063Q�6)   5      5      �� 5   
   $
��Left=�6   $	��299��6/     PrimaryHueMidBrush#���  6<   $	��Top=�6j   $	��602��6�   $��	7,252,0,0q�6�   �� 5   
   $��Center=�6   $	��208��61   #���  6>   $	��Top=�6l   $	��959��6�   $��0,32,0,0q�6�   �� 5!   
   -   5        	 ��Name$	 ButtonClose��5!         MaterialDesignFlatDarkButton#��[ 5"      $��×��5#      $
��Left=�6   $��27(�68   $��
947,-6,0,0q�6F   $	��Top=�5$      $��26��6)   $ 
-0.06,0.72&�65   $��27��5%      
 � Cursor$

 Hand��67     MaterialDesignBody#���  6E   ���	#FFBD3F3F$��0,0,0,0q�6�   �� 5'   
   -   5        $	 
button_Add��5(      $��Добавить��5'      #��[ 5)       ) %MaterialDesignDarkSeparatorBackground#���  5*      $
��Left=�5+      $��853,517,0,0q�6,   $	��Top=�6A   $	��110��5,      $

 Hand��6   $��34��6,   $ 
0.29,0.558&�68   6[   �� 5.   
   -   5        $	 button_Delete��5/      $��Очистить��5.      #��[ 50      #���  51      $
��Left=�52      $��625,517,0,0q�6,   $	��Top=�6A   $	��110��53      $

 Hand��6   $��34��6,   $ 
0.29,0.558&�68   6[   &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ DataGridAccess��55        MaterialDesignDataGrid#��[ 56      $

 Hand��57         AutoGenerateColumns$ False��58         SelectionMode$ Single=�59      $��9,255,366,18q�5:      #���  6)    � ContextMenu 5<      �� 5=      .@�5>      m� -   5        $��Добавить��5>   8   5?         Columns 5A      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Тип��64      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$ _type� �� Mode$ OneWay=�6p     5C      $ Наименование��64   $ * 6x    6J   �� $ _name�$ OneWay=�6x     5D      $ Цена за шт��64   $ * 6x    6H   �� $ _price�$ OneWay=�6x     5E      $ Описание��65   $ * 6u    6G   �� $ _opis�$ OneWay=�6u   5G        5J   
   -   5        $ DataGridCar��5J      #��[ 5K      $

 Hand��5L      $ False��5M      $ Single=�5N      $��
10,36,16,0q�5P      #���  6'   $	��201��6f   $	��Top=�6s    5Q      �� 5R      .@�5S      m� -   5        $��Добавить��5S   6   5T       5W        5X      $	 VIN��64   $ * 6o    6A   �� $
 _Vin�$ OneWay=�6o     5Y      $  Производитель��64   $ * 6�    6K   �� $ _manufacturer�$ OneWay=�6�   0  *System.Windows.Controls.DataGridTextColumn  5Z      $ Модель��6%   $ * 6e    65   �� $ _model�$ OneWay=�6e     5[      $ Комплектация��6%   $ * 6o    6;   �� $ 
_equipment�$ OneWay=�6o     5\      $ Дата выпуска��6%   $ * 6j    6;   �� $ _date�$ OneWay=�6j     5]      $ Цвет��6%   $ * 6c    63   �� $ _color�$ OneWay=�6c   5_      �� 5`   
   $
��Left=�6   $	��255��6/   $��626,252,0,0q�6<   ���	#FF305F6B$	��Top=�6d   $	��334��6|   �� 5b   
   -	   5         ��Name$ TextBlock_Car��5b      $��17(�6'   $
��Left=�65   $��629,255,0,0q�6P   $��Автомобиль��6e   $	��Top=�6z   $	��328��6�   $��25��6�   $
��Bold"�6�   #���  6�   $��Center=�6�   $��Center=�6  �� 5f   
   -
   5         ��Name$ listViewAcess��5f   !   $��12(�6   $	��330��68   $��629,282,14,56q�6D   $ 0.5,0.5&�6[   z�5g      V� 5h      .~�5i      �� �� 5j      $ -0.056Q�6$   �� 5k      T� 5l      $ -0.134Q�6)   5m       �� View 5o      �� 5p      .P�5q      ��  �� Width$ 90��6%   $��Тип��60    �� DisplayMemberBinding 6=   �� *_type+�� 5r      $	 148��6%   $��Наименование��61    6G   �� *_name+�� 5s      $ 95��6%   $��Цена��60    6>   �� *_price+5t      5v      �� 5y   
   -   5        $ 	label_suc��5y      $��17(�6   $.��(Аксессуары добавлены!��61   $
��Left=�6Q   $��625,336,0,0q�6l   $	��Top=�6�   $	��332��6�   ���	#DD0F57D4$��Center=�6�   $��Center=�6�   $y�Visible=�6  5{      5|      
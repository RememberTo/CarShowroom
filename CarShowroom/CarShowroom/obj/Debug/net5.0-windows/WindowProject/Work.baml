   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CarShowroomSystem.WindowCarShowroomSystem.Window  5   	   #    CarShowroomSystem.Window.Work   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CarShowroomSystem.Window     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
    "  MaterialDesignFlatButtonRipple#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
      MaterialDesignToolBackground#���  5   
     MaterialDesignFont#���  5   
    � Title$ CarShowroom��5   	   $��869.445��6   $��1549.714��6/    � WindowStyle$
 None=�6@    � 
ResizeMode$ NoResize=�5       � WindowState$ 	Maximized=�5      .��5      � $��0,0,-0.286,0.647q�6    � ColumnDefinitions 5   
   �� 5      $
��195* �6   �� 5      $��1354* �6    � RowDefinitions 5   
   �� 5      $	��38* �6   �� 5       $
��831* �6   .+�5#   
   �  # MaterialDesignToolBarBackground#���  6   $��1��6N   � 5$   
   $��2��6   $��	0,0,0,831q�6#   $��2��66    ) %MaterialDesignDarkSeparatorBackground#���  6G   �� 5'   
   -   5         ��Name$ ButtonClose��5'         MaterialDesignFlatDarkButton#��[ 5(      $��×��5)      $
��Left=�6   $��29(�68   $��1302,-3,0,0q�6F   $	��Top=�5*      $��53��6)   	 J� RenderTransformOrigin$	 
-0.06,0.72&�65   $��41��5+      $��1��6   
 � Cursor$

 Hand��6G     MaterialDesignBody#���  6U   ���	#FFBD3F3F$��2��6�   �� 5,   
   -   5        $ ButtonMinimaized��5,      #��[ 5-      $	��—��5.      $
��Left=�6   $��20(�68   $
��Bold"�6F   $��
1249,0,0,0q�5/      $��Center=�6%   $��53��6@   $	 0.839,1.596&�50      $��38��65   $��1��6A   $

 Hand��6p   #���  6~    � 52   
   -   5          �Name$ WorkTableFrame��52      $��	195,0,0,0q�53      $��1��6$     � NavigationUIVisibility$ Hidden=�61   $��2��6Q   '  !MaterialDesignThemes.Wpf.PopupBox  54   
   $��PopupBox��6"   $��Center=�65   $��36��6P   $��47��6\   ���	#DD040000 J� OpacityMask
 �   ����	#FFB3BFC1$��8,0,0,0q�6�   $	 0.5,0.5&�6�   ���	#FF364761$��0,0,0,0q�6�   z�55      V� 56      .~�57      ��  �� ScaleY$ 1Q�6%   �� 58      �� 59      T� 5:      5;         PopupContent. 5=      �� .+�5>      �� -   5        $��Аккаунт��5>   .   �� 5?      -   5        $!��Журнал событий��5?   3   �� 5@      -   5        $��
Выход��5@   0   5A      5B      �� 5J   
   -   5        $ 	ButtonCar��5J      #��[ 5K      $��Center=�5L      $��20(�6/   $
��Bold"�6=   $	��Top=�6O   $	��195��6g   $��1��6s   $��54��6�   $

 Hand��6�   .��5M      ��  �� Orientation$ 
Horizontal=�6   $	��173��62   .+�5N      �� $��Images\cars.png��6   $��29��63   $��30��6?   �� 5O      $��Автомобили��6     PrimaryHueDarkBrush#���  6.   $	��142��6a   5P      5Q      �� 5S   
   -   5        $ ButtonAccessory��5S      #��[ 5T      $��Center=�5U      $��20(�6+   $
��Bold"�69   $��0,54,0,0q�5V      $	��Top=�6#   $	��194��6;   $��1��6G   $��54��6T   $

 Hand��6`   .��5W      �� $ 
Horizontal=�6   $	��170��62   .+�5X      �� $��Images\acess.png��6   $��29��64   $��30��6@   �� 5Y      $��Аксессуары��6   #���  6.   $	��138��6a   5Z      5[      �� 5\   
   -	   5        $ ButtonBidCar��5\      #��[ 5]      $��Center=�5^      $��20(�6*   $
��Bold"�68   $��	0,162,0,0q�5_      $	��Top=�6$   $	��195��6<   $��1��6H   $��54��6U   $

 Hand��6a   .��5`      �� $ 
Horizontal=�6   $	��167��62   .+�5a      �� $��Images\bid.png��6   $��29��62   $��30��6>   �� 5b      $��Заявки��6   #���  6*   $	��131��6]   5c      5d      �� 5f   
   -
   5        $ ButtonEvent��5f      #��[ 5g      $!��Журнал событий��5h      $��Center=�6&   $��20(�6C   $
��Bold"�6Q   $��	0,715,0,0q�5i      $	��Top=�6$   $	��195��6<   $��1��6H   $��54��6U   $

 Hand��6a   6o   �� 5l   
   -   5        $ ButtonContract��5l      #��[ 5m      $��Center=�5n      $��20(�6+   $
��Bold"�69   $��	0,108,0,0q�5o      $	��Top=�6    $	��195��68   $��1��6D   $��54��6Q   $

 Hand��6]   .��5p      �� $ 
Horizontal=�6   $	��168��62   .+�5q      �� $��Images\contract.png��6   $��29��67   $��30��6C   �� 5r      $��Контракты��6   #���  6-   $	��129��6`   5s      5t      �� 5x   
   -   5         ��Name$ 	labelTime��5y      $��15(�5z      $
��Wrap=�5{      $
��Left=�5|      $��	8,774,0,0q�5}      $��1��6#   $	��Top=�60   $��52��6H   $	��187��6T     MaterialDesignTextBoxBorder#���  6`   �� 5~   
   -   5        $ label_fiouser��5      $��1��5~      $
��Left=�5�      $��
1058,4,0,0q�5�      $�� ��6(   $
��Wrap=�5�      $	��Top=�6(   $��32��6@   $	��191��6L   #���  6X   5�      5�      
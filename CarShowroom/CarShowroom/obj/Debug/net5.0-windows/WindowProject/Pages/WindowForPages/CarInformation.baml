   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:CarShowroom.WindowProject.Pages.WindowForElement0CarShowroom.WindowProject.Pages.WindowForElement  5   	   E    ?CarShowroom.WindowProject.Pages.WindowForElement.CarInformation   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Plocal>clr-namespace:CarShowroom.WindowProject.Pages.WindowForElement     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5         "  MaterialDesignFlatButtonRipple#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
    # MaterialDesignToolBarBackground#���  5   
    � Title$ Автомобиль��5   	   $	��506��6   $	��666��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � WindowStyle$
 None=�6q   .��5      � .+�5   
   �� $��Center=�6   $	��506��61   
���   �$��Center=�6M   $	��666��6h   �� 5   
   -   5         ��Name$ TextBlock_Name��5      $��25(�6(   $��Center=�66   $��0,10,0,0q�6S   $��sdasd��6e   $	��Top=�6v   $	��494��6�   $��35��6�     PrimaryHueDarkBrush#���  6�   $
��Bold"�6�   $��Center=�6�   $��Center=�6  �� 5   
   -   5         ��Name$	 img��5      $
��Left=�6   $	��243��69   $��	21,65,0,0q�6F   $	��Top=�6Y   $	��363��6q   �� 5   
   -   5         ��Name$ ButtonClose��5         MaterialDesignFlatDarkButton#��[ 5      $��×��5      $
��Left=�6   $��27(�68   $��
640,-6,0,0q�6F   $	��Top=�5      $��26��6)   	 J� RenderTransformOrigin$	 
-0.06,0.72&�65   $��27��5      
 � Cursor$

 Hand��67     MaterialDesignBody#���  6E   ���	#FFBD3F3F$��0,0,0,0q�6�   �� 5    
   -   5        $ labelImg��5       $��Изображение��6#   $
��Left=�69   $��	26,65,0,0q�6T   $	��Top=�6g   $	��238��6   $	��352��6�   $��Center=�6�   $��Center=�6�    ( $MaterialDesignTextAreaInactiveBorder#���  6�   �� 5!   
   -   5        $ ButtonSourceImage��5!      #��[ 5"      $	��...��5#      $
��Left=�6   $��20(�6:   $��
26,308,0,0q�6H   $	��Top=�5$      $��31��6)   $	 
-0.06,0.72&�65   $��16��5%      $

 Hand��6   #���  6+   $��	0,-11,0,0q�6^   6r   �� 5&   
   -   5         ��Name$ TextBlock_Vin��5)      $��17(�5&       �� 	MaxLength$ 17��5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 VIN��5(       % !MaterialDesignFloatingHintTextBox#��[ 67   $
��Left=�5)   )   $��
419,68,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��234��6�     MaterialDesignColumnHeader#���  6�   $��41��6�   $
 IBeam��6�   $��0,0,0,0q�6�   ${�False��6�   �� 5*   
   -   5        $ TextBlock_Fuel��5*       $��17(�6   $ Топливо��5+      #��[ 6;   $
��Left=�5,      $��419,150,0,0q�6-   $
 Wrap=�6C   $	��Top=�6W   $	��234��6o   #���  6{   $��0,0,0,0q�6�   $��41��6�   $	 0.504,0.577&�6�   ${�False��6�   �� 5-   
   -	   5        $ TextBlock_Drive��5-   !   $��17(�6   $ Тип привода��5.      #��[ 6?   $
��Left=�5/      $��419,109,0,0q�6-   $
 Wrap=�6C   $	��Top=�6W   $	��234��6o   #���  6{   $��41��6�   ${�False��6�   $��0,0,0,0q�6�   (  "System.Windows.Controls.DatePicker  51   
   -
   5          Name$ TextBlock_Date��51   #   $��17(�6   $ Дата выпуска��52       (	 $MaterialDesignFloatingHintDatePicker#��[	 6C   $
��Left=�53      $��419,191,0,0q�60      Text$ Дата выпуска: ��6E   $	��Top=�6[   $	��234��6s   #���  6   $��1,3,1,1q�6�   $��43��6�   ${�False��6�   $��0,2,0,4q�6�   �� 54   
   -   5        $ TextBlock_Color��54       $��17(�6   $ Цвет��55      #��[ 68   $
��Left=�56      $��419,232,0,0q�6-   $
 Wrap=�6C   $	��Top=�6W   $	��235��6o   #���  6{   $��0,0,0,0q�6�   $��41��6�   ${�False��6�   �� 57   
   -   5        $ TextBlock_Price��57       $��17(�6   $ Цена��58      #��[ 69   $
��Left=�59      $��419,273,0,0q�6-   $
 Wrap=�6C   $	��Top=�6W   $	��234��6o   #���  6{   $��0,0,0,0q�6�   $��41��6�   ${�False��6�   6�   �� 5:   
   -   5        $ TextBlock_Mileage��5:       $��17(�6   $ Пробег��5;      #��[ 5<      $
��Left=�5=      $��416,311,0,0q�6-   $
 Wrap=�6B   $	��Top=�6V   $	��237��6n   #���  6z   $��0,0,0,0q�6�   $��41��6�   ${�False��6�   $
 IBeam��6"  �� 5?   
   -   5        $ button_Edit��5@      $��Изменить��5?      #��[ 5A       )
 %MaterialDesignDarkSeparatorBackground#��� 
 5B      $
��Left=�5C      $��483,462,0,0q�6,   $	��Top=�6A   $	��173��5D      $

 Hand��6   $��34��6,   $	 
0.29,0.558&�68   6[   �� 5F   
   $��17(�6   $
��Left=�6   $��
21,314,0,0q�6:   $��Аксессуары��6N   $	��Top=�6d   $	��393��6|   $��35��6�   #���  6�   $��Normal"�6�   $��Center=�6�   $��Center=�6  $��Normal$�6(  �� 5H   
   -   5         ��Name$ listViewAcess��5H   !   $��12(�6   $��26,346,249,13q�68   $	 0.5,0.5&�6O   $��0,0,0,0q�6o    � UseLayoutRounding$ False��6�   $��45��6�   z�5I      V� 5J      .~�5K      �� �� 5L       �� AngleX$ -0.041Q�6$   �� 5M      T� 5N       T� X$ -0.134Q�6)   5O       � ContextMenu 5R      �� 5S      .@�5T      m� -   5        $E��?Удалить акксессуар для автомобиля��5T      6J   5U       �� View 5X      �� 5Y      .P�5Z      ��  �� Width$	 100��6%   $��Тип��61    �� DisplayMemberBinding 6>   �� *_type+�� 5[      $	 160��6%   $��Наименование��61    6G   �� *_name+�� 5\      $��Цена��6%    63   �� *_price+5]      5_        5`   
   $
��Left=�6   $��742,224,0,0q�60   $	��Top=�6E   �� 5a   
   $
��Left=�6   $��5��6/   $��416,231,0,0q�6:   #���  6O   $	��Top=�6�   $	��244��6�   #���  6�   �� 5c   
   -   5        $ 	label_suc��5c      $��17(�6   $(��"Изменения внесены!��61   $
��Left=�6N   $��420,357,0,0q�6i   $	��Top=�6~   $	��236��6�   ���	#DD0F57D4$��Center=�6�   $��Center=�6�   $y�Visible=�6�   5e      5g      
   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CarShowroomSystem.WindowCarShowroomSystem.Window  5   	   +    %CarShowroomSystem.Window.Registration   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CarShowroomSystem.Window     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
       "  MaterialDesignFlatButtonRipple#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
     MaterialDesignSelection#���  5   
    � Title$ Регистрация��5   	   $	��460��6   $	��530��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5      � $��0,0,0,-6q�6    � RowDefinitions 5   
   �� 5      .+�5   
   �� $��Images\employee.png��6   $��7,75,355,225q�6-    J� RenderTransformOrigin$ 0.474,0.556&�6C   �� 5   
   -   5         ��Name$ 	button_OK��5      $*��$Зарегистрироваться��5         MaterialDesignFlatDarkButton#��[ 5        PrimaryHueLightBrush#���  5      $
��Left=�5      $��166,378,0,0q�6,   $	��Top=�6A   $	��167��5      4  .System.Windows.Automation.AutomationProperties   Name$ buttonOK��6   	 � Cursor$
	 Hand��6B   $ 0.072,0.429&�6P     SecondaryHueMidBrush#���  6t   6�   �� 5   
   -   5        $ button_Close��5       $��Отмена��5      #��[ 5!      #���  5"      $
��Left=�5#      $��408,378,0,0q�6,   $	��Top=�6A   $��91��6Y   6d   �� 5$   
   -   5        
 ��Name$
 TextBox_Login��5%      $
��Left=�5&      $��
180,10,0,0q�5'      $��44��6"   $	��Top=�5(      $	��300��6%   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��5)       % !MaterialDesignFloatingHintTextBox#��[ 5*      $��15(�5+       �� 
CaretBrush �	#FF39505D  MaterialDesignBody#���  5-      #���  5.       �� SelectionBrush �	#FF8BB1CE$
	 Hand��6]   G� 50   
   -   5         G�Name$ TextBox_Password��51      $
��Left=�52      $��44��53      $��180,235,0,0q�6   $	��Top=�54      $	��300��6%   $ Пароль��55       ) %MaterialDesignFloatingHintPasswordBox#��[ 56      $��15(�57       G� 
CaretBrush �	#FF39505D#���  59      #���  5:      ���	#00000000 G� SelectionBrush �	#FF8BB1CE$
	 Hand��5;   ?   G� 5=   
   -   5        $ TextBox_RePassword��5>      $
��Left=�5?      $��44��5@      $��180,279,0,0q�6   $	��Top=�5A      $	��300��6%   $- 'Подтверждение пароля��5B      #��[ 5C      $��15(�5D       �	#FF39505D#���  5F      #���  5G      ���	#00000000 �	#FF8BB1CE$
	 Hand��5H   ?   �� 5J   
   -   5        $
 TextBox_Position��5K      $
��Left=�5L      $��
180,98,0,0q�5M      $��44��6#   $	��Top=�5N      $	��300��6%   $ Должность��5O      #��[ 5P      $��15(�5Q       �	#FF39505D#���  5S      #���  5T       �	#FF8BB1CE$
	 Hand��6]   �� 5V   
   -   5        $
 TextBox_Depart��5W      $
��Left=�5X      $��180,142,0,0q�5Y      $��44��6$   $	��Top=�5Z      $	��300��6%   $ 
Отдел��5[      #��[ 5\      $��15(�5]       �	#FF39505D#���  5_      #���  5`       �	#FF8BB1CE$
	 Hand��6]   �� 5b   
   -   5        $
 TextBox_Phone��5c      $
��Left=�5d      $��44��6*   $	��Top=�5e      $	��300��6%   $! Номер телефона��5f      #��[ 5g      $��15(�5h       �	#FF39505D#���  5j      #���  5k       �	#FF8BB1CE$
	 Hand��6]   $��180,186,0,0q�6k   6�   �� 5m   
   -	   5        $
 TextBox_FIO��5n      $
��Left=�5o      $��
180,54,0,0q�5p      $��44��6#   $	��Top=�5q      $	��300��6%   $ ФИО��5r      #��[ 5s      $��15(�5t       �	#FF39505D#���  5v      #���  5w       �	#FF8BB1CE$
	 Hand��6]   �� 5y   
   $
��Left=�6   $��1��6/   $��180,238,0,0q�6:    	 MaterialDesignDivider#��� 	 6O   $	��Top=�6�   $	��300��6�   $ 0.5,0.5&�6�     
 MaterialDesignDarkBackground#��� 
 6�   z�5z      V� 5{      .~�5|      ��  �� ScaleY$ -1Q�6%   �� 5}      �� 5~      T� 5      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarShowroomSystemCarShowroomSystem  5   	   %    CarShowroomSystem.Authorization   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CarShowroomSystem     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
       "  MaterialDesignFlatButtonRipple#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
     MaterialDesignSelection#���  5   
    � Title$ Авторизация��5   	   $	��341��6   $	��503��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5      � $��0,0,10,7q�6   .+�5   
   �� $��Images\car.png��6   $��3,49,324,136q�6(   �� 5   
   -   5         ��Name$ 	button_OK��5      $
��ОК��5         MaterialDesignFlatDarkButton#��[ 5        PrimaryHueLightBrush#���  5      $
��Left=�5      $��285,262,0,0q�6,   $	��Top=�6A   $��92��5      4  .System.Windows.Automation.AutomationProperties   Name$ buttonOK��6    � Cursor$
 Hand��6A   6O   �� 5   
   -   5        $ button_Close��5      $��Отмена��5      #��[ 5      #���  5      $
��Left=�5       $��391,262,0,0q�6,   $	��Top=�6A   $��91��6Y   6d   �� 5!   
   -   5        $ button_Registr��5"      $��Регистрация��5!       , (MaterialDesignDataGridRowHoverBackground#���  5#      $
��Left=�5$      $��
10,262,0,0q�6,   $	��Top=�6@   $	��115��6X   $
 Hand��6�     MaterialDesignTextBoxBorder#���  6�   ��6�   Z� �� 5%   
   -   5         ��Name$ TextBox_Login��5&      $
��Left=�5'      $��
173,49,0,0q�5(      $��44��6"   $	��Top=�5)      $	��298��6%   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Введите логин��5*       % !MaterialDesignFloatingHintTextBox#��[ 5+      $��15(�5,      
 �� 
CaretBrush
 �	#FF39505D  MaterialDesignBody#���  5.      #���  5/       �� SelectionBrush �	#FF8BB1CE$
 Hand��6]   .��50      51      G� 52   
   -   5         G�Name$ TextBox_Password��53      $
��Left=�54      $��44��55      $��173,111,0,0q�6   $	��Top=�56      $	��298��6%   $!	 Введите пароль��57       )	 %MaterialDesignFloatingHintPasswordBox#��[	 58      $��15(�59       G� 
CaretBrush �	#FF39505D#���  5;      #���  5<      ���	#00000000 G� SelectionBrush �	#FF8BB1CE$
 Hand��5=   ?   �� 5?   
   $��Images/AuthIco.jpg��6   $
��Left=�6,   $	��135��6G   $	��Top=�6T   $	��134��6l   $��0,41,0,0q�6x   �� 5@   
   -   5         ��Name$ LabelErrorAuth��5@      $�� ��6,   $
��Left=�64   $��
173,26,0,0q�6O   $
��Wrap=�6c   $	��Top=�6w   $	��298��6�   ���	#FFE61818$��18��6�   5A      5B      
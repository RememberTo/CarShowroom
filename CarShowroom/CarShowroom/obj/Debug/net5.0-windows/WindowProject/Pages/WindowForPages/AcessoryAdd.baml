   M S B A M L   `   `   `  ����F  BCarShowroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages.CarShowroom.WindowProject.Pages.WindowForPages  5   	   @    :CarShowroom.WindowProject.Pages.WindowForPages.AcessoryAdd   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:CarShowroom.WindowProject.Pages.WindowForPages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5         "  MaterialDesignFlatButtonRipple#���   5
   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont#���  5   
    # MaterialDesignToolBarBackground#���  5   
    � Title$ AcessoryAdd��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[    � WindowStyle$
 None=�6r   .��5      � .+�5   
   �� $��Center=�6   $	��450��61   
���   �$��Center=�6M   $	��800��6h   �� 5   
   -   5         ��Name$ ButtonClose��5         MaterialDesignFlatDarkButton#��[ 5      $��×��5      $
��Left=�6   $��27(�68   $��
774,-6,0,0q�6F   $	��Top=�5      $��26��6)    J� RenderTransformOrigin$ 
-0.06,0.72&�65   $��27��5       � Cursor$
 Hand��67     MaterialDesignBody#���  6E   ���	#FFBD3F3F$��0,0,0,0q�6�   �� 5   
   -   5        $ 
button_Add��5      $��Добавить��5      #��[ 5       ) %MaterialDesignDarkSeparatorBackground#���  5      $
��Left=�5       $��680,406,0,0q�6,   $	��Top=�6A   $	��110��5!      $
 Hand��6   $��34��6,   68   &   System.Windows.Controls.DataGrid  5"   
   -   5        	  Name$	 DataGridTypeAccess��5"        MaterialDesignDataGrid#��[ 5#      $
 Hand��5$      
   AutoGenerateColumns$
 False��5%         SelectionMode$ Single=�5&      $��48,98,479,26q�5'      #���  6)    � ContextMenu 5)      �� 5*      .@�5+      m� -   5        $��Добавить��5+   6   5,         Columns 5.      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��64      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ��  �� Path$	 _id� �� Mode$ OneWay=�6m     50      $! Тип аксессуара��64   $	 140 6y    6L   �� $
 _typ�$ OneWay=�6y   52      	� 53   
   -   5         	�Name$ 
Radio_Type��53      $��15(�6*   $2��,Добавить тип аксессуара��68   $
��Left=�6Z   $��	10,10,0,0q�6u   $	��Top=�6�   #���  6�   #���  6�   6  	� 54   
   -   5        $ 
Radio_Name��54      $��15(�6*   $)��#Добавить аксессуар��68   $
��Left=�6U   $��	10,35,0,0q�6p   $	��Top=�6�   #���  6�   #���  6�   6   �� 56   
   -   5         ��Name$ TextBox_type��57      $
��Left=�58      $��
400,98,0,0q�59      $��46��6"   $	��Top=�5:      $	��242��6%   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Тип аксессуара��5;       % !MaterialDesignFloatingHintTextBox#��[ 5<      $��15(�5=       �� 
CaretBrush �	#FF39505D#���  5?         MaterialDesignToolForeground#���  5@       �� SelectionBrush �	#FF8BB1CE$
 Hand��6e   $��5,4,0,4q�6s   �� 5C   
   -	   5        $ TextBox_Name��5D      $
��Left=�5E      $��400,144,0,0q�5F      $��46��6#   $	��Top=�5G      $	��242��6%   $+ %Название аксессуара��5H      #��[ 5I      $��15(�5J       �	#FF39505D#���  5L      #���  5M       �	#FF8BB1CE$
 Hand��6e   $��5,4,0,4q�6s   �� 5P   
   -
   5        $ TextBox_Price��5Q      $
��Left=�5R      $��400,190,0,0q�5S      $��46��6#   $	��Top=�5T      $	��242��6%   $ Цена��5U      #��[ 5V      $��15(�5W       �	#FF39505D#���  5Y      #���  5Z       �	#FF8BB1CE$
 Hand��6e   $��5,4,0,4q�6�   �� 5]   
   -   5        $ TextBox_Opis��5^      $
��Left=�5_       �� TextWrapping$
 Wrap=�5`      $��400,310,0,0q�5b      $��98��6#   $	��Top=�5c      $	��242��6%   $ Описание��5d      #��[ 5e      $��15(�5f       �	#FF39505D#���  5h      #���  5i       �	#FF8BB1CE$
 Hand��6e   $��1,1,1,1q�6s   $��5,4,0,4q�6�   �� 5k   
   -   5         ��Name$ 	label_suc��5k      $��17(�6   $&�� Предмет добавлен!��61   $
��Left=�6M   $��
400,71,0,0q�6h   $	��Top=�6|   $	��242��6�   ���	#DD0F57D4$��Center=�6�   $��Center=�6�   $y�Visible=�6�   5l      5m      
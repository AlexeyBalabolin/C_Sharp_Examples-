   M S B A M L   `   `   `  ����J  FTelegramBot_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TelegramBot_WPFTelegramBot_WPF  5   	        TelegramBot_WPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TelegramBot_WPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ logList��5
      $��0��5      $��Stretch=�5      $��5q�5      $��Stretch=�5      ��5      �� 5      .R�5      �� 
���   �$��5q�61   $��1q�6<    �� CornerRadius$ 10��6P   ._�5      �� $��10q�6%   .+�5      �� $��0q�6C   $��15(�6N   ��6(   �� *	FirstName+6N   �� 5      $��0q�6=   $��20(�6H   ��6(   �� *Msg+6H   �� 5      $
��10 0q�6>   $��10(�6L   
������� �� TextAlignment$ Right=�6l   ��6(   �� *Time+6l   5      5      5      5      �� 5   
   -   5         ��Name$ sendMessageBox��5      $��Send Message��6+   $
��Left=�6A   $	��399��6\   $��
415,10,0,0q�6i   $	��Top=�6}   $	��367��6�   $��18(�6�   .��5      �� $
��Left=�6   $	��379��64   $��0,10,-2,-21q�6A   $	��Top=�6V   $	��357��6n   .+�5      �� -   5         ��Name$ 
TargetSend��5      $y�	Collapsed=�5       $��5q�5!      ��5      ��  �� ElementName$ logList�� �� Path$ SelectedItem.Id�5!      �� 5"      -   5         ��Name$ msgSend��5"      $��80��6+   	 �� TextWrapping$
	 Wrap=�67   $�� ��6K   �� 5#      -   5        
 ��Name$
 button��5#      $
��Send��6)   $��35,10,35,20q�68   $��39��6M   $��22(�6Y   6g   �� 5$      -   5        $

 save��5$      $��Save messages��6'   $��35,10,35,20q�6?   $��39��6T   $��22(�6`   6n   5%      5&      5(      5)      
   M S B A M L   `   `   `  ����K  GUserInterfaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UserInterfaceWPF.BestellingUserInterfaceWPF.Bestelling  5   	   B    <UserInterfaceWPF.Bestelling.BestellingSelecteerTruitjeWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:UserInterfaceWPF.Bestelling     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$&  BestellingSelecteerTruitjeWindow��5   	   $	��450��62   $	��800��6?    � 	Resources 5       �� 
TargetType �� Property �� Value  HeaderStyle  BestuurderStyle  
InputStyle  DatePickerStyle(  "System.Windows.Controls.DatePicker  
ComboStyle  	cellStyle*  $System.Windows.Controls.DataGridCell �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers �� Value �� Binding �� RelativeSource �� 
TargetName 	 rowStyle)  #System.Windows.Controls.DataGridRow��%O  '��       '�� p     &	     &	 r    &	 Q    &	 �    &	 �    &	 /    &		 B    �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   5      �� 5   
   " ��6   .�5      ��  � ��$
 auto��6&   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 30(�6)   5      �� 5   
   " ��6$   .�5      ��  � ��$
 auto��6&   �� 5       � ��$ 10(�6)   5      �� 5    
   " ��6(   .�5!      ��  � ��$
 auto��6&   �� 5"       � ��
 �����6+   �� 5#       � ��
 �   �6+   �� 5$       � ��$	 135��6&   �� 5%       � ��$ 30��6'   5&      �� 5'   
   " ��6#   .�5(      ��  � ��
 �����6+   5)      �� 5*   
   "  6(   .�5+      ��  � ��
 �����6+   5,      �� 5-   
   " ��6#   .�5.      ��  � ��
 �����6+   5/      �� 50   
   "  6"   .�51      ��  � ��$ 0q�6(   �� 52       � ��$ 2q�6'   �� 53       � ��
 �   �6+   �� 54       � �� 55      �� 56      "  6&   .R�57      �� 
���   �$��0q�64   ._�58      �� $ border��6%   
�������$��2q�5:      
�������$	 5��5<      ._�5=   "   �� 5>      5?      
 5@      �� 5A      $
 true��6c    6*   ��  �� *Self+.a�5B   "   �� $ border��6)    � ��
 � ���6S   5C      5E      5G      5H      �� 5I   
   "  6!   .�5J      ��  � ��$ 0q�6(   �� 5K       � ��$ 0q�6'   �� 5L       � ��$ 0q�60   �� 5M       � ��
 �   �6+   5N      5O      .��5Q      �  J� RenderTransformOrigin$ 0.176,0.995&�6    � ColumnDefinitions 5R   
   �� 5S      $
��auto �6   �� 5T      $��* �6    � RowDefinitions 5V   
   �� 5W      $
��auto �6   �� 5X      $��* �6   .+�5\   
   � $��0��6   $��1��6   $��	0,0,0,145q�6,    5]      �� 5^      $
��auto �6#   �� 5_      $	��200 �6#   �� 5`      $
��auto �6#   �� 5a      $	��150 �6#   �� 5b      $��* �6#    5d      �� 5e      $
��auto �6    �� 5f      $
��auto �6    �� 5g      $
��auto �6    �� 5h      $
��auto �6    �� 5i      $
��auto �6    �� 5j      $
��auto �6    .+�5o      �� $��Voetbaltrui��6   $��Center=�6+   $��0��6H   $��0��6U   $��4��6e   $	��Top=�6y   $��25q�6�   �� 5p      -   5         ��Name$ lbl_Id��5p      #��[ 6$   $	��Id:��6J   $��Center=�6X   $��0��6s   $��1��6�   �� 5q      -   5        $ lbl_Competitie��5q      #��[ 6,   $��Center=�6Q   $��Competitie:��6l   $��0��6�   $��2��6�   �� 5r      -   5        $ lbl_Seizoen��5r      #��[ 6)   $��Center=�6N   $��Seizoen:��6i   $��0��6|   $��3��6�   �� 5s      -   5        $ lbl_Club��5s      #��[ 6&   $��Center=�6K   $��Club:��6f   $��0��6v   $��4��6�   �� 5t      -   5        $ 	lbl_Prijs��5t      #��[ 6'   $��Center=�6L   $��Prijs��6g   $��0��6w   $��5��6�   �� 5u      -   5        $ lbl_Maat��5u      #��[ 6&   $��Center=�6K   $
��Maat��6f   $��2��6u   $��1��6�   �� 5v      -   5        $ 
lbl_Versie��5v      #��[ 6(   $��Center=�6M   $��Versie��6h   $��2��6y   $��2��6�   �� 5w      -	   5        $ 	lbl_Thuis��5w      #��[ 6'   $��Center=�6L   $��Thuis��6g   $��2��6w   $��3��6�   �� 5x      -
   5        $ lbl_Uit��5x      #��[ 6%   $��Center=�6J   $	��Uit��6e   $��2��6s   $��4��6�   �� 5|      -   5         ��Name$ btn_TruiZoeken��5|   2   $��Trui zoeken��6J   $��4��6`   $��	10,5,10,7q�6p   $ 0.642,0.447&�6�   $��1��6�   �� 5}      -   5        $ 	btn_Reset��5}   -   $��Reset velden��6@   $��4��6W   $��2��6g   $��	10,7,10,2q�6t   �� 5�      -   5         ��Name$ txtbw_Id��5�      #��[ 6(   $��1��6L   $��1��5�      $��5q�6#   ${�False��6.   �� 5�      -   5         ��Name$ combobx_Competitie��5�      #��[ 63   $��1��5�      $��2��6'   $��5,0,5,5q�64    �� SelectedIndex$ 0��6E   $��22��5�   N   $��Bottom=�6Z   �� 5�      -   5        $ combobx_Club��5�      #��[ 6-   $��1��5�      $��4��6'   $��5q�64   $ 0��6?   �� 5�      -   5        $ combobx_Maat��5�      #��[ 6-   $��3��5�      $��1��6'   $��5q�64   $ 0��6?   5�      �� 5�      -   5        $ txtbw_Seizoen��5�      #��[ 6-   $��1��6Q   $��3��5�      $��5,0,5,5q�6#   $��20��64   $��Bottom=�6@   �� 5�      -   5        $ txtbw_Prijs��5�      #��[ 6+   $��1��6O   $��5��5�      $��5q�6#   	� 5�      -   5         	�Name$ 
rdio_Thuis��5�      $��Center=�6.   $��3��6K   $��3��5�      $��0,0,0,23q�6*   $��2��6<   $	��130��6M   	� 5�      -   5        $ rdio_UIT��5�      $��4��6,   $��3��69   $��2��6I   $��
10,0,205,0q�5�      �� 5�      -   5        $ txtbw_Versie��5�      #��[ 6,   $��3��6P   $��2��5�      $��5q�6#   �� 5�      -   5        $ btn_wachttlijst��5�   4   $��Zet me op de wachtlijst��6M   $��4��6o   $��3��6   $��10,16,10,20q�6�   $��2��6�   5�      �� 5�   
   -   5         ��Name$ 
lstVw_Trui��5�      
�������
�������$��5q�6R   $��1��6f   $��
0,259,0,10q�6v   $��2��6�    � ContextMenu 5�      �� 5�      .@�5�      m� -   5         m�Name$ btn_Selecteer��5�      $��	Selecteer��66   6I   m� 5�      -   5        $ 
btn_Update��5�      $��Update��63   6C   5�      5�      5�      5�      
   M S B A M L   `   `   `  ����K  GUserInterfaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:UserInterfaceWPFUserInterfaceWPF  5   	   (    "UserInterfaceWPF.KlantUpdateWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:UserInterfaceWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ KlantUpdateWindow��5   	   $	��450��6#   $	��800��60    � 	Resources 5        
InputStyle �� 
TargetType �� Property �� Value  OldElementStyle  
ComboStyle  
TitelStyle��%�  &	       &	 J     &	 �     &	 �     �� 5   
   " ��6#   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6(   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6#   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6#   .�5      ��  � ��$ Verdana)�6+   �� 5       � ��$ 
ExtraBlack"�6+   �� 5       � ��$ 34(�6)   5      5       .��5!      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $��* �6    � ColumnDefinitions 5*   
   �� 5+      $��* �6   �� 5,      $
��auto �6   �� 5-      $��* �6   �� 5.      $��* �6   �� 5/      $��* �6   .+�53   
   �� -   5        	 ��Name$	 lbl_Naam��53      $��0��6"   $��2��62   $�� Nieuwe Naam��54      $��Center=�55      $��
0,15,0,100q�56      �� 58   
   -   5        $	 Adres��58      $��0��6   $��2��6/   $��Nieuw Adres��59      $��Center=�6&   $��	0,89,0,23q�6J   �� 5<   
   -   5        $	 
NaamHuidig��5<      $��3��6$   $��2��64   $��Huidige naam��5=      $��Center=�6'   $��29��5>      $	��Top=�6   $��0,14,0,0q�64   �� 5A   
   -   5        $	 AdresHuidig��5A      $��3��6%   $��2��65   $��Huidig Adres��5B      $��Center=�6'   $��5,91,195,23q�5C      $��2��6%   �� 5E   
   -   5        $	 
GiantTitel��5E      $��0��6$   $��1��64   #��[ 5F      $��Center=�64   $��5��6X   $��	0,0,0,144q�6l   $��2��6   .��5G      �� -   5        
 ��Name$
 button_reset��5G      $��44��6+   $	��145��67   $��Reset��5H      6%   5I      �� 5N   
   -   5         ��Name$ txt_Naam��5N      #��[ 6$   $��2��5O      $��2��6$   $��0,14,10,100q�61   5P      �� 5S   
   -   5        $ 	txt_Adres��5S      #��[ 6%   $��2��5T      $��2��6"   $��
0,88,10,25q�6/   6C   �� 5W   
   -	   5        $ txt_NaamHuidig��5W      #��[ 6*   $��4��5X      $��2��6"   $��29��6/   $	��Top=�5Y      ${�False��6*   $��	0,14,20,0q�6<   �� 5[   
   -
   5        $ txt_AdresHuidig��5[      #��[ 5\      $��4��5]      $��2��6"   $��29��6/   $	��Top=�5^      ${�False��6*   $��	0,88,20,0q�6<   �� 5c   
   -   5        $��UpdateWindow��5d      $��3��5c      $��Update klant��6   $��	0,109,0,4q�5d   %   $��5��68   $
{�True��5e      6"   �� 5h   
   -   5        $	 Id_Nieuw��5h      $��1��6"   $��Id��5i      $��Center=�6   $��29��5j      $	��Top=�6   $��-10,90,10,0q�61   �� 5m   
   -   5        $	 	Id_Hudiig��5m      $��1��6#   $��Id��5n      $��Center=�6   $��29��5o      $	��Top=�5p      $��190,90,10,0q�5q      $��2��5r      $��2��5s      �� 5v   
   -   5        $ txt_NaamNieuw��5v      #��[ 6)   $��1��6M   $��195,90,15,25q�6Z   ${�False��5x      $��3��6   �� 5z   
   -   5        $ txt_NaamHuidig_Copy��5z      #��[ 6/   $��4��5{      $��1��6   $��29��6*   $	��Top=�5|      ${�False��5}      $��	0,90,20,0q�6#   5�      5�      
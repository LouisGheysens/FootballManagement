   M S B A M L   `   `   `  ����K  GUserInterfaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UserInterfaceWPF.BestellingUserInterfaceWPF.Bestelling  5   	   8    2UserInterfaceWPF.Bestelling.BestellingUpdateWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:UserInterfaceWPF.Bestelling     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ BestellingUpdateWindow��5   	   $	��450��6(   $	��800��65   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5!      �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    .+�5'      �� $��Klant��6   �� 5(      -   5         ��Name$ 	txt_klant��5(       �� 
IsReadOnly$
 True��6)   $��1��5)      $��2��5*      �� 5,      -   5         ��Name$ btn_SelecteerKlant��5,      $��Selecteer Klant��5-      $��3��5/      $��10,-5,-10,5q�6%   �� 51      $��Prijs��6   $��1��6%   �� 52      -   5        $ 	txt_Prijs��52      $
 True��6)   $��1��53      $��1��6#   54      �� 55      -   5         ��Name$ chkbx_betaald��55      $��1��56      $��2��6$   �� 57      -   5        $ btn_SelecteerTruitje��57      $��Selecteer truitje��58      $��1��5:      $��3��5;      $��10,5,-10,-5q�6%   5<      &   System.Windows.Controls.DataGrid  5=   
   -   5        $��DataGridTruitjes��5=   D   $��2��6\   $��	0,80,0,10q�6i   	   AutoGenerateColumns$	 False��6|   
   Columns
 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Truitje��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Truitje+ �� Mode$ OneWay=�  5@      $ Aantal��6%    65   �� *Aantal+$ TwoWay=� � 	Resources 5B        ContextMenu � DataContext �� RelativeSource��%�   &	       �� 5C       62   �� *PlacementTarget.DataContext+ �� *Self+.@�5D      m� $��DeleteVoetbaltruitje��6   -   5        $��Verwijderen��5D   ;   6P   5E      5F         RowStyle 5G      �� 5H       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5I      ��  �� Property �@�ContextMenu �� Value# [ 64   5J      5L      �� 5M   
   -	   5        $ btn_updateOrder��5M      $��3��5N      $��10q�6"   .��5O      ��  �� Orientation$ 
Horizontal=�6   .+�5P      �� -
   5        $ txtbx_Update��5P      $��Bestelling updaten��60   $	��123��6J   5Q      5R      5S      5T      
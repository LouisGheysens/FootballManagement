   M S B A M L   `   `   `  ����K  GUserInterfaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UserInterfaceWPF.BestellingUserInterfaceWPF.Bestelling  5   	   6    0UserInterfaceWPF.Bestelling.BestellingZoekWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:UserInterfaceWPF.Bestelling     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ BestellingZoekWindow��5   	   $	��450��6&   $	��800��63   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#    5       �� 5!      �� 5"      �� 5#      $
��auto �6    .+�5'      �� $��Id��6   �� 5(      -   5         ��Name$ txt_id��5(      $��1��6&   �� 5*      $��
StartDatum��6   $��2��6*   (  "System.Windows.Controls.DatePicker  5+      -   5        $��dtpickr_startdatum��5+      $��3��63   �� 5-      $��	EindDatum��6   $��4��6)     5.      -   5        $��dtpickr_einddatum��5.      $��5��62   �� 50      -   5         ��Name$ btn_zoekBestelling��50      $��6��52      $��2��53      $��Right=�54      $
��Zoek��55      �� 57      $��Klant��6   $��1��6%   �� 58      -   5        $ txtbx_Klant��58      $��1��59      $��1��5:       �� 
IsReadOnly$
 True��5;      $��0,0,0,16q�5<   2   $��2��6D   �� 5>      -   5        $ btn_selectKlant��5>      $��Selecteer Klant��5?      $��2��5@      $��3��6"   $��14,37,0,-37q�66   $��4��6K   5A      �� 5C      -   5        $ 	btn_Reset��5C      $��6��5E      $��2��5F      $��Center=�5G      $��Reset��5H      $��
0,74,0,-74q�6!   5I      �� 5K   
   -   5         ��Name$ lstvw_Bestellingen��5K      $��1��6f   $��	0,109,0,0q�6s   	 � 	Resources	 5L        ItemMenu
 m� Command �� Path �� RelativeSource �� Mode �� AncestorType��%f  &	       �� 5M      .@�5N      m� $��DeleteVoetbaltruitje��6   -	   5        $��Verwijderen��5N   ;   
 6s   �� $ DataContext.MoreInfo� �� $ FindAncestor=� ListViewm� 5O      $��UpdateVoetbaltruitje��6   $��	Aanpassen��6;   
 5P      �� $ DataContext.MoreInfo� �� $ FindAncestor=� ListView5R      5S      5T      5U      5V      
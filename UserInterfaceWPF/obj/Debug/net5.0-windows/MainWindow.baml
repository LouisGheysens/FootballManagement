   M S B A M L   `   `   `  ����K  GUserInterfaceWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:UserInterfaceWPFUserInterfaceWPF  5   	   !    UserInterfaceWPF.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:UserInterfaceWPF     5   	   <controls'using:Microsoft.Toolkit.Uwp.UI.Controls     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 60Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 60Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ btn_OpenMenu��66   .[�5      �� #��[  6   5      :� 5!   
   $ ButtonBase.Click��6   $ btn_CloseMenu��66   .[�5"      �� #��[ 6   5#      .��5'      � 
�������	 � ColumnDefinitions	 5(   
   �� 5)      $	��17* �6   �� 5*      $��3* �6   
 � RowDefinitions
 5,   
   �� 5-      $
��179* �6   �� 5.      $
��255* �6   .+�50   
   � $��84��6   $	��Top=�6   $��2��63   .+�51      �� -   5         ��Name$ 	textBlock��51      $��Center=�6+   $��0,24,0,0q�6H   $
��Wrap=�6Z   $	��Top=�6n   $��60��6�   $	��320��6�   �� 6�    � Language$ nl-be�6�   $�Voetbaltruitje��6�   ��52      �� 53      .�54      ��  �� Property � �� �� Value$ 45(�6?   55      57      �� 58      $��Center=�6    �� Orientation$ 
Horizontal=�64   $��Right=�6M   .+�59      �� $��Louis Gheysens��6   $��Center=�62   $��18(�6M   '  !MaterialDesignThemes.Wpf.PopupBox  5:      $��10q�6*      PlacementMode$ BottomAndAlignRightEdges=�66      	StaysOpen$ False��6_      PopupContent. 5;      �� $	��150��6!   .+�5<      �� -   5        $��Instellingen��5<   !   68   �� 5=      -   5        $��Meer informatie��5=   !   6;   �� 5>      -   5        $��Ontwikkelaar��5>   !   68   �� 5?      �� 5@      -   5         ��Name$ btn_CloseAppMainWindow��5@   !   $��Sluit af��6A   6T   5A      5B      5C      5D      �� 5E   
    �� BitmapScalingMode$ HighQuality=�6   $��245,131,48,31q�6>   $��2��6U   ��5F      �� 5G       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /Media/VoetbalJongen.png?�65   5I      � 5J   
   -   5         �Name$ GridMenu��5J      $��50��6!   $
��Left=�6,     PrimaryHueDarkBrush#���  6G   $��2��6z   .+�5K      �� .+�5L      � $	��150��6   
�������.+�5M      �� -   5        $ btn_CloseMenu��5M      $��60��64   $��60��6?   $	��Top=�6x   $��Right=�6�   $y�	Collapsed=�6�   ��6K   Z� ��6a   Z� .��5N      '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FF1B3861   Kind$ 	ArrowLeft=�6I   $��25��6Z   $��25��6e   5O      �� 5Q      -   5        $ btn_OpenMenu��5Q      $��60��63   $��60��6>   $	��Top=�6w   $��Right=�6�   ��6J   Z� ��6`   Z� .��5R        ���	#FF1B3861$
 Menu=�6I   $��25��6U   $��25��6`   5S      5T      �� 5U      $��Disabled=�6   ���	#FF1B3861.@�5V      �� $��60��6#   .��5W      �� $ 
Horizontal=�6%   .+�5X        -	   5        $ Person=�5X   6   $��25��6D   $��25��6O   $��10q�6[   $��Center=�6g   6�   �� 5Y      $��Klant��6(   $��Center=�65   $��20 10q�6P   5Z      5[      �� 5\      $��60��6#   .��5]      �� $ 
Horizontal=�6%   .+�5^        -
   5        $ ClothesHanger=�5^   6   $��25��6K   $��25��6V   $��10q�6c   $��Center=�6o   6�   �� 5_      $
��Trui��6(   $��Center=�64   $��20 10q�6O   5`      5a      �� 5b      $��60��6#   .��5c      �� $ 
Horizontal=�6%   .+�5d        -   5        $ 
BagCarryOn=�5d   6   $��25��6H   $��25��6S   $��10q�6`   $��Center=�6l   6�   �� 5e      $��
Bestelling��6(   $��Center=�6:   $��20 10q�6U   5f      5g      5h      5i      5j      5k      5l      
   M S B A M L   `   `   `  ����A  =MiniTC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MiniTCMiniTC  5   	   3clr-namespace:MiniTC.ViewModelMiniTC.ViewModel  5   	       MiniTC.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MiniTC     5   	   -vmclr-namespace:MiniTC.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��800��6   $
��1200��6)    � 	Resources 5
         MiniTC.ViewModel.ViewModel   	Presenter��%   &	          5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$       � RowDefinitions 5&   
   �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      �� 55      �� 56      �� 57      �� 58      �� 59      �� 5:      �� 5;      �� 5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A      �� 5B      �� 5C      �� 5D      �� 5E      .+�5G   
      MiniTC.PanelTC  $��1��5M      $��1��6   $��9��6*   $��26��6>      
DrivesList	 5H      �� *CopyDriveList+
   Path 5I      �� *
CopyPath+ �� Mode$ TwoWay=�   
ComboIndex 5J      �� *CopyComboIndex+$ TwoWay=�	   	FilesList		 5K      �� *CopyFilesList+

   	ListIndex
 5L      �� *CopyListIndex+$ TwoWay=�5M   >     5N   
   $��1��5T      $��11��6   $��9��6+   $��26��6?   	 5O      �� *PasteDriveList+
 5P      �� *	PastePath+$ TwoWay=� 5Q      �� *PasteComboIndex+$ TwoWay=�		 5R      �� *PasteFilesList+

 5S      �� *PasteListIndex+$ TwoWay=�5T   ?   �� 5U   
   $��27��6.   $��9��6<   $��2��6L   $��3��6]   $��Copy >>>��6q   ��6   �� *
CopyFile+6q   5V      5W      
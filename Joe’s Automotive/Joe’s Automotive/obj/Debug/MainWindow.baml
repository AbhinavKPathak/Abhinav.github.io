   M S B A M L   `   `   `  ����  Joe’s Automotive!    Joe_s_Automotive.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Joe's Automotive��5
   	   $	��650��6"   $	��600��6/   .��5      ��  �� Padding$ 20q�6   ._�5   
   � 
������� � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��4* �6    �� 5      $��1* �6    �� 5      $��2* �6    .+�5      �� $��3,3,3,3q�6   
���   �$��0��6C   ._�5      �� $��Joe's Automotive��6   $��Arial)�63   $��40(�6F   $��Center=�6T   $��Center=�6x   
���  ��6�   5      �� 5      $��3,0,3,0q�6   
���   �$ 10q�6C   $��1��6P   ._�5      �  � ColumnDefinitions 5      �� 5      $
��1.5* �6+   �� 5      $��3* �6+   .+�5      �� $��0��6   ��5       �� 5!      .��6$   Select Services65   .��5#      �� $��0��6%    � 	Resources 5$       �� 
TargetType �� Property	 �� Value��%X   '��       �� 5%   "   " ��6(   .�5&   &   ��  � ��$	 0,18,0,0q�6?   5'   #   5(      .+�5)      �� -   5        
 ��Name$
 OilCheck��5)   '   $��
Oil Change��69    d� 	IsChecked 6N   �� *	OilChange+ �� Mode$ TwoWay=��� 5*      -   5        $
 LubeJob��5*   '   $��Lube Job��68    6K   �� *	LubeJob+$ TwoWay=��� 5+      -   5        $
 RadiatorFlush��5+   '   $��Radiator Flush��6>    6W   �� *RadiatorFlush+$ TwoWay=��� 5,      -   5        $
 TransmissionFlush��5,   '   $��Transmission Flush��6B    6_   �� *TransmissionFlush+$ TwoWay=��� 5-      -   5        $
 
Inspection��5-   '   $��
Inspection��6;    6P   �� *
Inspection+$ TwoWay=��� 5.      -   5        $
 MufflerReplacement��5.   '   $��Muffler Replacement��6C    6a   �� *MufflerReplacement+$ TwoWay=��� 5/      -   5        $
 TireRotation��5/   '   $��Tire Rotation��6=    6U   �� *TireRotation+$ TwoWay=�50      51      �� 53      $��1��6   ��54      �� 55      .��6$   Other Services64   .��58      �� $��Center=�6%    59      ��%X   '��       �� 5:   "   " ��6(   .�5;   &   ��  � ��$	 0,10,0,0q�6?   5<   #   5=      .+�5>      ��  �� Orientation$ 
Horizontal=�6)   .+�5?   "   �� $��0,0,25,0q�6(   .��6:   Parts Charges :6K   �� 5@   "   -   5         ��Name$ PartsCharge��5@   *   $��Center=�6?   $	��150��6Z    �� TextAlignment$ Right=�6f   ��6�   �� *PartsCharges+$ TwoWay=�6  5A      �� 5B      $ 
Horizontal=�6)   .+�5C   "   �� $��0,0,25,0q�6(   .��6:   Labor (Hours) :6K   �� 5D   "   -	   5        $ LabourHours��5D   *   $��Center=�6?   $	��150��6Z   $ Right=�6f   ��6�   �� *LaborCharges+$ TwoWay=�6  5E      �� 5F      $	��300��6(   $��0,10,0,0q�64   
���  �� J� SnapsToDevicePixels . $��10��6s   �� 5G      $ 
Horizontal=�6)   .+�5H   "   �� $��15(�6)   $��Sub Total : ��67   �� 5I   "   -
   5         ��Name$ SubTotalAmount��5I   7   $��15(�6)   $��Right=�6O   $	��200��6r   5J      �� 5K      $ 
Horizontal=�6)   .+�5L   "   �� $��15(�6)   $��+       Tax : ��67   �� 5M   "   -   5        $ 	TaxAmount��5M   7   $��15(�6)   $��Right=�6J   $	��200��6m   5N      �� 5O      $	��300��6(   
���  �� . $��10��6a   �� 5P      $ 
Horizontal=�6)   .+�5Q   "   �� $��20(�6)   $��   Total : ��67   �� 5R   "   -   5        $ TotalAmount��5R   7   $��20(�6)   $��Right=�6L   $	��200��6o   5S      5T      5U      5W      5X      �� 5Y      $��2��6    �� CornerRadius$ 2��6"   $��3q�63   
���   �$ 5q�6[   $
��Left=�6g   ._�5Z      �� $ 
Horizontal=�6   .+�5[      �� -   5         ��Name$ CalculateTotal��5[      
�����_�$	��240��6L   $��0,0,50,0q�6X   .��5\      �� $��Calculate Bill��6    
�������69   5]      �� 5^      -   5        $ Clear��5^      
�����_�$	��250��6C   .��5_      �� $��Clear��6    
�������60   5`      5a      5b      �� 5d      $��3,0,3,3q�6   
���   �$��3��6D   $ 10q�6Q   ._�5e      �� -   5         ��Name$ BillList��5e      
������� �� ItemStringFormat$  ��6?   $��Disabled=�6S   5f      5g      5h      5i      
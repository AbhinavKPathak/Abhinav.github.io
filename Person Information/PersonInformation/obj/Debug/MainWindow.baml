   M S B A M L   `   `   `  ����F  BAddressBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AddressBookAddressBook  5   	       AddressBook.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AddressBook     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��600��6   $	��415��6)    � 	Resources 5      (   "AddressBook.StringToImageConverter  StringToImageConverter��%   &	         5   
   6'   5      .��5      �� $	��600��6   $	��400��6    5   
    �� Source�� 5      $l fpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToggleButton.xaml?�6!   %    .+�5   
   �� -   5         ��Name$ MainWindowClose��5       K� ZIndex$ 2��6*   $
��Left=�6;   $��40��6]   	 �� Left$		 350��6h   $��0q�6z   

 �� Top$
 4��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   $��20��63   $��-7 0 0 0q�6>   5      #  MaterialDesignThemes.Wpf.Card  5   
   $��10q�6   ���#F44336$	��400��6@   $	��100��6L   $
 0��6Y   .��5       ��    MaterialDesignTitleTextBlock#���  6   
�������$��35(�6f   $��Bottom=�6t   $
��Left=�6�   Person Information6�   5!        5#   
   ���	#00000000$	��400��65   $	
 520��6A   $ 1��6R   .��5$      �� -   5        $ 	AddPerson��5$        RoundedButtonStyle#���  6(   $��50��6V   $��50��6b   $��0 0 20 0q�6m   $��Right=�6   $��1q�6�   .��5%        $
 Plus=�6*   $��25��66   $��25��6B   ���#F443366M   5&      5'        5)   
   $	��500��6   $	��410��6+   ���#FFEBEE$	
 100��6L   .��5*      �� -   5        $��
PersonList��5*      
������ $��0 0 -5 0q�6�   ��6(   �� *PersonsList+ �� SelectedItem 6L   �� *SelectedPerson+��5+      �� 5,      .R�5-        $	��400��6.   $��	-4 0 0 -2q�6:   $��10q�6M   .��5.      ��  �� Orientation$ 
Horizontal=�6)   .+�5/   "   d� $��0 0 10 0q�6/    $  MaterialDesignActionToggleButton#��[ 6A   $��50��6{   $��50��6�   .��50   &   �� ��6,   ��  �� Path$ Image� �� 	Converter# [ 6   51   #   �� 52   "   ��53   &   `� 54   *    �� StringFormat$ {0}
{1}��67   .1�55   .   �� $
 Name�66   �� 56   .   $ PhoneNumber�66   57   +   59   #   5:      5;      5<      ��5>      �� 5?       �� 
TargetType" ��6   .�5@      ��  �� Property � �� �� Value$ 18(�65    �� Triggers 5A      P� 5B       P� Property �@J�IsMouseOver P� Value . . �5C   "   ��  � �� �#F443366G   �� 5D   "    � �� �#FFEBEE6G   5E      5G      5I      5J      5M      5N      
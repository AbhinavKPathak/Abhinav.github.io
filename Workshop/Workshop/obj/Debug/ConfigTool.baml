   M S B A M L   `   `   `  ����C  ?Workshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WorkshopWorkshop  5
   	       Workshop.ConfigTool   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   (localclr-namespace:Workshop     5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5   	    � Title$ 
ConfigTool��5   	   $	��800��6   $	��600��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ ConfigJsonSave��5   5      
SaveToJson#��[  6   $��1��6M   $��2��6]   $
��Save��6j   $��Center=�6y   $��Center=�6�   $��90��6�   $��30��6�   6�   &   System.Windows.Controls.DataGrid  5   
     ConfigToolData#��[ 6   $��0��6]   $��1��6m   $
��Auto��6z      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      MaxColumnWidth$	 190Q�6�   ��6;   �� *	Workshops+6�     5   
   #��[ 6   $��1��6\   $��1��6l   $
��Auto��6y   $ * 6�   $	 190Q�6�   ��6;   �� *
Location+6�   �� 5   
     LabelDesignDataGrid#��[ 6   $��0��6=   $��0��6M   $��Workshop��6Z   $��Center=�6m   $��30��6�   $��Center=�6�   $��90��6�   �� 5   
   #��[ 6   $��1��6=   $��0��6M   $��Location��6Z   $��Center=�6m   $��30��6�   $��Center=�6�   $��90��6�   5      5      
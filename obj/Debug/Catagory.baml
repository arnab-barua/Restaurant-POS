   M S B A M L   `   `   `  ����L  HRestaurentMngment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RestaurentMngmentRestaurentMngment  5   	        RestaurentMngment.Catagory   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RestaurentMngment     5   	     � Title$  Catagory��5   	   ���#282828 � WindowStyle$
 None=�5	       � WindowState$ 	Maximized=�61   .��5
      � $��
20,0,20,20q�6   .+�5   
   �� $(��"Main Menu > Manage > Food Catagory��6   $
��Bold"�6=   ���#AB82FF$��16(�6d   $��Center=�6r   $	��Top=�6�   � 5   
   $��0,25,0,0q�6   ���#E8E8E8 � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grdCatagory��5      $��2��6*   $��5��6?      AutoGenerateColumns .     CanUserAddRows .     AlternatingRowBackground �#f5f5f5   CanUserReorderColumns .  	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Catagory ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *Cat_Id+  5       $ Catagory Name��6)   $	 500 6@    6L   �� *
Cat_Name+5"      � 5$      
���2͚�$��2��6,   $��4��6<   .+�5%      �� $��Catagory Id��6   $
��Left=�6.   $��	10,63,0,0q�6I   $	��Top=�6\   �� 5&      -   5         ��Name$ CatagoryIdTxt��5&      {�.  $
��Left=�6C   $��23��6^   $��103,66,-159,0q�6j    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��289��6�   �� 5'      $��Catagory Name��6   $
��Left=�60   $��	10,94,0,0q�6K   $	��Top=�6^   �� 5(      -   5        $ CatagoryNameTxt��5(      $
��Left=�63   $��23��6N   $��103,97,-159,0q�6Z   $
 Wrap=�6q   $	��Top=�6�   $	��289��6�   �� 5)      -   5         ��Name$ Create��5)      $��Create��6)   $
��Left=�6:   $��
10,176,0,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 5*      -   5        $ Update��5*      $��Update��6)   $
��Left=�6:   $��114,176,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5+      -   5        $ Delete��5+      $��Delete��6)   $��219,176,-54,0q�6:   $	��Top=�6Q   $
��Left=�6~   $��75��6�   5,      �� 5.      -   5        $
��back��5.      $
��Back��6!   ���#8B4513$��40(�6E   $
��Bold"�6S   $��2��6e   $��4��6u   6�   5/      50      51      
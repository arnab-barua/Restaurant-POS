   M S B A M L   `   `   `  ����L  HRestaurentMngment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RestaurentMngmentRestaurentMngment  5   	       RestaurentMngment.Item   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RestaurentMngment     5   	     � Title$
  Item��5   	   ���#282828 � WindowStyle$
 None=�5	       � WindowState$ 	Maximized=�61   .��5
      � $��
20,0,20,20q�6   .+�5   
   �� $%��Main Menu > Manage > Food Items��6   $
��Bold"�6:   ���#AB82FF$��16(�6a   $��Center=�6o   $	��Top=�6�   � 5   
   $��0,25,0,0q�6   ���#E8E8E8 � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      &   System.Windows.Controls.DataGrid  -   5        $��lvUsers��5      $��2��6&   $��5��6;      AutoGenerateColumns .     CanUserAddRows .     AlternatingRowBackground �#f5f5f5   CanUserReorderColumns .  	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Food Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	Food_Id+  5      $ Catagory Id��6)   $ 70 6>    6I   �� *Catagory_Id+  5      $ Catagory Name��6)   $	 200 6@    6L   �� *CatagoryName+  5       $ 	Food Name��6)   $	 200 6<    6H   �� *
FoodName+  5!      $ Price��6)   $	 100 68    6D   �� *Price+  5"      $ Description��6)   $	 300 6>    6J   �� *Description+5$      � 5&      
���2͚�$��2��6,   $��4��6<   .+�5'      �� $��Food Id��6   $
��Left=�6*   $��	10,32,0,0q�6E   $	��Top=�6X    J� RenderTransformOrigin$ -0.057,0.573&�6p   �� 5(      -   5         ��Name$ 	FoodIdTxt��5(      {�.  $
��Left=�6?   $��23��6Z   $��	82,36,0,0q�6f    �� TextWrapping$
 Wrap=�6y   $	��Top=�6�   $	��300��6�   �� 5)      $��Catagory Id��6   $
��Left=�6.   $��	10,63,0,0q�6I   $	��Top=�6\   �� 5*      -   5        $ CatagoryIdTxt��5*      $
��Left=�61   $��23��6L   $��	82,67,0,0q�6X   $
 Wrap=�6k   $	��Top=�6   $	��300��6�   �� 5+      $��	Food Name��6   $
��Left=�6,   $��	10,94,0,0q�6G   $	��Top=�6Z   �� 5,      -   5        $ FoodNameTxt��5,      $
��Left=�6/   $��23��6J   $��	82,98,0,0q�6V   $
 Wrap=�6i   $	��Top=�6}   $	��300��6�   �� 5-      $��Price��6   $
��Left=�6(   $��
10,125,0,0q�6C   $	��Top=�6W   �� 5.      -   5        $ PriceTxt��5.      $
��Left=�6,   $��23��6G   $��
82,129,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��300��6�   �� 5/      -   5        $ DescriptionTxt��5/      $
��Left=�62   $��85��6M   $��
82,160,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��300��6�   �� 50      $��Description��6   $
��Left=�6.   $��
10,156,0,0q�6I   $	��Top=�6]   �� 51      -   5         ��Name$ Create��51      $��Create��6)   $
��Left=�6:   $��
10,278,0,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 52      -   5        $ Update��52      $��Update��6)   $
��Left=�6:   $��105,278,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 53      -	   5        $ Delete��53      $��Delete��6)   $
��Left=�6:   $��200,278,0,0q�6U   $	��Top=�6j   $��75��6�   6�   55      �� 57      -
   5        $
��back��57      $
��Back��6!   ���#8B4513$��40(�6E   $
��Bold"�6S   $��2��6e   $��4��6u   6�   58      5:      5;      
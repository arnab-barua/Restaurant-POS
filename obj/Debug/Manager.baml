   M S B A M L   `   `   `  ����L  HRestaurentMngment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RestaurentMngmentRestaurentMngment  5   	       RestaurentMngment.Manager   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RestaurentMngment     5   	     � Title$  Manager��5   	   ���#282828 � WindowStyle$
 None=�5	       � WindowState$ 	Maximized=�61   .��5
      � $��
20,0,20,20q�6   .+�5   
   �� $��Main Menu > Manage��6   $
��Bold"�6-   ���#AB82FF$��16(�6T   $��Center=�6b   $	��Top=�6   � 5   
   $��0,25,0,0q�6   ���#E8E8E8 � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� -   5        $��Catagory��5      ���#8B4513$��40(�6:   $
��Bold"�6H   .��6q   Manage Food Catagory6�   � 5      $��1��6   ���#7A67EE.+�5      �� $#��Service Charge Control Module��6   $
��Left=�6@   $��
140,10,0,0q�6[   $	��Top=�6o   $
��Bold"�6�   �� 5      $��Current Service Charge(%)��6   $
��Left=�6<   $��	21,41,0,0q�6W   $	��Top=�6j   �� 5      $��New Service Charge(%)��6   $
��Left=�68   $��	21,74,0,0q�6S   $	��Top=�6f   �� 5      -   5         ��Name$ CurrentSerCharge��5      $
��Left=�64   $��23��6O   $��
169,44,0,0q�6[    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��181��6�   {�.  6�   �� 5      -   5        $ NewSerCharge��5      $
��Left=�60   $��23��6K   $��
169,77,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��181��6�   �� 5      -   5         ��Name$ service_button��5      $��Change��61   $
��Left=�6B   $��169,126,0,0q�6]   $	��Top=�6r   $��75��6�   6�   5      �� 5      -   5        $��items��5   "   $��1��6   ���#8B4513$��40(�6D   $
��Bold"�6R   .��6x   Manage Food Items6�   � 5       $��1��6   $��2��6    ���#836FFF.+�5!      �� $��Discount Control Module��6   $
��Left=�6:   $��
140,10,0,0q�6U   $	��Top=�6i   $
��Bold"�6�   �� 5"      $��Current Discount Rate(%)��6   $
��Left=�6;   $��	21,41,0,0q�6V   $	��Top=�6i   �� 5#      $��New Discount Rate(%)��6   $
��Left=�67   $��	21,75,0,0q�6R   $	��Top=�6e   �� 5$      -   5        $ CurrentDiscount��5$      $
��Left=�63   $��23��6N   $��
169,44,0,0q�6Z   $
 Wrap=�6n   $	��Top=�6�   $	��177��6�   {�.  6�   �� 5%      -   5        $ NewDiscount��5%      $
��Left=�6/   $��23��6J   $��
169,78,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��177��6�   �� 5&      -   5        $ discount_button��5&      $��Change��62   $
��Left=�6C   $��169,122,0,0q�6^   $	��Top=�6s   $��75��6�   6�   5'      � 5(      $��2��6   ���#7A67EE.+�5)      �� $��Password Change Module��6   $
��Left=�69   $��
145,11,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   �� 5*      $��Enter New Password��6   $
��Left=�65   $��	21,76,0,0q�6P   $	��Top=�6c   �� 5+      $��Enter Current Password��6   $
��Left=�69   $��	21,38,0,0q�6T   $	��Top=�6g   �� 5,      -	   5        $ password_button��5,      $��change��62   $
��Left=�6C   $��155,123,0,0q�6^   $	��Top=�6s   $��75��6�   6�   G� 5-      -
   5         G�Name$ CurrentPass��5-      $
��Left=�63   $��20(�6N   $��
155,42,0,0q�6\   $	��Top=�6p   $	��201��6�   	 G� 	MaxLength$	 20��6�   
 G� PasswordChar$
 *��6�    J� RenderTransformOrigin$ 0.155,0.444&�6�   G� 5.      -   5        $ NewPass��5.      $
��Left=�6/   $��20(�6J   $��
155,76,0,0q�6X   $	��Top=�6l   $	 20��6�   $
 *��6�   $	��201��6�   5/      �� 50      -   5        $��logout��50   2   $��2��6   $��2��6"   ���#8B4513$��40(�6U   $
��Bold"�6c   .��6�   	Main Menu6�   51      52      53      
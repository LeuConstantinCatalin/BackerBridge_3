   M S B A M L   `   `   `  ����I  EBackerBridge_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BackerBridge_3.ViewsBackerBridge_3.Views  5      )    #BackerBridge_3.Views.AccountUC_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:BackerBridge_3.Views     5        � 	Resources  5
       �� 
TargetType �� Property �� Value �� 
TargetType ��Name4   .BackerBridge_3.Views.BoolToVisibilityConverter   BoolToVisibilityConverter��%i  '��       &	  B    �� 5   
   " ��6   .�5      ��  � ��$ 42��6'   �� 5       � ��$	 321��6&   �� 5       � ��
 ���� 6,   �� 5       � ��$ 5 15 0 0q�6(   �� 5       � ��$	 Top=�62   �� 5       � ��$
 Left=�64   �� 5       � ��
 ���w�6+   �� 5       � ��$ Gadugi)�6+   �� 5       �@��
CaretBrush
 ���w�6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   
������ #��z��5   !   ._�5      �� $ PART_ContentHost��6+   5      5      5      5         5!   
   6*   5"      .��5%      � ���#1F1F1F � ColumnDefinitions 5&   
   �� 5'      $��3* �6   �� 5)      $��2* �6   .+�5.   
   �� $
��Auto=�6   $��30q�6:   $��0��6F   .��5/      �� .+�50      �� -   5         ��Name$ 
tbLastName��50       �� 
IsReadOnly . $
��Left=�51      ��50   .   �� *
LastName+.��51   1   ��52      �� 53      	 �� ImageSource$!	 /Images/TextBoxLastName.png��6%   .��54   *   55      �� 57      -   5        $ tbFirstName��57       . $
��Left=�58      ��57   /   �� *	FirstName+.��58   1   ��59      �� 5:      $"	 /Images/TextBoxFirstName.png��6%   .��5;   *   5<      �� 5>      -   5        $ tbEmail��5>       . $
��Left=�5?      ��5>   +   �� *Email+.��5?   1   ��5@      �� 5A      $	 /Images/TextBoxEmail.png��6%   .��5B   *   5C      �� 5E      -   5        $ tbBirthDate��5E       . $
��Left=�5F      ��5E   /   �� *	BirthDate+
 �� StringFormat$
 
dd-MM-yyyy��.��5F   1   ��5G      �� 5H      $"	 /Images/TextBoxBirthDate.png��6%   .��5I   *   5J      �� 5M       �� Orientation$ 
Horizontal=�6   $��0,20,0,0q�66   .+�5N      �� -   5        $��Change Details��5N      $	��150��6R   $��40��6^   $��5q�6j   
�������
���   �6�   �� 5O      -   5         ��Name$ btnApplyChanges��5O   5   $��Apply Changes��6   
�������
���   �$	��150��5P      $��40��6%   $��5q�61   $y�	Collapsed=�6<   �� 5Q      $��Log Out��6   $	��150��6Q   $��40��6]   $��5q�6i   
���  ��
���������6/   �� *LogOutCommand+5R   *   5S      5T      5U      �� 5X   
   $��1��6   $��20q�6%   y�61   �� *	IsDonor+ �� 	Converter# [  .+�5Y      �� $(��"Want to create donation campaigns?��6   $
��Bold"�6B   $��16(�6T   
�������$��0,0,0,10q�6u   �� 5Z      $,��&Send a request to become a fundraiser.��6   
�������$��0,0,0,20q�6Y   �� 5[      -   5        $ tbRequestMessage��5[      $	��300��6u   $	��100��6�    �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0,0,0,10q�6�   ��60   �� *RequestMessage+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5\      $��Send Request��6   $	��150��6S   $��40��6_   
����  �
���������6,   �� *SendRequestCommand+6}   5]      5^      5`      
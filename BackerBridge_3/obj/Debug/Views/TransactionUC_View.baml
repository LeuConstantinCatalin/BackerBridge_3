   M S B A M L   `   `   `  ����  BackerBridge_3-    'BackerBridge_3.Views.TransactionUC_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	         RoundedGradientButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� 
StartPoint �� EndPoint � Color	 � Offset��%  &	        �� 5
   
   " ��63   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   ��5      �� 5   "   $	 0,0&�66   $	 1,1&�6G   .��5   &   � $ #AA3131��63   $		 0.0Q�6C   � 5   &   $ #781010��63   $		 1.0Q�6C   5   #   ._�5      �� $��Center=�6/   $��Center=�6L   ���#f7ba3c6g   5      5      5      �� 5       � ��$ Gadugi)�6+   �� 5       � ��$ 30��6'   �� 5       � ��$	 100��6&   5      5      .��5       � ���#1F1F1F.+�5"   
   �� $��Active Campaigns��6   $��28(�6,   $
��Bold"�6:   
�������$��	20,10,0,0q�6_   �� 5%   
   $
��Auto=�6   $��20,60,40,20q�6:   .��5&      �� ��6   �� *	Campaigns+��5'      �� 5(      .R�5)      �� $��1q�6!   
����������#282828$ 8��6]   
 �� Padding$
 15q�6n   $��0,0,0,10q�6{   ._�5*      ��  �� Orientation$ Vertical=�6)   .+�5,   "   �� $��18(�6J   $
��Bold"�6X   
�������$��0,0,0,5q�6}   ��6,   �� *CampaignName+6}   �� 5/   "   $��14(�6P   
�������$
��Wrap=�6u   $��0,0,0,10q�6�   ��6,   �� *ProjectDescription+6�   � 52   "   $��0,0,0,10q�6'   .+�53   &   �  � Minimum$ 0Q�62   $��20��6}   
���2�2� � Maximum 6>   �� *
GoalAmount+ � Value 6]   �� *CurrentAmount+6�   �� 54   &   $��Center=�60   $��Center=�6M   
���   �$��12(�6{   ��55   *   `� 56   .    �� StringFormat$ {0:C} / {1:C}��6;   .1�57   2   ��  �� Path$ CurrentAmount�6:   �� 58   2   $ 
GoalAmount�6:   59   /   5;   '   5<   #   �� 5?   "   $��Donate��6)   $	��100��6:   $��30��6F   $��Right=�6R   $��Gadugi)�6n   
������
�������#��[  5@   T   ��5A   )   �� *DataContext.DonateCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL���5B   )   �� 5C      5D      5E      5G      5H      5I      5J      
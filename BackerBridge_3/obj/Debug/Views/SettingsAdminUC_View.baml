   M S B A M L   `   `   `  ����  BackerBridge_3/    )BackerBridge_3.Views.SettingsAdminUC_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	         ButtonHoverStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  CenterTextStyle  LeftTextStyle*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  &	        &	 0    &	 �    '  �    '  ;    �� 5   
   " ��6)   .�5      ��  � ��$
 10,5q�6(   �� 5       � ��$ 14(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��
 ���� 6+    5      P� 5       �@J�IsMouseOver . . �5      ��  �@J�Opacity$	 0.8Q�60   5      5      �� 5   
   " ��6(   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 16(�6)   �� 5       � ��
 �����6+   5      �� 5    
   " ��6&   .�5!      ��  � ��$
 Left=�64   �� 5"       � ��$ Center=�62   �� 5#       � ��$ 16(�6)   �� 5$       � ��
 �����6+   5%      �� 5(   
   "  6   .�5)      ��  � �� �#2E2E2E6+   �� 5*       � ��
 �����6+   �� 5+       � �� �#3C3C3C6,   �� 5,       � ��$ 0,0,0,1q�60    5-      P� 5.       �@J�IsMouseOver . . �5/      ��  � �� �#55555563   50      P� 51       �@ 
IsSelected . . �52      ��  � �� �#007ACC63   53      55      �� 58   
   "  6   .�59      ��  � �� �#3C3C3C6+   �� 5:       � ��
 �����6+   �� 5;       � ��$ Center=�6;   �� 5<       � ��$ 16(�6)   �� 5=       � ��$
 Bold"�6+   �� 5>       � ��$
 10,5q�6(    5?      P� 5@       �@J�IsMouseOver . . �5A      ��  � �� �#55555563   5B      5D      5E      .��5G      � ���#1F1F1F$��20q�6    .+�5H   
   �� .+�5J      �� $��Pending Requests��6   $��28(�60   $
��Bold"�6>   ���#FFD700$��0,0,0,20q�5K      �� 5N      ���#2E2E2E �� CornerRadius$ 10��6*    �� Padding$ 10q�6<   $��0,0,0,20q�6I   ._�5O      &   System.Windows.Controls.DataGrid  	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  
������ 
�������   GridLinesVisibility$ 
Horizontal=�5P   G   $��Center=�5Q      $	��900��68   ���#3C3C3C$��1q�5R   1      	RowHeight$ 50Q�6E   ��5O      �� *PendingRequests+   Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Request ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6_   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5U   -      Binding 5T   A   �� *	RequestID+5U   -     5V      $ User ID��6-   $	 100 6Y   # [ 5W   -    5V   >   �� *UserID+5W   -     5X      $ Message��6-   $	 300 6Z   # [ 5Y   -    5X   >   �� *	Message+5Y   -     5Z      $ Request Date��6-   $	 150 6c   # [ 5[   -    5Z   C   �� *RequestDate+5[   -   4  .System.Windows.Controls.DataGridTemplateColumn  5\      $ Actions��61   $	 200 6B      CellTemplate 5]      �� 5^   "   .R�5_   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   $��0,0,0,0q�6g   .+�5a   *   �� $ 8��61   ���#00C853$��0,0,10,0q�6W   ._�5b   .   �� $��Accept��65   $��80��6F   $��35��6Q   $
��Bold"�6]   
�������
������ #��[  5f   5   ��5c   5   �� *" DataContext.AcceptRequestCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���5d   5   �� 5f   5   5g   +   �� 5j   *   $ 8��61   ���#D32F2F._�5k   .   �� $��Decline��65   $��80��6G   $��35��6R   $
��Bold"�6^   
�������
������ #��[  5o   5   ��5l   5   �� *#!DataContext.DeclineRequestCommand+ �� $ DataGridL���5m   5   �� 5o   5   5p   +   5q   '   5r   #   5t      5v      5w      5x      5y      5z      
   M S B A M L   `   `   `  ����  BackerBridge_33    -BackerBridge_3.Views.InsightFundraiserUC_View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5   
   "  6   .�5      ��  � �� �#3C3C3C6+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 10q�6(   5      5      .��5      � ���#1F1F1F$��20q�6    .+�5   
   �� .+�5      �� $��Your Campaigns��6   $��28(�6.   $
��Bold"�6<   ���#FFD700$��0,0,0,20q�5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserAddRows .  ���#2E2E2E
�������   GridLinesVisibility$
 None=�5   ?   ���#3C3C3C$��1q�5   -      	RowHeight$ 50Q�6A      RowBackground �#2A2A2A	   AlternatingRowBackground	 �#3A3A3A��5      �� *	Campaigns+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Campaign Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *CampaignName+6a     5$      $ Goal Amount��6)   $ 1* 6]    6>   �� *
GoalAmount+6]     5'      $ Current Amount��6)   $ 1* 6c    6A   �� *CurrentAmount+6c     5*      $ Status��6)   $ 1* 6\    69   �� *CampaignStatus+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5-      $ Progress��6-   $ 2* 6?      CellTemplate 5.      �� 5/      .R�50   "   � .+�51   &   �  � Maximum$	 100Q�6M   $��20��6[   ���#3C87F7���#2A2A2A � Value 62   �� *
Progress+52   G   �� 53   &   $��Center=�54   0   $��Center=�6M   
�������$
��Bold"�55   C   ��53   0   �� *
Progress+ �� StringFormat$ {0:N2}%��55   C   56   #   57      59        5<      $ Actions��6-   $ 3* 6>    5=      �� 5>      .R�5?   "   ��  �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5@   &   �� $��80��6O   $��30��6Z   ���#3C87F7
�������$
��Bold"�5A   U   ��5@   -   �� *ButtonContent+��5B   -   �� *'%DataContext.StopResumeCampaignCommand+ �� RelativeSource ��  �� AncestorType$ DataGridL���5C   -   �� �� 5E   &   $��Complete��6-   $��80��6@   $��30��6K   ���#45B45C
�������$
��Bold"�5F   U   ��5G   -   �� *%#DataContext.CompleteCampaignCommand+ �� $ DataGridL���5H   -   �� �� 5J   &   $��View Donations��6-   $	��120��6F   $��30��6R   ���#AA3131
�������$
��Bold"�5K   U   ��5L   -   �� *" DataContext.ViewDonationsCommand+ �� $ DataGridL���5M   -   �� 5N   #   5O      5Q      5S      5T      5U      5V      
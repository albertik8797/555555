   M S B A M L   `   `   `  ����  WpfApp2    CalendarApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Календарь��5   	   $��458.368��6   $��642.678��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ monthYearTextBlock��5      $��0��60   $��Center=�6=   $��Center=�6Z   $��20(�6u   �� 5   
   -   5         ��Name$ previousMonthButton��5      $��0��6.   $��<��6;   $
��Left=�6J   $
��10,0q�6e   6s   �� 5   
   -   5        $ nextMonthButton��5      $��0��6*   $��>��67   $��Right=�6F   $��0,0,10,0q�6b   6t   �� 5   
   -   5         ��Name$ calendarItemsControl��5      $��1��65   $��10q�6B   ��5      �� 5      .R�5      A�  A� Rows$ 7��6"    A� Columns$ 7��6+   5      ��5      �� 5      .R�5      �� 
�������$��1q�65   $��1q�6I   ._�5      �� $��Center=�65   $��Center=�6R   ��6$   �� 6R   5       5!      5#      5$      5%      
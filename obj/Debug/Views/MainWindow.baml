   M S B A M L   `   `   `  ����C  ?WPFluent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFluent.ViewsWPFluent.Views  5   	   ;"clr-namespace:WPFluent.CompositionWPFluent.Composition  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       WPFluent.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<x,http://schemas.microsoft.com/winfx/2006/xaml       5   
   Bd2http://schemas.microsoft.com/expression/blend/2008       5   	   0viewsclr-namespace:WPFluent.Views       5   	   <composition"clr-namespace:WPFluent.Composition       5   	   `iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       5   	     � Title$  WPF Fluent Design Window��5   	    � WindowStartupLocation$ CenterScreen=�5	   	      MainWindowStyle#���   5
   	   .  (System.Windows.Interactivity.Interaction   	Behaviors 5      2   ,WPFluent.Composition.BlurCompositionBehavior  5   
   .��5      �   WindowContainer#���  6   .+�5   
   "   WPFluent.Views.EffectsPasses  �� 5   
   -   5         ��Name$ ViewContainer��5        BorderShadowWindowContainer#���  6(   $��0q�6^   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      !   WPFluent.Views.WindowHeader  $��0��6%   $��Stretch=�62   $��Stretch=�6N   � 5      $��1��6   
������ $��10q�6=    � ColumnDefinitions 5       �� 5!      $	��20* �6+   �� 5"      $	��80* �6+   .+�5%      � $��0��6   ���	#00FFFFFF$��5q�6C   5'      A� 5(       A� Rows$ 4��6#    A� Columns$ 2��5)   #   $��1��6/   .+�5*      � 
�������$��5q�62   � 5+      
�������$��5q�62   � 5,      
�������$��5q�62   � 5-      
�������$��5q�62   � 5.      
�������$��5q�62   � 5/      
�������$��5q�62   � 50      
�������$��5q�62   � 51      
�������$��5q�62   52      53      54      55      57      58      
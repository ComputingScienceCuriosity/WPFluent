   M S B A M L   `   `   `  ����C  ?WPFluent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFluent.ViewsWPFluent.Views  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NMicrosoft.Windows.Shell, Version=3.0.1.0, Culture=neutral, PublicKeyToken=null   MainWindowStyle  �� 
TargetType    WPFluent.Views.MainWindow �� Property �� Value �� Source*  $Microsoft.Windows.Shell.WindowChrome   ResizeBorderThickness   CaptionHeight   CornerRadius   GlassFrameThickness  WindowContainer  BorderShadowWindowContainer  WindowHeaderStackPanelStyle  HeaderButtonFocusVisual �� 
TargetType	 ��Name
 � ActualWidth � ActualHeight �� CornerRadius  BackgroundButtonHeader  HeaderBouton'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration �� 
TargetName �� TargetProperty W� From	 W� To J� Opacity �� Triggers P� Property P� Value �� 
TargetName  BrushCouleurFondDesactive �� Triggers  WindowButton �� BasedOn 	 WindowButtonCloseImage 
 BrushCloseWhite  WindowButtonMinimizeImage  BrushMinimizeWhite  WindowButtonMaximizeImage  BrushMaximizeWhite �� Binding �� RelativeSource �� AncestorType �� Value  BrushResizeWindowWhite�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    <x,http://schemas.microsoft.com/winfx/2006/xaml       5      Kshell?http://schemas.microsoft.com/winfx/2006/xaml/presentation/shell  5      &viewsclr-namespace:WPFluent.Views  5      %l  &	        &	     &	 g    &	 �    &	 8    &	     &	 �    7  7  &	 
    7  &		 �
    7  &	 �
    7  &	 o    7  �� 5      "    6$   .�5   
   ��  � �� 6%   �� # Z���� 5   
    � �� 6&   �� # Z���� 5	   
    � ��
 �����6(   �� 5
   
    � ��$ 2q�6,   �� 5   
    �@�WindowStyle$
 None=�6(   �� 5   
    � ��$ Center=�6.   �� 5   
    � ��$ Stretch=�60   �� 5   
    � ��
 ���� 6'   �� 5   
    �@�AllowsTransparency . 6/   �� 5   
    �@ WindowChrome 5        5      $ 2q�6%   $ 30Q�6?   $ 0��6R   $ 0q�6c   5      5      �� 5      "  �6   .�5   
   ��  � ��
 ���� 6'   5      �� 5      "  ��6   .�5   
   ��  � ��$ 1q�6,   �� 5   
    � ��$ 0,0,0,0q�6#   �� 5   
    �@J�RenderTransformOrigin$	 0,0&�62   �� 5   
    � z� 5       V� 5!      .~�5"      �� �� 5#      �� 5$      T� 5%      5&      5(      5)      �� 5+      "  ��6   .�5,   
   ��  �@��Orientation$ 
Horizontal=�6(   �� 5-   
    � ��$ Right=�6+   �� 5.   
    � ��$	 Top=�6.   5/      �� 51      .�52   
   ��  � �� 53      �� 54      " ��6"   .R�55      � .+�56      �� $	 border��6!   #��z
 61   #��z 6W   
������$ 2��6�   $��1q�6�   57      58      5:      5;      �� 5=      "  ��6+   .�5>   
   ��  � ��$ 0q�6,   �� 5?   
    � ��$ 0q�6#   �� 5@   
    �@�Cursor$
 Hand��6#   5A      �� 5C      "  ��6!   .�5D   
   ��  � ��$
 Auto��6#   �� 5E   
    � ��$ 38��6"   �� 5F   
    � ��$ 2q�6$   �� 5G   
    �@J�Opacity$
 0.75Q�6$   �� 5H   
    �@�FocusVisualStyle8   6-   �� 5I   
    � ��$ Center=�60   �� 5J   
    � �� 5K      �� 5L      " ��6"   .R�5M      �� $	 MainBackground��6M   8��  5N        5O      CommonStates��. 5P   "     
Normal��6.     5Q   "   	MouseOver��. 5R   &   �� .��5S   *   W� $ 0D�6:   $ BackgroundAnimation��6G   $ Opacity�6s   $	 0.0X�6�   $	 0.9X�6�   5T   '   5U   #   5V      ._�5X      � .+�5Y      �� $	 BackgroundAnimation��6%   $ 0Q�6B   #��z��6N   �� 5Z      $��18��6(   #��z��64   �� 5[      $y�Hidden=�6/   5\      5]       5^      P� 5_       � {� .  . �5`      �� $ BackgroundAnimation��6;   # �  6\    � ���� 5a       �@J�Opacity$
 0.25Q�68   5b      5d      5f       5g   
   P� 5h       �@J�IsMouseOver . . �5i      ��  �@J�Opacity$	 1.0Q�6,   5j      5l      �� 5n      "  ��6!   8   .�5o   
   ��  � ��$ 20��6#   �� 5p   
    � ��$ 30��6"   5q      �� 5r      "  ��6+   8   .�5s   
   ��  � ��# � 
 6(   �� 5t   
    � �� �	#EEE748566'   5u      �� 5v      "  ��6.   8   .�5w   
   ��  � ��# �  6(   �� 5x   
    � �� �	#FFFFFFFF6'   5y      �� 5z      "  ��6.   8   .�5{   
   ��  � ��# �  6(   �� 5|   
    � �� �	#FFFFFFFF6'    5}   
   �� 5~       6   �� *WindowState+ �� " �
 Normal6x   .a�5      ��  � ��# �  60   5�      �� 5�       6   �� *WindowState+ �� " � 	Maximized6x   .a�5�      ��  � ��# �  60   5�      5�      5�      
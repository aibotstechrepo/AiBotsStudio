   M S B A M L   `   `   `  ����D  @Tab_Files, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Tab_Files	Tab_Files  5   	       Tab_Files.Recorder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Tab_Files     5   	     � Title$  Recorder��5   	   $��131.667��6   $��369.416��6+    � WindowStartupLocation$ CenterScreen=�6;    � WindowStyle$
 None=�6`   .��5	      � $��
0,0,-30,-1q�6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FF93BF93��6   $ 1Q�61   5      .+�5   
   �� -   5         ��Name$ btnStart��5      $�� ��6#   $
��Left=�6.   $��	22,27,0,0q�6I   $	��Top=�6\   $��70��6t   $��64��6   ��5      �� 5       j� TileMode$
 Tile=�6   	 �� ImageSource$	 UIRecorder/PLAY.png��6-   5      �� 5   
   -   5        $ btnStop��5      $�� ��6"   $
��Left=�6-   $��
107,27,0,0q�6H   $	��Top=�6\   $��70��6t   $��64��6   ��5      �� 5      $	 UIRecorder/STOP.png��6   5      �� 5   
   -   5        $ btnPlay��5      $�� ��6"   $
��Left=�6-   $��
193,27,0,0q�6H   $	��Top=�6\   $��71��6t   $��64��6   ��5      �� 5      $	 UIRecorder/REPLAY.png��6   5      �� 5   
   -   5        $�� ��5      $
��Left=�6   $��
281,27,0,0q�67   $	��Top=�6K   $��84��6c   $��64��6n   
 J� RenderTransformOrigin$
 0.167,0.506&�6z   ��5       �� 5!      $	 UIRecorder/CLOSE.png��6   $
 Tile=�6@   5#      5%      5&      
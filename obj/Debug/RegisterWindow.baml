   M S B A M L   `   `   `  ����R  NQuestionsAndAnswersGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuestionsAndAnswersGameQuestionsAndAnswersGame  5   	   ,    &QuestionsAndAnswersGame.RegisterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:QuestionsAndAnswersGame     5   	     � WindowStyle$
  None=�5   	   $��18(�5	   	    � Title$ Registration Window��5
   	   $	��245��6%   $	��400��62   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6    .��5      �� .�6   Please register!5      5      �� 5   
   $��1��6   $��1��6    .��6.   Enter nickname:6?   �� 5   
   -   5        $��NicknameField��5      $�� ��6   $��1��6/   $��2��6?   $	��250��6L   6]   �� 5    
   $��3��6   $��4��6   .��6.   !Create password (8-16 symbols):6O   G� 5!   
   -   5        $��PasswordBox��5!      $��4��6)   $��2��66   6L   � 5"   
   $��5��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   .+�5#      �� -   5         �� 	IsDefault . $��60��5#   &   $��0,0,10,0q�64   .��6[   _Ok6`   �� 5$      -   5         �� IsCancel . $��60��5$   %   .��6K   	_Cancel6T   5%      5&      5'      
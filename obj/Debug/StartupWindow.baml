   M S B A M L   `   `   `  ����R  NQuestionsAndAnswersGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuestionsAndAnswersGameQuestionsAndAnswersGame  5   	   %    QuestionsAndAnswersGame.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:QuestionsAndAnswersGame     5   	     � WindowStyle$
  None=�5   	   $��18(�5	   	    � Title$ Welcome��5
   	   $	��245��6   $	��400��6&   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6    .��5      �� .�6   #!Welcome to Questions and Answers!5      5      �� 5   
   -   5        $��lblQuestion��5      $��1��6#   $��1��63   .��6A   Please enter nickname:6Y   �� 5    
   -   5        $��AnswerField��5        �� 
IsEditable .  �� Text$  ��6\   $��1��6d   $��2��6t   $	��250��6�   ��68   �� *Suggestions+6�   �� 5!   
   -   5        $��lblPassword��5!      $��3��6#   $��4��60   .��6A   Please enter password:6Y   G� 5"   
   -   5        $��PasswordBox��5"      $��4��6)   $��2��66   6L   � 5#   
   $��5��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   .+�5$      �� -   5        $��btnRegister��5$   &    �� 	IsDefault . $��60��6S   $��0,0,10,0q�6a   .��6s   _Create an account6�   �� 5%      -   5        $��btnDialogOk��5%   &    . $��60��6S   $��0,0,10,0q�6a   .��6s   _Ok6x   �� 5&      -   5         �� IsCancel . $��60��5&   %   .��6H   	_Cancel6Q   5'      5(      5)      
   M S B A M L   `   `   `  ����R  NQuestionsAndAnswersGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuestionsAndAnswersGameQuestionsAndAnswersGame  5      #    QuestionsAndAnswersGame.Page1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:QuestionsAndAnswersGame     5        N� FontSize$  22(�5	       N� Title$ Page1��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��0��6   $��1��6!   $��Category��61   $��5q�6A   $��Center=�6L   �� 5   
   $��0��6   $��2��6!   $��
Difficulty��61   $��5q�6C   $��Center=�6N   �� 5    
   $��2��6   $��1��6!   $
��Type��61   $��5q�6=   $��Center=�6H   �� 5!   
   $��2��6   $��2��6!   $"��Number of questions (max 50)��61   $��5q�6U   $��Center=�6`   �� 5#   
   -   5         ��Name$ categoryBox��5#      $��1��6)   $��1��66   $��5q�6F   $	��Top=�6Q   .@�5$      �� 
 � Tag$	 any��6   $��Random Category��6%   �� 5%      $ 9��6   $��General Knowledge��6#   �� 5&      $ 10��6   $��Entertainment: Books��6$   �� 5'      $ 11��6   $��Entertainment: Film��6$   �� 5(      $ 12��6   $��Entertainment: Music��6$   �� 5)      $ 13��6   $*��$Entertainment: Musicals and Theatres��6$   �� 5*      $ 14��6   $��Entertainment: Television��6$   �� 5+      $ 15��6   $ ��Entertainment: Video Games��6$   �� 5,      $ 16��6   $ ��Entertainment: Board Games��6$   �� 5-      $ 17��6   $��Science and Nature��6$   �� 5.      $ 18��6   $��Science: Computers��6$   �� 5/      $ 19��6   $��Science: Mathematics��6$   �� 50      $ 20��6   $��	Mythology��6$   �� 51      $ 21��6   $��Sports��6$   �� 52      $ 22��6   $��	Geography��6$   �� 53      $ 23��6   $��History��6$   �� 54      $ 24��6   $��Politics��6$   �� 55      $ 25��6   $	��Art��6$   �� 56      $ 26��6   $��Celebrities��6$   �� 57      $ 27��6   $��Animals��6$   �� 58      $ 28��6   $��Vehicles��6$   �� 59      $ 29��6   $��Entertainment: Comics��6$   �� 5:      $ 30��6   $��Science: Gadgets��6$   �� 5;      $ 31��6   $-��'Entertainment: Japanese Anime and Manga��6$   �� 5<      $ 32��6   $+��%Entertainment: Cartoon and Animations��6$   5=      �� 5?   
   -   5        $ difficultyBox��5?      $��1��6*   $��2��67   $��5q�6G   $	��Top=�6R   .@�5@      �� $	 any��6   $��Random Difficulty��6%   �� 5A      $
 easy��6   $
��Easy��6&   �� 5B      $ medium��6   $��Medium��6(   �� 5C      $
 hard��6   $
��Hard��6&   5D      �� 5F   
   -   5        $ typeBox��5F      $��3��6$   $��1��61   $��5q�6A   $	��Top=�6L   .@�5G      �� $	 any��6   $��Random Type��6%   �� 5H      $ multiple��6   $��Multiple Choice��6*   �� 5I      $ boolean��6   $��True / False��6)   5J      �� 5K   
   -   5         ��Name$ numberField��5K      $��3��6'   $��2��64   $��5q�6h   6u   �� 5M   
   -   5        $��4��5M      $��1��6   $��2��6.   $��5q�6P   .��6[   	Ranking6d   �� 5N   
   -   5        $��5��5N      $��1��6   $��2��6.   $��5q�6U   .��6`   Single player6o   5O      5P      
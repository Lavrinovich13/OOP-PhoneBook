   M S B A M L   `   `   `  ����  	PhoneBook&     PhoneBook.Pages.UpdatePersonPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $	��501��5      $	��567��6   .��5      � .+�5	   
   �� -   5        $��bLeft��5	   M   $��50��6   $
��Left=�6   $��444,408,0,0q�68   $	��Top=�6Z   $��50��6r     � ToolTip$  
Назад��6}   $��0q�6�   ���	#FFFFFEFE.��5
      �� .+�5      �� $��../Resource/left_3029.png��6   5      5      �� 5   
   -   5        $��bSave��5   M   $��50��6   $
��Left=�6   $��494,408,0,0q�68   $	��Top=�6Z   $��50��6r   $  Сохранить��6}   $��0q�6�   ���	#FFFFFEFE.��5      �� .+�5      �� $��../Resource/save_9159.png��6    J� RenderTransformOrigin$ 0.5,0.5&�6;   5      5      �� 5   
   -   5        $��iPersonImage��5      $��../Resource/noFoto.png��6%   $
��Left=�6E   $	��182��6`   $��	19,10,0,0q�6m   $	��Top=�6�   $	��205��6�   6�   �� 5   
   -   5        $��
tbPersonId��5      $y�Hidden=�6&   �� 5   
   $��Имя:��6   $
��Left=�6   $��
229,10,0,0q�6:   $	��Top=�6N   $��49��6f   $��32��6q   $��18(�6}   �� 5   
   $��Фамилия:��6   $
��Left=�6#   $��
229,71,0,0q�6>   $	��Top=�6R   $	��106��6j   $��34��6v   $��18(�6�   �� 5   
   $��Отчество:��6   $
��Left=�6$   $��229,130,0,0q�6?   $	��Top=�6T   $	��101��6l   $��34��6x   $��18(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgPhoneNumbers��5         CanUserAddRows .    CanUserDeleteRows . $
��Left=�6p   $��
19,218,0,0q�6�   $	��Top=�6�   $	��185��6�   $	��525��6�      AutoGenerateColumns .  ���	#FFFFFEFE$��0,0,0,0q�6  ��6)   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<      
Visibility$ Hidden=�6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6H     5      $ Телефон��6@   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 262 6Q    6%   �� *Number+6Q     5      $ Описание��6E   $		 255 6W    6%   �� *Description+6W   5      �� 5    
   -   5        $��tbFirstName��5       $
��Left=�6%   $��28��6@   $��
229,43,0,0q�6L   
 �� TextWrapping$

 Wrap=�6`   $	��Top=�6t   $	��315��6�   $��18(�6�   .��6�   5"      �� 5#   
   -   5         ��Name$ 
tbLastName��5#      $
��Left=�6&   $��28��6A   $��229,105,0,0q�6M   $

 Wrap=�6b   $	��Top=�6v   $	��315��6�   $��18(�6�   �� 5$   
   -	   5        $ tbPatronymic��5$      $
��Left=�6(   $��28��6C   $��229,164,0,0q�6O   $

 Wrap=�6d   $	��Top=�6x   $	��315��6�   $��18(�6�   5%      5&      
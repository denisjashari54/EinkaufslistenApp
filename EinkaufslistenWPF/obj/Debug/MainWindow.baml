   M S B A M L   `   `   `  ����  EinkaufslistenWPF"    EinkaufslistenWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Einkaufsliste��5   	   $	��450��6   $	��800��6,   .��5      � .+�5   
   �� -   5         ��Name$ BenutzerAuswahl��5      $	��150��6,   $��30��68   $	��Top=�6D   $
��Left=�6\   $��	10,10,0,0q�6w   .@�5      �� $��Alice��6   
 � Tag$ 1��6+   �� 5      $	��Bob��6   $ 2��6)   5	      �� 5   
   -   5         ��Name$ LadenButton��5      $��Laden��6&   $	��100��66   $��30��6B   $	��Top=�6N   $
��Left=�6f   $��
170,10,0,0q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EinkaufslisteGrid��5         AutoGenerateColumns .  $��10,50,10,50q�6J   $	��300��6_      SelectionMode$ Single=�6l      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6H   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6S     5      $
 Name��6%   $		 150 6L    63   �� *Name+6L     5      $ Menge��6%   $		 100 6N    64   �� *Menge+6N   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Gekauft��6)   $		 100 6V    6:   �� *	Gekauft+6V     5      $ 
ErstelltAm��6%   $		 200 6X   
 .  69   �� *
ErstelltAm+6d   5      �� 5   
   -   5        $ HinzufügenButton��5      $��Hinzufügen��6+   $	��100��6@   $��30��6L   $��Bottom=�6X   $
��Left=�6s   $��
150,0,0,10q�6�   6�   �� 5   
   -   5        $ BearbeitenButton��5      $��
Bearbeiten��6+   $	��100��6@   $��30��6L   $��Bottom=�6X   $��Center=�6s   $��0,0,0,10q�6�   6�   �� 5   
   -   5        $ LöschenButton��5      $��Löschen��6(   $	��100��6:   $��30��6F   $��Bottom=�6R   $��Right=�6m   $��
0,0,150,10q�6�   6�   5      5      
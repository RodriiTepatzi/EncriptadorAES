   M S B A M L   `   `   `  ���� I  EEncriptadorDES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EncriptadorDESEncriptadorDES      EncriptadorDES.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:EncriptadorDES     -     �Name$  	mainFrame�� � Title$ Encriptador��$	��550��$	��900�����	#FF1B1B1B � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� -   $
��grid�����	#FF1B1B1B � RowDefinitions �� $	��17* ��� $��5* �.+��� -    ��Name$ title_label��$��Encriptador AES��$
��Left=�$��6,0,0,0q�$	��Top=�$
��Bold"�$��20(�   BlackSecondary#��[  �� -   $:��4Desarrollado Por: Marco Rodrigo, Jose Alonso y Diego��$
��Left=�$��
600,87,0,0q�$	��Top=�$
��Bold"�#���   $��1��$��10(��� -    ��Name$ close��$��Right=�$��26��$��0,5,10,0q�$	��Top=�$��26��$��	close.png�� � Cursor$
 Hand��	 J� OpacityMask	 �� 
 j� Stretch$
 UniformToFill=� �� ImageSource$ 	close.png���� -   $ 	minimizar��$
��Left=�$��26��$��	832,5,0,0q�$	��Top=�$��26��$��minimizar.png��$
 Hand��	 �� $
 UniformToFill=�$ minimizar.png���� -    ��Name$ 
txt_normal��$��10,37,90,163q����	#FF272727#��[    GreenPrimary#��[  �� SelectionBrush
 �   � �� SelectionOpacity$
 0.65Q�$��1����.  $��Texto normal��$	��225��$��2q��� -    ��Name$ encriptar_btn��$��	Encriptar��$��	0,37,10,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�  ButtonStyle#��[ ��Z� �� -	   $ txt_encriptado��$��10,277,90,50q�  
BlackInput#��[ #��[  ���	#FF4ECF3A
 �   �$
 0.65Q�$��1����.  $��Texto encriptado��$	��223��$��2��$��2q��� -
   $ copiar1��$��Copiar��$��	0,67,10,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�#��[ ��Z� �� -   $ desencriptar_btn��$��Desencriptar��$��
0,277,10,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�#��[ ��Z� �� -   $ copiar2��$��Copiar��$��
0,307,10,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�#��[ ��Z� �� -   $ TextboxLlave��$
��Left=�$��25��$��	10,87,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��425�� �� 	UndoLimit$ 32�� �� MaxLines$ 1�� �� 	MaxLength$ 32�����	#FF272727#��[  #��[ 
 �   �$
 0.65Q�$��1����.  $)��#Llave (32 caracteres) (Hexadecimal)��$��1��$��Center=�$��2,0,0,0q��� -   $ copiar3��$��Copiar��$��
0,87,305,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�#��[ $��1�� J� RenderTransformOrigin$ 0.498,0.747&���Z� �� -   $ generar��$��Generar��$��
0,87,385,0q�$	��Top=�$��Right=�$��75��$��25�����	#FF4ECF3A
���   ���.  $��0��$��0,0,0,0q�#��[ $��1��$ 0.498,0.747&���Z� �� -     BlackPrimary#���  $
��Left=�$��27��$��	172,5,0,0q�$	��Top=�$	��638��
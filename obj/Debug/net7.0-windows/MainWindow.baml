   M S B A M L   `   `   `  ����I  EEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EncryptDecryptEncryptDecrypt  5   	       EncryptDecrypt.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EncryptDecrypt     5   	     � Title$  Encrypt and Decrypt��5   	   $	��450��6%   $	��800��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   
 � Tag$ Settings��6'   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��8q�6)   .+�5      �� $
��Bold"�6   $��
Input Mode��6*   	� 5      $
��Text��6    d� 	IsChecked$
 TrueY�6-   	� 5      $
��File��6   5      �� 5      $��1��6   $��8q�6)   .+�5      �� $
��Bold"�6   $��Processing Mode��6*   	� 5      -   5         	�Name$ EncryptCheck��5   0   $��Encrypt��6   $
 TrueY�6F   	� 5      -   5        $ DecryptCheck��5   0   $��Decrypt��6   60   	� 5      -   5        $ 	HashCheck��5   -   $
��Hash��6   6-   5      �� 5       $��2��6   $��8q�6)   .+�5!      �� $
��Bold"�6   $��	Algorithm��6*   �� 5"      -   5        $��AlgorithmComboBox��5"      .@�5#      �� $��DefaultCryptoProvider��6#   �� 5$      $��LegacyCryptoProvider��6#   5%      �� 5&      $��Passphrase:��6   �� 5'      -   5        $��PassphraseTextBox��5'      5(      5)      � 5*   
   $��1��6   .+�5+      �� $��10q�6   .+�5,      �� $
��Bold"�6   $��Input��6*   �� 5-      $��Text:��6   $��Center=�6)   �� 5.      -   5         ��Name$ RecieveText��5.   2   $��30��6   $��10q�6&   62   �� 5/      -   5         ��Name$ UploadButton��5/   1   $��Choose a file��6   $��5q�6b   $��27��6m   
���"�"�
�������6�   50      52      � 53   
   $��2��6   .+�54      �� $��10q�6   .+�55      �� $��Output��6   $��Center=�6)   $
��Bold"�6F   �� 56      -   5        $ 
OutputText��56   2   $��50��6   $��10q�6&   62   �� 57      -	   5        $��Show The Desire Output��57      
���"�"�
�������6i   58      5:      5;      5<      
   M S B A M L   `   `   `  ����K  GImageService.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ImageService.GUI.ViewModelImageService.GUI.ViewModel  5      O KImageService.Logging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:ImageService.Logging;assembly=ImageService.LoggingImageService.Logging 5      I)clr-namespace:ImageService.GUI.ConvertersImageService.GUI.Converters  5      +    %ImageService.GUI.View.LogsUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ImageService.GUI.ViewModel     5      Xlog_message@clr-namespace:ImageService.Logging;assembly=ImageService.Logging     5      @
converters)clr-namespace:ImageService.GUI.Converters     5        � 	Resources  5      2  ,ImageService.GUI.Converters.LogTypeConverter   logTypeConverter 	 Title �� Property �� Value��%  &	        &	        5   
   6&   �� 5   
   .�5      ��  � ��$ 20(�63   �� 5       � ��$
 Bold"�65   �� 5       � ��
 � � �65   �� 5       � ��$ Center=�6<   �� 5       � ��$ Center=�6>   5      5      .��5      � 
������  � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	LogsLabel��5      $
��Logs��6#   $��2��62   $��Stretch=�6F   $��Stretch=�6i   #��[ 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ LogDataGrid��5      
������ $��2��6A   $��2��6N      AutoGenerateColumns .     
IsReadOnly . ��.  ��6b   �� *VM_LogMessages+	   Columns	 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Type��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6L      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Type+   ElementStyle 5"      �� 5#       �� 
TargetType" ��6    .�5$      ��  � �� 6;   �� *Type+ �� 	Converter# [  5%      5'        5(      $
 Message��6%    .   66   �� *	Message+6R   5*      5+      5,      
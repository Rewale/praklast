   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	       WpfApp2.View.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp2.View     5   	   M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle  .  � Title$ MainView��5
   	   $	��450��6   $	��800��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      .+�5   
   �� $��40��6   $
��Left=�6?   $��10q�6Z   $	��150��6f   $��Водители��6r   ��6   �� *clickOnDrive+6r   �� 5   
   $��40��6   $��Center=�6B   $��10q�6_   $	��150��6k   $��
Права��6w   ��6   �� *clickOnLicenses+6w   �� 5   
   $��40��6   $��Right=�6=   $��10q�6Y   $	��150��6e   $��ДТП��6q   ��6   �� *
clickOnDTP+6q   �� 5   
   $��40��6   $��Right=�6>   $��0,15,167,15q�6Z   $	��150��6o   $��Авто��6{   ��6   �� *clickOnAuto+6{   �� 5   
   $��1��5      $��10q�5      ��5      �� *CurrentView+5      5      5      
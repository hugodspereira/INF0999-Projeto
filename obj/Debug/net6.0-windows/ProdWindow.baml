   M S B A M L   `   `   `  ????J  FINF0999-Projeto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:INF0999_ProjetoINF0999_Projeto  5   	   $    INF0999_Projeto.ProdutorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:INF0999_Projeto     5   	     ? Title$  Produtor??5   	   $	??450??6   $	??800??6'    ? WindowState$ 	Maximized=?63   .??5	      ? .+?5
   
   ?? ???#CFE2F36   ?? 5   
   $??1??6   ???#B6D7A86#   ?? 5   
    ?? Orientation$ Vertical=?6   $??Center=?6,   $??Center=?6G   .+?5      ?? $??Agendar coleta??6   $??Center=?6.   $??18(?6K   &   System.Windows.Controls.DataGrid  5      $   HorizontalScrollBarVisibility$ Hidden=?6   $	??700??6>      AutoGenerateColumns$ False??6o      
IsReadOnly$
 True??6?   $??18(?6?   ??6M   ?? *	listaLixo+ ?? SelectedItem 6?   ?? *LixoSelecionado+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Item??6)   	   MaxWidth$		 590Q?6R   
   MinWidth$	
 590Q?6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ?? *Item+6a     5      $ 
Quantidade??6)   $	
 110Q?6^   $		 110Q?6m    6?   ?? *
Quantidade+6m   5      ?? 5      $ 
Horizontal=?6   $??Center=?62   $??Center=?6M   .+?5      ?? $??18(?6   $??Inserir??6'   $??
20,20,20,0q?6S   $??80??6i   ??69   ?? *Novox+6i   ?? 5      $??18(?6   $??Agendar??6'   $??
20,20,20,0q?6V   $??80??6l   ??69   ?? *
Agendarx+6l   ?? 5      $??18(?6   $??Editar??6'    ?? IsCancel$
 true??68   $??
20,20,20,0q?6d   $??80??6z   ??6H   ?? *	Editarx+6z   ?? 5      $??18(?6   $??Deletar??6'   $
 true??69   $??
20,20,20,0q?6f   $??80??6|   ??6I   ?? *
Deletarx+6|   ?? 5      $??18(?6   $
??Sair??6'   $
 true??66   $??
20,20,20,0q?6`   $??80??6v   ??6F   ?? *Sairx+6v   5      5      5      5      
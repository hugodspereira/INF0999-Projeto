   M S B A M L   `   `   `  ????J  FINF0999-Projeto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:INF0999_ProjetoINF0999_Projeto  5   	   !    INF0999_Projeto.Cooperativa   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:INF0999_Projeto     5   	     ? Title$  Cooperativa??5   	   $	??450??6   $	??800??6*    ? WindowState$ 	Maximized=?66   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??2* ?6   ?? 5      $??5* ?6   .+?5   
   ?? ???#CFE2F36   ?? 5   
   $??1??6   ???#B6D7A86#   ?? 5   
    ?? Orientation$ Vertical=?6   $??Center=?6,   $??Center=?6I   .+?5      ?? $ 
Horizontal=?6   $??Center=?62   $??Center=?6O   .+?5      ?? $??Coletores ativos hoje: ??6   $??Center=?6=   $??18(?6Z   ?? 5      $??Center=?6<   $??18(?6Y   ??6   ?? *NumColetores+6Y   5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns$ False??6<      
IsReadOnly$
 True??6X   $??18(?6?   ??6   ?? *listaColetor+ ?? SelectedItem 6j   ?? *ColetorSelecionado+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nome??6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   ?? *Nome+  5      $ 	Endereço??6)   	 6=   ?? *	Endereço+  5      $ Telefone??6)   	 6=   ?? *
Telefone+5      ?? 5      
????ح?$??Registar coletor??6,   $??20q?6~   $??18(?6?   ??6G   ?? ??6d   ?? *Novox+6?   ?? 5      $ 
Horizontal=?6   $??Center=?62   $??Center=?6O   .+?5      ?? 
????ح?$??Center=?60   $??64??6M   $??Deletar??6Z   
 ?? IsCancel$

 true??6l   $??20q?6?   $??18(?6?   ??6|   ?? *
Deletarx+6?   ?? 5      
????ح?$??Center=?60   $??64??6M   $??Editar??6Z   $

 true??6k   $??20q?6?   $??18(?6?   ??6{   ?? *	Editarx+6?   ?? 5       
????ح?$??Center=?60   $??64??6M   $
??Sair??6Z   $

 true??6i   $??20q?6?   $??18(?6?   ??6y   ?? *Sairx+6?   5!      5"      ?? 5#   
   $??1??6   $ Vertical=?6'   $??Center=?6>   $??Center=?6[   .+?5$      ?? $ 
Horizontal=?6   $??Center=?62   $??Center=?6O   .+?5%      ?? $??Produtores cadastrados: ??6   $??Center=?6>   $??18(?6[   ?? 5&      $??Center=?6=   $??18(?6Z   ??6   ?? *NumProdutores+6Z   5'        5(      $ False??6=   $
 True??6Y   $??18(?6?   ??6   ?? *listaProdutor+ 6k   ?? *ProdutorSelecionado+ 5)        5*      $
 Nome??6)   	 69   ?? *Nome+  5+      $ 	Endereço??6)   	 6=   ?? *	Endereço+  5,      $ Telefone??6)   	 6=   ?? *
Telefone+  5-      $ E-mail??6)   	 6;   ?? *Email+5/      ?? 50      $??1??6   $ Vertical=?6+   $??Center=?6B   $??Center=?6_   $??	0,100,0,0q?6z   .+?51      ?? $ 
Horizontal=?6   $??Center=?66   $??Center=?6S   .+?52      ?? $??Coletas Agendadas: ??6    $??Center=?6=   $??18(?6Z   ?? 53      $??Center=?6>   $??18(?6[   ??6    ?? *
NumColetas+6[   54        55      $ False??6=   $
 True??6Y   $??18(?6?   ??6   ?? *	listaLixo+ 6k   ?? *LixoSelecionado+ 56        57      $
 Item??6-   	 6=   ?? *Item+  58      $ 
Quantidade??6-   	 6C   ?? *
Quantidade+  59      $ Produtor??6-   	 6A   ?? *Dono+5;      5<      5=      5?      5@      
   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   A =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistasVistas 5   	      Vistas.vtnFiltroServicio   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >DATOS,clr-namespace:ClasesBase;assembly=ClasesBase     5   	   &localclr-namespace:Vistas     5   	   -   5          � Title$  vtnFiltroServicio��5   	   $	��386��6#   $	��659��60    � 	Resources 5         listaTerminal S� 
ObjectType#   ClasesBase.TrabajarTerminales S� 
MethodName  listaServicios"   ClasesBase.TrabajarServicios  ColeccionServicios �� Source��%�   &	        &	 D     &	 �     7  S� 5	   
   "  5
      $ traerTerminales��5      5      S� 5   
   "  5      $ traerServiciosCollection��5      5      �� 5   
   -   5        8   5      5      .��5      � .+�5   
   �� -   5        $��label1��5   [   $��Fecha��6   $��28��6    $
��Left=�6,   $��
135,12,0,0q�6G   $	��Top=�6i   �� 5   
   -   5        $��label2��5   \   $��Origen��6   $��28��6!   $
��Left=�6-   $��
264,12,0,0q�6H   $	��Top=�6j   �� 5   
   -   5        $��label3��5   ]   $��Destino��6   $��28��6"   $
��Left=�6.   $��
403,12,0,0q�6I   $	��Top=�6k   �� 5   
   -   5        $��	btnUpdate��5   M   $��32��6   $��Right=�6   $��
0,168,50,0q�69     btnTemplateReloadUser#��[ 6^   $	��Top=�6�   $��29��6�    � ToolTip$ Ver todos los Servicios��5   .   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpFecha��5   O   $��25��6   $
��Left=�6!   $��	94,37,0,0q�6<   $	��Top=�6^   $	��115��6v   �� 5   
   -   5        $��	cmbOrigen��5        �� DisplayMemberPath$ 
Ter_Nombre��5   Q    �� SelectedValuePath$ 
Ter_Codigo��6p   $��23��5    $   $
��Left=�60   $��
230,39,0,0q�6K   $	��Top=�6_   $	��120��6w   ��5      ��  �� Source# [  5    w   �� 5!   
   -	   5        $��
cmbDestino��5"      $ 
Ter_Nombre��5!   Q   $ 
Ter_Codigo��6p   $��23��5"   %   $
��Left=�61   $��
367,39,0,0q�6L   $	��Top=�6`   $	��120��6x   ��5!      �� # [  5"   x   �� 5#   
   -
   5        $��	btnBuscar��5#   L   $��26��6   $
��Left=�6   $��
501,36,0,0q�68   $	��Top=�6]   $��32��6u     btnTemplateSearch#��[ 6�   $ Buscar��5$   .   �� 5%   
   -   5        	 ��Name$	 lstServicios��5%      $��81,78,104,31q�6x   ��6)   �� # [ 
 �� View
 5&      �� 5'      .P�5(      �� $��ID Servicio��6%    �� Width$
 Auto��6k    �� DisplayMemberBinding 6:   ��  �� Path$ 
Ser_Codigo�6k   �� 5)      $��Fecha��6%   $
 Auto��6h    64   �� $ Ser_FechaHora�6h   �� 5*      $��Tipo Servicio��6%   $
 Auto��6s    6<   �� $ Aut_TipoServicio�6s   �� 5+      $��Terminal Origen��6%   $
 Auto��6o    6>   �� $ 
Ter_Origen�6o   �� 5,      $��Terminal Destino��6%   $
 Auto��6q    6?   �� $ Ter_Destino�6q   �� 5-      $��
Matrícula��6%   $
 Auto��6l    68   �� $ Aut_Matricula�6l   �� 5.      $��Pisos��6%   $
 Auto��6d    64   �� $ 	Aut_Pisos�6d   �� 5/      $��	Capacidad��6%   $
 Auto��6l    68   �� $ Aut_Capacidad�6l   �� 50      $��Empresa��6%   $
 Auto��6g    66   �� $ 
Emp_Nombre�6g   �� 51      $��	Teléfono��6%   $
 Auto��6j    67   �� $ Emp_Telefono�6j   �� 52      $��
Dirección��6%   $
 Auto��6l    68   �� $ Emp_Direccion�6l   �� 53      $��E-mail��6%   $
 Auto��6e    65   �� $ 	Emp_Email�6e   54      56      58      59      
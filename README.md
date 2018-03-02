# bikesrental

Precondiciones
- Asumí que podían existir muchas sucursales (en el modelo de dominio cada sucursal se llemaa branch).
- Asumí que pude ocurrir que una persona puede hacer varios alquileres (no necesariamente con descuento familiar). Ejemplo: Un preceptor de un colegio tiene organizada una excursión y necesita 20 bicicletas.

Diseño
- Usé el patrón inyección de dependencias para poder generar escenarios de prueba.
- La interfáz IRentService tiene la responsabilidad de negocio.
- La interfáz IBranchesRepository será la responsable de obtener físicamente un branch.
- Un Branch tiene:
	- Bicicletas disponibles, si no hay disponibilidad no deberíamos poder alquilarlas.
- Se crearon dos tipos de excepciones
	- Excepciones técnicas: No tienen que ver con el negocio. Ante su ocurrencia, deberían loguear contra algo.
	- Excepciones de negocio: Tienen que ver con inputs de usuario o con comportamiento del sistema. Son atendidas y en base al tipo tendrán un comportamiento.
	



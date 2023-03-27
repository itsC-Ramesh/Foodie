Clean Architecture

	Presentation		Infrastructure	->	DB
		|					   |
		------------------------
					|
				Application
					|
				  Domain	
----------------||------------------||--------------||----------||
Presentation	||	Infrastructure	||	Application	||	Domain--||
----------------||------------------||--------------||----------||
API/MVC/UI-SAP	|| Persistance/File System	|| Interface/Models || Entities/ValueObkjects/Exceptions
------------------------------------------------------------------

										

Domain Layer -> Core Logic (at the center of application)
	- Foodie.Domain

Application Layer
	- Foodie.Application

Infrastructure Layer -> Pheripheral stuff like DB, web clients etc.,
	- Foodie.Infrastructure

Presentation Layer
	- Foodie.Contracts -> This will model our API
	- Foodie.API -> This project will listen out the requests


Project Dependencies
	- API				-> Contracts | Application | Infrastructure (Only theoretically it is totally independent but API need to communicate with infra)
	- Infrastructure	-> Application
	- Application		-> Domain

In clean arc. we never want to leak anything from API/Contract i.e presentation layer into Application Layer because in future we may change schemas and it should not affect everywhere and for that Application layer should have dependency of presentation layer



Create database Prueba_Tecnica_AportesEnLinea
use Prueba_Tecnica_AportesEnLinea

Create table Department(
IdDepartament int identity primary key not null,
Name varchar(50)
)

create table Employee(
Id int identity primary key not null,
Name varchar(50),
Email varchar(30),
Salary decimal(10,2),
IdDepartament int not null foreign key  references Department(IdDepartament)
on delete cascade
on update cascade,
Position NVARCHAR(50)
)

INSERT INTO Department(Name)
VALUES ('Ventas');


INSERT INTO Employee (Name, Email, Salary, IdDepartament, Position)
VALUES 
 ('Pedro', 'pedro@hotmail.com', 1000000, 1, 'Developer'),
 ('Maria', 'maria@gmail.com', 2000000.00, 1, 'Developer'),
 ('Bob Johnson','bob@company.com',7000.00, 2, 'Manager'),
 ('Clara Lee', 'clara@company.com', 4500.00, 3, 'HR'),
 ('David Green', 'david@company.com', 4000.00, 4, 'Sales'),
 ('María González', 'maria.gonzalez@company.com', 8000.00, 2, 'Manager'),
 ('Carlos Torres', 'carlos.torres@company.com', 8500.00, 2, 'Manager'),
 ('Sofía Ramírez', 'sofia.ramirez@company.com', 5000.00, 3, 'HR'),
 ('Andrés Mejía', 'andres.mejia@company.com', 5200.00, 3, 'HR'),
 ('Pedro Salazar', 'pedro.salazar@company.com', 4500.00, 4, 'Sales'),
 ('Camila López', 'camila.lopez@company.com', 4700.00, 4, 'Sales');
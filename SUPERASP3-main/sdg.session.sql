CREATE database Eco_lifer;
USE Eco_lifer;	

CREATE TABLE Cadastros1 (
    ID_User INT AUTO_INCREMENT PRIMARY KEY,
    Nome_User VARCHAR(100) not null,
    Email_User VARCHAR(100) not null,
    Senha_User VARCHAR (100) not null,
    CPF VARCHAR(11) NOT NULL
);

ALTER TABLE Cadastros1
MODIFY COLUMN CPF VARCHAR(11) NOT NULL;

CREATE TABLE Produtos1 (
    ID_Produtos INT AUTO_INCREMENT PRIMARY KEY,
    Nome_Produto VARCHAR(100) NOT NULL DEFAULT 'Produto Desconhecido',
    Categoria VARCHAR(100) NOT NULL DEFAULT 'Categoria Desconhecida',
    Estoque INT NOT NULL DEFAULT 0,
    preco_produto DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    descricao VARCHAR(900) NOT NULL DEFAULT 'Sem Descrição'
);

CREATE TABLE Pedidos (
    ID_Pedido INT PRIMARY KEY AUTO_INCREMENT,
    ID_Produtos INT,
    ID_User INT,
    Qtd_pedido INT NOT NULL,
    Data_Pedido DATETIME DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (ID_Produtos) REFERENCES Produtos1(ID_Produtos),
    FOREIGN KEY (ID_User) REFERENCES Cadastros1(ID_User) 
);

CREATE TABLE Funcionarios1 (
    Id_Funcionario INT AUTO_INCREMENT PRIMARY KEY,
    Nome_Funcionario VARCHAR(100) not null,
    Email_Funcionario VARCHAR(200) not null,
    Senha_Funcionario VARCHAR(100) not null,
    Token VARCHAR (255) null
);

select * from Cadastros1;
select * from Produtos1;
select * from Funcionarios1;

DELETE FROM Cadastros1 WHERE ID_User = 1;	
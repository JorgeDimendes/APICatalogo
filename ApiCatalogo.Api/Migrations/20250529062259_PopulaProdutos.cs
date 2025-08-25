using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) 
                                   Values('Coca-Cola Diet', 'Refrigerante de Cola 350 ml',5.45,'cocacola.jpg',50,now(),1)");

            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)
                  Values('Guaraná Antarctica', 'Refrigerante de Guaraná 350 ml',4.99,'guarana.jpg',75,now(),1)");

            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)
                  Values('Água Mineral sem gás', 'Água Mineral sem gás 500 ml',2.50,'agua.jpg',100,now(),2)");

            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)
                  Values('Salgadinho Cheetos', 'Salgadinho de queijo 45g',3.75,'cheetos.jpg',60,now(),2)");

            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)
                  Values('Chocolate Lacta Ao Leite', 'Barra de chocolate ao leite 90g',6.00,'lacta.jpg',40,now(),3)");

            mb.Sql(@"Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)
                  Values('Biscoito Oreo', 'Biscoito recheado de chocolate com creme 140g',4.20,'oreo.jpg',80,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}

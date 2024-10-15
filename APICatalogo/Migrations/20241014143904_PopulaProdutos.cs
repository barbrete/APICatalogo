using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder MigrationBuilder)
        {
            MigrationBuilder.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values('Coca-Cola','Refrigerante de Cola 350 ml','5.45','cocacola.jpg',50,now(),1)");

            MigrationBuilder.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
               "Values('Lanche de Atum','Lanche de Atum com maionesa','8.50','atum.jpg',10,now(),2)");

            MigrationBuilder.Sql("insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
               "Values('Pudim 100g','Pudim de leite condensado 100 g','6.75','pudim.jpg',20,now(),3)");
        }

        protected override void Down(MigrationBuilder MigrationBuilder)
        {
            MigrationBuilder.Sql("Delete FROM Produtos");
        }
    }
}

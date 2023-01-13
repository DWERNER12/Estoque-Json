using EstoqueJson.Models;
using Newtonsoft.Json;

List<Produto> produtos = new List<Produto>();
Produto produto = new Produto();



bool exibeMenu = true;
while (exibeMenu)
{
    Console.Clear();
    Console.WriteLine("Escolha uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar produto");
    Console.WriteLine("2 - Listar produtos cadastrados");
    Console.WriteLine("3 - Quantidade total de itens no estoque");
    Console.WriteLine("4 - Sair");
    var opcaoMenu = Convert.ToInt16(Console.ReadLine());


    switch (opcaoMenu)
    {
        case 1:
           
            Console.WriteLine("Informe o codigo do Produto:");
            var codigoProduto = Convert.ToInt32(Console.ReadLine());
            produto.Codigo = codigoProduto;
            Console.WriteLine("Informe o nome do Produto:");
            var nomeProduto = Console.ReadLine();
            produto.NomeProduto = nomeProduto;

            var novoProduto = new Produto() {  Codigo = codigoProduto, NomeProduto = nomeProduto };
            produtos.Add(novoProduto);

            string salvarEmJson = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            File.WriteAllText("Arquivos/Estoque.json", salvarEmJson);

            break;
        case 2:
            Console.WriteLine("Produtos em estoque:");
            string conteudoAquivo = File.ReadAllText("Arquivos/Estoque.json");

            List<Produto> listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(conteudoAquivo);

            foreach (Produto produtosJson in listaProdutos)
            {
                Console.WriteLine($"Codigo: {produtosJson.Codigo}");
                Console.WriteLine($"Nome: {produtosJson.NomeProduto}");
                Console.WriteLine($"Quantidade: {produtosJson.Quantidade}");
            }
            break;
        case 3:
            Console.WriteLine("Quantidades de produtos em estoque:");
            Console.Write($"{produtos.Count}");
            break;
        case 4:
            exibeMenu = false;
            break;
        default:

            break;
    }
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}
Console.WriteLine("O programa se encerrou");

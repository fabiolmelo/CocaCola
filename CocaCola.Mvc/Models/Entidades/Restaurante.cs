using CocaCola.Mvc.Extensoes;

namespace CocaCola.Mvc.Models.Entidades
{
    public class Restaurante 
    {
        public int Id { get; set; }
        public string Cnpj { get; set; } = String.Empty; 
        public string RazaoSocial { get; set; } = String.Empty;
        public string Cidade { get; set; } = String.Empty; 
        public string Uf { get; set; } = String.Empty; 
        public ICollection<ExtratoVenda> ExtratoVendas { get; private set; } = new List<ExtratoVenda>();
        public string MesCompetencia => $"{this.ExtratoMesCompetencia.Competencia.
                                                ToString("MMMM yyyy").PriMaiuscula()}"; 
        public ExtratoVenda ExtratoMesCompetencia => this.ExtratoVendas.
                                                     OrderByDescending(x=>x.Mes).
                                                     ElementAt(0); 
        public int? RedeId { get; set; }    
        public Rede? Rede { get; set; }
        public Restaurante()
        {
        }

        public void AdicionarExtrato(ExtratoVenda extratoVenda){
            this.ExtratoVendas.Add(extratoVenda);
        }
        public void AdicionarExtratos(List<ExtratoVenda> extratosVenda){
            foreach(var extrato in extratosVenda){
                this.ExtratoVendas.Add(extrato);
            }
        }
    }
}
using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("tbArtigos")]
    public partial class TbArtigos : EntityBase
    {
        public TbArtigos()
        {
            TbArtigosAlternativosIdartigoAlternativoNavigation = new HashSet<TbArtigosAlternativos>();
            TbArtigosAlternativosIdartigoNavigation = new HashSet<TbArtigosAlternativos>();
            TbArtigosAnexos = new HashSet<TbArtigosAnexos>();
            TbArtigosArmazensLocalizacoes = new HashSet<TbArtigosArmazensLocalizacoes>();
            TbArtigosAssociadosIdartigoAssociadoNavigation = new HashSet<TbArtigosAssociados>();
            TbArtigosAssociadosIdartigoNavigation = new HashSet<TbArtigosAssociados>();
            TbArtigosComponentesIdartigoComponenteNavigation = new HashSet<TbArtigosComponentes>();
            TbArtigosComponentesIdartigoNavigation = new HashSet<TbArtigosComponentes>();
            TbArtigosDimensoes = new HashSet<TbArtigosDimensoes>();
            TbArtigosIdiomas = new HashSet<TbArtigosIdiomas>();
            TbArtigosLotes = new HashSet<TbArtigosLotes>();
            TbArtigosNumerosSeries = new HashSet<TbArtigosNumerosSeries>();
            TbArtigosPrecos = new HashSet<TbArtigosPrecos>();
            TbArtigosStock = new HashSet<TbArtigosStock>();
            TbArtigosUnidades = new HashSet<TbArtigosUnidades>();
            TbCalculoComparticipacoesArtigos = new HashSet<TbCalculoComparticipacoesArtigos>();
            TbCcstockArtigos = new HashSet<TbCcstockArtigos>();
            TbDocumentosStockLinhas = new HashSet<TbDocumentosStockLinhas>();
            TbDocumentosVendasLinhas = new HashSet<TbDocumentosVendasLinhas>();
            TbProcessamentoUtentesLinhas = new HashSet<TbProcessamentoUtentesLinhas>();
            TbStockArtigos = new HashSet<TbStockArtigos>();
            TbUtentesValenciasArtigos = new HashSet<TbUtentesValenciasArtigos>();
            TbValenciasArtigosIdartigoNavigation = new HashSet<TbValenciasArtigos>();
            TbValenciasArtigosIdartigoReducaoNavigation = new HashSet<TbValenciasArtigos>();
        }

        
        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }
        [Column("IDFamilia")]
        public long? Idfamilia { get; set; }
        [Column("IDSubFamilia")]
        public long? IdsubFamilia { get; set; }
        [Column("IDTipoArtigo")]
        public long? IdtipoArtigo { get; set; }
        [Column("IDComposicao")]
        public long? Idcomposicao { get; set; }
        [Column("IDTipoComposicao")]
        public long? IdtipoComposicao { get; set; }
        [Column("IDGrupoArtigo")]
        public long? IdgrupoArtigo { get; set; }
        [Column("IDMarca")]
        public long? Idmarca { get; set; }
        [StringLength(50)]
        public string CodigoBarras { get; set; }
        [Column("QRCode")]
        [StringLength(50)]
        public string Qrcode { get; set; }
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        [StringLength(20)]
        public string DescricaoAbreviada { get; set; }
        public string Observacoes { get; set; }
        public bool? GereLotes { get; set; }
        public bool? GereStock { get; set; }
        public bool? GereNumeroSerie { get; set; }
        public bool? DescricaoVariavel { get; set; }
        [Column("IDTipoDimensao")]
        public long? IdtipoDimensao { get; set; }
        [Column("IDDimensaoPrimeira")]
        public long? IddimensaoPrimeira { get; set; }
        [Column("IDDimensaoSegunda")]
        public long? IddimensaoSegunda { get; set; }
        [Column("IDOrdemLoteApresentar")]
        public long? IdordemLoteApresentar { get; set; }
        [Column("IDUnidade")]
        public long? Idunidade { get; set; }
        [Column("IDUnidadeVenda")]
        public long? IdunidadeVenda { get; set; }
        [Column("IDUnidadeCompra")]
        public long? IdunidadeCompra { get; set; }
        [StringLength(20)]
        public string VariavelContabilidade { get; set; }
        [Column("Ativo")]
        public override bool IsActive { get; set; }
        [Column("Sistema")]
        public override bool IsSystem { get; set; }
        [Column("DataCriacao")]
        public override DateTime CreatedAt { get; set; }
        [Required]
        [StringLength(256)]
        [Column("UtilizadorCriacao")]
        public override string CreatedBy { get; set; }
        [Column("DataAlteracao")]
        public override DateTime? UpdatedAt { get; set; }
        [StringLength(256)]
        [Column("UtilizadorAlteracao")]
        public override string UpdatedBy { get; set; }
        [Column("F3MMarcador")]
        public override byte[] F3MMarker { get; set; }
        [Column("IDEstacao")]
        public long? Idestacao { get; set; }
        [Column("NE")]
        public double? Ne { get; set; }
        [Column("DTEX")]
        public double? Dtex { get; set; }
        [StringLength(25)]
        public string CodigoEstatistico { get; set; }
        public double? LimiteMax { get; set; }
        public double? LimiteMin { get; set; }
        public double? Reposicao { get; set; }
        [Column("IDOrdemLoteMovEntrada")]
        public long? IdordemLoteMovEntrada { get; set; }
        [Column("IDOrdemLoteMovSaida")]
        public long? IdordemLoteMovSaida { get; set; }
        [Column("IDTaxa")]
        public long? Idtaxa { get; set; }
        public double? DedutivelPercentagem { get; set; }
        public double? IncidenciaPercentagem { get; set; }
        public double? UltimoPrecoCusto { get; set; }
        public double? Medio { get; set; }
        public double? Padrao { get; set; }
        public double? UltimosCustosAdicionais { get; set; }
        public double? UltimosDescontosComerciais { get; set; }
        public double? UltimoPrecoCompra { get; set; }
        [Column("TotalQuantidadeVSUPC")]
        public double? TotalQuantidadeVsupc { get; set; }
        [Column("TotalQuantidadeVSPCM")]
        public double? TotalQuantidadeVspcm { get; set; }
        [Column("TotalQuantidadeVSPCPadrao")]
        public double? TotalQuantidadeVspcpadrao { get; set; }
        [Column("IDTiposComponente")]
        public long? IdtiposComponente { get; set; }
        [Column("IDCompostoTransformacaoMetodoCusto")]
        public long? IdcompostoTransformacaoMetodoCusto { get; set; }
        [Column("IDImpostoSelo")]
        public long? IdimpostoSelo { get; set; }
        [Column("FatorFTOFPercentagem")]
        public double? FatorFtofpercentagem { get; set; }
        [StringLength(255)]
        public string Foto { get; set; }
        public string FotoCaminho { get; set; }
        [Column("IDUnidadeStock2")]
        public long? IdunidadeStock2 { get; set; }
        [Column("IDTipoPreco")]
        public long? IdtipoPreco { get; set; }
        [Column("CodigoAT")]
        [StringLength(20)]
        public string CodigoAt { get; set; }
        [Column("RestituicaoIVA")]
        public bool? RestituicaoIva { get; set; }
        public long? Torcao { get; set; }
        [Column("IDTipoDocumentoUPC")]
        public long? IdtipoDocumentoUpc { get; set; }
        [Column("IDDocumentoUPC")]
        public long? IddocumentoUpc { get; set; }
        [Column("DataControloUPC", TypeName = "datetime")]
        public DateTime? DataControloUpc { get; set; }
        [Column("RecalculaUPC")]
        public bool? RecalculaUpc { get; set; }

        [ForeignKey("IddimensaoPrimeira")]
        [InverseProperty("TbArtigosIddimensaoPrimeiraNavigation")]
        public virtual TbDimensoes IddimensaoPrimeiraNavigation { get; set; }
        [ForeignKey("IddimensaoSegunda")]
        [InverseProperty("TbArtigosIddimensaoSegundaNavigation")]
        public virtual TbDimensoes IddimensaoSegundaNavigation { get; set; }
        [ForeignKey("Idfamilia")]
        [InverseProperty("TbArtigos")]
        public virtual TbFamilias IdfamiliaNavigation { get; set; }
        [ForeignKey("IdgrupoArtigo")]
        [InverseProperty("TbArtigos")]
        public virtual TbGruposArtigo IdgrupoArtigoNavigation { get; set; }
        [ForeignKey("IdimpostoSelo")]
        [InverseProperty("TbArtigos")]
        public virtual TbImpostoSelo IdimpostoSeloNavigation { get; set; }
        [ForeignKey("IdordemLoteApresentar")]
        [InverseProperty("TbArtigosIdordemLoteApresentarNavigation")]
        public virtual TbSistemaOrdemLotes IdordemLoteApresentarNavigation { get; set; }
        [ForeignKey("IdordemLoteMovEntrada")]
        [InverseProperty("TbArtigosIdordemLoteMovEntradaNavigation")]
        public virtual TbSistemaOrdemLotes IdordemLoteMovEntradaNavigation { get; set; }
        [ForeignKey("IdordemLoteMovSaida")]
        [InverseProperty("TbArtigosIdordemLoteMovSaidaNavigation")]
        public virtual TbSistemaOrdemLotes IdordemLoteMovSaidaNavigation { get; set; }
        [ForeignKey("IdsubFamilia")]
        [InverseProperty("TbArtigos")]
        public virtual TbSubFamilias IdsubFamiliaNavigation { get; set; }
        [ForeignKey("Idtaxa")]
        [InverseProperty("TbArtigos")]
        public virtual TbIva IdtaxaNavigation { get; set; }
        [ForeignKey("IdtipoArtigo")]
        [InverseProperty("TbArtigos")]
        public virtual TbTiposArtigos IdtipoArtigoNavigation { get; set; }
        [ForeignKey("IdtipoDocumentoUpc")]
        [InverseProperty("TbArtigos")]
        public virtual TbTiposDocumento IdtipoDocumentoUpcNavigation { get; set; }
        [ForeignKey("IdtipoPreco")]
        [InverseProperty("TbArtigos")]
        public virtual TbSistemaTiposPrecos IdtipoPrecoNavigation { get; set; }
        [ForeignKey("IdunidadeCompra")]
        [InverseProperty("TbArtigosIdunidadeCompraNavigation")]
        public virtual TbUnidades IdunidadeCompraNavigation { get; set; }
        [ForeignKey("Idunidade")]
        [InverseProperty("TbArtigosIdunidadeNavigation")]
        public virtual TbUnidades IdunidadeNavigation { get; set; }
        [ForeignKey("IdunidadeStock2")]
        [InverseProperty("TbArtigosIdunidadeStock2Navigation")]
        public virtual TbUnidades IdunidadeStock2Navigation { get; set; }
        [ForeignKey("IdunidadeVenda")]
        [InverseProperty("TbArtigosIdunidadeVendaNavigation")]
        public virtual TbUnidades IdunidadeVendaNavigation { get; set; }
        [InverseProperty("IdartigoAlternativoNavigation")]
        public virtual ICollection<TbArtigosAlternativos> TbArtigosAlternativosIdartigoAlternativoNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosAlternativos> TbArtigosAlternativosIdartigoNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosAnexos> TbArtigosAnexos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosArmazensLocalizacoes> TbArtigosArmazensLocalizacoes { get; set; }
        [InverseProperty("IdartigoAssociadoNavigation")]
        public virtual ICollection<TbArtigosAssociados> TbArtigosAssociadosIdartigoAssociadoNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosAssociados> TbArtigosAssociadosIdartigoNavigation { get; set; }
        [InverseProperty("IdartigoComponenteNavigation")]
        public virtual ICollection<TbArtigosComponentes> TbArtigosComponentesIdartigoComponenteNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosComponentes> TbArtigosComponentesIdartigoNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosDimensoes> TbArtigosDimensoes { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosIdiomas> TbArtigosIdiomas { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosLotes> TbArtigosLotes { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosNumerosSeries> TbArtigosNumerosSeries { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosPrecos> TbArtigosPrecos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosStock> TbArtigosStock { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosUnidades> TbArtigosUnidades { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbCalculoComparticipacoesArtigos> TbCalculoComparticipacoesArtigos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbCcstockArtigos> TbCcstockArtigos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbDocumentosStockLinhas> TbDocumentosStockLinhas { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbDocumentosVendasLinhas> TbDocumentosVendasLinhas { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbProcessamentoUtentesLinhas> TbProcessamentoUtentesLinhas { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbStockArtigos> TbStockArtigos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbUtentesValenciasArtigos> TbUtentesValenciasArtigos { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbValenciasArtigos> TbValenciasArtigosIdartigoNavigation { get; set; }
        [InverseProperty("IdartigoReducaoNavigation")]
        public virtual ICollection<TbValenciasArtigos> TbValenciasArtigosIdartigoReducaoNavigation { get; set; }
    }
}

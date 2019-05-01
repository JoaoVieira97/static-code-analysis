using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("tbUtentes")]
    public partial class TbUtentes : EntityBase
    {
        public TbUtentes()
        {
            TbCccofreEntidades = new HashSet<TbCccofreEntidades>();
            TbCcentidades = new HashSet<TbCcentidades>();
            TbContratosUtentes = new HashSet<TbContratosUtentes>();
            TbDevolucoesUtentes = new HashSet<TbDevolucoesUtentes>();
            TbDocumentosVendasUtentes = new HashSet<TbDocumentosVendasUtentes>();
            TbMovimentosCofre = new HashSet<TbMovimentosCofre>();
            TbProcessamentoUtentes = new HashSet<TbProcessamentoUtentes>();
            TbRecibosUtentes = new HashSet<TbRecibosUtentes>();
            TbSaldosEntidades = new HashSet<TbSaldosEntidades>();
            TbUtentesAnexos = new HashSet<TbUtentesAnexos>();
            TbUtentesAusenciasSaidas = new HashSet<TbUtentesAusenciasSaidas>();
            TbUtentesPrevisaoRendimentos = new HashSet<TbUtentesPrevisaoRendimentos>();
            TbUtentesResponsaveis = new HashSet<TbUtentesResponsaveis>();
            TbUtentesValencias = new HashSet<TbUtentesValencias>();
        }

        [Column("IDEntidadeRegistada")]
        public long? IdentidadeRegistada { get; set; }
        
        [Column("IDSituacaoEconomica")]
        public long? IdsituacaoEconomica { get; set; }
        [Column("IDGrauDeficienciaIncapacidade")]
        public long? IdgrauDeficienciaIncapacidade { get; set; }
        public double? GrauDeficienciaIncapacidade { get; set; }
        public string FichaSocial { get; set; }
        public string Obs { get; set; }
        public string AvisosDocumentos { get; set; }
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

        [ForeignKey("IdentidadeRegistada")]
        [InverseProperty("TbUtentes")]
        public virtual TbEntidadesRegistadas IdentidadeRegistadaNavigation { get; set; }
        [ForeignKey("IdgrauDeficienciaIncapacidade")]
        [InverseProperty("TbUtentes")]
        public virtual TbGrausDeficienciaIncapacidade IdgrauDeficienciaIncapacidadeNavigation { get; set; }
        [ForeignKey("IdsituacaoEconomica")]
        [InverseProperty("TbUtentes")]
        public virtual TbSituacoesEconomicas IdsituacaoEconomicaNavigation { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbCccofreEntidades> TbCccofreEntidades { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbCcentidades> TbCcentidades { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbContratosUtentes> TbContratosUtentes { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbDevolucoesUtentes> TbDevolucoesUtentes { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbDocumentosVendasUtentes> TbDocumentosVendasUtentes { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbMovimentosCofre> TbMovimentosCofre { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbProcessamentoUtentes> TbProcessamentoUtentes { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbRecibosUtentes> TbRecibosUtentes { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbSaldosEntidades> TbSaldosEntidades { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbUtentesAnexos> TbUtentesAnexos { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbUtentesAusenciasSaidas> TbUtentesAusenciasSaidas { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbUtentesPrevisaoRendimentos> TbUtentesPrevisaoRendimentos { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbUtentesResponsaveis> TbUtentesResponsaveis { get; set; }
        [InverseProperty("IdutenteNavigation")]
        public virtual ICollection<TbUtentesValencias> TbUtentesValencias { get; set; }
    }
}

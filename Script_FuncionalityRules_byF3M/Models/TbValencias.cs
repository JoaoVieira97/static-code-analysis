using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("tbValencias")]
    public partial class TbValencias : EntityBase
    {
        public TbValencias()
        {
            TbAtendimentos = new HashSet<TbAtendimentos>();
            TbCalculoComparticipacoes = new HashSet<TbCalculoComparticipacoes>();
            TbContratosUtentes = new HashSet<TbContratosUtentes>();
            TbDocumentosVendasLinhasUtentes = new HashSet<TbDocumentosVendasLinhasUtentes>();
            TbProcessamentoUtentes = new HashSet<TbProcessamentoUtentes>();
            TbTiposContrato = new HashSet<TbTiposContrato>();
            TbUtentesCandidatosValencias = new HashSet<TbUtentesCandidatosValencias>();
            TbUtentesValencias = new HashSet<TbUtentesValencias>();
            TbValenciasAnexos = new HashSet<TbValenciasAnexos>();
            TbValenciasArtigos = new HashSet<TbValenciasArtigos>();
            TbValenciasCalcMensalDef = new HashSet<TbValenciasCalcMensalDef>();
            TbValenciasComparticipacoes = new HashSet<TbValenciasComparticipacoes>();
            TbValenciasCriteriosSelecao = new HashSet<TbValenciasCriteriosSelecao>();
            TbValenciasDocsInscricao = new HashSet<TbValenciasDocsInscricao>();
        }

        
        [StringLength(20)]
        public string Codigo { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
        [Column("IDEstabelecimento")]
        public long? Idestabelecimento { get; set; }
        [Column("IDAreaValencia")]
        public long? IdareaValencia { get; set; }
        [Column("IDTipologiaValencia")]
        public long? IdtipologiaValencia { get; set; }
        [Column("IDTipoRespostaSocial")]
        public long? IdtipoRespostaSocial { get; set; }
        [Column("IDCAE")]
        public long? Idcae { get; set; }
        [Column("IDSeguradora")]
        public long? Idseguradora { get; set; }
        [StringLength(50)]
        public string Ramo { get; set; }
        [StringLength(20)]
        public string Apolice { get; set; }
        public string Obs { get; set; }
        public string AvisosDocumentos { get; set; }
        public int? CapacidadeTotal { get; set; }
        public int? OcupacaoTotal { get; set; }
        public int? LivreTotal { get; set; }
        public int? CapacidadeAcordo { get; set; }
        public int? OcupacaoAcordo { get; set; }
        public int? LivreAcordo { get; set; }
        public int? CapacidadeCativos { get; set; }
        public int? OcupacaoCativos { get; set; }
        public int? LivreCativos { get; set; }
        public int? CapacidadeForaAcordo { get; set; }
        public int? OcupacaoForaAcordo { get; set; }
        public int? LivreForaAcordo { get; set; }
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
        [Column("PrecosComIVAIncluido")]
        public bool? PrecosComIvaincluido { get; set; }

        [ForeignKey("IdareaValencia")]
        [InverseProperty("TbValencias")]
        public virtual TbSistemaAreaValencia IdareaValenciaNavigation { get; set; }
        [ForeignKey("Idcae")]
        [InverseProperty("TbValencias")]
        public virtual TbParametrosEmpresaCae IdcaeNavigation { get; set; }
        [ForeignKey("Idestabelecimento")]
        [InverseProperty("TbValencias")]
        public virtual TbEstabelecimentos IdestabelecimentoNavigation { get; set; }
        [ForeignKey("Idseguradora")]
        [InverseProperty("TbValencias")]
        public virtual TbSeguradoras IdseguradoraNavigation { get; set; }
        [ForeignKey("IdtipoRespostaSocial")]
        [InverseProperty("TbValencias")]
        public virtual TbTiposRespostaSocial IdtipoRespostaSocialNavigation { get; set; }
        [ForeignKey("IdtipologiaValencia")]
        [InverseProperty("TbValencias")]
        public virtual TbSistemaTipologiasValencia IdtipologiaValenciaNavigation { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbAtendimentos> TbAtendimentos { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbCalculoComparticipacoes> TbCalculoComparticipacoes { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbContratosUtentes> TbContratosUtentes { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbDocumentosVendasLinhasUtentes> TbDocumentosVendasLinhasUtentes { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbProcessamentoUtentes> TbProcessamentoUtentes { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbTiposContrato> TbTiposContrato { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbUtentesCandidatosValencias> TbUtentesCandidatosValencias { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbUtentesValencias> TbUtentesValencias { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasAnexos> TbValenciasAnexos { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasArtigos> TbValenciasArtigos { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasCalcMensalDef> TbValenciasCalcMensalDef { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasComparticipacoes> TbValenciasComparticipacoes { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasCriteriosSelecao> TbValenciasCriteriosSelecao { get; set; }
        [InverseProperty("IdvalenciaNavigation")]
        public virtual ICollection<TbValenciasDocsInscricao> TbValenciasDocsInscricao { get; set; }
    }
}

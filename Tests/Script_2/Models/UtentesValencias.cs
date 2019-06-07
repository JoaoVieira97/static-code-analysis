using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("tbUtentesValencias")]
    public partial class UtentesValencias : EntityBase
    {
        public TbUtentesValencias()
        {
            TbDocumentosVendasLinhasUtentes = new HashSet<TbDocumentosVendasLinhasUtentes>();
            TbProcessamentoUtentes = new HashSet<TbProcessamentoUtentes>();
            TbUtentesAusenciasSaidas = new HashSet<TbUtentesAusenciasSaidas>();
            TbUtentesValenciasArtigos = new HashSet<TbUtentesValenciasArtigos>();
            TbUtentesValenciasDocsInscricao = new HashSet<TbUtentesValenciasDocsInscricao>();
        }

        
        [Column("IDUtente")]
        public long? Idutente { get; set; }
        [Column("IDCAE")]
        public long? Idcae { get; set; }
        [Column("IDValencia")]
        public long? Idvalencia { get; set; }
        [Column("IDSala")]
        public long? Idsala { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInscricao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAdmissao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataRenovacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataSaida { get; set; }
        public bool? Gratuito { get; set; }
        public bool? EntraMedia { get; set; }
        [Column("VagaCativaSS")]
        public bool? VagaCativaSs { get; set; }
        [Column("IDAcordo")]
        public long? Idacordo { get; set; }
        [Column("IDContrato")]
        public long? Idcontrato { get; set; }
        [Column("IDSalaLocalizacao")]
        public long? IdsalaLocalizacao { get; set; }
        public string Obs { get; set; }
        [Column("Ativo")]
        public bool IsActive { get; set; }
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

        [ForeignKey("Idacordo")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbAcordos IdacordoNavigation { get; set; }
        [ForeignKey("Idcae")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbParametrosEmpresaCae IdcaeNavigation { get; set; }
        [ForeignKey("Idcontrato")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbContratosUtentes IdcontratoNavigation { get; set; }
        [ForeignKey("IdsalaLocalizacao")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbSalasLocalizacoes IdsalaLocalizacaoNavigation { get; set; }
        [ForeignKey("Idsala")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbSalas IdsalaNavigation { get; set; }
        [ForeignKey("Idutente")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbUtentes IdutenteNavigation { get; set; }
        [ForeignKey("Idvalencia")]
        [InverseProperty("TbUtentesValencias")]
        public virtual TbValencias IdvalenciaNavigation { get; set; }
        [InverseProperty("IdutenteValenciaNavigation")]
        public virtual ICollection<TbDocumentosVendasLinhasUtentes> TbDocumentosVendasLinhasUtentes { get; set; }
        [InverseProperty("IdutenteValenciaNavigation")]
        public virtual ICollection<TbProcessamentoUtentes> TbProcessamentoUtentes { get; set; }
        [InverseProperty("IdutentesValenciasNavigation")]
        public virtual ICollection<TbUtentesAusenciasSaidas> TbUtentesAusenciasSaidas { get; set; }
        [InverseProperty("IdutenteValenciaNavigation")]
        public virtual ICollection<TbUtentesValenciasArtigos> TbUtentesValenciasArtigos { get; set; }
        [InverseProperty("IdutenteValenciaNavigation")]
        public virtual ICollection<TbUtentesValenciasDocsInscricao> TbUtentesValenciasDocsInscricao { get; set; }
    }
}

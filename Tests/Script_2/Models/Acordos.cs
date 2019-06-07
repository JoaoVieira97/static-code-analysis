using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("tbAcordos")]
    public partial class Acordos : EntityBase
    {
        public TbAcordos()
        {
            TbProcessamentoUtentes = new HashSet<TbProcessamentoUtentes>();
            TbUtentesCandidatosValencias = new HashSet<TbUtentesCandidatosValencias>();
            TbUtentesValencias = new HashSet<TbUtentesValencias>();
        }

        [Required]
        [StringLength(6)]
        public string Codigo { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }
        [StringLength(20)]
        public string Abreviatura { get; set; }
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

        [InverseProperty("IdacordoNavigation")]
        public virtual ICollection<TbProcessamentoUtentes> TbProcessamentoUtentes { get; set; }
        [InverseProperty("IdacordoNavigation")]
        public virtual ICollection<TbUtentesCandidatosValencias> TbUtentesCandidatosValencias { get; set; }
        [InverseProperty("IdacordoNavigation")]
        public virtual ICollection<TbUtentesValencias> TbUtentesValencias { get; set; }
    }
}

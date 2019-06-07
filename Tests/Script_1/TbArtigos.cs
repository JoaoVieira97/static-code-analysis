using F3M.Core.Domain.Entity;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    [Table("TbArtigos")]
    public partial class TbArtigos : EntityBase
    {
        public TbArtigos()
        {
            TbArtigosAlternativosIdartigoAlternativoNavigation = new HashSet<TbArtigosAlternativos>();
            TbArtigosAlternativosIdartigoNavigation = new HashSet<TbArtigosAlternativos>();
        }
        
        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }
        [Column("IDFamilia")]
        public long? Idfamilia { get; set; }
        [Column("IDSubFamilia")]
        public long? IdsubFamilia { get; set; }
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
        [Column("DAtaAlteracao")]
        public override DateTime? UpdatedAt { get; set; }
        [StringLength(256)]
        [Column("UtilizadorAlteracao")]
        public override string UpdatedBy { get; set; }
        [Column("F3MMarcador")]
        public override byte[] F3MMarker { get; set; }
        [ForeignKey("IddimensaoPrimeira")]
        [InverseProperty("TbArtigosIddimensaoPrimeiraNavigation")]
        public virtual TbDimensoes IddimensaoPrimeiraNavigation { get; set; }
        [ForeignKey("IDdimensaoSegunda")]
        [InverseProperty("TbArtigosIddimensaoSegundaNavigation")]
        [InverseProperty("IdartigoAlternativoNavigation")]
        public virtual ICollection<TbArtigosAlternativos> TbArtigosAlternativosIdartigoAlternativoNavigation { get; set; }
        [InverseProperty("IdartigoNavigation")]
        public virtual ICollection<TbArtigosAlternativos> TbArtigosAlternativosIdartigoNavigation { get; set; }
    }
}

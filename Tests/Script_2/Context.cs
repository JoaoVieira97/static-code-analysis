using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace F3M.UMinho.Esocial.Units.Data.F3MESR3S1Domain
{
    public partial class F3MESR3S1Context : DbContext
    {

        public F3MESR3S1Context(DbContextOptions<F3MESR3S1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAcordos> TbAcordos { get; set; }
        public virtual DbSet<TbAreas> TbAreas { get; set; }
        public virtual DbSet<TbArtigos> TbArtigos { get; set; }
        public virtual DbSet<TbUtentes> TbUtentes { get; set; }
        public virtual DbSet<TbUtentesValencias> TbUtentesValencias { get; set; }
        public virtual DbSet<TbValencias> TbValencias { get; set; }
        public virtual DbSet<TbArtigosAnexos> TbArtigosAnexos { get; set; }
        
        // Unable to generate entity type for table 'dbo.tbControloDocumentos'. Please see the warning messages.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Server=40.68.193.44,1433;Initial Catalog=F3MESR3S1;Trusted_Connection=false;User ID=SA;Password=qwerty!2#4%6;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<TbAcordos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbAgendamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdareaAgendamentoNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdareaAgendamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAgendamento_tbAreaAgendamento");

                entity.HasOne(d => d.IdprofissionalNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.Idprofissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAgendamento_tbProfissionais");
            });

            modelBuilder.Entity<TbAnexosFuncionalidades>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Tabela).HasDefaultValueSql("('tb')");
            });

            modelBuilder.Entity<TbAnexosFuncionalidadesCopia>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdfuncionalidadeDestinoNavigation)
                    .WithMany(p => p.TbAnexosFuncionalidadesCopiaIdfuncionalidadeDestinoNavigation)
                    .HasForeignKey(d => d.IdfuncionalidadeDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAnexosFuncionalidadesCopia_tbAnexosFuncionalidades2");

                entity.HasOne(d => d.IdfuncionalidadeOrigemNavigation)
                    .WithMany(p => p.TbAnexosFuncionalidadesCopiaIdfuncionalidadeOrigemNavigation)
                    .HasForeignKey(d => d.IdfuncionalidadeOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAnexosFuncionalidadesCopia_tbAnexosFuncionalidades1");
            });

            modelBuilder.Entity<TbAreaAgendamento>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbAreaAgendamento")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbAreas>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbAreas")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbArmazens>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Morada).HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalNavigation)
                    .WithMany(p => p.TbArmazens)
                    .HasForeignKey(d => d.IdcodigoPostal)
                    .HasConstraintName("FK_tbArmazens_tbCodigosPostais");

                entity.HasOne(d => d.IdconcelhoNavigation)
                    .WithMany(p => p.TbArmazens)
                    .HasForeignKey(d => d.Idconcelho)
                    .HasConstraintName("FK_tbArmazens_tbConcelhos");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.TbArmazens)
                    .HasForeignKey(d => d.Iddistrito)
                    .HasConstraintName("FK_tbArmazens_tbDistritos");

                entity.HasOne(d => d.IdlojaNavigation)
                    .WithMany(p => p.TbArmazens)
                    .HasForeignKey(d => d.Idloja)
                    .HasConstraintName("FK_tbArmazens_tbLojas");
            });

            modelBuilder.Entity<TbArmazensLocalizacoes>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdarmazemNavigation)
                    .WithMany(p => p.TbArmazensLocalizacoes)
                    .HasForeignKey(d => d.Idarmazem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArmazensLocalizacoes_tbArmazens");
            });

            modelBuilder.Entity<TbArtigos>(entity =>
            {
                entity.HasIndex(e => e.IsActive)
                    .HasName("IX_tbArtigosAtivo");

                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbArtigosCodigo")
                    .IsUnique();

                entity.HasIndex(e => e.CodigoBarras)
                    .HasName("IX_tbArtigosCodigoBarras");

                entity.HasIndex(e => e.Descricao)
                    .HasName("IX_tbArtigosDescricao");

                entity.HasIndex(e => new { e.Codigo, e.Descricao })
                    .HasName("IX_tbArtigosCodigoDescricao");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.RestituicaoIva).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IddimensaoPrimeiraNavigation)
                    .WithMany(p => p.TbArtigosIddimensaoPrimeiraNavigation)
                    .HasForeignKey(d => d.IddimensaoPrimeira)
                    .HasConstraintName("FK_tbArtigos_tbDimensoes");

                entity.HasOne(d => d.IddimensaoSegundaNavigation)
                    .WithMany(p => p.TbArtigosIddimensaoSegundaNavigation)
                    .HasForeignKey(d => d.IddimensaoSegunda)
                    .HasConstraintName("FK_tbArtigos_tbDimensoes1");

                entity.HasOne(d => d.IdfamiliaNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.Idfamilia)
                    .HasConstraintName("FK_tbArtigos_tbFamilias");

                entity.HasOne(d => d.IdgrupoArtigoNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdgrupoArtigo)
                    .HasConstraintName("FK_tbArtigos_tbGruposArtigo");

                entity.HasOne(d => d.IdimpostoSeloNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdimpostoSelo)
                    .HasConstraintName("FK_tbArtigos_tbImpostoSelo");

                entity.HasOne(d => d.IdordemLoteApresentarNavigation)
                    .WithMany(p => p.TbArtigosIdordemLoteApresentarNavigation)
                    .HasForeignKey(d => d.IdordemLoteApresentar)
                    .HasConstraintName("FK_tbArtigos_tbSistemaOrdemLotes");

                entity.HasOne(d => d.IdordemLoteMovEntradaNavigation)
                    .WithMany(p => p.TbArtigosIdordemLoteMovEntradaNavigation)
                    .HasForeignKey(d => d.IdordemLoteMovEntrada)
                    .HasConstraintName("FK_tbArtigos_tbSistemaOrdemLotes1");

                entity.HasOne(d => d.IdordemLoteMovSaidaNavigation)
                    .WithMany(p => p.TbArtigosIdordemLoteMovSaidaNavigation)
                    .HasForeignKey(d => d.IdordemLoteMovSaida)
                    .HasConstraintName("FK_tbArtigos_tbSistemaOrdemLotes2");

                entity.HasOne(d => d.IdsubFamiliaNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdsubFamilia)
                    .HasConstraintName("FK_tbArtigos_tbSubFamilias");

                entity.HasOne(d => d.IdtaxaNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.Idtaxa)
                    .HasConstraintName("FK_tbArtigos_tbIVA");

                entity.HasOne(d => d.IdtipoArtigoNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdtipoArtigo)
                    .HasConstraintName("FK_tbArtigos_tbTiposArtigos");

                entity.HasOne(d => d.IdtipoDocumentoUpcNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdtipoDocumentoUpc)
                    .HasConstraintName("FK_tbArtigos_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoPrecoNavigation)
                    .WithMany(p => p.TbArtigos)
                    .HasForeignKey(d => d.IdtipoPreco)
                    .HasConstraintName("FK_tbArtigos_tbSistemaTiposPrecos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbArtigosIdunidadeNavigation)
                    .HasForeignKey(d => d.Idunidade)
                    .HasConstraintName("FK_tbArtigos_tbUnidades");

                entity.HasOne(d => d.IdunidadeCompraNavigation)
                    .WithMany(p => p.TbArtigosIdunidadeCompraNavigation)
                    .HasForeignKey(d => d.IdunidadeCompra)
                    .HasConstraintName("FK_tbArtigos_tbUnidades_Compra");

                entity.HasOne(d => d.IdunidadeStock2Navigation)
                    .WithMany(p => p.TbArtigosIdunidadeStock2Navigation)
                    .HasForeignKey(d => d.IdunidadeStock2)
                    .HasConstraintName("FK_tbArtigos_tbUnidadesStock2");

                entity.HasOne(d => d.IdunidadeVendaNavigation)
                    .WithMany(p => p.TbArtigosIdunidadeVendaNavigation)
                    .HasForeignKey(d => d.IdunidadeVenda)
                    .HasConstraintName("FK_tbArtigos_tbUnidades_Venda");
            });

            modelBuilder.Entity<TbArtigosAlternativos>(entity =>
            {
                entity.HasIndex(e => new { e.Idartigo, e.IdartigoAlternativo })
                    .HasName("IX_tbArtigosAlternativos")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosAlternativosIdartigoNavigation)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosAlternativos_tbArtigos");

                entity.HasOne(d => d.IdartigoAlternativoNavigation)
                    .WithMany(p => p.TbArtigosAlternativosIdartigoAlternativoNavigation)
                    .HasForeignKey(d => d.IdartigoAlternativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosAlternativos_tbArtigos_Alternativo");
            });

            modelBuilder.Entity<TbArtigosAnexos>(entity =>
            {
                entity.HasIndex(e => new { e.Idartigo, e.Ficheiro })
                    .HasName("IX_tbArtigosAnexos")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosAnexos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosAnexos_tbArtigos");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbArtigosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbArtigosAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbArtigosArmazensLocalizacoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdarmazemNavigation)
                    .WithMany(p => p.TbArtigosArmazensLocalizacoes)
                    .HasForeignKey(d => d.Idarmazem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosArmazensLocalizacoes_tbArmazens");

                entity.HasOne(d => d.IdarmazemLocalizacaoNavigation)
                    .WithMany(p => p.TbArtigosArmazensLocalizacoes)
                    .HasForeignKey(d => d.IdarmazemLocalizacao)
                    .HasConstraintName("FK_tbArtigosArmazensLocalizacoes_tbArmazensLocalizacoes");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosArmazensLocalizacoes)
                    .HasForeignKey(d => d.Idartigo)
                    .HasConstraintName("FK_tbArtigosArmazensLocalizacoes_tbArtigos");
            });

            modelBuilder.Entity<TbArtigosAssociados>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosAssociadosIdartigoNavigation)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosAssociados_tbArtigos");

                entity.HasOne(d => d.IdartigoAssociadoNavigation)
                    .WithMany(p => p.TbArtigosAssociadosIdartigoAssociadoNavigation)
                    .HasForeignKey(d => d.IdartigoAssociado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosAssociados_tbArtigos_Associado");
            });

            modelBuilder.Entity<TbArtigosComponentes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosComponentesIdartigoNavigation)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosComponentes_tbArtigos");

                entity.HasOne(d => d.IdartigoComponenteNavigation)
                    .WithMany(p => p.TbArtigosComponentesIdartigoComponenteNavigation)
                    .HasForeignKey(d => d.IdartigoComponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosComponentes_tbArtigos1");

                entity.HasOne(d => d.IdsistemaTiposComponenteNavigation)
                    .WithMany(p => p.TbArtigosComponentes)
                    .HasForeignKey(d => d.IdsistemaTiposComponente)
                    .HasConstraintName("FK_tbArtigosComponentes_tbSistemaTiposComponente");
            });

            modelBuilder.Entity<TbArtigosDimensoes>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.Idartigo, e.IddimensaoLinha1, e.IddimensaoLinha2 })
                    .HasName("IX_tbArtigosDimensoes")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosDimensoes)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosDimensoes_tbArtigos");

                entity.HasOne(d => d.IddimensaoLinha1Navigation)
                    .WithMany(p => p.TbArtigosDimensoesIddimensaoLinha1Navigation)
                    .HasForeignKey(d => d.IddimensaoLinha1)
                    .HasConstraintName("FK_tbArtigosDimensoes_tbDimensoesLinhas_1");

                entity.HasOne(d => d.IddimensaoLinha2Navigation)
                    .WithMany(p => p.TbArtigosDimensoesIddimensaoLinha2Navigation)
                    .HasForeignKey(d => d.IddimensaoLinha2)
                    .HasConstraintName("FK_tbArtigosDimensoes_tbDimensoesLinhas_2");

                entity.HasOne(d => d.IdtipoDocumentoUpcNavigation)
                    .WithMany(p => p.TbArtigosDimensoes)
                    .HasForeignKey(d => d.IdtipoDocumentoUpc)
                    .HasConstraintName("FK_tbArtigosDimensoes_IDTipoDocumento");
            });

            modelBuilder.Entity<TbArtigosDimensoesEmpresa>(entity =>
            {

                entity.HasOne(d => d.IdartigosDimensoesNavigation)
                    .WithMany(p => p.TbArtigosDimensoesEmpresa)
                    .HasForeignKey(d => d.IdartigosDimensoes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosDimensoesEmpresa_tbArtigosDimensoes");
            });

            modelBuilder.Entity<TbArtigosIdiomas>(entity =>
            {
                entity.HasIndex(e => new { e.Idartigo, e.Ididioma })
                    .HasName("IX_tbArtigosIdiomas")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosIdiomas)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosIdiomas_tbArtigos");

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbArtigosIdiomas)
                    .HasForeignKey(d => d.Ididioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosIdiomas_tbIdiomas");
            });

            modelBuilder.Entity<TbArtigosLotes>(entity =>
            {
                entity.HasIndex(e => new { e.Idartigo, e.Codigo })
                    .HasName("IX_tbArtigosLotes")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosLotes)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosLotes_tbArtigos");
            });

            modelBuilder.Entity<TbArtigosNumerosSeries>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosNumerosSeries)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosNumerosSeries_IDArtigo");
            });

            modelBuilder.Entity<TbArtigosPrecos>(entity =>
            {
                entity.HasIndex(e => new { e.IdcodigoPreco, e.Idunidade, e.Idartigo })
                    .HasName("IX_tbArtigosPrecos")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosPrecos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosPrecos_tbArtigos");

                entity.HasOne(d => d.IdcodigoPrecoNavigation)
                    .WithMany(p => p.TbArtigosPrecos)
                    .HasForeignKey(d => d.IdcodigoPreco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosPrecos_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbArtigosPrecos)
                    .HasForeignKey(d => d.Idunidade)
                    .HasConstraintName("FK_tbArtigosPrecos_tbUnidades");
            });

            modelBuilder.Entity<TbArtigosStock>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosStock)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosStock_tbArtigos");
            });

            modelBuilder.Entity<TbArtigosUnidades>(entity =>
            {
                entity.HasIndex(e => new { e.Idunidade, e.IdunidadeConversao, e.Idartigo })
                    .HasName("IX_tbArtigosUnidades")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbArtigosUnidades)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosUnidades_tbArtigos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbArtigosUnidadesIdunidadeNavigation)
                    .HasForeignKey(d => d.Idunidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosUnidades_tbUnidades");

                entity.HasOne(d => d.IdunidadeConversaoNavigation)
                    .WithMany(p => p.TbArtigosUnidadesIdunidadeConversaoNavigation)
                    .HasForeignKey(d => d.IdunidadeConversao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbArtigosUnidades_tbUnidades_Conversao");
            });

            modelBuilder.Entity<TbAtendimentoAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdatendimentoNavigation)
                    .WithMany(p => p.TbAtendimentoAnexos)
                    .HasForeignKey(d => d.Idatendimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAtendimentoAnexos_tbAtendimentos");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbAtendimentoAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbAtendimentoAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbAtendimentoAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbAtendimentoAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbAtendimentos>(entity =>
            {
                entity.HasIndex(e => new { e.Serie, e.Numero })
                    .HasName("IX_tbAtendimentos_NumeroAtendimento")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbAtendimentos)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAtendimentos_tbEntidades");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbAtendimentos)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbAtendimentos_tbEstados");

                entity.HasOne(d => d.IdtipoRespostaSocialNavigation)
                    .WithMany(p => p.TbAtendimentos)
                    .HasForeignKey(d => d.IdtipoRespostaSocial)
                    .HasConstraintName("FK_tbAtendimentos_tbTiposRespostaSocial");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbAtendimentos)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbAtendimentos_tbValencias");
            });

            modelBuilder.Entity<TbAtestadoComunicacao>(entity =>
            {
                entity.Property(e => e.Selecionado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdserieNavigation)
                    .WithMany(p => p.TbAtestadoComunicacao)
                    .HasForeignKey(d => d.Idserie)
                    .HasConstraintName("FK_tbATEstadoComunicacao_tbTiposDocumentoSeries");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbAtestadoComunicacao)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .HasConstraintName("FK_tbATEstadoComunicacao_tbTiposDocumento");
            });

            modelBuilder.Entity<TbAtestadoComunicacaoLinhas>(entity =>
            {
                entity.HasOne(d => d.IdatestadoComunicacaoNavigation)
                    .WithMany(p => p.TbAtestadoComunicacaoLinhas)
                    .HasForeignKey(d => d.IdatestadoComunicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbATEstadoComunicacaoLinhas_tbATEstadoComunicacao");
            });

            modelBuilder.Entity<TbBancos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbBloqueamentoMeses>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCalcMensalFormVariaveis>(entity =>
            {
                entity.HasIndex(e => new { e.IdcalcMensalFormula, e.Variavel })
                    .HasName("IX_tbCalcMensalFormVariaveis_Variavel")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormulaNavigation)
                    .WithMany(p => p.TbCalcMensalFormVariaveis)
                    .HasForeignKey(d => d.IdcalcMensalFormula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalcMensalFormVariaveis_tbCalcMensalFormulas");
            });

            modelBuilder.Entity<TbCalcMensalFormVariaveisDef>(entity =>
            {
                entity.HasIndex(e => new { e.IdcalcMensalFormulaDef, e.Variavel })
                    .HasName("IX_tbCalcMensalFormVariaveisDef_Variavel")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormulaDefNavigation)
                    .WithMany(p => p.TbCalcMensalFormVariaveisDef)
                    .HasForeignKey(d => d.IdcalcMensalFormulaDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalcMensalFormVariaveisDef_tbCalcMensalFormulasDef");
            });

            modelBuilder.Entity<TbCalcMensalFormVariaveisQuadros>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormVariavelNavigation)
                    .WithMany(p => p.TbCalcMensalFormVariaveisQuadros)
                    .HasForeignKey(d => d.IdcalcMensalFormVariavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalcMensalFormVariaveisQuadros_tbCalcMensalFormVariaveis");
            });

            modelBuilder.Entity<TbCalcMensalFormVariaveisQuadrosDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormVariavelDefNavigation)
                    .WithMany(p => p.TbCalcMensalFormVariaveisQuadrosDef)
                    .HasForeignKey(d => d.IdcalcMensalFormVariavelDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalcMensalFormVariaveisQuadrosDef_tbCalcMensalFormVariaveisDef");
            });

            modelBuilder.Entity<TbCalcMensalFormulas>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCalcMensalFormulasDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCalculoComparticipacoes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoes)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoes_tbValencias");
            });

            modelBuilder.Entity<TbCalculoComparticipacoesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalculoComparticipacoesNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesAnexos)
                    .HasForeignKey(d => d.IdcalculoComparticipacoes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesAnexos_tbCalculoComparticipacoes");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbCalculoComparticipacoesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbCalculoComparticipacoesAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbCalculoComparticipacoesArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Unidade).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesArtigos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigos_tbArtigos");

                entity.HasOne(d => d.IdcalculoComparticipacoesNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesArtigos)
                    .HasForeignKey(d => d.IdcalculoComparticipacoes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigos_tbCalculoComparticipacoes");

                entity.HasOne(d => d.IdprecoSugeridoNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesArtigos)
                    .HasForeignKey(d => d.IdprecoSugerido)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigos_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesArtigos)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigos_tbIVA");
            });

            modelBuilder.Entity<TbCalculoComparticipacoesArtigosCalcMensal>(entity =>
            {
                entity.HasIndex(e => e.IdcalculoComparticipacaoArtigo)
                    .HasName("IX_tbCalculoComparticipacoesArtigosCalcMensal_IDContexto")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormulaNavigation)
                    .WithMany(p => p.TbCalculoComparticipacoesArtigosCalcMensal)
                    .HasForeignKey(d => d.IdcalcMensalFormula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigosCalcMensal_tbCalcMensalFormulas");

                entity.HasOne(d => d.IdcalculoComparticipacaoArtigoNavigation)
                    .WithOne(p => p.TbCalculoComparticipacoesArtigosCalcMensal)
                    .HasForeignKey<TbCalculoComparticipacoesArtigosCalcMensal>(d => d.IdcalculoComparticipacaoArtigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCalculoComparticipacoesArtigosCalcMensal_tbCalculoComparticipacoesArtigos");
            });

            modelBuilder.Entity<TbCategoriasAnexos>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCategoriasAnexosCopia>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdanexosFuncionalidadesCopiaNavigation)
                    .WithMany(p => p.TbCategoriasAnexosCopia)
                    .HasForeignKey(d => d.IdanexosFuncionalidadesCopia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCategoriasAnexosCopia_tbAnexosFuncionalidadesCopia");

                entity.HasOne(d => d.IdcategoriasAnexosOrigemNavigation)
                    .WithMany(p => p.TbCategoriasAnexosCopia)
                    .HasForeignKey(d => d.IdcategoriasAnexosOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCategoriasAnexosCopia_tbCategoriasAnexos1");
            });

            modelBuilder.Entity<TbCategoriasAnexosFuncionalidades>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdanexosFuncionalidadesNavigation)
                    .WithMany(p => p.TbCategoriasAnexosFuncionalidades)
                    .HasForeignKey(d => d.IdanexosFuncionalidades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCategoriasAnexosFuncionalidades_tbAnexosFuncionalidades");

                entity.HasOne(d => d.IdcategoriasAnexosNavigation)
                    .WithMany(p => p.TbCategoriasAnexosFuncionalidades)
                    .HasForeignKey(d => d.IdcategoriasAnexos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCategoriasAnexosFuncionalidades_tbCategoriasAnexos");
            });

            modelBuilder.Entity<TbCategoriasFormulasDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCccofreEntidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbCccofreEntidades)
                    .HasForeignKey(d => d.Identidade)
                    .HasConstraintName("FK_tbCCCofreEntidades_tbEntidades");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbCccofreEntidades)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbCCCofreEntidades_tbMoedas");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbCccofreEntidades)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbCCCofreEntidades_tbUtentes");
            });

            modelBuilder.Entity<TbCcentidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbCcentidades)
                    .HasForeignKey(d => d.Identidade)
                    .HasConstraintName("FK_tbCCEntidades_tbEntidades");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbCcentidades)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbCCEntidades_tbMoedas");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbCcentidades)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .HasConstraintName("FK_tbCCEntidades_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoDocumentoSeriesNavigation)
                    .WithMany(p => p.TbCcentidades)
                    .HasForeignKey(d => d.IdtipoDocumentoSeries)
                    .HasConstraintName("FK_tbCCEntidades_tbTiposDocumentoSeries");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbCcentidades)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbCCEntidades_tbUtentes");
            });

            modelBuilder.Entity<TbCcstockArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdarmazemNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.Idarmazem)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArmazem");

                entity.HasOne(d => d.IdarmazemLocalizacaoNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.IdarmazemLocalizacao)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArmazemLocalizacao");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArtigo");

                entity.HasOne(d => d.IdartigoDimensaoNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.IdartigoDimensao)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArtigoDimensao");

                entity.HasOne(d => d.IdartigoLoteNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.IdartigoLote)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArtigoLote");

                entity.HasOne(d => d.IdartigoNumeroSerieNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.IdartigoNumeroSerie)
                    .HasConstraintName("FK_tbCCStockArtigos_IDArtigoNumeroSerie");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbCCStockArtigos_IDMoeda");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbCcstockArtigosIdtipoDocumentoNavigation)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .HasConstraintName("FK_tbCCStockArtigos_IDTipoDocumento");

                entity.HasOne(d => d.IdtipoDocumentoOrigemNavigation)
                    .WithMany(p => p.TbCcstockArtigosIdtipoDocumentoOrigemNavigation)
                    .HasForeignKey(d => d.IdtipoDocumentoOrigem)
                    .HasConstraintName("FK_tbCCStockArtigos_IDTipoDocumentoOrigem");

                entity.HasOne(d => d.IdtipoEntidadeNavigation)
                    .WithMany(p => p.TbCcstockArtigos)
                    .HasForeignKey(d => d.IdtipoEntidade)
                    .HasConstraintName("FK_tbCCStockArtigos_IDTipoEntidade");
            });

            modelBuilder.Entity<TbCentrosSaude>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbCentrosSaude")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalNavigation)
                    .WithMany(p => p.TbCentrosSaude)
                    .HasForeignKey(d => d.IdcodigoPostal)
                    .HasConstraintName("FK_tbCentrosSaude_tbCodigosPostais");

                entity.HasOne(d => d.IdconcelhoNavigation)
                    .WithMany(p => p.TbCentrosSaude)
                    .HasForeignKey(d => d.Idconcelho)
                    .HasConstraintName("FK_tbCentrosSaude_tbConcelhos");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.TbCentrosSaude)
                    .HasForeignKey(d => d.Iddistrito)
                    .HasConstraintName("FK_tbCentrosSaude_tbDistritos");

                entity.HasOne(d => d.IdfreguesiaNavigation)
                    .WithMany(p => p.TbCentrosSaude)
                    .HasForeignKey(d => d.Idfreguesia)
                    .HasConstraintName("FK_tbCentrosSaude_tbFreguesias");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.TbCentrosSaude)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_tbCentrosSaude_tbPaises");
            });

            modelBuilder.Entity<TbClientes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbCondicoesPagamento");

                entity.HasOne(d => d.IdentidadeRegistadaNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdentidadeRegistada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbEntidadesRegistadas");

                entity.HasOne(d => d.IdespacoFiscalNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdespacoFiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbSistemaEspacoFiscal");

                entity.HasOne(d => d.IdformaExpedicaoNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdformaExpedicao)
                    .HasConstraintName("FK_tbClientes_tbFormasExpedicao");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbFormasPagamento");

                entity.HasOne(d => d.IdlocalOperacaoNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdlocalOperacao)
                    .HasConstraintName("FK_tbClientes_tbSistemaRegioesIVA");

                entity.HasOne(d => d.IdprecoSugeridoNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdprecoSugerido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdregimeIvaNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdregimeIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbSistemaRegimeIVA");
            });

            modelBuilder.Entity<TbCodigosDonativos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbCodigosDonativosCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbCodigosPostais>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Idfreguesia })
                    .HasName("IX_tbCodigosPostaisCodigoFreguesia")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdfreguesiaNavigation)
                    .WithMany(p => p.TbCodigosPostais)
                    .HasForeignKey(d => d.Idfreguesia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCodigosPostais_tbFreguesias");
            });

            modelBuilder.Entity<TbConcelhos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_Concelhos_Codigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.TbConcelhos)
                    .HasForeignKey(d => d.Iddistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbConcelhos_tbDistritos");
            });

            modelBuilder.Entity<TbCondicionantes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdparametroCamposContextoNavigation)
                    .WithMany(p => p.TbCondicionantes)
                    .HasForeignKey(d => d.IdparametroCamposContexto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCondicionantes_IDParametroCamposContexto");
            });

            modelBuilder.Entity<TbCondicoesPagamento>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbCondicoesPagamentoCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbCondicoesPagamentoIdiomas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbCondicoesPagamentoIdiomas)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCondicoesPagamentoIdiomas_tbCondicoesPagamento");

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbCondicoesPagamentoIdiomas)
                    .HasForeignKey(d => d.Ididioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCondicoesPagamentoIdiomas_tbIdiomas");
            });

            modelBuilder.Entity<TbConsentimentos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdparametrizacaoConsentimentosNavigation)
                    .WithMany(p => p.TbConsentimentos)
                    .HasForeignKey(d => d.IdparametrizacaoConsentimentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbConsentimentos_tbParametrizacaoConsentimentos");
            });

            modelBuilder.Entity<TbContratosUtentes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdtipoContratoNavigation)
                    .WithMany(p => p.TbContratosUtentes)
                    .HasForeignKey(d => d.IdtipoContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbContratosUtentes_tbTiposContrato");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbContratosUtentes)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbContratosUtentes_tbUtentes");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbContratosUtentes)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbContratosUtentes_tbValencias");
            });

            modelBuilder.Entity<TbDecIrs>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbDecIrsconfiguracoes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbDecIrsutentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbDecIrsutentesArtigos>(entity =>
            {
                entity.HasOne(d => d.IddecIrsutenteNavigation)
                    .WithMany(p => p.TbDecIrsutentesArtigos)
                    .HasForeignKey(d => d.IddecIrsutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDecIRSUtentesArtigos_tbDecIRSUtentes");
            });

            modelBuilder.Entity<TbDecIrsutentesCaes>(entity =>
            {
                entity.HasOne(d => d.IddecIrsutenteNavigation)
                    .WithMany(p => p.TbDecIrsutentesCaes)
                    .HasForeignKey(d => d.IddecIrsutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDecIRSUtentesCAEs_tbDecIRSUtentes");
            });

            modelBuilder.Entity<TbDevolucoes>(entity =>
            {
                entity.HasIndex(e => new { e.IdtipoDocumento, e.IdtiposDocumentoSeries, e.NumeroDocumento })
                    .HasName("IX_tbDevolucoes_Documento")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbDevolucoes_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbDevolucoes_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbDevolucoes_tbDistritos_Fiscal");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoes_tbEntidades");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbDevolucoes_tbEstados");

                entity.HasOne(d => d.IdfreguesiaFiscalNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdfreguesiaFiscal)
                    .HasConstraintName("FK_tbDevolucoes_tbFreguesias_Fiscal");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbDevolucoes_tbMoedas");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbDevolucoes_tbPaises_Fiscal");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoes_tbTiposDocumento");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbDevolucoes)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoes_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbDevolucoesFormasPagamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddevolucaoNavigation)
                    .WithMany(p => p.TbDevolucoesFormasPagamento)
                    .HasForeignKey(d => d.Iddevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesFormasPagamento_tbDevolucoes");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbDevolucoesFormasPagamento)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesFormasPagamento_tbFormasPagamento");
            });

            modelBuilder.Entity<TbDevolucoesLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddevolucaoNavigation)
                    .WithMany(p => p.TbDevolucoesLinhas)
                    .HasForeignKey(d => d.Iddevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesLinhas_tbRecibos");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDevolucoesLinhas)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesLinhas_tbDocumentosVendas");
            });

            modelBuilder.Entity<TbDevolucoesLinhasArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddevolucaoLinhaNavigation)
                    .WithMany(p => p.TbDevolucoesLinhasArtigos)
                    .HasForeignKey(d => d.IddevolucaoLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesLinhasArtigos_tbDevolucoesLinhas");

                entity.HasOne(d => d.IddocumentoVendaLinhaNavigation)
                    .WithMany(p => p.TbDevolucoesLinhasArtigos)
                    .HasForeignKey(d => d.IddocumentoVendaLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesLinhasArtigos_tbDocumentosVendasLinhas");
            });

            modelBuilder.Entity<TbDevolucoesUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddevolucaoNavigation)
                    .WithMany(p => p.TbDevolucoesUtentes)
                    .HasForeignKey(d => d.Iddevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesUtentes_tbDevolucoes");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbDevolucoesUtentes)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesUtentes_tbUtentes");
            });

            modelBuilder.Entity<TbDevolucoesUtentesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbDevolucoesUtentesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbDevolucoesUtentesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IddevolucoesUtenteNavigation)
                    .WithMany(p => p.TbDevolucoesUtentesAnexos)
                    .HasForeignKey(d => d.IddevolucoesUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDevolucoesUtentesAnexos_tbDevolucoesUtentes");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDevolucoesUtentesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDevolucoesUtentesAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDimensoes>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbDimensoes")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbDimensoesLinhas>(entity =>
            {
                entity.HasIndex(e => e.Ordem)
                    .HasName("IX_tbDimensoesLinhas");

                entity.HasIndex(e => new { e.Descricao, e.Iddimensao })
                    .HasName("IX_tbDimensoesLinhas_IDD_Descricao")
                    .IsUnique();

                entity.HasIndex(e => new { e.Iddimensao, e.Ordem })
                    .HasName("IX_tbDimensoesLinhas_IDD_Ordem")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IddimensaoNavigation)
                    .WithMany(p => p.TbDimensoesLinhas)
                    .HasForeignKey(d => d.Iddimensao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDimensoesLinhas_tbDimensoes");
            });

            modelBuilder.Entity<TbDistritos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbDistritos")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbDoadores>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeRegistadaNavigation)
                    .WithMany(p => p.TbDoadores)
                    .HasForeignKey(d => d.IdentidadeRegistada)
                    .HasConstraintName("FK_tbDoadores_tbEntidadesRegistadas");
            });

            modelBuilder.Entity<TbDoadoresAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbDoadoresAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbDoadoresAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IddoadorNavigation)
                    .WithMany(p => p.TbDoadoresAnexos)
                    .HasForeignKey(d => d.Iddoador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDoadoresAnexos_tbDoadores");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDoadoresAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDoadoresAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDocVendasPagamentoDocumentos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocVendaPagNavigation)
                    .WithMany(p => p.TbDocVendasPagamentoDocumentos)
                    .HasForeignKey(d => d.IddocVendaPag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocVendasPagamentoDocumentos_tbDocumentosVendasPagamento");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocVendasPagamentoDocumentos)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocVendasPagamentoDocumentos_tbDocumentosVendas");
            });

            modelBuilder.Entity<TbDocVendasPagamentoDocumentosLinhasArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocVendaPagamentoDocumentoNavigation)
                    .WithMany(p => p.TbDocVendasPagamentoDocumentosLinhasArtigos)
                    .HasForeignKey(d => d.IddocVendaPagamentoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocVendasPagamentoDocumentosLinhasArtigos_tbDocVendasPagamentoDocumentos");

                entity.HasOne(d => d.IddocumentoVendaLinhaNavigation)
                    .WithMany(p => p.TbDocVendasPagamentoDocumentosLinhasArtigos)
                    .HasForeignKey(d => d.IddocumentoVendaLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocVendasPagamentoDocumentosLinhasArtigos_tbDocumentosVendasLinhas");
            });

            modelBuilder.Entity<TbDocumentosStock>(entity =>
            {
                entity.HasIndex(e => new { e.IdtipoDocumento, e.IdtiposDocumentoSeries, e.NumeroDocumento, e.NumeroInterno })
                    .HasName("IX_tbDocumentosStock_Chave")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.IdcondicaoPagamento).HasDefaultValueSql("((13))");

                entity.Property(e => e.IdlocalOperacao).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalCargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdcodigoPostalCargaNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalCarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbCodigosPostais_Carga");

                entity.HasOne(d => d.IdcodigoPostalDescargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdcodigoPostalDescargaNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalDescarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbCodigosPostais_Descarga");

                entity.HasOne(d => d.IdcodigoPostalDestinatarioNavigation)
                    .WithMany(p => p.TbDocumentosStockIdcodigoPostalDestinatarioNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalDestinatario)
                    .HasConstraintName("FK_tbDocumentosStock_tbCodigosPostais_Destinatario");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockIdcodigoPostalFiscalNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbDocumentosStock_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoCargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdconcelhoCargaNavigation)
                    .HasForeignKey(d => d.IdconcelhoCarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbConcelhos_Carga");

                entity.HasOne(d => d.IdconcelhoDescargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdconcelhoDescargaNavigation)
                    .HasForeignKey(d => d.IdconcelhoDescarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbConcelhos_Descarga");

                entity.HasOne(d => d.IdconcelhoDestinatarioNavigation)
                    .WithMany(p => p.TbDocumentosStockIdconcelhoDestinatarioNavigation)
                    .HasForeignKey(d => d.IdconcelhoDestinatario)
                    .HasConstraintName("FK_tbDocumentosStock_tbConcelhos_Destinatario");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockIdconcelhoFiscalNavigation)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbDocumentosStock_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .HasConstraintName("FK_tbDocumentosStock_tbCondicoesPagamento");

                entity.HasOne(d => d.IddistritoCargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIddistritoCargaNavigation)
                    .HasForeignKey(d => d.IddistritoCarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbDistritos_Carga");

                entity.HasOne(d => d.IddistritoDescargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIddistritoDescargaNavigation)
                    .HasForeignKey(d => d.IddistritoDescarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbDistritos_Descarga");

                entity.HasOne(d => d.IddistritoDestinatarioNavigation)
                    .WithMany(p => p.TbDocumentosStockIddistritoDestinatarioNavigation)
                    .HasForeignKey(d => d.IddistritoDestinatario)
                    .HasConstraintName("FK_tbDocumentosStock_tbDistritos_Destinatario");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockIddistritoFiscalNavigation)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbDocumentosStock_tbDistritos_Fiscal");

                entity.HasOne(d => d.IdespacoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockIdespacoFiscalNavigation)
                    .HasForeignKey(d => d.IdespacoFiscal)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaEspacoFiscal1");

                entity.HasOne(d => d.IdespacoFiscalPortesNavigation)
                    .WithMany(p => p.TbDocumentosStockIdespacoFiscalPortesNavigation)
                    .HasForeignKey(d => d.IdespacoFiscalPortes)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaEspacoFiscal");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbDocumentosStock_tbEstados");

                entity.HasOne(d => d.IdformaExpedicaoNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdformaExpedicao)
                    .HasConstraintName("FK_tbDocumentosStock_tbFormasExpedicao");

                entity.HasOne(d => d.IdlocalOperacaoNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdlocalOperacao)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaRegioesIVA");

                entity.HasOne(d => d.IdlojaNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.Idloja)
                    .HasConstraintName("FK_tbDocumentosStock_tbLojas");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbDocumentosStock_tbMoedas");

                entity.HasOne(d => d.IdpaisCargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdpaisCargaNavigation)
                    .HasForeignKey(d => d.IdpaisCarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbPaises");

                entity.HasOne(d => d.IdpaisDescargaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdpaisDescargaNavigation)
                    .HasForeignKey(d => d.IdpaisDescarga)
                    .HasConstraintName("FK_tbDocumentosStock_tbPaises_Descarga");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockIdpaisFiscalNavigation)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbDocumentosStock_tbPaises_Fiscal");

                entity.HasOne(d => d.IdregimeIvaNavigation)
                    .WithMany(p => p.TbDocumentosStockIdregimeIvaNavigation)
                    .HasForeignKey(d => d.IdregimeIva)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaRegimeIVA1");

                entity.HasOne(d => d.IdregimeIvaPortesNavigation)
                    .WithMany(p => p.TbDocumentosStockIdregimeIvaPortesNavigation)
                    .HasForeignKey(d => d.IdregimeIvaPortes)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaRegimeIVA");

                entity.HasOne(d => d.IdsisTiposDocPuNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdsisTiposDocPu)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaTiposDocumentoPrecoUnitario");

                entity.HasOne(d => d.IdtaxaIvaPortesNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdtaxaIvaPortes)
                    .HasConstraintName("FK_tbDocumentosStock_tbIVA_Portes");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStock_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoEntidadeNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdtipoEntidade)
                    .HasConstraintName("FK_tbDocumentosStock_tbSistemaTiposEntidade");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbDocumentosStock)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStock_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbDocumentosStockAnexos>(entity =>
            {
                entity.HasIndex(e => new { e.IddocumentoStock, e.Ficheiro })
                    .HasName("IX_tbDocumentosStockAnexos")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IddocumentoStockNavigation)
                    .WithMany(p => p.TbDocumentosStockAnexos)
                    .HasForeignKey(d => d.IddocumentoStock)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStockAnexos_tbDocumentosStock");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDocumentosStockAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDocumentosStockAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDocumentosStockLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdarmazemNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdarmazemNavigation)
                    .HasForeignKey(d => d.Idarmazem)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArmazens");

                entity.HasOne(d => d.IdarmazemDestinoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdarmazemDestinoNavigation)
                    .HasForeignKey(d => d.IdarmazemDestino)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArmazens_Destino");

                entity.HasOne(d => d.IdarmazemLocalizacaoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdarmazemLocalizacaoNavigation)
                    .HasForeignKey(d => d.IdarmazemLocalizacao)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArmazensLocalizacoes");

                entity.HasOne(d => d.IdarmazemLocalizacaoDestinoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdarmazemLocalizacaoDestinoNavigation)
                    .HasForeignKey(d => d.IdarmazemLocalizacaoDestino)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArmazensLocalizacoes_Destino");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.Idartigo)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArtigos");

                entity.HasOne(d => d.IdartigoNumSerieNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdartigoNumSerie)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArtigosNumerosSeries");

                entity.HasOne(d => d.IdcodigoIvaNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdcodigoIva)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbSistemaCodigosIVA");

                entity.HasOne(d => d.IddocumentoStockNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IddocumentoStock)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbDocumentosStock");

                entity.HasOne(d => d.IdespacoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdespacoFiscal)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbSistemaEspacoFiscal");

                entity.HasOne(d => d.IdloteNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.Idlote)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbArtigosLotes");

                entity.HasOne(d => d.IdregimeIvaNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdregimeIva)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbSistemaRegimeIVA");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbIVA");

                entity.HasOne(d => d.IdtipoDocumentoOrigemNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdtipoDocumentoOrigem)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_IDTipoDocumentoOrigem");

                entity.HasOne(d => d.IdtipoIvaNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdtipoIva)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbSistemaTiposIVA");

                entity.HasOne(d => d.IdtipoPrecoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhas)
                    .HasForeignKey(d => d.IdtipoPreco)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbSistemaTiposPrecos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdunidadeNavigation)
                    .HasForeignKey(d => d.Idunidade)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbUnidades");

                entity.HasOne(d => d.IdunidadeStockNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdunidadeStockNavigation)
                    .HasForeignKey(d => d.IdunidadeStock)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbUnidades2");

                entity.HasOne(d => d.IdunidadeStock2Navigation)
                    .WithMany(p => p.TbDocumentosStockLinhasIdunidadeStock2Navigation)
                    .HasForeignKey(d => d.IdunidadeStock2)
                    .HasConstraintName("FK_tbDocumentosStockLinhas_tbUnidades3");
            });

            modelBuilder.Entity<TbDocumentosStockLinhasDimensoes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoDimensaoNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasDimensoes)
                    .HasForeignKey(d => d.IdartigoDimensao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStockLinhasDimensoes_tbArtigosDimensoes");

                entity.HasOne(d => d.IddocumentoStockLinhaNavigation)
                    .WithMany(p => p.TbDocumentosStockLinhasDimensoes)
                    .HasForeignKey(d => d.IddocumentoStockLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosStockLinhasDimensoes_tbDocumentosStockLinhas");
            });

            modelBuilder.Entity<TbDocumentosVendas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcaeNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.Idcae)
                    .HasConstraintName("FK_tbDocumentosVendas_tbParametrosEmpresaCAE");

                entity.HasOne(d => d.IdcodigoPostalCargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdcodigoPostalCargaNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalCarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbCodigosPostais_Carga");

                entity.HasOne(d => d.IdcodigoPostalDescargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdcodigoPostalDescargaNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalDescarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbCodigosPostais_Descarga");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdcodigoPostalFiscalNavigation)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoCargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdconcelhoCargaNavigation)
                    .HasForeignKey(d => d.IdconcelhoCarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbConcelhos_Carga");

                entity.HasOne(d => d.IdconcelhoDescargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdconcelhoDescargaNavigation)
                    .HasForeignKey(d => d.IdconcelhoDescarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbConcelhos_Descarga");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdconcelhoFiscalNavigation)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .HasConstraintName("FK_tbDocumentosVendas_tbCondicoesPagamento");

                entity.HasOne(d => d.IddistritoCargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIddistritoCargaNavigation)
                    .HasForeignKey(d => d.IddistritoCarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbDistritos_Carga");

                entity.HasOne(d => d.IddistritoDescargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIddistritoDescargaNavigation)
                    .HasForeignKey(d => d.IddistritoDescarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbDistritos_Descarga");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendasIddistritoFiscalNavigation)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbDistritos_Fiscal");

                entity.HasOne(d => d.IdespacoFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.IdespacoFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbSistemaEspacoFiscal");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbDocumentosVendas_tbEstados");

                entity.HasOne(d => d.IdfreguesiaCargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdfreguesiaCargaNavigation)
                    .HasForeignKey(d => d.IdfreguesiaCarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbFreguesias_Carga");

                entity.HasOne(d => d.IdfreguesiaDescargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdfreguesiaDescargaNavigation)
                    .HasForeignKey(d => d.IdfreguesiaDescarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbFreguesias_Descarga");

                entity.HasOne(d => d.IdfreguesiaFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdfreguesiaFiscalNavigation)
                    .HasForeignKey(d => d.IdfreguesiaFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbFreguesias_Fiscal");

                entity.HasOne(d => d.IdlocalOperacaoNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.IdlocalOperacao)
                    .HasConstraintName("FK_tbDocumentosVendas_tbSistemaRegioesIVA");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbDocumentosVendas_tbMoedas");

                entity.HasOne(d => d.IdpaisCargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdpaisCargaNavigation)
                    .HasForeignKey(d => d.IdpaisCarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbPaises_Carga");

                entity.HasOne(d => d.IdpaisDescargaNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdpaisDescargaNavigation)
                    .HasForeignKey(d => d.IdpaisDescarga)
                    .HasConstraintName("FK_tbDocumentosVendas_tbPaises_Descarga");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbDocumentosVendasIdpaisFiscalNavigation)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbDocumentosVendas_tbPaises_Fiscal");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendas_tbTiposDocumento");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbDocumentosVendas)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendas_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbDocumentosVendasCandidatos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatos)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatos_tbDocumentosVendas");

                entity.HasOne(d => d.IdfamiliarClienteNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatos)
                    .HasForeignKey(d => d.IdfamiliarCliente)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatos_IDFamiliarCliente");

                entity.HasOne(d => d.IdutenteCandidatoNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatos)
                    .HasForeignKey(d => d.IdutenteCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatos_IDUtenteCandidato");

                entity.HasOne(d => d.IdutenteCandidatoValenciaNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatos)
                    .HasForeignKey(d => d.IdutenteCandidatoValencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatos_IDUtenteCandidatoValencia");
            });

            modelBuilder.Entity<TbDocumentosVendasCandidatosAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatosAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatosAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IddocumentosVendasCandidatoNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatosAnexos)
                    .HasForeignKey(d => d.IddocumentosVendasCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatosAnexos_tbDocumentosVendasCandidatos");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDocumentosVendasCandidatosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDocumentosVendasCandidatosAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDocumentosVendasFormasPagamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocVendaPagNavigation)
                    .WithMany(p => p.TbDocumentosVendasFormasPagamento)
                    .HasForeignKey(d => d.IddocVendaPag)
                    .HasConstraintName("FK_tbDocumentosVendasFormasPagamento_tbDocumentosVendasPagamento");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocumentosVendasFormasPagamento)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasFormasPagamento_tbDocumentosVendas");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbDocumentosVendasFormasPagamento)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasFormasPagamento_tbFormasPagamento");
            });

            modelBuilder.Entity<TbDocumentosVendasLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.Idartigo)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbArtigos");

                entity.HasOne(d => d.IdcodigoIvaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdcodigoIva)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbSistemaCodigosIVA");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbDocumentosVendas");

                entity.HasOne(d => d.IdprecoSugeridoNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdprecoSugerido)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbIVA");

                entity.HasOne(d => d.IdtipoDocumentoOrigemNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdtipoDocumentoOrigem)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbTiposDocumento_Origem");

                entity.HasOne(d => d.IdtipoIvaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdtipoIva)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbSistemaTiposIVA");

                entity.HasOne(d => d.IdtipoPrecoNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.IdtipoPreco)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbSistemaTiposPrecos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhas)
                    .HasForeignKey(d => d.Idunidade)
                    .HasConstraintName("FK_tbDocumentosVendasLinhas_tbUnidades");
            });

            modelBuilder.Entity<TbDocumentosVendasLinhasUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaLinhaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhasUtentes)
                    .HasForeignKey(d => d.IddocumentoVendaLinha)
                    .HasConstraintName("FK_tbDocumentosVendasLinhasUtentes_tbDocumentosVendasLinhas");

                entity.HasOne(d => d.IdsalaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhasUtentes)
                    .HasForeignKey(d => d.Idsala)
                    .HasConstraintName("FK_tbDocumentosVendasLinhasUtentes_tbSalas");

                entity.HasOne(d => d.IdutenteValenciaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhasUtentes)
                    .HasForeignKey(d => d.IdutenteValencia)
                    .HasConstraintName("FK_tbDocumentosVendasLinhasUtentes_tbUtentesValencias");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbDocumentosVendasLinhasUtentes)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbDocumentosVendasLinhasUtentes_tbValencias");
            });

            modelBuilder.Entity<TbDocumentosVendasPagamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocumentosVendasPagamento)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasPagamento_tbDocumentosVendas");
            });

            modelBuilder.Entity<TbDocumentosVendasUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentes)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .HasConstraintName("FK_tbDocumentosVendasUtentes_tbDocumentosVendas");

                entity.HasOne(d => d.IdfamiliarClienteNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentes)
                    .HasForeignKey(d => d.IdfamiliarCliente)
                    .HasConstraintName("FK_tbDocumentosVendasUtentes_tbEntidadesFamiliares");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentes)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbDocumentosVendasUtentes_tbUtentes");
            });

            modelBuilder.Entity<TbDocumentosVendasUtentesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IddocumentoVendaUtenteNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesAnexos)
                    .HasForeignKey(d => d.IddocumentoVendaUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesAnexos_tbDocumentosVendasUtentes");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDocumentosVendasUtentesMovimentosCofre>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaUtenteNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IddocumentoVendaUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesMovimentosCofre_tbDocumentosVendasUtentes");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesMovimentosCofre_tbFormasPagamento");

                entity.HasOne(d => d.IdmovimentoCofreNavigation)
                    .WithMany(p => p.TbDocumentosVendasUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IdmovimentoCofre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumentosVendasUtentesMovimentosCofre_tbMovimentosCofre");
            });

            modelBuilder.Entity<TbDonativos>(entity =>
            {
                entity.HasIndex(e => new { e.IdtipoDocumento, e.IdtiposDocumentoSeries, e.NumeroDocumento })
                    .HasName("IX_tbDonativos_Documento")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoDonativoNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdcodigoDonativo)
                    .HasConstraintName("FK_tbDonativos_tbCodigosDonativos");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbDonativos_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbDonativos_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbDonativos_tbDistritos_Fiscal");

                entity.HasOne(d => d.IddoadorNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.Iddoador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativos_tbDoadores");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativos_tbEntidades");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbDonativos_tbEstados");

                entity.HasOne(d => d.IdfreguesiaFiscalNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdfreguesiaFiscal)
                    .HasConstraintName("FK_tbDonativos_tbFreguesias_Fiscal");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbDonativos_tbMoedas");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbDonativos_tbPaises_Fiscal");

                entity.HasOne(d => d.IdsistemaFormaDonativoNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdsistemaFormaDonativo)
                    .HasConstraintName("FK_tbDonativos_tbSistemaFormasDonativo");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativos_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoDonativoNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdtipoDonativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativos_tbTiposDonativos");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbDonativos)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativos_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbDonativosAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbDonativosAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbDonativosAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IddonativoNavigation)
                    .WithMany(p => p.TbDonativosAnexos)
                    .HasForeignKey(d => d.Iddonativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativosAnexos_tbDonativos");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbDonativosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbDonativosAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbDonativosFormasPagamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddonativoNavigation)
                    .WithMany(p => p.TbDonativosFormasPagamento)
                    .HasForeignKey(d => d.Iddonativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativosFormasPagamento_tbDonativos");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbDonativosFormasPagamento)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDonativosFormasPagamento_tbFormasPagamento");
            });

            modelBuilder.Entity<TbEntidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.IdtipoPessoa).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdProfissaoNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdProfissao)
                    .HasConstraintName("FK_tbEntidades_tbProfissoes");

                entity.HasOne(d => d.IdcentroSaudeNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdcentroSaude)
                    .HasConstraintName("FK_tbEntidades_tbCentrosSaude");

                entity.HasOne(d => d.IdestadoCivilNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdestadoCivil)
                    .HasConstraintName("FK_tbEntidades_tbSistemaEstadoCivil");

                entity.HasOne(d => d.IdfreguesiaNaturalidadeNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdfreguesiaNaturalidade)
                    .HasConstraintName("FK_tbEntidades_tbFreguesias");

                entity.HasOne(d => d.IdhabilitacaoLiterariaNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdhabilitacaoLiteraria)
                    .HasConstraintName("FK_tbEntidades_tbHabilitacoesLiterarias");

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.Ididioma)
                    .HasConstraintName("FK_tbEntidades_tbIdiomas");

                entity.HasOne(d => d.IdpaisNacionalidadeNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdpaisNacionalidade)
                    .HasConstraintName("FK_tbEntidades_tbPaises");

                entity.HasOne(d => d.IdsexoNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.Idsexo)
                    .HasConstraintName("FK_tbEntidades_tbSistemaSexo");

                entity.HasOne(d => d.IdtipoPessoaNavigation)
                    .WithMany(p => p.TbEntidades)
                    .HasForeignKey(d => d.IdtipoPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidades_tbSistemaTiposPessoa");
            });

            modelBuilder.Entity<TbEntidadesContatos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbEntidadesContatos)
                    .HasForeignKey(d => d.Identidade)
                    .HasConstraintName("FK_tbEntidadesContatos_tbEntidades");

                entity.HasOne(d => d.IdtipoContatoNavigation)
                    .WithMany(p => p.TbEntidadesContatos)
                    .HasForeignKey(d => d.IdtipoContato)
                    .HasConstraintName("FK_tbEntidadesContatos_tbSistemaTiposContato");
            });

            modelBuilder.Entity<TbEntidadesFamiliares>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbEntidadesFamiliaresIdentidadeNavigation)
                    .HasForeignKey(d => d.Identidade)
                    .HasConstraintName("FK_tbEntidadesFamiliares_tbEntidades");

                entity.HasOne(d => d.IdentidadeFamiliarNavigation)
                    .WithMany(p => p.TbEntidadesFamiliaresIdentidadeFamiliarNavigation)
                    .HasForeignKey(d => d.IdentidadeFamiliar)
                    .HasConstraintName("FK_tbEntidadesFamiliares_tbEntidades1");

                entity.HasOne(d => d.IdparentescoNavigation)
                    .WithMany(p => p.TbEntidadesFamiliares)
                    .HasForeignKey(d => d.Idparentesco)
                    .HasConstraintName("FK_tbEntidadesFamiliares_tbSistemaParentesco");
            });

            modelBuilder.Entity<TbEntidadesMoradas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.IdcodigoPostal)
                    .HasConstraintName("FK_tbEntidadesMoradas_tbCodigosPostais");

                entity.HasOne(d => d.IdconcelhoNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.Idconcelho)
                    .HasConstraintName("FK_tbEntidadesMoradas_tbConcelhos");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.Iddistrito)
                    .HasConstraintName("FK_tbEntidadesMoradas_tbDistritos");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidadesMoradas_IDEntidade");

                entity.HasOne(d => d.IdfreguesiaNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.Idfreguesia)
                    .HasConstraintName("FK_tbEntidadesMoradas_tbFreguesias");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.TbEntidadesMoradas)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_tbEntidadesMoradas_tbPaises");
            });

            modelBuilder.Entity<TbEntidadesRegistadas>(entity =>
            {
                entity.HasIndex(e => new { e.IdtipoEntidade, e.Codigo })
                    .HasName("IX_tbEntidadesRegistadasCodigo")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdtipoEntidade, e.CodigoVisualizado })
                    .HasName("IX_tbEntidadesRegistadasCodigoVisualizado")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdtipoEntidade, e.IdtipoEntidadeClasse, e.CodigoClasse })
                    .HasName("IX_tbEntidadesRegistadasCodigoClasse")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbEntidadesRegistadas)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidadesRegistadas_tbEntidades");

                entity.HasOne(d => d.IdtipoEntidadeNavigation)
                    .WithMany(p => p.TbEntidadesRegistadas)
                    .HasForeignKey(d => d.IdtipoEntidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidadesRegistadas_tbTiposEntidade");

                entity.HasOne(d => d.IdtipoEntidadeClasseNavigation)
                    .WithMany(p => p.TbEntidadesRegistadas)
                    .HasForeignKey(d => d.IdtipoEntidadeClasse)
                    .HasConstraintName("FK_tbEntidadesRegistadas_tbTiposEntidadeClasses");
            });

            modelBuilder.Entity<TbEntidadesSync>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdsistemaAppNavigation)
                    .WithMany(p => p.TbEntidadesSync)
                    .HasForeignKey(d => d.IdsistemaApp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidadesSync_tbSistemaSyncAPP");
            });

            modelBuilder.Entity<TbEntidadesSyncPendentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdsistemaAppNavigation)
                    .WithMany(p => p.TbEntidadesSyncPendentes)
                    .HasForeignKey(d => d.IdsistemaApp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEntidadesSyncPendentes_tbSistemaSyncAPP");
            });

            modelBuilder.Entity<TbEstabelecimentos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.IdcodigoPostal)
                    .HasConstraintName("FK_tbEstabelecimentos_tbCodigosPostais");

                entity.HasOne(d => d.IdconcelhoNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.Idconcelho)
                    .HasConstraintName("FK_tbEstabelecimentos_tbConcelhos");

                entity.HasOne(d => d.IddistritoNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.Iddistrito)
                    .HasConstraintName("FK_tbEstabelecimentos_tbDistritos");

                entity.HasOne(d => d.IdfreguesiaNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.Idfreguesia)
                    .HasConstraintName("FK_tbEstabelecimentos_tbFreguesias");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_tbEstabelecimentos_tbPaises");

                entity.HasOne(d => d.IdregiaoNavigation)
                    .WithMany(p => p.TbEstabelecimentos)
                    .HasForeignKey(d => d.Idregiao)
                    .HasConstraintName("FK_tbEstabelecimentos_tbSistemaRegioesIVA");
            });

            modelBuilder.Entity<TbEstabelecimentosAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbEstabelecimentosAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbEstabelecimentosAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdestabelecimentoNavigation)
                    .WithMany(p => p.TbEstabelecimentosAnexos)
                    .HasForeignKey(d => d.Idestabelecimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstabelecimentosAnexos_tbEstabelecimentos");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbEstabelecimentosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbEstabelecimentosAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbEstados>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdentidadeEstadoNavigation)
                    .WithMany(p => p.TbEstados)
                    .HasForeignKey(d => d.IdentidadeEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstados_tbSistemaEntidadesEstados");

                entity.HasOne(d => d.IdtipoEstadoNavigation)
                    .WithMany(p => p.TbEstados)
                    .HasForeignKey(d => d.IdtipoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstados_tbSistemaTiposEstados");
            });

            modelBuilder.Entity<TbFamilias>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbFormasExpedicao>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbFormasExpedicaoCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbFormasExpedicaoIdiomas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdformaExpedicaoNavigation)
                    .WithMany(p => p.TbFormasExpedicaoIdiomas)
                    .HasForeignKey(d => d.IdformaExpedicao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormasExpedicaoIdiomas_tbFormasExpedicao");

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbFormasExpedicaoIdiomas)
                    .HasForeignKey(d => d.Ididioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormasExpedicaoIdiomas_tbIdiomas");
            });

            modelBuilder.Entity<TbFormasPagamento>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbFormasPagamentoCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdtipoFormaPagamentoNavigation)
                    .WithMany(p => p.TbFormasPagamento)
                    .HasForeignKey(d => d.IdtipoFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormasPagamento_tbSistemaTiposFormasPagamento");
            });

            modelBuilder.Entity<TbFormasPagamentoIdiomas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbFormasPagamentoIdiomas)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormasPagamentoIdiomas_tbFormasPagamento");

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbFormasPagamentoIdiomas)
                    .HasForeignKey(d => d.Ididioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormasPagamentoIdiomas_tbIdiomas");
            });

            modelBuilder.Entity<TbFormulasDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriasIndicadoresNavigation)
                    .WithMany(p => p.TbFormulasDef)
                    .HasForeignKey(d => d.IdcategoriasIndicadores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormulasDef_tbCategoriasFormulasDef");
            });

            modelBuilder.Entity<TbFormulasVariaveisDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdformulasNavigation)
                    .WithMany(p => p.TbFormulasVariaveisDef)
                    .HasForeignKey(d => d.Idformulas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormulasVariaveisDef_tbFormulasDef");

                entity.HasOne(d => d.IdvariavelNavigation)
                    .WithMany(p => p.TbFormulasVariaveisDef)
                    .HasForeignKey(d => d.Idvariavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFormulasVariaveisDef_tbVariaveisDef");
            });

            modelBuilder.Entity<TbFreguesias>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdconcelhoNavigation)
                    .WithMany(p => p.TbFreguesias)
                    .HasForeignKey(d => d.Idconcelho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFreguesias_tbConcelhos");
            });

            modelBuilder.Entity<TbGrausDeficienciaIncapacidade>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbGrausDeficienciaIncapacidade")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdnivelAutonomiaNavigation)
                    .WithMany(p => p.TbGrausDeficienciaIncapacidade)
                    .HasForeignKey(d => d.IdnivelAutonomia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbGrausDeficienciaIncapacidade_tbSistemaNivelAutonomia");

                entity.HasOne(d => d.IdtipoDeficienciaNavigation)
                    .WithMany(p => p.TbGrausDeficienciaIncapacidade)
                    .HasForeignKey(d => d.IdtipoDeficiencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbGrausDeficienciaIncapacidade_tbSistemaTipoDeficiencia");
            });

            modelBuilder.Entity<TbGruposArtigo>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcaeNavigation)
                    .WithMany(p => p.TbGruposArtigo)
                    .HasForeignKey(d => d.Idcae)
                    .HasConstraintName("FK_tbGruposArtigo_tbParametrosEmpresaCAE");
            });

            modelBuilder.Entity<TbHabilitacoesLiterarias>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbHabLiterarias")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbIdiomas>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Descricao })
                    .HasName("IX_tbIdiomas_Codigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdculturaNavigation)
                    .WithMany(p => p.TbIdiomas)
                    .HasForeignKey(d => d.Idcultura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIdiomas_tbSistemaIdiomas");
            });

            modelBuilder.Entity<TbImpostoSelo>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbImpostoSeloCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbIva>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcodigoIvaNavigation)
                    .WithMany(p => p.TbIva)
                    .HasForeignKey(d => d.IdcodigoIva)
                    .HasConstraintName("FK_tbIVA_tbSistemaCodigosIVA");

                entity.HasOne(d => d.IdtipoIvaNavigation)
                    .WithMany(p => p.TbIva)
                    .HasForeignKey(d => d.IdtipoIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIVA_tbSistemaTiposIVA");
            });

            modelBuilder.Entity<TbIvaregioes>(entity =>
            {
                entity.HasIndex(e => new { e.Idiva, e.Idregiao })
                    .HasName("IX_tbIVARegioes")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdivaNavigation)
                    .WithMany(p => p.TbIvaregioesIdivaNavigation)
                    .HasForeignKey(d => d.Idiva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIVARegioes_tbIVA");

                entity.HasOne(d => d.IdivaRegiaoNavigation)
                    .WithMany(p => p.TbIvaregioesIdivaRegiaoNavigation)
                    .HasForeignKey(d => d.IdivaRegiao)
                    .HasConstraintName("FK_tbIVARegioes_tbIVA1");

                entity.HasOne(d => d.IdregiaoNavigation)
                    .WithMany(p => p.TbIvaregioes)
                    .HasForeignKey(d => d.Idregiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIVARegioes_tbSistemaRegioesIVA");
            });

            modelBuilder.Entity<TbLojas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbMapasVistas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdlojaNavigation)
                    .WithMany(p => p.TbMapasVistas)
                    .HasForeignKey(d => d.Idloja)
                    .HasConstraintName("FK_tbMapasVistas_tbLojas");

                entity.HasOne(d => d.IdmoduloNavigation)
                    .WithMany(p => p.TbMapasVistas)
                    .HasForeignKey(d => d.Idmodulo)
                    .HasConstraintName("FK_tbMapasVistas_tbSistemaModulos");

                entity.HasOne(d => d.IdsistemaTipoDocNavigation)
                    .WithMany(p => p.TbMapasVistas)
                    .HasForeignKey(d => d.IdsistemaTipoDoc)
                    .HasConstraintName("FK_tbMapasVistas_tbSistemaTiposDocumento");

                entity.HasOne(d => d.IdsistemaTipoDocFiscalNavigation)
                    .WithMany(p => p.TbMapasVistas)
                    .HasForeignKey(d => d.IdsistemaTipoDocFiscal)
                    .HasConstraintName("FK_tbMapasVistas_tbSistemaTiposDocumentoFiscal");
            });

            modelBuilder.Entity<TbModelosFiscais>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbModelosFiscaisAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbModelosFiscaisAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbModelosFiscaisAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdmodeloFiscalNavigation)
                    .WithMany(p => p.TbModelosFiscaisAnexos)
                    .HasForeignKey(d => d.IdmodeloFiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModelosFiscaisAnexos_tbModelosFiscais");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbModelosFiscaisAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbModelosFiscaisAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbModelosFiscaisLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdmodelosFiscaisNavigation)
                    .WithMany(p => p.TbModelosFiscaisLinhas)
                    .HasForeignKey(d => d.IdmodelosFiscais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModelosFiscaisLinhas_tbModelosFiscais");
            });

            modelBuilder.Entity<TbModelosRelatorios>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("IX_tbModelosRelatorios")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbModelosRelatoriosTags>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdformulaDefNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTags)
                    .HasForeignKey(d => d.IdformulaDef)
                    .HasConstraintName("FK_tbModelosRelatoriosTags_tbFormulasDef");

                entity.HasOne(d => d.IdmodelosRelatoriosNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTags)
                    .HasForeignKey(d => d.IdmodelosRelatorios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModelosRelatoriosTags_tbModelosRelatorios");

                entity.HasOne(d => d.IdsistemaTipoTagNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTags)
                    .HasForeignKey(d => d.IdsistemaTipoTag)
                    .HasConstraintName("FK_tbModelosRelatoriosTags_tbSistemaTiposTag");

                entity.HasOne(d => d.IdvariavelDefNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTags)
                    .HasForeignKey(d => d.IdvariavelDef)
                    .HasConstraintName("FK_tbModelosRelatoriosTags_tbVariaveisDef");
            });

            modelBuilder.Entity<TbModelosRelatoriosTagsVariaveisParametros>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdmodelosRelatoriosTagsNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTagsVariaveisParametros)
                    .HasForeignKey(d => d.IdmodelosRelatoriosTags)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModelosRelatoriosTagsVariaveisParametros_tbModelosRelatoriosTags");

                entity.HasOne(d => d.IdparametrosDefNavigation)
                    .WithMany(p => p.TbModelosRelatoriosTagsVariaveisParametros)
                    .HasForeignKey(d => d.IdparametrosDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbModelosRelatoriosTagsVariaveisParametros_tbParametrosDef");
            });

            modelBuilder.Entity<TbMoedas>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdsistemaMoedaNavigation)
                    .WithMany(p => p.TbMoedas)
                    .HasForeignKey(d => d.IdsistemaMoeda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMoedas_tbSistemaMoedas");
            });

            modelBuilder.Entity<TbMotivosAusenciaSaida>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbMovimentosCofre>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbMovimentosCofre_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbMovimentosCofre_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbMovimentosCofre_tbDistritos_Fiscal");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofre_tbEntidades");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbMovimentosCofre_tbEstados");

                entity.HasOne(d => d.IdfreguesiaFiscalNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdfreguesiaFiscal)
                    .HasConstraintName("FK_tbMovimentosCofre_tbFreguesias_Fiscal");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbMovimentosCofre_tbMoedas");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbMovimentosCofre_tbPaises_Fiscal");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofre_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoMovimentoCofreNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdtipoMovimentoCofre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofre_tbTiposMovimentosCofre");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofre_tbTiposDocumentoSeries");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbMovimentosCofre)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofre_tbUtentes");
            });

            modelBuilder.Entity<TbMovimentosCofreAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbMovimentosCofreAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbMovimentosCofreAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdmovimentoCofreNavigation)
                    .WithMany(p => p.TbMovimentosCofreAnexos)
                    .HasForeignKey(d => d.IdmovimentoCofre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimentosCofreAnexos_tbMovimentosCofre");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbMovimentosCofreAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbMovimentosCofreAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbMovimentosCofreBens>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdmovimentoCofreNavigation)
                    .WithMany(p => p.TbMovimentosCofreBens)
                    .HasForeignKey(d => d.IdmovimentoCofre)
                    .HasConstraintName("FK_tbMovimentosCofreBens_tbMovimentosCofre");

                entity.HasOne(d => d.IdmovimentoCofreBensEntradaNavigation)
                    .WithMany(p => p.InverseIdmovimentoCofreBensEntradaNavigation)
                    .HasForeignKey(d => d.IdmovimentoCofreBensEntrada)
                    .HasConstraintName("FK_tbMovimentosCofreBens_tbMovimentosCofreBens_Entrada");

                entity.HasOne(d => d.IdmovimentoCofreBensSaidaNavigation)
                    .WithMany(p => p.InverseIdmovimentoCofreBensSaidaNavigation)
                    .HasForeignKey(d => d.IdmovimentoCofreBensSaida)
                    .HasConstraintName("FK_tbMovimentosCofreBens_tbMovimentosCofreBens_Saida");
            });

            modelBuilder.Entity<TbMovimentosCofreDisponibilidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdmovimentoCofreNavigation)
                    .WithMany(p => p.TbMovimentosCofreDisponibilidades)
                    .HasForeignKey(d => d.IdmovimentoCofre)
                    .HasConstraintName("FK_tbMovimentosCofreDisponibilidades_tbMovimentosCofre");

                entity.HasOne(d => d.IdutentePrevRendTiposRendNavigation)
                    .WithMany(p => p.TbMovimentosCofreDisponibilidades)
                    .HasForeignKey(d => d.IdutentePrevRendTiposRend)
                    .HasConstraintName("FK_tbMovimentosCofreDisponibilidades_tbUtentesPrevRendTiposRend");
            });

            modelBuilder.Entity<TbOutrasEntidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeRegistadaNavigation)
                    .WithMany(p => p.TbOutrasEntidades)
                    .HasForeignKey(d => d.IdentidadeRegistada)
                    .HasConstraintName("FK_tbOutrasEntidades_tbEntidadesRegistadas");
            });

            modelBuilder.Entity<TbPaises>(entity =>
            {
                entity.HasIndex(e => e.Idsigla)
                    .HasName("IX_tbPaisesSigla");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsiglaNavigation)
                    .WithMany(p => p.TbPaises)
                    .HasForeignKey(d => d.Idsigla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPaises_tbSistemaSiglasPaises");
            });

            modelBuilder.Entity<TbParametrizacaoConsentimentos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdfuncionalidadeConsentimentoNavigation)
                    .WithMany(p => p.TbParametrizacaoConsentimentos)
                    .HasForeignKey(d => d.IdfuncionalidadeConsentimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrizacaoConsentimentos_tbSistemaFuncionalidadesConsentimento");
            });

            modelBuilder.Entity<TbParametrizacaoConsentimentosCamposEntidade>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdparametrizacaoConsentimentoNavigation)
                    .WithMany(p => p.TbParametrizacaoConsentimentosCamposEntidade)
                    .HasForeignKey(d => d.IdparametrizacaoConsentimento)
                    .HasConstraintName("FK_tbParametrizacaoConsentimentosCamposEntidade_tbParametrizacaoConsentimentos");

                entity.HasOne(d => d.IdsistemaFuncionalidadesConsentimentoNavigation)
                    .WithMany(p => p.TbParametrizacaoConsentimentosCamposEntidade)
                    .HasForeignKey(d => d.IdsistemaFuncionalidadesConsentimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrizacaoConsentimentosCamposEntidade_tbSistemaFuncionalidadesConsentimento");
            });

            modelBuilder.Entity<TbParametrizacaoConsentimentosPerguntas>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.IdparametrizacaoConsentimento })
                    .HasName("IX_tbParametrizacaoConsentimentosPerguntas_Codigo_IDPa")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdparametrizacaoConsentimentoNavigation)
                    .WithMany(p => p.TbParametrizacaoConsentimentosPerguntas)
                    .HasForeignKey(d => d.IdparametrizacaoConsentimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrizacaoConsentimentosPerguntas_tbParametrizacaoConsentimentos");
            });

            modelBuilder.Entity<TbParametrosCamposContexto>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdparametroContextoNavigation)
                    .WithMany(p => p.TbParametrosCamposContexto)
                    .HasForeignKey(d => d.IdparametroContexto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrosCamposContexto_tbParametrosContexto");

                entity.HasOne(d => d.IdtipoDadosNavigation)
                    .WithMany(p => p.TbParametrosCamposContexto)
                    .HasForeignKey(d => d.IdtipoDados)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrosCamposContexto_tbTiposDados");
            });

            modelBuilder.Entity<TbParametrosContexto>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.MostraConteudo).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdpaiNavigation)
                    .WithMany(p => p.InverseIdpaiNavigation)
                    .HasForeignKey(d => d.Idpai)
                    .HasConstraintName("FK_tbParametrosContexto_tbParametrosContexto");

                entity.HasOne(d => d.IdparametrosEmpresaNavigation)
                    .WithMany(p => p.TbParametrosContexto)
                    .HasForeignKey(d => d.IdparametrosEmpresa)
                    .HasConstraintName("FK_tbParametrosContexto_tbParametrosEmpresa");
            });

            modelBuilder.Entity<TbParametrosDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaTipoControlosNavigation)
                    .WithMany(p => p.TbParametrosDef)
                    .HasForeignKey(d => d.IdsistemaTipoControlos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrosDef_tbSistemaTipoControlos");
            });

            modelBuilder.Entity<TbParametrosDefValidacoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.Idparametro1Navigation)
                    .WithMany(p => p.TbParametrosDefValidacoesIdparametro1Navigation)
                    .HasForeignKey(d => d.Idparametro1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Idparametro2Navigation)
                    .WithMany(p => p.TbParametrosDefValidacoesIdparametro2Navigation)
                    .HasForeignKey(d => d.Idparametro2)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TbParametrosEmpresa>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdmoedaDefeitoNavigation)
                    .WithMany(p => p.TbParametrosEmpresa)
                    .HasForeignKey(d => d.IdmoedaDefeito)
                    .HasConstraintName("FK_tbParametrosEmpresa_tbMoedas");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.TbParametrosEmpresa)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_tbParametrosEmpresa_tbSistemaSiglasPaises");

                entity.HasOne(d => d.IdpaisesDescNavigation)
                    .WithMany(p => p.TbParametrosEmpresa)
                    .HasForeignKey(d => d.IdpaisesDesc)
                    .HasConstraintName("FK_tbParametrosEmpresa_tbPaises");
            });

            modelBuilder.Entity<TbParametrosEmpresaCae>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbParametrosEmpresaCAE")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdparametrosEmpresaNavigation)
                    .WithMany(p => p.TbParametrosEmpresaCae)
                    .HasForeignKey(d => d.IdparametrosEmpresa)
                    .HasConstraintName("FK_tbParametrosEmpresaCAE_tbParametrosEmpresa");
            });

            modelBuilder.Entity<TbParametrosRelatoriosGestao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbPlaneamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdprofissionalNavigation)
                    .WithMany(p => p.TbPlaneamento)
                    .HasForeignKey(d => d.Idprofissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPlaneamento_tbProfissionais");
            });

            modelBuilder.Entity<TbProcessamentoDocsVendasUtentes>(entity =>
            {
                entity.HasKey(e => new { e.IdprocessamentoUtentes, e.IddocumentoVendaUtentes });

                entity.HasOne(d => d.IddocumentoVendaUtentesNavigation)
                    .WithMany(p => p.TbProcessamentoDocsVendasUtentes)
                    .HasForeignKey(d => d.IddocumentoVendaUtentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProcessamentoDocsVendasUtentes_tbDocumentosVendasUtentes");

                entity.HasOne(d => d.IdprocessamentoUtentesNavigation)
                    .WithMany(p => p.TbProcessamentoDocsVendasUtentes)
                    .HasForeignKey(d => d.IdprocessamentoUtentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProcessamentoDocsVendasUtentes_tbProcessamentoUtentes");
            });

            modelBuilder.Entity<TbProcessamentoUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdacordoNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.Idacordo)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbAcordos");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbMoedas");

                entity.HasOne(d => d.IdsalaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.Idsala)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbSalas");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbUtentes");

                entity.HasOne(d => d.IdutenteValenciaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.IdutenteValencia)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbUtentesValencias");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentes)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbProcessamentoUtentes_tbValencias");
            });

            modelBuilder.Entity<TbProcessamentoUtentesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbProcessamentoUtentesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdprocessamentoUtenteNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesAnexos)
                    .HasForeignKey(d => d.IdprocessamentoUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProcessamentoUtentesAnexos_tbProcessamentoUtentes");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbProcessamentoUtentesAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbProcessamentoUtentesLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.Idartigo)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbArtigos");

                entity.HasOne(d => d.IdcodigoIvaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdcodigoIva)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbSistemaCodigosIVA");

                entity.HasOne(d => d.IdprecoSugeridoNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdprecoSugerido)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdprocessamentoUtentesNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdprocessamentoUtentes)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbProcessamentoUtentes");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbIVA");

                entity.HasOne(d => d.IdtipoIvaNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdtipoIva)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbSistemaTiposIVA");

                entity.HasOne(d => d.IdtipoPrecoNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.IdtipoPreco)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbSistemaTiposPrecos");

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbProcessamentoUtentesLinhas)
                    .HasForeignKey(d => d.Idunidade)
                    .HasConstraintName("FK_tbProcessamentoUtentesLinhas_tbUnidades");
            });

            modelBuilder.Entity<TbProfissionais>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbProfissional")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdtipoProfissionalNavigation)
                    .WithMany(p => p.TbProfissionais)
                    .HasForeignKey(d => d.IdtipoProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProfissionais_tbTipoProfissional");
            });

            modelBuilder.Entity<TbProfissoes>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbProfissoes")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbRazoes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdlojaNavigation)
                    .WithMany(p => p.TbRazoes)
                    .HasForeignKey(d => d.Idloja)
                    .HasConstraintName("FK_tbRazoes_tbLojas");
            });

            modelBuilder.Entity<TbRecibos>(entity =>
            {
                entity.HasIndex(e => new { e.IdtipoDocumento, e.IdtiposDocumentoSeries, e.NumeroDocumento })
                    .HasName("IX_tbRecibos_Documento")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdcodigoPostalFiscalNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdcodigoPostalFiscal)
                    .HasConstraintName("FK_tbRecibos_tbCodigosPostais_Fiscal");

                entity.HasOne(d => d.IdconcelhoFiscalNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdconcelhoFiscal)
                    .HasConstraintName("FK_tbRecibos_tbConcelhos_Fiscal");

                entity.HasOne(d => d.IddistritoFiscalNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IddistritoFiscal)
                    .HasConstraintName("FK_tbRecibos_tbDistritos_Fiscal");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.Identidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibos_tbEntidades");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbRecibos_tbEstados");

                entity.HasOne(d => d.IdfreguesiaFiscalNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdfreguesiaFiscal)
                    .HasConstraintName("FK_tbRecibos_tbFreguesias_Fiscal");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbRecibos_tbMoedas");

                entity.HasOne(d => d.IdpaisFiscalNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdpaisFiscal)
                    .HasConstraintName("FK_tbRecibos_tbPaises_Fiscal");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibos_tbTiposDocumento");

                entity.HasOne(d => d.IdtiposDocumentoSeriesNavigation)
                    .WithMany(p => p.TbRecibos)
                    .HasForeignKey(d => d.IdtiposDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibos_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbRecibosFormasPagamento>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbRecibosFormasPagamento)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosFormasPagamento_tbFormasPagamento");

                entity.HasOne(d => d.IdreciboNavigation)
                    .WithMany(p => p.TbRecibosFormasPagamento)
                    .HasForeignKey(d => d.Idrecibo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosFormasPagamento_tbRecibos");
            });

            modelBuilder.Entity<TbRecibosLinhas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaNavigation)
                    .WithMany(p => p.TbRecibosLinhas)
                    .HasForeignKey(d => d.IddocumentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosLinhas_tbDocumentosVendas");

                entity.HasOne(d => d.IdreciboNavigation)
                    .WithMany(p => p.TbRecibosLinhas)
                    .HasForeignKey(d => d.Idrecibo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosLinhas_tbRecibos");
            });

            modelBuilder.Entity<TbRecibosLinhasArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IddocumentoVendaLinhaNavigation)
                    .WithMany(p => p.TbRecibosLinhasArtigos)
                    .HasForeignKey(d => d.IddocumentoVendaLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosLinhasArtigos_tbDocumentosVendasLinhas");

                entity.HasOne(d => d.IdreciboLinhaNavigation)
                    .WithMany(p => p.TbRecibosLinhasArtigos)
                    .HasForeignKey(d => d.IdreciboLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosLinhasArtigos_tbRecibosLinhas");
            });

            modelBuilder.Entity<TbRecibosLinhasTaxas>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdreciboLinhaNavigation)
                    .WithMany(p => p.TbRecibosLinhasTaxas)
                    .HasForeignKey(d => d.IdreciboLinha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosLinhasTaxas_tbRecibosLinhas");
            });

            modelBuilder.Entity<TbRecibosUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdreciboNavigation)
                    .WithMany(p => p.TbRecibosUtentes)
                    .HasForeignKey(d => d.Idrecibo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosUtentes_tbRecibos");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbRecibosUtentes)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosUtentes_tbUtentes");
            });

            modelBuilder.Entity<TbRecibosUtentesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbRecibosUtentesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbRecibosUtentesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdrecebimentoUtenteNavigation)
                    .WithMany(p => p.TbRecibosUtentesAnexos)
                    .HasForeignKey(d => d.IdrecebimentoUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosUtentesAnexos_tbRecibosUtentes");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbRecibosUtentesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbRecibosUtentesAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbRecibosUtentesMovimentosCofre>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbRecibosUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .HasConstraintName("FK_tbRecibosUtentesMovimentosCofre_tbFormasPagamento");

                entity.HasOne(d => d.IdmovimentoCofreNavigation)
                    .WithMany(p => p.TbRecibosUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IdmovimentoCofre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosUtentesMovimentosCofre_tbMovimentosCofre");

                entity.HasOne(d => d.IdreciboUtenteNavigation)
                    .WithMany(p => p.TbRecibosUtentesMovimentosCofre)
                    .HasForeignKey(d => d.IdreciboUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecibosUtentesMovimentosCofre_tbRecibosUtentes");
            });

            modelBuilder.Entity<TbRelatorios>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("IX_tbRelatorios")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbRelatoriosEstados>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdrelatoriosNavigation)
                    .WithMany(p => p.TbRelatoriosEstados)
                    .HasForeignKey(d => d.Idrelatorios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRelatoriosEstados_tbRelatorios");

                entity.HasOne(d => d.IdsistemaTiposEstadosRelatoriosNavigation)
                    .WithMany(p => p.TbRelatoriosEstados)
                    .HasForeignKey(d => d.IdsistemaTiposEstadosRelatorios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRelatoriosEstados_tbSistemaTiposEstadosRelatorios");
            });

            modelBuilder.Entity<TbRelatoriosTags>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdformulaDefNavigation)
                    .WithMany(p => p.TbRelatoriosTags)
                    .HasForeignKey(d => d.IdformulaDef)
                    .HasConstraintName("FK_tbRelatoriosTags_tbFormulasDef");

                entity.HasOne(d => d.IdrelatoriosNavigation)
                    .WithMany(p => p.TbRelatoriosTags)
                    .HasForeignKey(d => d.Idrelatorios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRelatoriosTags_tbRelatorios");

                entity.HasOne(d => d.IdsistemaTipoTagNavigation)
                    .WithMany(p => p.TbRelatoriosTags)
                    .HasForeignKey(d => d.IdsistemaTipoTag)
                    .HasConstraintName("FK_tbRelatoriosTags_tbSistemaTiposTag");

                entity.HasOne(d => d.IdvariavelDefNavigation)
                    .WithMany(p => p.TbRelatoriosTags)
                    .HasForeignKey(d => d.IdvariavelDef)
                    .HasConstraintName("FK_tbRelatoriosTags_tbVariaveisDef");
            });

            modelBuilder.Entity<TbRelatoriosTagsVariaveisParametros>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdparametrosDefNavigation)
                    .WithMany(p => p.TbRelatoriosTagsVariaveisParametros)
                    .HasForeignKey(d => d.IdparametrosDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRelatoriosTagsVariaveisParametros_tbParametrosDef");

                entity.HasOne(d => d.IdrelatoriosTagsNavigation)
                    .WithMany(p => p.TbRelatoriosTagsVariaveisParametros)
                    .HasForeignKey(d => d.IdrelatoriosTags)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRelatoriosTagsVariaveisParametros_tbRelatoriosTags");
            });

            modelBuilder.Entity<TbRespostasConsentimentos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdconsentimentoNavigation)
                    .WithMany(p => p.TbRespostasConsentimentos)
                    .HasForeignKey(d => d.Idconsentimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRespostasConsentimentos_tbConsentimentos");

                entity.HasOne(d => d.IdparametrizacaoConsentimentoPerguntasNavigation)
                    .WithMany(p => p.TbRespostasConsentimentos)
                    .HasForeignKey(d => d.IdparametrizacaoConsentimentoPerguntas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRespostasConsentimentos_tbParametrizacaoConsentimentosPerguntas");
            });

            modelBuilder.Entity<TbRestricaoAnexosFuncionalidades>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdanexosFuncionalidade1Navigation)
                    .WithMany(p => p.TbRestricaoAnexosFuncionalidadesIdanexosFuncionalidade1Navigation)
                    .HasForeignKey(d => d.IdanexosFuncionalidade1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRestricaoAnexosFuncionalidades_tbAnexosFuncionalidades1");

                entity.HasOne(d => d.IdanexosFuncionalidade2Navigation)
                    .WithMany(p => p.TbRestricaoAnexosFuncionalidadesIdanexosFuncionalidade2Navigation)
                    .HasForeignKey(d => d.IdanexosFuncionalidade2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRestricaoAnexosFuncionalidades_tbAnexosFuncionalidades2");
            });

            modelBuilder.Entity<TbSaft>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSalas>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdestabelecimentoNavigation)
                    .WithMany(p => p.TbSalas)
                    .HasForeignKey(d => d.Idestabelecimento)
                    .HasConstraintName("FK_tbSalas_tbEstabelecimentos");

                entity.HasOne(d => d.IdtipoSalaNavigation)
                    .WithMany(p => p.TbSalas)
                    .HasForeignKey(d => d.IdtipoSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSalas_tbSistemaTipoSala");
            });

            modelBuilder.Entity<TbSalasLocalizacoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsalaNavigation)
                    .WithMany(p => p.TbSalasLocalizacoes)
                    .HasForeignKey(d => d.Idsala)
                    .HasConstraintName("FK_tbSalasLocalizacoes_tbSalas");
            });

            modelBuilder.Entity<TbSalasQuartosAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbSalasQuartosAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbSalasQuartosAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdsalaQuartoNavigation)
                    .WithMany(p => p.TbSalasQuartosAnexos)
                    .HasForeignKey(d => d.IdsalaQuarto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSalasQuartosAnexos_tbSalas");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbSalasQuartosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbSalasQuartosAnexos_tbSistemaTiposAnexos");
            });

            modelBuilder.Entity<TbSaldosEntidades>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeNavigation)
                    .WithMany(p => p.TbSaldosEntidades)
                    .HasForeignKey(d => d.Identidade)
                    .HasConstraintName("FK_tbSaldosEntidades_tbEntidades");

                entity.HasOne(d => d.IdmoedaNavigation)
                    .WithMany(p => p.TbSaldosEntidades)
                    .HasForeignKey(d => d.Idmoeda)
                    .HasConstraintName("FK_tbSaldosEntidades_tbMoedas");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbSaldosEntidades)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSaldosEntidades_tbUtentes");
            });

            modelBuilder.Entity<TbSeguradoras>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSetores>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbSetores")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaAcoes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaAreaValencia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaClassificacoesTiposArtigos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.IsSystem).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbSistemaClassificacoesTiposArtigosGeral>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.IsSystem).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbSistemaCodigosIva>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaCodigosPrecos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaEntidadesEstados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaEntidadesF3m>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaEspacoFiscal>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaEstadoCivil>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbSistemaEstadoCivil");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaFormasDonativo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaFuncionalidadesConsentimento>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaFuncoesWebServiceDef>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaIdiomas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaModelosFiscais>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaModulos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaMoedas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaNaturezas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaNivelAutonomia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaOrdemLotes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.IsSystem).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbSistemaParentesco>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaRegimeIva>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaRegioesIva>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaSexo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaSiglasPaises>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao).HasDefaultValueSql("('')");

                entity.Property(e => e.DescricaoPais).HasDefaultValueSql("('')");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaSyncApp>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTipoControlos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTipoDeficiencia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaTipoSala>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaTipologiasValencia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaTiposAnexos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdentidadeF3mNavigation)
                    .WithMany(p => p.TbSistemaTiposAnexos)
                    .HasForeignKey(d => d.IdentidadeF3m)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposAnexos_tbSistemaEntidadesF3M");

                entity.HasOne(d => d.IdtipoExtensaoFicheiroNavigation)
                    .WithMany(p => p.TbSistemaTiposAnexos)
                    .HasForeignKey(d => d.IdtipoExtensaoFicheiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposAnexos_tbSistemaTiposExtensoesFicheiros");
            });

            modelBuilder.Entity<TbSistemaTiposComponente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposContato>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaTiposDistResp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSistemaTiposDocumento>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdmoduloNavigation)
                    .WithMany(p => p.TbSistemaTiposDocumento)
                    .HasForeignKey(d => d.Idmodulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposDocumento_tbSistemaModulos");
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoComunicacao>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoFiscal>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbSistemaTiposDocumentoFiscal)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposDocumentoFiscal_tbSistemaTiposDocumento");
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoImportacao>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoMovStock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoOrigem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposDocumentoPrecoUnitario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposEntidade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposEntidadeModulos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaModulosNavigation)
                    .WithMany(p => p.TbSistemaTiposEntidadeModulos)
                    .HasForeignKey(d => d.IdsistemaModulos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposEntidadeModulos_tbSistemaModulos");

                entity.HasOne(d => d.IdsistemaTiposEntidadeNavigation)
                    .WithMany(p => p.TbSistemaTiposEntidadeModulos)
                    .HasForeignKey(d => d.IdsistemaTiposEntidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposEntidadeModulos_tbSistemaTiposEntidade");
            });

            modelBuilder.Entity<TbSistemaTiposEstados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdentidadeEstadoNavigation)
                    .WithMany(p => p.TbSistemaTiposEstados)
                    .HasForeignKey(d => d.IdentidadeEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSistemaTiposEstados_tbSistemaEntidadesEstados");
            });

            modelBuilder.Entity<TbSistemaTiposEstadosRelatorios>(entity =>
            {
                entity.HasIndex(e => e.Ordem)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposExtensoesFicheiros>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposFormasPagamento>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposIva>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposPessoa>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposPrecos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSistemaTiposTextoBase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbSituacoesEconomicas>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbSituacoesEconomicasCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbStockArtigos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdarmazemNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.Idarmazem)
                    .HasConstraintName("FK_tbStockArtigos_IDArmazem");

                entity.HasOne(d => d.IdarmazemLocalizacaoNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.IdarmazemLocalizacao)
                    .HasConstraintName("FK_tbStockArtigos_IDArmazemLocalizacao");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbStockArtigos_IDArtigo");

                entity.HasOne(d => d.IdartigoDimensaoNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.IdartigoDimensao)
                    .HasConstraintName("FK_tbStockArtigos_IDArtigoDimensao");

                entity.HasOne(d => d.IdartigoLoteNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.IdartigoLote)
                    .HasConstraintName("FK_tbStockArtigos_IDArtigoLote");

                entity.HasOne(d => d.IdartigoNumeroSerieNavigation)
                    .WithMany(p => p.TbStockArtigos)
                    .HasForeignKey(d => d.IdartigoNumeroSerie)
                    .HasConstraintName("FK_tbStockArtigos_IDArtigoNumeroSerie");
            });

            modelBuilder.Entity<TbSubFamilias>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.RestituicaoIva).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdfamiliaNavigation)
                    .WithMany(p => p.TbSubFamilias)
                    .HasForeignKey(d => d.Idfamilia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSubFamilias_tbFamilias");
            });

            modelBuilder.Entity<TbSyncApp>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaAppNavigation)
                    .WithMany(p => p.TbSyncApp)
                    .HasForeignKey(d => d.IdsistemaApp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSyncAPP_tbSistemaSyncAPP");
            });

            modelBuilder.Entity<TbTags>(entity =>
            {
                entity.HasIndex(e => e.Tag)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdformulasDefNavigation)
                    .WithMany(p => p.TbTags)
                    .HasForeignKey(d => d.IdformulasDef)
                    .HasConstraintName("FK_tbTags_tbFormulasDef");

                entity.HasOne(d => d.IdvariaveisDefNavigation)
                    .WithMany(p => p.TbTags)
                    .HasForeignKey(d => d.IdvariaveisDef)
                    .HasConstraintName("FK_tbTags_tbVariaveisDef");
            });

            modelBuilder.Entity<TbTextosBase>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdtiposTextoBaseNavigation)
                    .WithMany(p => p.TbTextosBase)
                    .HasForeignKey(d => d.IdtiposTextoBase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTextosBase_tbSistemaTiposTextoBase");
            });

            modelBuilder.Entity<TbTipoProfissional>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbTipoProfissional")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbTiposArtigos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaClassificacaoNavigation)
                    .WithMany(p => p.TbTiposArtigos)
                    .HasForeignKey(d => d.IdsistemaClassificacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposArtigos_tbSistemaClassificacoesTiposArtigos");

                entity.HasOne(d => d.IdsistemaClassificacaoGeralNavigation)
                    .WithMany(p => p.TbTiposArtigos)
                    .HasForeignKey(d => d.IdsistemaClassificacaoGeral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposArtigos_tbSistemaClassificacoesTiposArtigosGeral");
            });

            modelBuilder.Entity<TbTiposContrato>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbTiposContrato)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposContrato_tbValencias");
            });

            modelBuilder.Entity<TbTiposDados>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbTiposDocumento>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Predefinido).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.TbTiposDocumento)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("FK_tbTiposDocumento_tbEstados");

                entity.HasOne(d => d.IdmoduloNavigation)
                    .WithMany(p => p.TbTiposDocumento)
                    .HasForeignKey(d => d.Idmodulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumento_tbSistemaModulos");

                entity.HasOne(d => d.IdsistemaNaturezasNavigation)
                    .WithMany(p => p.TbTiposDocumento)
                    .HasForeignKey(d => d.IdsistemaNaturezas)
                    .HasConstraintName("FK_tbTiposDocumento_tbSistemaNaturezas");

                entity.HasOne(d => d.IdsistemaTiposDocumentoNavigation)
                    .WithMany(p => p.TbTiposDocumento)
                    .HasForeignKey(d => d.IdsistemaTiposDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumento_tbSistemaTiposDocumento");

                entity.HasOne(d => d.IdsistemaTiposDocumentoFiscalNavigation)
                    .WithMany(p => p.TbTiposDocumento)
                    .HasForeignKey(d => d.IdsistemaTiposDocumentoFiscal)
                    .HasConstraintName("FK_tbTiposDocumento_tbSistemaTiposDocumentoFiscal");
            });

            modelBuilder.Entity<TbTiposDocumentoIdioma>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdidiomaNavigation)
                    .WithMany(p => p.TbTiposDocumentoIdioma)
                    .HasForeignKey(d => d.Ididioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumentoIdioma_tbIdiomas");

                entity.HasOne(d => d.IdtiposDocumentoNavigation)
                    .WithMany(p => p.TbTiposDocumentoIdioma)
                    .HasForeignKey(d => d.IdtiposDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumentoIdioma_tbTiposDocumento");
            });

            modelBuilder.Entity<TbTiposDocumentoSeries>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdmapasVistasNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeries)
                    .HasForeignKey(d => d.IdmapasVistas)
                    .HasConstraintName("FK_tbTiposDocumentoSeries_tbMapasVistas");

                entity.HasOne(d => d.IdparametrosEmpresaCaeNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeries)
                    .HasForeignKey(d => d.IdparametrosEmpresaCae)
                    .HasConstraintName("FK_tbTiposDocumentoSeries_tbParametrosEmpresaCAE");

                entity.HasOne(d => d.IdsistemaTiposDocumentoComunicacaoNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeries)
                    .HasForeignKey(d => d.IdsistemaTiposDocumentoComunicacao)
                    .HasConstraintName("FK_tbTiposDocumentoSeries_tbSistemaTiposDocumentoComunicacao");

                entity.HasOne(d => d.IdsistemaTiposDocumentoOrigemNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeries)
                    .HasForeignKey(d => d.IdsistemaTiposDocumentoOrigem)
                    .HasConstraintName("FK_tbTiposDocumentoSeries_tbSistemaTiposDocumentoOrigem");

                entity.HasOne(d => d.IdtiposDocumentoNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeries)
                    .HasForeignKey(d => d.IdtiposDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumentoSeries_tbTiposDocumento");
            });

            modelBuilder.Entity<TbTiposDocumentoSeriesPermissoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdserieNavigation)
                    .WithMany(p => p.TbTiposDocumentoSeriesPermissoes)
                    .HasForeignKey(d => d.Idserie)
                    .HasConstraintName("FK_tbTiposDocumentoSeriesPermissoes_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbTiposDocumentoTipEntPermDoc>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaTiposEntidadeModulosNavigation)
                    .WithMany(p => p.TbTiposDocumentoTipEntPermDoc)
                    .HasForeignKey(d => d.IdsistemaTiposEntidadeModulos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumentoTipEntPermDoc_tbSistemaTiposEntidadeModulos");

                entity.HasOne(d => d.IdtiposDocumentoNavigation)
                    .WithMany(p => p.TbTiposDocumentoTipEntPermDoc)
                    .HasForeignKey(d => d.IdtiposDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDocumentoTipEntPermDoc_tbTiposDocumento");
            });

            modelBuilder.Entity<TbTiposDonativos>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbTiposDonativosCodigo")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcodigoDonativoNavigation)
                    .WithMany(p => p.TbTiposDonativos)
                    .HasForeignKey(d => d.IdcodigoDonativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposDonativos_tbCodigosDonativos");
            });

            modelBuilder.Entity<TbTiposEntidade>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdsistemaTipoEntidadeNavigation)
                    .WithMany(p => p.TbTiposEntidade)
                    .HasForeignKey(d => d.IdsistemaTipoEntidade)
                    .HasConstraintName("FK_tbTiposEntidade_tbSistemaTiposEntidade");
            });

            modelBuilder.Entity<TbTiposEntidadeClasses>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdtiposEntidadeNavigation)
                    .WithMany(p => p.TbTiposEntidadeClasses)
                    .HasForeignKey(d => d.IdtiposEntidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposEntidadeClasses_tbTiposEntidade");
            });

            modelBuilder.Entity<TbTiposMovimentosCofre>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbTiposMovimentosCofre)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .HasConstraintName("FK_tbTiposMovimentosCofre_tbFormasPagamento");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.TbTiposMovimentosCofre)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposMovimentosCofre_tbTiposDocumento");

                entity.HasOne(d => d.IdtipoDocumentoSeriesNavigation)
                    .WithMany(p => p.TbTiposMovimentosCofre)
                    .HasForeignKey(d => d.IdtipoDocumentoSeries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposMovimentosCofre_tbTiposDocumentoSeries");
            });

            modelBuilder.Entity<TbTiposRendimento>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbTiposRespostaSocial>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbTiposRespostaSocialCodigo")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbUnidades>(entity =>
            {
                entity.HasIndex(e => e.Codigo)
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();
            });

            modelBuilder.Entity<TbUnidadesRelacoes>(entity =>
            {
                entity.HasIndex(e => new { e.Idunidade, e.IdunidadeConversao })
                    .HasName("IX_tbUnidadesRelacoes")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdunidadeNavigation)
                    .WithMany(p => p.TbUnidadesRelacoesIdunidadeNavigation)
                    .HasForeignKey(d => d.Idunidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUnidadesRelacoes_tbUnidades");

                entity.HasOne(d => d.IdunidadeConversaoNavigation)
                    .WithMany(p => p.TbUnidadesRelacoesIdunidadeConversaoNavigation)
                    .HasForeignKey(d => d.IdunidadeConversao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUnidadesRelacoes_tbUnidades_Conversao");
            });

            modelBuilder.Entity<TbUtentes>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeRegistadaNavigation)
                    .WithMany(p => p.TbUtentes)
                    .HasForeignKey(d => d.IdentidadeRegistada)
                    .HasConstraintName("FK_tbUtentes_tbEntidadesRegistadas");

                entity.HasOne(d => d.IdgrauDeficienciaIncapacidadeNavigation)
                    .WithMany(p => p.TbUtentes)
                    .HasForeignKey(d => d.IdgrauDeficienciaIncapacidade)
                    .HasConstraintName("FK_tbUtentes_tbGrausDeficienciaIncapacidade");

                entity.HasOne(d => d.IdsituacaoEconomicaNavigation)
                    .WithMany(p => p.TbUtentes)
                    .HasForeignKey(d => d.IdsituacaoEconomica)
                    .HasConstraintName("FK_tbUtentes_tbSituacoesEconomicas");
            });

            modelBuilder.Entity<TbUtentesAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbUtentesAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbUtentesAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbUtentesAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbUtentesAnexos_tbSistemaTiposAnexos");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbUtentesAnexos)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesAnexos_tbUtentes");
            });

            modelBuilder.Entity<TbUtentesAusenciasSaidas>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdmotivoAusenciaSaidaNavigation)
                    .WithMany(p => p.TbUtentesAusenciasSaidas)
                    .HasForeignKey(d => d.IdmotivoAusenciaSaida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesAusenciasSaidas_IdMotivoAusenciaSaida");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbUtentesAusenciasSaidas)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesAusenciasSaidas_IDUtente");

                entity.HasOne(d => d.IdutentesValenciasNavigation)
                    .WithMany(p => p.TbUtentesAusenciasSaidas)
                    .HasForeignKey(d => d.IdutentesValencias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesAusenciasSaidas_IDUtentesValencias");
            });

            modelBuilder.Entity<TbUtentesCandidatos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdentidadeRegistadaNavigation)
                    .WithMany(p => p.TbUtentesCandidatos)
                    .HasForeignKey(d => d.IdentidadeRegistada)
                    .HasConstraintName("FK_tbUtentesCandidatos_tbEntidadesRegistadas");

                entity.HasOne(d => d.IdgrauDeficienciaIncapacidadeNavigation)
                    .WithMany(p => p.TbUtentesCandidatos)
                    .HasForeignKey(d => d.IdgrauDeficienciaIncapacidade)
                    .HasConstraintName("FK_tbUtentesCandidatos_tbGrausDeficienciaIncapacidade");

                entity.HasOne(d => d.IdsituacaoEconomicaNavigation)
                    .WithMany(p => p.TbUtentesCandidatos)
                    .HasForeignKey(d => d.IdsituacaoEconomica)
                    .HasConstraintName("FK_tbUtentesCandidatos_tbSituacoesEconomicas");
            });

            modelBuilder.Entity<TbUtentesCandidatosAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Idcategoria).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbUtentesCandidatosAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbUtentesCandidatosAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbUtentesCandidatosAnexos_tbSistemaTiposAnexos");

                entity.HasOne(d => d.IdutenteCandidatoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosAnexos)
                    .HasForeignKey(d => d.IdutenteCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesCandidatosAnexos_tbUtentes");
            });

            modelBuilder.Entity<TbUtentesCandidatosResponsaveis>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbancoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosResponsaveis)
                    .HasForeignKey(d => d.Idbanco)
                    .HasConstraintName("FK_tbUtentesCandidatosResponsaveis_tbBancos");

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosResponsaveis)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .HasConstraintName("FK_tbUtentesCandidatosResponsaveis_tbCondicoesPagamento");

                entity.HasOne(d => d.IdfamiliarNavigation)
                    .WithMany(p => p.TbUtentesCandidatosResponsaveis)
                    .HasForeignKey(d => d.Idfamiliar)
                    .HasConstraintName("FK_tbUtentesCandidatosResponsaveis_tbEntidadesFamiliares");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosResponsaveis)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .HasConstraintName("FK_tbUtentesCandidatosResponsaveis_tbFormasPagamento");

                entity.HasOne(d => d.IdutenteCandidatoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosResponsaveis)
                    .HasForeignKey(d => d.IdutenteCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesCandidatosResponsaveis_tbUtentesCandidatos");
            });

            modelBuilder.Entity<TbUtentesCandidatosValencias>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdacordoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.Idacordo)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbAcordos");

                entity.HasOne(d => d.IdcaeNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.Idcae)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbParametrosEmpresaCAE");

                entity.HasOne(d => d.IdcontratoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.Idcontrato)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbContratosUtentes");

                entity.HasOne(d => d.IdsalaNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.Idsala)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbSalas");

                entity.HasOne(d => d.IdsalaLocalizacaoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.IdsalaLocalizacao)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbSalasLocalizacoes");

                entity.HasOne(d => d.IdutenteCandidatoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.IdutenteCandidato)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbUtentesCandidatos");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValencias)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbUtentesCandidatosValencias_tbValencias");
            });

            modelBuilder.Entity<TbUtentesCandidatosValenciasCriteriosSelecao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdutenteCandidatoValenciaNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValenciasCriteriosSelecao)
                    .HasForeignKey(d => d.IdutenteCandidatoValencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesCandidatosValenciasCriteriosSelecao_tbUtentesCandidatosValencias");

                entity.HasOne(d => d.IdvalenciaCriterioSelecaoNavigation)
                    .WithMany(p => p.TbUtentesCandidatosValenciasCriteriosSelecao)
                    .HasForeignKey(d => d.IdvalenciaCriterioSelecao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesCandidatosValenciasCriteriosSelecao_tbValenciasCriteriosSelecao");
            });

            modelBuilder.Entity<TbUtentesPrevRendTiposRend>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdtipoRendimentoNavigation)
                    .WithMany(p => p.TbUtentesPrevRendTiposRend)
                    .HasForeignKey(d => d.IdtipoRendimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesPrevRendTiposRend_tbTiposRendimento");

                entity.HasOne(d => d.IdutentePrevisaoRendimentoNavigation)
                    .WithMany(p => p.TbUtentesPrevRendTiposRend)
                    .HasForeignKey(d => d.IdutentePrevisaoRendimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesPrevRendTiposRend_tbUtentesPrevisaoRendimentos");
            });

            modelBuilder.Entity<TbUtentesPrevisaoRendimentos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbUtentesPrevisaoRendimentos)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbUtentesPrevisaoRendimentos_tbUtentes");
            });

            modelBuilder.Entity<TbUtentesResponsaveis>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdbancoNavigation)
                    .WithMany(p => p.TbUtentesResponsaveis)
                    .HasForeignKey(d => d.Idbanco)
                    .HasConstraintName("FK_tbUtentesResponsaveis_tbBancos");

                entity.HasOne(d => d.IdcondicaoPagamentoNavigation)
                    .WithMany(p => p.TbUtentesResponsaveis)
                    .HasForeignKey(d => d.IdcondicaoPagamento)
                    .HasConstraintName("FK_tbUtentesResponsaveis_tbCondicoesPagamento");

                entity.HasOne(d => d.IdfamiliarNavigation)
                    .WithMany(p => p.TbUtentesResponsaveis)
                    .HasForeignKey(d => d.Idfamiliar)
                    .HasConstraintName("FK_tbUtentesResponsaveis_tbEntidadesFamiliares");

                entity.HasOne(d => d.IdformaPagamentoNavigation)
                    .WithMany(p => p.TbUtentesResponsaveis)
                    .HasForeignKey(d => d.IdformaPagamento)
                    .HasConstraintName("FK_tbUtentesResponsaveis_tbFormasPagamento");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbUtentesResponsaveis)
                    .HasForeignKey(d => d.Idutente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesResponsaveis_tbUtentes");
            });

            modelBuilder.Entity<TbUtentesValencias>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdacordoNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idacordo)
                    .HasConstraintName("FK_tbUtentesValencias_tbAcordos");

                entity.HasOne(d => d.IdcaeNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idcae)
                    .HasConstraintName("FK_tbUtentesValencias_tbParametrosEmpresaCAE");

                entity.HasOne(d => d.IdcontratoNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idcontrato)
                    .HasConstraintName("FK_tbUtentesValencias_tbContratosUtentes");

                entity.HasOne(d => d.IdsalaNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idsala)
                    .HasConstraintName("FK_tbUtentesValencias_tbSalas");

                entity.HasOne(d => d.IdsalaLocalizacaoNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.IdsalaLocalizacao)
                    .HasConstraintName("FK_tbUtentesValencias_tbSalasLocalizacoes");

                entity.HasOne(d => d.IdutenteNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idutente)
                    .HasConstraintName("FK_tbUtentesValencias_tbUtentes");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbUtentesValencias)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbUtentesValencias_tbValencias");
            });

            modelBuilder.Entity<TbUtentesValenciasArtigos>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.Unidade).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigos)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigos_tbArtigos");

                entity.HasOne(d => d.IdprecoSugeridoNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigos)
                    .HasForeignKey(d => d.IdprecoSugerido)
                    .HasConstraintName("FK_tbUtentesValenciasArtigos_tbSistemaCodigosPrecos");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigos)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigos_tbIVA");

                entity.HasOne(d => d.IdutenteCandidatoValenciaNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigos)
                    .HasForeignKey(d => d.IdutenteCandidatoValencia)
                    .HasConstraintName("FK_tbUtentesValenciasArtigos_tbUtentesCandidatosValencias");

                entity.HasOne(d => d.IdutenteValenciaNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigos)
                    .HasForeignKey(d => d.IdutenteValencia)
                    .HasConstraintName("FK_tbUtentesValenciasArtigos_tbUtentesValencias");
            });

            modelBuilder.Entity<TbUtentesValenciasArtigosCalcMensal>(entity =>
            {
                entity.HasIndex(e => e.IdutenteValenciaArtigo)
                    .HasName("IX_tbUtentesValenciasArtigosCalcMensal_IDContexto")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormulaNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigosCalcMensal)
                    .HasForeignKey(d => d.IdcalcMensalFormula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigosCalcMensal_tbCalcMensalFormulas");

                entity.HasOne(d => d.IdutenteValenciaArtigoNavigation)
                    .WithOne(p => p.TbUtentesValenciasArtigosCalcMensal)
                    .HasForeignKey<TbUtentesValenciasArtigosCalcMensal>(d => d.IdutenteValenciaArtigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigosCalcMensal_tbUtentesValenciasArtigos");
            });

            modelBuilder.Entity<TbUtentesValenciasArtigosDistribuicao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdentidadeFamiliarNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigosDistribuicao)
                    .HasForeignKey(d => d.IdentidadeFamiliar)
                    .HasConstraintName("FK_tbUtentesValenciasArtigosDistribuicao_tbEntidadesFamiliares");

                entity.HasOne(d => d.IdtiposDistRespNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigosDistribuicao)
                    .HasForeignKey(d => d.IdtiposDistResp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigosDistribuicao_tbSistemaTiposDistResp");

                entity.HasOne(d => d.IdutenteValenciaArtigoNavigation)
                    .WithMany(p => p.TbUtentesValenciasArtigosDistribuicao)
                    .HasForeignKey(d => d.IdutenteValenciaArtigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUtentesValenciasArtigosDistribuicao_tbUtentesValenciasArtigos");
            });

            modelBuilder.Entity<TbUtentesValenciasDocsInscricao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdutenteCandidatoValenciaNavigation)
                    .WithMany(p => p.TbUtentesValenciasDocsInscricao)
                    .HasForeignKey(d => d.IdutenteCandidatoValencia)
                    .HasConstraintName("FK_tbUtentesValenciasDocsInscricao_tbUtentesCandidatosValencias");

                entity.HasOne(d => d.IdutenteValenciaNavigation)
                    .WithMany(p => p.TbUtentesValenciasDocsInscricao)
                    .HasForeignKey(d => d.IdutenteValencia)
                    .HasConstraintName("FK_tbUtentesValenciasDocsInscricao_tbUtentesValencias");
            });

            modelBuilder.Entity<TbValencias>(entity =>
            {
                entity.HasIndex(e => e.Abreviatura)
                    .HasName("IX_tbValenciasAbreviatura")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo)
                    .HasName("IX_tbValenciasCodigo")
                    .IsUnique();

                entity.HasIndex(e => e.Descricao)
                    .HasName("IX_tbValenciasDescricao")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdareaValenciaNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.IdareaValencia)
                    .HasConstraintName("FK_tbValencias_tbSistemaAreaValencia");

                entity.HasOne(d => d.IdcaeNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.Idcae)
                    .HasConstraintName("FK_tbValencias_tbParametrosEmpresaCAE");

                entity.HasOne(d => d.IdestabelecimentoNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.Idestabelecimento)
                    .HasConstraintName("FK_tbValencias_tbEstabelecimentos");

                entity.HasOne(d => d.IdseguradoraNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.Idseguradora)
                    .HasConstraintName("FK_tbValencias_tbSeguradoras");

                entity.HasOne(d => d.IdtipoRespostaSocialNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.IdtipoRespostaSocial)
                    .HasConstraintName("FK_tbValencias_tbTiposRespostaSocial");

                entity.HasOne(d => d.IdtipologiaValenciaNavigation)
                    .WithMany(p => p.TbValencias)
                    .HasForeignKey(d => d.IdtipologiaValencia)
                    .HasConstraintName("FK_tbValencias_tbSistemaTipologiasValencia");
            });

            modelBuilder.Entity<TbValenciasAnexos>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.TbValenciasAnexos)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("FK_tbValenciasAnexos_tbCategoriasAnexosFuncionalidades");

                entity.HasOne(d => d.IdtipoAnexoNavigation)
                    .WithMany(p => p.TbValenciasAnexos)
                    .HasForeignKey(d => d.IdtipoAnexo)
                    .HasConstraintName("FK_tbValenciasAnexos_tbSistemaTiposAnexos");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasAnexos)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasAnexos_tbValencias");
            });

            modelBuilder.Entity<TbValenciasArtigos>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdartigoNavigation)
                    .WithMany(p => p.TbValenciasArtigosIdartigoNavigation)
                    .HasForeignKey(d => d.Idartigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasArtigos_tbArtigos");

                entity.HasOne(d => d.IdartigoReducaoNavigation)
                    .WithMany(p => p.TbValenciasArtigosIdartigoReducaoNavigation)
                    .HasForeignKey(d => d.IdartigoReducao)
                    .HasConstraintName("FK_tbValenciasArtigos_tbArtigosReducao");

                entity.HasOne(d => d.IdsistemaModeloFiscalNavigation)
                    .WithMany(p => p.TbValenciasArtigos)
                    .HasForeignKey(d => d.IdsistemaModeloFiscal)
                    .HasConstraintName("FK_tbValenciasArtigos_tbSistemaModelosFiscais");

                entity.HasOne(d => d.IdtaxaIvaNavigation)
                    .WithMany(p => p.TbValenciasArtigosIdtaxaIvaNavigation)
                    .HasForeignKey(d => d.IdtaxaIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasArtigos_tbIVA");

                entity.HasOne(d => d.IdtaxaIvareducaoNavigation)
                    .WithMany(p => p.TbValenciasArtigosIdtaxaIvareducaoNavigation)
                    .HasForeignKey(d => d.IdtaxaIvareducao)
                    .HasConstraintName("FK_tbValenciasArtigos_tbIVAReducao");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasArtigos)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasArtigos_tbValencias");
            });

            modelBuilder.Entity<TbValenciasArtigosReducoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaArtigoNavigation)
                    .WithMany(p => p.TbValenciasArtigosReducoes)
                    .HasForeignKey(d => d.IdvalenciaArtigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasArtigosReducoes_tbValenciasArtigos");
            });

            modelBuilder.Entity<TbValenciasCalcMensalDef>(entity =>
            {
                entity.HasIndex(e => new { e.Idvalencia, e.IdcalcMensalFormulaDef })
                    .HasName("IX_tbValenciasCalcMensalDef_IDParContexto")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdcalcMensalFormulaDefNavigation)
                    .WithMany(p => p.TbValenciasCalcMensalDef)
                    .HasForeignKey(d => d.IdcalcMensalFormulaDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasCalcMensalDef_tbCalcMensalFormulasDef");

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasCalcMensalDef)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasCalcMensalDef_tbValencias");
            });

            modelBuilder.Entity<TbValenciasComparticipacaoEscaloes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaCompNavigation)
                    .WithMany(p => p.TbValenciasComparticipacaoEscaloes)
                    .HasForeignKey(d => d.IdvalenciaComp)
                    .HasConstraintName("FK_tbValenciasComparticipacaoEscaloes_tbValenciasComparticipacoes");
            });

            modelBuilder.Entity<TbValenciasComparticipacaoEscaloesServicos>(entity =>
            {
                entity.HasIndex(e => new { e.IdvalenciaCompEscalao, e.IdvalenciaCompServico })
                    .HasName("IX_tbValenciasComparticipacaoEscaloesServicos_EscalaoServico")
                    .IsUnique();

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaCompEscalaoNavigation)
                    .WithMany(p => p.TbValenciasComparticipacaoEscaloesServicos)
                    .HasForeignKey(d => d.IdvalenciaCompEscalao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasComparticipacaoEscaloesServicos_tbValenciasComparticipacaoEscaloes");

                entity.HasOne(d => d.IdvalenciaCompServicoNavigation)
                    .WithMany(p => p.TbValenciasComparticipacaoEscaloesServicos)
                    .HasForeignKey(d => d.IdvalenciaCompServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasComparticipacaoEscaloesServicos_tbValenciasComparticipacaoServicos");
            });

            modelBuilder.Entity<TbValenciasComparticipacaoServicos>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaCompNavigation)
                    .WithMany(p => p.TbValenciasComparticipacaoServicos)
                    .HasForeignKey(d => d.IdvalenciaComp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasComparticipacaoServicos_tbValenciasComparticipacoes");
            });

            modelBuilder.Entity<TbValenciasComparticipacoes>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasComparticipacoes)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbValenciasComparticipacoes_tbValencias");
            });

            modelBuilder.Entity<TbValenciasCriteriosSelecao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasCriteriosSelecao)
                    .HasForeignKey(d => d.Idvalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbValenciasCriteriosSelecao_tbValencias");
            });

            modelBuilder.Entity<TbValenciasDocsInscricao>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdvalenciaNavigation)
                    .WithMany(p => p.TbValenciasDocsInscricao)
                    .HasForeignKey(d => d.Idvalencia)
                    .HasConstraintName("FK_tbValenciasDocsInscricao_tbValencias");
            });

            modelBuilder.Entity<TbVariaveisDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdsistemaFuncoesNavigation)
                    .WithMany(p => p.TbVariaveisDef)
                    .HasForeignKey(d => d.IdsistemaFuncoes)
                    .HasConstraintName("FK_tbVariaveisDef_tbSistemaFuncoesWebServiceDef");

                entity.HasOne(d => d.IdsistemaTipoControlosNavigation)
                    .WithMany(p => p.TbVariaveisDef)
                    .HasForeignKey(d => d.IdsistemaTipoControlos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVariaveisDef_tbSistemaTipoControlos");
            });

            modelBuilder.Entity<TbVariaveisParametrosDef>(entity =>
            {
                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.HasOne(d => d.IdparametrosNavigation)
                    .WithMany(p => p.TbVariaveisParametrosDef)
                    .HasForeignKey(d => d.Idparametros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVariaveisParametrosDef_tbParametrosDef");

                entity.HasOne(d => d.IdvariaveisNavigation)
                    .WithMany(p => p.TbVariaveisParametrosDef)
                    .HasForeignKey(d => d.Idvariaveis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbVariaveisParametrosDef_tbVariaveisDef");
            });

            modelBuilder.Entity<TbVersao>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.F3MMarker).IsRowVersion();

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            });
        }
    }
}

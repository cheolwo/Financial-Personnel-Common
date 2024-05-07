using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 재무인사Common.Model
{
    public class 재무인사DbContext : DbContext
    {
        public DbSet<은행> 은행 { get; set; }
        public DbSet<거래처> 거래처 { get; set; }

        public 재무인사DbContext(DbContextOptions<재무인사DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new 거래처Configuration());
        }
    }
    public class 거래처Configuration : IEntityTypeConfiguration<거래처>
    {
        public void Configure(EntityTypeBuilder<거래처> builder)
        {
            builder.HasKey(x => x.거래처코드);
            builder.Property(x => x.사용구분).IsRequired(); // 'YES'로 고정이라 가정
            builder.Property(x => x.이체정보).HasMaxLength(50);
            builder.Property(x => x.주소).HasMaxLength(200);
            builder.Property(x => x.외화거래처).IsRequired();
            builder.Property(x => x.업종구분).IsRequired();
        }
    }
}

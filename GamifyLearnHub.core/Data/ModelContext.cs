using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GamifyLearnHub.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Assignmentsolution> Assignmentsolutions { get; set; } = null!;
        public virtual DbSet<Assignmentsolutiondetail> Assignmentsolutiondetails { get; set; } = null!;
        public virtual DbSet<Attendence> Attendences { get; set; } = null!;
        public virtual DbSet<Attendencedetail> Attendencedetails { get; set; } = null!;
        public virtual DbSet<Badgeactivity> Badgeactivities { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Cartitem> Cartitems { get; set; } = null!;
        public virtual DbSet<Certification> Certifications { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Coursesection> Coursesections { get; set; } = null!;
        public virtual DbSet<Coursesequence> Coursesequences { get; set; } = null!;
        public virtual DbSet<Educationalperiod> Educationalperiods { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Examsolution> Examsolutions { get; set; } = null!;
        public virtual DbSet<Examsolutiondetail> Examsolutiondetails { get; set; } = null!;
        public virtual DbSet<Instructordetail> Instructordetails { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Pointsactivity> Pointsactivities { get; set; } = null!;
        public virtual DbSet<Program> Programs { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Questionoption> Questionoptions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Sectionannoncment> Sectionannoncments { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userbadgeactivity> Userbadgeactivities { get; set; } = null!;
        public virtual DbSet<Usercoupon> Usercoupons { get; set; } = null!;
        public virtual DbSet<Userlogin> Userlogins { get; set; } = null!;
        public virtual DbSet<Userpointsactivity> Userpointsactivities { get; set; } = null!;
        public virtual DbSet<Userprogress> Userprogresses { get; set; } = null!;
        public virtual DbSet<Usersection> Usersections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=GamifyLearningHub;PASSWORD=Ahmadzuiod2;DATA SOURCE=localhost:1521/XEPDB1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GAMIFYLEARNINGHUB")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("ANNOUNCEMENT");

                entity.Property(e => e.Announcementid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ANNOUNCEMENTID");

                entity.Property(e => e.Declaration)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DECLARATION");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008795");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("ASSIGNMENT");

                entity.Property(e => e.Assignmentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTID");

                entity.Property(e => e.Assignmentdeadline)
                    .HasColumnType("DATE")
                    .HasColumnName("ASSIGNMENTDEADLINE");

                entity.Property(e => e.Assignmentdescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENTDESCRIPTION");

                entity.Property(e => e.Assignmentmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ASSIGNMENTMARK");

                entity.Property(e => e.Assignmentname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENTNAME");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008672");
            });

            modelBuilder.Entity<Assignmentsolution>(entity =>
            {
                entity.ToTable("ASSIGNMENTSOLUTION");

                entity.Property(e => e.Assignmentsolutionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTSOLUTIONID");

                entity.Property(e => e.Assignmentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTID");

                entity.Property(e => e.Assignmentsolutionmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ASSIGNMENTSOLUTIONMARK");

                entity.Property(e => e.Assignmentsolutionvalue)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENTSOLUTIONVALUE");

                entity.Property(e => e.Submittedat)
                    .HasColumnType("DATE")
                    .HasColumnName("SUBMITTEDAT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Assignmentsolutions)
                    .HasForeignKey(d => d.Assignmentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008675");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assignmentsolutions)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008676");
            });

            modelBuilder.Entity<Assignmentsolutiondetail>(entity =>
            {
                entity.HasKey(e => e.Assignmentsolutiondetailsid)
                    .HasName("SYS_C008679");

                entity.ToTable("ASSIGNMENTSOLUTIONDETAILS");

                entity.Property(e => e.Assignmentsolutiondetailsid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTSOLUTIONDETAILSID");

                entity.Property(e => e.Assignmentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ASSIGNMENTID");

                entity.Property(e => e.Assignmentsolutionmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ASSIGNMENTSOLUTIONMARK");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Assignmentsolutiondetails)
                    .HasForeignKey(d => d.Assignmentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008681");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assignmentsolutiondetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008680");
            });

            modelBuilder.Entity<Attendence>(entity =>
            {
                entity.ToTable("ATTENDENCE");

                entity.Property(e => e.Attendenceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDENCEID");

                entity.Property(e => e.Attenddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ATTENDDATE");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Attendences)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008712");
            });

            modelBuilder.Entity<Attendencedetail>(entity =>
            {
                entity.HasKey(e => e.Attendencedetailsid)
                    .HasName("SYS_C008714");

                entity.ToTable("ATTENDENCEDETAILS");

                entity.Property(e => e.Attendencedetailsid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDENCEDETAILSID");

                entity.Property(e => e.Attendenceid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ATTENDENCEID");

                entity.Property(e => e.Isattended)
                    .HasPrecision(1)
                    .HasColumnName("ISATTENDED");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Attendence)
                    .WithMany(p => p.Attendencedetails)
                    .HasForeignKey(d => d.Attendenceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008716");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attendencedetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008715");
            });

            modelBuilder.Entity<Badgeactivity>(entity =>
            {
                entity.ToTable("BADGEACTIVITY");

                entity.Property(e => e.Badgeactivityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BADGEACTIVITYID");

                entity.Property(e => e.Badgeimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BADGEIMAGE");

                entity.Property(e => e.Badgename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BADGENAME");

                entity.Property(e => e.Badgepoints)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BADGEPOINTS");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("CART");

                entity.Property(e => e.Cartid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARTID");

                entity.Property(e => e.Cartstatus)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CARTSTATUS");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Paymentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008705");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008704");
            });

            modelBuilder.Entity<Cartitem>(entity =>
            {
                entity.HasKey(e => e.Cartitemsid)
                    .HasName("SYS_C008707");

                entity.ToTable("CARTITEMS");

                entity.Property(e => e.Cartitemsid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARTITEMSID");

                entity.Property(e => e.Cartid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARTID");

                entity.Property(e => e.Programid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROGRAMID");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Cartitems)
                    .HasForeignKey(d => d.Cartid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008709");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Cartitems)
                    .HasForeignKey(d => d.Programid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008773");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Cartitems)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008797");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("CERTIFICATION");

                entity.Property(e => e.Certificationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CERTIFICATIONID");

                entity.Property(e => e.Certificationimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CERTIFICATIONIMAGE");

                entity.Property(e => e.Coursesequenceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSESEQUENCEID");

                entity.Property(e => e.Dateearned)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEEARNED");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Coursesequence)
                    .WithMany(p => p.CertificationsNavigation)
                    .HasForeignKey(d => d.Coursesequenceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008772");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008735");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Messagereceived)
                    .HasColumnType("DATE")
                    .HasColumnName("MESSAGERECEIVED");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("COUPON");

                entity.Property(e => e.Couponid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COUPONID");

                entity.Property(e => e.Couponname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COUPONNAME");

                entity.Property(e => e.Couponpercent)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COUPONPERCENT");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POINTS");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Assignmentweight)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ASSIGNMENTWEIGHT");

                entity.Property(e => e.Courseimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("COURSEIMAGE");

                entity.Property(e => e.Courselevel)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COURSELEVEL");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Examweight)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMWEIGHT");

                entity.Property(e => e.Quizzezweight)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUIZZEZWEIGHT");
            });

            modelBuilder.Entity<Coursesection>(entity =>
            {
                entity.ToTable("COURSESECTION");

                entity.Property(e => e.Coursesectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSESECTIONID");

                entity.Property(e => e.Coursesectionduration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSESECTIONDURATION");

                entity.Property(e => e.Coursesectionname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COURSESECTIONNAME");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Coursesections)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_COURSESECTION_SECTIONID");
            });

            modelBuilder.Entity<Coursesequence>(entity =>
            {
                entity.ToTable("COURSESEQUENCE");

                entity.Property(e => e.Coursesequenceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSESEQUENCEID");

                entity.Property(e => e.Certifications)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CERTIFICATIONS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Perviouscourseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PERVIOUSCOURSEID");

                entity.Property(e => e.Programid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROGRAMID");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesequenceCourses)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008768");

                entity.HasOne(d => d.Perviouscourse)
                    .WithMany(p => p.CoursesequencePerviouscourses)
                    .HasForeignKey(d => d.Perviouscourseid)
                    .HasConstraintName("FK_PREVIOUSCOURSE");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Coursesequences)
                    .HasForeignKey(d => d.Programid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008770");
            });

            modelBuilder.Entity<Educationalperiod>(entity =>
            {
                entity.ToTable("EDUCATIONALPERIOD");

                entity.Property(e => e.Educationalperiodid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EDUCATIONALPERIODID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("EXAM");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Closeat)
                    .HasPrecision(6)
                    .HasColumnName("CLOSEAT");

                entity.Property(e => e.Examdate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXAMDATE");

                entity.Property(e => e.Exammark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMMARK");

                entity.Property(e => e.Examstatus)
                    .HasPrecision(1)
                    .HasColumnName("EXAMSTATUS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Examtype)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EXAMTYPE");

                entity.Property(e => e.Openat)
                    .HasPrecision(6)
                    .HasColumnName("OPENAT");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008650");
            });

            modelBuilder.Entity<Examsolution>(entity =>
            {
                entity.ToTable("EXAMSOLUTION");

                entity.Property(e => e.Examsolutionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMSOLUTIONID");

                entity.Property(e => e.Questionoptionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUESTIONOPTIONID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Questionoption)
                    .WithMany(p => p.Examsolutions)
                    .HasForeignKey(d => d.Questionoptionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008663");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Examsolutions)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008662");
            });

            modelBuilder.Entity<Examsolutiondetail>(entity =>
            {
                entity.HasKey(e => e.Examsolutiondetailsid)
                    .HasName("SYS_C008759");

                entity.ToTable("EXAMSOLUTIONDETAILS");

                entity.Property(e => e.Examsolutiondetailsid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMSOLUTIONDETAILSID");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Examsolutionmark)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMSOLUTIONMARK");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Examsolutiondetails)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008667");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Examsolutiondetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008668");
            });

            modelBuilder.Entity<Instructordetail>(entity =>
            {
                entity.HasKey(e => e.Instructorid)
                    .HasName("SYS_C008801");

                entity.ToTable("INSTRUCTORDETAILS");

                entity.Property(e => e.Instructorid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INSTRUCTORID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Experience)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIENCE");

                entity.Property(e => e.Facebooklink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FACEBOOKLINK");

                entity.Property(e => e.Instagramlink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSTAGRAMLINK");

                entity.Property(e => e.Linkedinlink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LINKEDINLINK");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Twitterlink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TWITTERLINK");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Instructordetails)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008802");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("LECTURE");

                entity.Property(e => e.Lectureid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LECTUREID");

                entity.Property(e => e.Coursesectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSESECTIONID");

                entity.Property(e => e.Lectureduration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LECTUREDURATION");

                entity.Property(e => e.Lecturefile)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("LECTUREFILE");

                entity.Property(e => e.Lecturename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LECTURENAME");

                entity.HasOne(d => d.Coursesection)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.Coursesectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008727");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENTDATE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008701");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("PLAN");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLANID");

                entity.Property(e => e.Planimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PLANIMAGE");

                entity.Property(e => e.Planname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PLANNAME");
            });

            modelBuilder.Entity<Pointsactivity>(entity =>
            {
                entity.ToTable("POINTSACTIVITY");

                entity.Property(e => e.Pointsactivityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("POINTSACTIVITYID");

                entity.Property(e => e.Numberofcourses)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBEROFCOURSES");

                entity.Property(e => e.Numberofdays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBEROFDAYS");

                entity.Property(e => e.Points)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POINTS");

                entity.Property(e => e.Pointsactivityname)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("POINTSACTIVITYNAME");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("PROGRAM");

                entity.Property(e => e.Programid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROGRAMID");

                entity.Property(e => e.Educationalperiodid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EDUCATIONALPERIODID");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.Property(e => e.Programdescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PROGRAMDESCRIPTION");

                entity.Property(e => e.Programimage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROGRAMIMAGE");

                entity.Property(e => e.Programname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PROGRAMNAME");

                entity.Property(e => e.Programprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROGRAMPRICE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Programsale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROGRAMSALE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Programsyllabus)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PROGRAMSYLLABUS");

                entity.HasOne(d => d.Educationalperiod)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.Educationalperiodid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008779");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008624");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("QUESTION");

                entity.Property(e => e.Questionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUESTIONID");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Questiondescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("QUESTIONDESCRIPTION");

                entity.Property(e => e.Questionweight)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUESTIONWEIGHT");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008655");
            });

            modelBuilder.Entity<Questionoption>(entity =>
            {
                entity.ToTable("QUESTIONOPTION");

                entity.Property(e => e.Questionoptionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUESTIONOPTIONID");

                entity.Property(e => e.Iscorrect)
                    .HasPrecision(1)
                    .HasColumnName("ISCORRECT");

                entity.Property(e => e.Questionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUESTIONID");

                entity.Property(e => e.Questionoptiondescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("QUESTIONOPTIONDESCRIPTION");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Questionoptions)
                    .HasForeignKey(d => d.Questionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008659");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("SECTION");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Coursesequenceid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSESEQUENCEID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Sectionname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONNAME");

                entity.Property(e => e.Sectionsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONSIZE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Coursesequence)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.Coursesequenceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008771");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008635");
            });

            modelBuilder.Entity<Sectionannoncment>(entity =>
            {
                entity.ToTable("SECTIONANNONCMENT");

                entity.Property(e => e.Sectionannoncmentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SECTIONANNONCMENTID");

                entity.Property(e => e.Annoncmentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ANNONCMENTDATE");

                entity.Property(e => e.Annoncmentmessage)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("ANNONCMENTMESSAGE");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Sectionannoncments)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008643");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Review)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("REVIEW");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008783");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Firsname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FIRSNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Totalpoints)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOTALPOINTS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Userimage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USERIMAGE");
            });

            modelBuilder.Entity<Userbadgeactivity>(entity =>
            {
                entity.ToTable("USERBADGEACTIVITY");

                entity.Property(e => e.Userbadgeactivityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERBADGEACTIVITYID");

                entity.Property(e => e.Badgeactivityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BADGEACTIVITYID");

                entity.Property(e => e.Dateearned)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEEARNED");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Badgeactivity)
                    .WithMany(p => p.Userbadgeactivities)
                    .HasForeignKey(d => d.Badgeactivityid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008698");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userbadgeactivities)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008697");
            });

            modelBuilder.Entity<Usercoupon>(entity =>
            {
                entity.ToTable("USERCOUPON");

                entity.Property(e => e.Usercouponid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERCOUPONID");

                entity.Property(e => e.Couponid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COUPONID");

                entity.Property(e => e.Dateearned)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEEARNED");

                entity.Property(e => e.Isused)
                    .HasPrecision(1)
                    .HasColumnName("ISUSED");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Usercoupons)
                    .HasForeignKey(d => d.Couponid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008744");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usercoupons)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008743");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.ToTable("USERLOGIN");

                entity.HasIndex(e => e.Username, "SYS_C008755")
                    .IsUnique();

                entity.Property(e => e.Userloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERLOGINID");

                entity.Property(e => e.Dayscount)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DAYSCOUNT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isaccepted)
                    .HasPrecision(1)
                    .HasColumnName("ISACCEPTED");

                entity.Property(e => e.Isonline)
                    .HasPrecision(1)
                    .HasColumnName("ISONLINE");

                entity.Property(e => e.Lastlogin)
                    .HasColumnType("DATE")
                    .HasColumnName("LASTLOGIN");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008757");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008756");
            });

            modelBuilder.Entity<Userpointsactivity>(entity =>
            {
                entity.ToTable("USERPOINTSACTIVITY");

                entity.Property(e => e.Userpointsactivityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERPOINTSACTIVITYID");

                entity.Property(e => e.Dateearned)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEEARNED");

                entity.Property(e => e.Isviewed)
                    .HasPrecision(1)
                    .HasColumnName("ISVIEWED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pointsactivityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POINTSACTIVITYID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Usersectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERSECTIONID");

                entity.HasOne(d => d.Pointsactivity)
                    .WithMany(p => p.Userpointsactivities)
                    .HasForeignKey(d => d.Pointsactivityid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008689");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userpointsactivities)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008688");

                entity.HasOne(d => d.Usersection)
                    .WithMany(p => p.Userpointsactivities)
                    .HasForeignKey(d => d.Usersectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008690");
            });

            modelBuilder.Entity<Userprogress>(entity =>
            {
                entity.HasKey(e => e.Userprogessid)
                    .HasName("SYS_C008729");

                entity.ToTable("USERPROGRESS");

                entity.Property(e => e.Userprogessid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERPROGESSID");

                entity.Property(e => e.Lectureid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LECTUREID");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Userprogresses)
                    .HasForeignKey(d => d.Lectureid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008731");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Userprogresses)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008798");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userprogresses)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008730");
            });

            modelBuilder.Entity<Usersection>(entity =>
            {
                entity.ToTable("USERSECTION");

                entity.Property(e => e.Usersectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERSECTIONID");

                entity.Property(e => e.Enrollmentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENROLLMENTDATE");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Studentmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTMARK")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Usersections)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008640");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usersections)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C008639");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

USE [AttendanceSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendances](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Present] [nvarchar](max) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Attendances] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[Fees] [float] NOT NULL,
	[ClassStartDate] [datetime2](7) NOT NULL,
	[ClassTime] [nvarchar](max) NOT NULL,
	[NoOfClasses] [int] NOT NULL,
	[AdminId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseStudents]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudents](
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_CourseStudents] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[ClassTime] [nvarchar](max) NOT NULL,
	[NoOfClasses] [int] NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[TeacherId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/1/2023 4:29:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221229141215_AddMigrations', N'6.0.11')
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [Name], [UserName], [Password]) VALUES (1, N'Rubaiyad Noor Shahriar', N'rubaiyad', N'asd@123')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (2, 2, N'No', CAST(N'2022-12-29T21:30:45.1012627' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (2, 3, N'Present', CAST(N'2022-12-29T22:13:17.2988435' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (2, 4, N'Present', CAST(N'2022-12-30T12:45:27.7890018' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (2, 5, N'No', CAST(N'2022-12-30T12:46:26.8038686' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (3, 1, N'Present', CAST(N'2022-12-29T21:47:39.4192908' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (3, 2, N'Present', CAST(N'2022-12-29T21:41:42.1680614' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (3, 3, N'Present', CAST(N'2022-12-29T22:12:43.9262090' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (5, 1, N'Present', CAST(N'2022-12-30T12:47:18.3708095' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (5, 2, N'no', CAST(N'2022-12-30T12:49:40.1779462' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (5, 3, N'Present', CAST(N'2022-12-29T23:47:08.3374024' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (7, 7, N'Present', CAST(N'2022-12-30T13:14:40.2578138' AS DateTime2))
INSERT [dbo].[Attendances] ([CourseId], [StudentId], [Present], [Time]) VALUES (7, 10, N'no', CAST(N'2022-12-30T13:15:03.1287910' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (1, N'Course1', 2000, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), N'Monday 6PM-9PM,Thursday 6PM-9PM', 10, 1, 2)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (2, N'Course2', 4000, CAST(N'2023-04-14T00:00:00.0000000' AS DateTime2), N'Sunday 11AM-1PM,Tuesday 11AM-1PM', 15, 1, 3)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (3, N'Course3', 8000, CAST(N'2023-06-01T00:00:00.0000000' AS DateTime2), N'Saturday 9PM-11PM,Monday 9PM-11PM', 18, 1, 4)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (4, N'Course5', 16000, CAST(N'2023-04-12T00:00:00.0000000' AS DateTime2), N'Monday 9PM-11PM,Thursday 9PM-11PM', 22, 1, 5)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (5, N'Course6', 2000, CAST(N'2023-02-12T00:00:00.0000000' AS DateTime2), N'Monday 8PM-9PM,Tuesday 8PM-9PM', 12, 1, 3)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (6, N'Course7', 8000, CAST(N'2023-02-06T00:00:00.0000000' AS DateTime2), N'Monday 8PM-11PM,Thursday 8PM-11PM', 22, 1, 6)
INSERT [dbo].[Courses] ([Id], [CourseName], [Fees], [ClassStartDate], [ClassTime], [NoOfClasses], [AdminId], [TeacherId]) VALUES (7, N'Course 7', 10000, CAST(N'2023-06-10T00:00:00.0000000' AS DateTime2), N'Monday 8PM-11PM,Thursday 11AM-2PM', 22, 1, 3)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (3, 1)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (5, 1)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (2, 2)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (3, 2)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (5, 2)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (2, 3)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (3, 3)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (5, 3)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (2, 4)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (2, 5)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (4, 5)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (4, 6)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (4, 7)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (7, 7)
INSERT [dbo].[CourseStudents] ([CourseId], [StudentId]) VALUES (7, 10)
GO
INSERT [dbo].[Schedules] ([TeacherId], [CourseId], [StudentId], [ClassTime], [NoOfClasses]) VALUES (2, 1, 1, N'Monday 8PM-11PM', 10)
INSERT [dbo].[Schedules] ([TeacherId], [CourseId], [StudentId], [ClassTime], [NoOfClasses]) VALUES (3, 2, 2, N'Monday 8PM-11PM,Thursday 9PM-11PM', 10)
INSERT [dbo].[Schedules] ([TeacherId], [CourseId], [StudentId], [ClassTime], [NoOfClasses]) VALUES (3, 2, 5, N'Monday 10PM-12PM', 2)
INSERT [dbo].[Schedules] ([TeacherId], [CourseId], [StudentId], [ClassTime], [NoOfClasses]) VALUES (2, 3, 2, N'Sunday 11PM-1AM', 2)
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (1, N'Student 1', N's1', N'asd', 1, 2)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (2, N'Student 2', N's2', N'asd', 1, 3)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (3, N'Student 3', N's333', N'asd', 1, 4)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (4, N'Student 4', N's4', N'asd', 1, 5)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (5, N'Student 5', N's5', N'asd', 1, 4)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (6, N'Student 6', N's6', N'asd', 1, 3)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (7, N'Student 7', N's7', N'asd', 1, 2)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (8, N'Student 8', N's8', N'asd', 1, 2)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (9, N'Student 9', N's9', N'asd', 1, 3)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (10, N'Student 10', N's10', N'asd', 1, 4)
INSERT [dbo].[Students] ([Id], [Name], [UserName], [Password], [AdminId], [TeacherId]) VALUES (11, N'Student 11', N's11', N'asd', 1, 6)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (1, N'Teacher 1', N't1', N'asd', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (2, N'Teacher 2', N't2', N'asd', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (3, N'Teacher 3', N'teacher3', N'asd@123', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (4, N'Teacher 4', N't4', N'asd', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (5, N'Teacher 5', N't5', N'asd', 1)
INSERT [dbo].[Teachers] ([Id], [Name], [UserName], [Password], [AdminId]) VALUES (6, N'Teacher6', N't6', N'asd', 1)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
/****** Object:  Index [IX_Attendances_StudentId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Attendances_StudentId] ON [dbo].[Attendances]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_AdminId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_AdminId] ON [dbo].[Courses]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_TeacherId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_TeacherId] ON [dbo].[Courses]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseStudents_StudentId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseStudents_StudentId] ON [dbo].[CourseStudents]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_StudentId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_StudentId] ON [dbo].[Schedules]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_TeacherId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_TeacherId] ON [dbo].[Schedules]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_AdminId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Students_AdminId] ON [dbo].[Students]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_TeacherId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Students_TeacherId] ON [dbo].[Students]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_AdminId]    Script Date: 1/1/2023 4:29:21 PM ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_AdminId] ON [dbo].[Teachers]
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendances_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendances_Courses_CourseId]
GO
ALTER TABLE [dbo].[Attendances]  WITH CHECK ADD  CONSTRAINT [FK_Attendances_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendances] CHECK CONSTRAINT [FK_Attendances_Students_StudentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Admins_AdminId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[CourseStudents]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudents_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseStudents] CHECK CONSTRAINT [FK_CourseStudents_Courses_CourseId]
GO
ALTER TABLE [dbo].[CourseStudents]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudents_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseStudents] CHECK CONSTRAINT [FK_CourseStudents_Students_StudentId]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Courses_CourseId]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Students_StudentId]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Admins_AdminId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Admins_AdminId] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admins] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Admins_AdminId]
GO

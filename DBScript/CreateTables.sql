SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*********************************
 *        IncomingTicket
 *********************************/

CREATE TABLE [dbo].[IncomingTicket] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [OneCallCenter]           NVARCHAR (20)   NOT NULL,
    [TicketNumber]            NVARCHAR (24)   NOT NULL,
    [LocateRequestFor]        NVARCHAR (150)  NOT NULL,
    [SequenceNumber]          INT             NOT NULL,
    [PreviousTicketNumber]    NVARCHAR (24)   NULL,
    [TicketType]              NVARCHAR (60)   NOT NULL,
    [TicketSource]            NVARCHAR (30)   NOT NULL,
    [LastResponseCode]        NVARCHAR (75)   NULL,
    [LastResponseDescription] NVARCHAR (300)  NULL,
    [LastResponseComment]     NVARCHAR (1000) NULL,
    [CallerName]              NVARCHAR (150)  NULL,
    [CallerPhoneNumber]       NVARCHAR (20)   NULL,
    [CallerPhoneExtension]    NVARCHAR (20)   NULL,
    [CallerEmailAddress]      NVARCHAR (255)  NULL,
    [CommenceOn]              DATETIME2 (7)   NULL,
	[CompletedBy]             DATETIME2 (7)   NULL,
    [ContactName]             NVARCHAR (150)  NULL,
    [ContactPhoneNumber]      NVARCHAR (20)   NULL,
    [ContactPhoneExtension]   NVARCHAR (20)   NULL,
    [ContactEmailAddress]     NVARCHAR (255)  NULL,
    [CreatedOn]               DATETIME2 (7)   NOT NULL,
    [CrossStreet]             NVARCHAR (255)  NULL,
    [DigsiteWKT]              NVARCHAR (MAX)  NULL,
    [DirectionalBoring]       BIT             NOT NULL,
    [DoneFor]                 NVARCHAR (50)   NULL,
    [Duration]                NVARCHAR (255)  NULL,
    [ExcavatorName]           NVARCHAR (255)  NULL,
    [ExcavatorPhoneNumber]    NVARCHAR (20)   NULL,
    [ExcavatorType]           NVARCHAR (255)  NULL,
    [ExcavatorAddress]        NVARCHAR (255)  NULL,
    [ExcavatorCity]           NVARCHAR (255)  NULL,
    [ExcavatorState]          NVARCHAR (2)    NULL,
    [ExcavatorZIPCode]        NVARCHAR (5)    NULL,
    [ExpiresOn]               DATETIME2 (7)   NULL,
    [Explosives]              BIT             NOT NULL,
    [LegalOn]                 DATETIME2 (7)   NULL,
    [LocateInstructions]      NVARCHAR (MAX)  NULL,
    [MeetingDate]             DATETIME2 (7)   NULL,
    [MeetingLocation]         NVARCHAR (255)  NULL,
    [Remarks]                 NVARCHAR (MAX)  NULL,
    [RespondBy]               DATETIME2 (7)   NULL,
    [RespondBy2]              DATETIME2 (7)   NULL,
    [RespondBy3]              DATETIME2 (7)   NULL,
    [ScopeOfWork]             NVARCHAR (255)  NULL,
    [TicketText]              NVARCHAR (MAX)  NULL,
    [TransmittedOn]           DATETIME2 (7)   NOT NULL,
    [UpdateBy]                DATETIME2 (7)   NULL,
    [UpdateableOn]            DATETIME2 (7)   NULL,
    [WhitePaint]              BIT             NOT NULL,
    [WhitePaintCount]         INT             NOT NULL,
    [WorkCity]                NVARCHAR (75)   NOT NULL,
    [WorkCounty]              NVARCHAR (MAX)  NULL,
    [WorkState]               NVARCHAR (2)    NOT NULL,
    [WorkStreetName]          NVARCHAR (255)  NOT NULL,
    [WorkStreetNumber]        NVARCHAR (20)   NULL,
    [WorkStreetPrefix]        NVARCHAR (10)   NULL,
    [WorkStreetSuffix]        NVARCHAR (10)   NULL,
    [WorkStreetType]          NVARCHAR (30)   NULL,
    [WorkType]                NVARCHAR (255)  NULL,
    [FacilityTypeDamaged]     NVARCHAR (50)   NULL,
    [TypeOfLine]              NVARCHAR (255)  NULL,
    [DamageExtent]            NVARCHAR (50)   NULL,
    [ServiceIsOut]            BIT             NULL,
    [EquipmentTypeUsed]       NVARCHAR (50)   NULL,
    [IsCrewOnSite]            BIT             NULL,
    [DamagedOnDate]           DATETIME        NULL,
 CONSTRAINT [PK_IncomingTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/*********************************
 *     IncomingTicketMember
 *********************************/
CREATE TABLE [dbo].[IncomingTicketMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](255) NULL,
	[FacitliyType] [nvarchar](40) NULL,
	[IncomingTicketId] [int] NULL,
 CONSTRAINT [PK_IncomingTicketMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IncomingTicketMember]  WITH CHECK ADD  CONSTRAINT [FK_IncomingTicketMember_IncomingTicket_IncomingTicketId] FOREIGN KEY([IncomingTicketId])
REFERENCES [dbo].[IncomingTicket] ([Id])
GO

ALTER TABLE [dbo].[IncomingTicketMember] CHECK CONSTRAINT [FK_IncomingTicketMember_IncomingTicket_IncomingTicketId]
GO

/*********************************
 *   IncomingTicketMemberPhone
 *********************************/

CREATE TABLE [dbo].[IncomingTicketMemberPhone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](40) NULL,
	[Number] [nvarchar](20) NULL,
	[Extension] [nvarchar](20) NULL,
	[IncomingTicketMemberId] [int] NULL,
 CONSTRAINT [PK_IncomingTicketMemberPhone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IncomingTicketMemberPhone]  WITH CHECK ADD  CONSTRAINT [FK_IncomingTicketMemberPhone_IncomingTicketMember_IncomingTicketMemberId] FOREIGN KEY([IncomingTicketMemberId])
REFERENCES [dbo].[IncomingTicketMember] ([Id])
GO

ALTER TABLE [dbo].[IncomingTicketMemberPhone] CHECK CONSTRAINT [FK_IncomingTicketMemberPhone_IncomingTicketMember_IncomingTicketMemberId]
GO


INSERT INTO dbo.Studies (Title, Sponsor, Status, StartDate)
VALUES
('Cardio Alpha',     'Pfizer',   1, DATEADD(day, -60, GETDATE())),
('Neuro Beta',       'Roche',    0, DATEADD(day, -30, GETDATE())),
('Onco Gamma',       'Novartis',  1, DATEADD(day, -15, GETDATE())),
('Immuno Delta',     'Sanofi',   2, DATEADD(day,  10, GETDATE())),
('Pulmo Epsilon',    'AstraZeneca', 0, DATEADD(day, -5, GETDATE())),
('Dermato Zeta',     'Bayer',    1, DATEADD(day, -45, GETDATE())),
('Endocrino Eta',    'Eli Lilly',1, DATEADD(day, -20, GETDATE())),
('Gastro Theta',     'Takeda',   2, DATEADD(day,  20, GETDATE())),
('Nephro Iota',      'AbbVie',   0, DATEADD(day, -8, GETDATE())),
('Rare Kappa',       'Merck',    1, DATEADD(day, -90, GETDATE()));


INSERT INTO dbo.Patients (Code, FullName, DateOfBirth, Email, StudyId)
VALUES
('P-001', 'Ana Popescu',      '1996-04-12', 'ana.popescu@demo.com', 1),
('P-002', 'Bogdan Ionescu',   '1990-11-03', 'bogdan.ionescu@demo.com', 1),
('P-003', 'Carmen Dumitru',   '1988-07-25', 'carmen.dumitru@demo.com', 2),
('P-004', 'Dan Marinescu',    '2001-01-19', 'dan.marinescu@demo.com', 3),
('P-005', 'Elena Radu',       '1994-09-09', 'elena.radu@demo.com', 4),
('P-006', 'Florin Georgescu', '1985-02-14', 'florin.georgescu@demo.com', 5),
('P-007', 'Ioana Stan',       '1999-06-30', 'ioana.stan@demo.com', 6),
('P-008', 'Mihai Pavel',      '1992-12-01', 'mihai.pavel@demo.com', 7),
('P-009', 'Raluca Enache',    '1987-03-18', 'raluca.enache@demo.com', 8),
('P-010', 'Vlad Petrescu',    '1995-10-27', 'vlad.petrescu@demo.com', 9);


INSERT INTO dbo.Patients (Code, FullName, DateOfBirth, Email, StudyId)
SELECT v.Code, v.FullName, v.DateOfBirth, v.Email, s.Id
FROM (VALUES
 ('P-001', 'Ana Popescu',      CONVERT(date,'1996-04-12'), 'ana.popescu@demo.com',      'Cardio Alpha'),
 ('P-002', 'Bogdan Ionescu',   CONVERT(date,'1990-11-03'), 'bogdan.ionescu@demo.com',   'Cardio Alpha'),
 ('P-003', 'Carmen Dumitru',   CONVERT(date,'1988-07-25'), 'carmen.dumitru@demo.com',   'Neuro Beta'),
 ('P-004', 'Dan Marinescu',    CONVERT(date,'2001-01-19'), 'dan.marinescu@demo.com',    'Onco Gamma'),
 ('P-005', 'Elena Radu',       CONVERT(date,'1994-09-09'), 'elena.radu@demo.com',       'Immuno Delta'),
 ('P-006', 'Florin Georgescu', CONVERT(date,'1985-02-14'), 'florin.georgescu@demo.com', 'Pulmo Epsilon'),
 ('P-007', 'Ioana Stan',       CONVERT(date,'1999-06-30'), 'ioana.stan@demo.com',       'Dermato Zeta'),
 ('P-008', 'Mihai Pavel',      CONVERT(date,'1992-12-01'), 'mihai.pavel@demo.com',      'Endocrino Eta'),
 ('P-009', 'Raluca Enache',    CONVERT(date,'1987-03-18'), 'raluca.enache@demo.com',    'Gastro Theta'),
 ('P-010', 'Vlad Petrescu',    CONVERT(date,'1995-10-27'), 'vlad.petrescu@demo.com',    'Nephro Iota')
) v(Code, FullName, DateOfBirth, Email, StudyTitle)
JOIN dbo.Studies s ON s.Title = v.StudyTitle;


INSERT INTO dbo.TaskItems (Title, DueDate, Priority, Status, PatientId)
SELECT t.Title, t.DueDate, t.Priority, t.Status, p.Id
FROM (VALUES
 ('Initial screening',    DATEADD(day, -5, GETDATE()), 1, 0, 'P-001'),
 ('Baseline visit',       DATEADD(day,  3, GETDATE()), 2, 1, 'P-001'),
 ('Lab results review',   DATEADD(day,  7, GETDATE()), 0, 0, 'P-002'),
 ('ECG evaluation',       DATEADD(day, -2, GETDATE()), 1, 2, 'P-003'),
 ('Consent verification', DATEADD(day,  1, GETDATE()), 2, 1, 'P-004'),
 ('Follow-up call',       DATEADD(day, 10, GETDATE()), 0, 0, 'P-005'),
 ('Blood sample',         DATEADD(day, -1, GETDATE()), 1, 2, 'P-006'),
 ('MRI scheduling',       DATEADD(day, 14, GETDATE()), 2, 0, 'P-007'),
 ('Adverse event review', DATEADD(day,  5, GETDATE()), 1, 1, 'P-008'),
 ('Final visit',          DATEADD(day, 21, GETDATE()), 0, 0, 'P-009')
) t(Title, DueDate, Priority, Status, PatientCode)
JOIN dbo.Patients p ON p.Code = t.PatientCode;

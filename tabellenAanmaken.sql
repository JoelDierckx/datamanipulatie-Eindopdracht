
--verwijder tabellen en schema's als ze bestaan
DROP TABLE IF EXISTS Layton.Relation;
DROP TABLE IF EXISTS Layton.Relationtype;
DROP TABLE IF EXISTS Layton.Alias;
DROP TABLE IF EXISTS Layton.PuzzleAccount;
DROP TABLE IF EXISTS Layton.Hint;
DROP TABLE IF EXISTS Layton.Puzzle;
DROP TABLE IF EXISTS Layton.[Character];
DROP TABLE IF EXISTS Layton.ArticleSubject;
DROP TABLE IF EXISTS Layton.Media;
DROP TABLE IF EXISTS Layton.Game;
DROP TABLE IF EXISTS Layton.Account;
DROP SCHEMA IF EXISTS Layton;
GO

--maak schema aan
CREATE SCHEMA Layton;
GO
--maak tabellen aan

--Account
CREATE TABLE Layton.Account(
id			int					Identity(1,1),
name		varchar(256)		NULL,
refID		varchar(256)		NULL,
Constraint PK_Account Primary Key (id),
Constraint UK_Account_refID Unique (refID)
);

GO

--Game
CREATE TABLE Layton.Game(
id			int					Identity(1,1),
tittle		varchar(256)		NOT NULL,
Gamecode	varchar(256)		NULL,
Constraint PK_Game Primary Key (id),
Constraint UK_Game_Gamecode Unique (Gamecode)
);

CREATE Unique Index AK_Game_Gamecode ON Layton.Game(Gamecode);

GO
--media
CREATE TABLE Layton.Media(
id		int						Identity(1,1)	,
[url]				varchar(2048)			NULL,
[url2]			varchar(2048)			NULL,
CharacterBool		int					NULL,
Constraint PK_Media Primary Key (id)
);
GO

--ArticleSubject
CREATE TABLE Layton.ArticleSubject(
id						int					Identity(1,1),
tittle					varchar(256)		NULL,
logo					int					NULL,
firstGameAppearance		int					NOT NULL,
Constraint PK_ArticleSubject Primary Key (id),
Constraint FK_ArticleSubject_Media Foreign Key (logo) References Layton.Media(id),
Constraint FK_ArticleSubject_Game Foreign Key (firstGameAppearance) References Layton.Game(id)
);
GO

--Character
CREATE TABLE Layton.[Character](
id						int					Identity(1,1),
articleSubjectId		int					NOT NULL,
hometown				varchar(256)		NULL,
occupation				varchar(256)		NULL,
gender					varchar(256)		NULL,
essential					int		NULL,
Constraint PK_Character Primary Key (id),
Constraint FK_Character_ArticleSubject Foreign Key (articleSubjectId) References Layton.ArticleSubject(id),
Constraint UK_Character_ArticleSubjectId Unique (articleSubjectId),
Constraint CK_Character_gender Check (gender = 'male' OR gender = 'female' OR gender = 'X')
);
GO

--Puzzle
CREATE TABLE Layton.Puzzle(
id						int					Identity(1,1),
puzzleAsset			int					NULL,
articleSubjectId		int					NOT NULL,
inputType				varchar(50)			NOT NULL,
puzzleText				Text				NULL,
solutionOptions			Text				NULL,
solution				Text				NULL,
solutionText			Text				NULL,
picarats				int					NULL,
givenById				int					NOT NULL,
solvedById				int					NOT NULL,
madeById				int					NULL,
Constraint PK_Puzzle Primary Key (id),
Constraint FK_Puzzle_ArticleSubject Foreign Key (articleSubjectId) References Layton.ArticleSubject(id),
Constraint FK_Puzzle_PuzzleAsset Foreign Key (puzzleAsset) References Layton.Puzzle(id),
Constraint FK_Puzzle_Character Foreign Key (givenById) References Layton.[Character](id),
Constraint FK_Puzzle_Character2 Foreign Key (solvedById) References Layton.[Character](id),
Constraint FK_Puzzle_Account Foreign Key (madeById) References Layton.Account(id),
Constraint UK_Puzzle_ArticleSubjectId Unique (articleSubjectId)
);
GO

--Hint
CREATE TABLE Layton.Hint(
id						int					Identity(1,1),
puzzleId				int					NOT NULL,
hintIndex				varchar(50)			NULL,
hintText				Text				NULL,
Constraint PK_Hint Primary Key (id),
Constraint FK_Hint_Puzzle Foreign Key (puzzleId) References Layton.Puzzle(id) ON DELETE CASCADE
);
GO

--Puzzle-Acount
CREATE TABLE Layton.PuzzleAccount(
id						int					Identity(1,1),
puzzleId				int					NULL,
accountId				int					NULL,
picaratsleft			int				NULL,
solved				int				NULL,
Constraint PK_PuzzleAccount Primary Key (id),
Constraint FK_PuzzleAccount_Puzzle Foreign Key (puzzleId) References Layton.Puzzle(id),
Constraint FK_PuzzleAccount_Account Foreign Key (accountId) References Layton.Account(id)
);
GO

--Alias
CREATE TABLE Layton.Alias(
id						int					Identity(1,1),
characterId				int					NOT NULL,
alias					varchar(256)		NULL,
Constraint PK_Alias Primary Key (id),
Constraint FK_Alias_Character Foreign Key (characterId) References Layton.[Character](id) ON DELETE CASCADE
);
GO

--Relationtype
CREATE TABLE Layton.Relationtype(
id			int					Identity(1,1),
[name]		varchar(256)		NOT NULL,
Constraint PK_Relationtype Primary Key (id)
);
GO

--Relations
CREATE TABLE Layton.Relation(
id						int					Identity(1,1),
character1				int					NULL,
character2				int					NULL,
relationtype			int					NOT NULL,
Constraint PK_Relation Primary Key (id),
Constraint FK_Relation_Character Foreign Key (character1) References Layton.[Character](id) ON DELETE CASCADE,
Constraint FK_Relation_Character2 Foreign Key (character2) References Layton.[Character](id),
Constraint FK_Relation_Relationtype Foreign Key (relationtype) References Layton.Relationtype(id)
);
GO










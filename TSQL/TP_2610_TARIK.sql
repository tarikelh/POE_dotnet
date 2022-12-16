-- TP JOINTURES :
-- 1) Vous devez obtenir la liste des races de chiens
-- qui sont des chiens de berger.

SELECT * FROM Race
JOIN Animal ON Animal.race_id = Race.id
JOIN Espece ON Espece.id = Race.espece_id
WHERE Espece.nom_courant = 'Chien' AND Race.nom LIKE 'Berger%';

-- 2) Vous devez obtenir la liste des animaux
-- (leur nom, date de naissance et race) 
-- pour lesquels nous n'avons aucune information sur leur pelage. 

SELECT A.nom, A.date_naissance, R.nom FROM Animal A
LEFT JOIN Race R ON A.race_id = R.id 
WHERE R.id IS NULL 
OR R.description NOT LIKE '%poil%' 
AND R.description NOT LIKE '%pelage%'
AND R.description NOT LIKE '%robe%';

-- 3) Vous devez obtenir la liste des chats et des perroquets amazones,
-- avec leur sexe, leur espèce (nom latin) et leur race s'ils en ont une.
-- Regroupez les chats ensemble, les perroquets ensemble et,
-- au sein de l'espèce, regroupez les races.

SELECT A.sexe, E.nom_latin , R.nom FROM Animal A
JOIN Espece E ON E.id = A.espece_id
FULL JOIN Race R ON A.race_id = R.id
WHERE E.nom_courant IN ('Perroquet amazone','Chat')
ORDER BY E.nom_latin , R.nom ;


-- 4) Vous devez obtenir la liste des chiennes dont on connaît la race,
-- et qui sont en âge de procréer (c'est-à-dire nées avant juillet 2010).
-- Affichez leurs nom, date de naissance et race.

SELECT A.nom, A.date_naissance, R.nom FROM Animal A
JOIN Espece E ON E.id = A.espece_id
JOIN Race R ON A.race_id = R.id
WHERE E.nom_courant = 'Chien' AND A.sexe='F'
AND A.date_naissance < '2010-07-01';

-- Pour les énervés de la jointure :
-- 1) Vous devez obtenir la liste des chats dont on connaît les parents,
-- ainsi que le nom de ces parents.

SELECT Enfant.nom, Pere.nom papa, Mere.nom maman FROM Animal as Enfant
JOIN Espece E ON E.id = Enfant.espece_id
JOIN Animal as Pere ON Enfant.pere_id=Pere.id
JOIN Animal as Mere ON Enfant.mere_id=Mere.id
WHERE E.nom_courant = 'Chat';

-- 2) Vous devez maintenant obtenir la liste des enfants de Bouli
-- (nom, sexe et date de naissance).

SELECT A.nom, A.sexe, A.date_naissance  FROM Animal A
JOIN Animal as Pere ON A.pere_id=Pere.id
WHERE Pere.nom = 'Bouli';

-- Pour la suivante, bon courage :)
-- 3) Vous devez obtenir la liste des animaux
-- dont on connaît le père, la mère, la race,
-- la race du père, la race de la mère.
-- Affichez le nom et la race de l'animal et de ses parents,
-- ainsi que l'espèce de l'animal (pas des parents).

SELECT A.nom, E.nom_courant, R.nom Race, 
Pere.nom papa, RP.nom,
Mere.nom maman, RM.nom
FROM Animal A
JOIN Animal as Pere ON A.pere_id=Pere.id
JOIN Animal as Mere ON A.mere_id=Mere.id
JOIN Espece E ON E.id = A.espece_id
JOIN Race R ON A.race_id = R.id
JOIN Race RP ON Pere.race_id = RP.id
JOIN Race RM ON Mere.race_id = RM.id;


SELECT * FROM Animal
WHERE date_naissance = (SELECT top(1) date_naissance FROM Animal Order by date_naissance asc );

-- on ajoute des prix à nos colonnes :
ALTER TABLE Race
ADD prix DECIMAL(7,2);

ALTER TABLE Espece
ADD prix DECIMAL(7,2) ;
GO
-- Remplissage des colonnes "prix"
UPDATE Espece SET prix = 200 WHERE id = 1;
UPDATE Espece SET prix = 150 WHERE id = 2;
UPDATE Espece SET prix = 140 WHERE id = 3;
UPDATE Espece SET prix = 700 WHERE id = 4;
GO

UPDATE Race SET prix = 450 WHERE id = 1;
UPDATE Race SET prix = 900 WHERE id = 2;
UPDATE Race SET prix = 950 WHERE id = 3;
UPDATE Race SET prix = 800 WHERE id = 4;
UPDATE Race SET prix = 700 WHERE id = 5;
UPDATE Race SET prix = 1200 WHERE id = 7;
GO

SELECT 'Tarik El Harjani' as mon_nom , REPLACE(CONCAT(REPLACE(LOWER('Tarik El Harjani'),' ',''),'@dawan.fr'),'arik','') as mon_email
